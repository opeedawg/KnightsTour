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
// File             : IMessage.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The IMessage interface.
    /// </summary>
    public interface IMessage
    {
        #region Properties
        /// <summary>
        /// Gets or sets the content value.
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// Gets or Sets the message type value.
        /// </summary>
        Enumerations.MessageType Type { get; set; }
        /// <summary>
        /// Gets or sets the related fields values.
        /// </summary>
        List<string> RelatedFields { get; set; }
        #endregion
    }
}