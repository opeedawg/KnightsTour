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
// File             : MessageHandlerBase.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class MessageHandlerBase.
    /// </summary>
    public abstract class MessageHandlerBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandlerBase"/> class.
        /// </summary>
        public MessageHandlerBase()
        {
            Messages = new Dictionary<string, string>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public Dictionary<string, string> Messages { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <param name="param3">The param3.</param>
        /// <param name="param4">The param4.</param>
        /// <param name="param5">The param5.</param>
        /// <returns>System.String.</returns>
        public string Get(Enumerations.SystemMessage key, string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null)
        {
            return Get(key.ToString(), param1, param2, param3, param4, param5);
        }
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <param name="param3">The param3.</param>
        /// <param name="param4">The param4.</param>
        /// <param name="param5">The param5.</param>
        /// <returns>System.String.</returns>
        public string Get(string key, string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null)
        {
            if (!Messages.ContainsKey(key))
                Set(key, $"Message not set '{key}'");

            return string.Format(Messages[key], param1, param2, param3, param4, param5);
        }
        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="message">The message.</param>
        public void Set(Enumerations.SystemMessage key, string message)
        {
            Set(key.ToString(), message);
        }
        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="message">The message.</param>
        public void Set(string key, string message)
        {
            if (Messages.ContainsKey(key))
                Messages[key] = message;
            else
                Messages.Add(key, message);
        }
        #endregion
    }
}