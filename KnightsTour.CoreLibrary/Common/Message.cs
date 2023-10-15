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
// File             : Message.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class Message.
    /// </summary>
    public class Message: IMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public Message(string message): this(message, Enumerations.MessageType.Positive, new List<string>())
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="relatedField">The related field.</param>
        public Message(string message, string relatedField) : this(message, Enumerations.MessageType.Positive, new List<string>() { relatedField})
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="relatedFields">The related fields.</param>
        public Message(string message, List<string> relatedFields) : this(message, Enumerations.MessageType.Positive, relatedFields)
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public Message(Exception exception)
        {
            Type = Enumerations.MessageType.Negative;
            RelatedFields = new List<string>();
            if (exception.InnerException == null)
            {
                Content = $"{exception.Message}";
            }
            else
            {
                Content = $"{exception.Message}: {exception.InnerException.Message}";
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="relatedFields">The related fields.</param>
        public Message(Exception exception, List<string> relatedFields)
        {
            Type = Enumerations.MessageType.Negative;
            RelatedFields = relatedFields;
            if (exception.InnerException == null)
            {
                Content = $"{exception.Message}";
            }
            else
            {
                Content = $"{exception.Message}: {exception.InnerException.Message}";
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="relatedField">The related field.</param>
        public Message(Exception exception, string relatedField)
        {
            Type = Enumerations.MessageType.Negative;
            RelatedFields = new List<string>() { relatedField };
            if (exception.InnerException == null)
            {
                Content = $"{exception.Message}";
            }
            else
            {
                Content = $"{exception.Message}: {exception.InnerException.Message}";
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public Message(string message, Enumerations.MessageType type) : this(message, type, new List<string>())
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        /// <param name="relatedFields">The related fields.</param>
        public Message(string message, Enumerations.MessageType type, List<string> relatedFields)
        {
            Content = message;
            Type = type;
            RelatedFields = relatedFields;
        }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Enumerations.MessageType Type { get; set; }
        /// <summary>
        /// Gets or sets the related fields.
        /// </summary>
        /// <value>The related fields.</value>
        public List<string> RelatedFields { get; set; }
    }
}