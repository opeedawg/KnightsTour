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
// File             : IActionResponse.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Interface for the ActionResponse class.
    /// </summary>
    public interface IActionResponse
    {
        #region Properties
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        string Context { get; set; }
        /// <summary>
        /// Gets or sets the list of messages.
        /// </summary>
        List<IMessage> Messages { get; set; }
        /// <summary>
        /// Gets a value indicating whether the action is valid.
        /// </summary>
        bool IsValid { get; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        Dictionary<string, dynamic> Data { get; set; }
        /// <summary>
        /// Gets or sets the DataObject.
        /// </summary>
        dynamic DataObject { get; set; }
        /// <summary>
        /// For collections (specifically to support server side pagination) you can add the total number of records that exist if required.
        /// </summary>
        int Count { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Appends action response to the data.
        /// </summary>
        /// <param name="response">The response to be appended.</param>
        void Append(IActionResponse response);
        /// <summary>
        /// Appends the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void Append(Exception exception);
        /// <summary>
        /// Appends message to the list of messages.
        /// </summary>
        /// <param name="message">The message to be appended.</param>
        void Append(IMessage message);
        /// <summary>
        /// Appends list of new messages to the list of messages.
        /// </summary>
        /// <param name="messages">The list messages to be appended.</param>
        void Append(List<IMessage> messages);
        /// <summary>
        /// Appends system message to the list of messages.
        /// </summary>
        /// <param name="message">The message to be appended.</param>
        /// <param name="messageType">The message type.</param>
        /// <param name="param1">Paramerer #1.</param>
        /// <param name="param2">Paramerer #2.</param>
        /// <param name="param3">Paramerer #3.</param>
        /// <param name="param4">Paramerer #4.</param>
        /// <param name="param5">Paramerer #5.</param>
        void Append(Enumerations.SystemMessage message, Enumerations.MessageType messageType, string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null);
        /// <summary>
        /// Returns string containing the formatted messages.
        /// </summary>
        /// <param name="format">The format specifier.</param>
        /// <param name="typeFilters">The type filters.</param>
        /// <returns></returns>
        string FormattedMessages(Enumerations.MessageFormat format = Enumerations.MessageFormat.NewLine, List<Enumerations.MessageType> typeFilters = null);
        #endregion
    }
}