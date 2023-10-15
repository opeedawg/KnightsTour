// © 2023 DXterity Solutions
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:07:03 AM
// File             : ActionResponse.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class ActionResponse.
    /// </summary>
    public class ActionResponse: IActionResponse
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResponse"/> class.
        /// </summary>
        public ActionResponse() : this(null, string.Empty)
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResponse"/> class assocciated to a base entity.
        /// </summary>
        /// <param name="dataObject"></param>
        public ActionResponse(dynamic dataObject)
        {
            Context = String.Empty;
            Messages = new List<IMessage>();
            Data = new Dictionary<string, object>();
            DataObject = dataObject;
            Count = 0;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResponse"/> class given the context.
        /// </summary>
        /// <param name="context"></param>
        public ActionResponse(string context) : this(null, context)
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResponse"/> class.
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="context">The context.</param>
        public ActionResponse(dynamic dataObject, string context)
        {
            Context = context;
            Messages = new List<IMessage>();
            Data = new Dictionary<string, object>();
            DataObject = dataObject;
            Count = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public string Context { get; set; }
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public List<IMessage> Messages { get; set; }
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get
            {
                return !Messages.Exists(m => m.Type == Enumerations.MessageType.Negative);
            }
        }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public Dictionary<string, dynamic> Data { get; set; }
        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        /// <value>The data object.</value>
        public dynamic DataObject { get; set; }
        /// <summary>
        /// For collections (specifically to support server side pagination) you can add the total number of records that exist if required.
        /// </summary>
        public int Count { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Appends the specified response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <exception cref="Exception"></exception>
        public void Append(IActionResponse response)
        {
            Messages.AddRange(response.Messages);
            foreach (string key in response.Data.Keys)
            {
                if (!Data.ContainsKey(key))
                    Data.Add(key, response.Data[key]);
                else
                    Data[key] = response.Data[key];
            }

            if (response.DataObject != null)
                DataObject = response.DataObject;
        }
        /// <summary>
        /// Appends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Append(IMessage message)
        {
            Messages.Add(message);
        }
        /// <summary>
        /// Appends the specified messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void Append(List<IMessage> messages)
        {
            Messages.AddRange(messages);
        }
        /// <summary>
        /// Appends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <param name="param3">The param3.</param>
        /// <param name="param4">The param4.</param>
        /// <param name="param5">The param5.</param>
        public void Append(Enumerations.SystemMessage message, Enumerations.MessageType messageType, string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null)
        {
            Messages.Add(new Message(new SystemMessageHandler().Get(message, param1, param2, param3, param4, param5), messageType));
        }
        /// <summary>
        /// Appends the specified exception as a negative mesage.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Append(Exception exception)
        {
            Messages.Add(new Message(exception));
        }
        /// <summary>
        /// Formatteds the messages.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="typeFilters">The type filters.</param>
        /// <returns>System.String.</returns>
        public string FormattedMessages(Enumerations.MessageFormat format = Enumerations.MessageFormat.NewLine, List<Enumerations.MessageType> typeFilters = null)
        {
            StringBuilder messageText = new StringBuilder();

            if (Messages.Count > 0)
            {
                if (format == Enumerations.MessageFormat.HtmlEnumeratedList)
                    messageText.AppendLine("<ol>");
                else if (format == Enumerations.MessageFormat.HtmlList)
                    messageText.AppendLine("<ul>");

                foreach (Message message in Messages)
                {
                    if (typeFilters == null || typeFilters.Contains(message.Type))
                    {
                        if (format == Enumerations.MessageFormat.NewLine)
                            messageText.AppendLine($"{message.Type.ToString()} Message:\t{message.Content}{Environment.NewLine}");
                        else if (format == Enumerations.MessageFormat.HtmlEnumeratedList)
                            messageText.AppendLine($"<li class=\"{message.Type.ToString()}\">{message.Content}</li>");
                    }
                }

                if (format == Enumerations.MessageFormat.HtmlEnumeratedList)
                    messageText.AppendLine("</ol>");
                else if (format == Enumerations.MessageFormat.HtmlList)
                    messageText.AppendLine("</ul>");
            }
            else
                messageText.AppendLine("No messages");

            return messageText.ToString();

        }
        /// <summary>
        /// Returns a collection of messages by type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IEnumerable<IMessage> MessagesByType(Enumerations.MessageType type)
        {
            return Messages.Where(m => m.Type == type);
        }
        #endregion
    }
}