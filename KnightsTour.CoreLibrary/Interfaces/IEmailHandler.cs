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
// File             : IEmailHandler.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The Email handler interface.
    /// </summary>
    public interface IEmailHandler
    {
        #region Properties
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        string Server { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        string User { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        int Port { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Sends the Email to the specified address.
        /// </summary>
        /// <param name="From">The sender Email address.</param>
        /// <param name="To">The receiver Email address.</param>
        /// <param name="Subject">The subject of the Email.</param>
        /// <param name="Body">The text of the Email.</param>
        /// <returns>Message.</returns>
        Message Send(string From, string To, string Subject, string Body);
        /// <summary>
        /// Sends the Email to the specified address and copies it to the addresses specified in CC and BCC.
        /// </summary>
        /// <param name="From">The sender Email address.</param>
        /// <param name="To">The receiver Email address.</param>
        /// <param name="CC">The Email addresses to copy.</param>
        /// <param name="BCC">The Email addresses to blind copy.</param>
        /// <param name="Subject">The subject of the Email.</param>
        /// <param name="Body">The text of the Email.</param>
        /// <returns>Message.</returns>
        Message Send(string From, string To, string CC, string BCC, string Subject, string Body);
        /// <summary>
        /// Sends the Email to the specified address and copies it to the addresses specified in CC and BCC.
        /// If the IsHTML flag is set to <c>true</c> the Email will be send as HTML; otherwise, as plain text.
        /// </summary>
        /// <param name="From">The sender Email address.</param>
        /// <param name="To">The receiver Email address.</param>
        /// <param name="CC">The Email addresses to copy.</param>
        /// <param name="BCC">The Email addresses to blind copy.</param>
        /// <param name="Subject">The subject of the Email.</param>
        /// <param name="Body">The text of the Email.</param>
        /// <param name="IsHTML">if set to <c>true</c> the Email will be sent as HTML; otherwise, as plain text.</param>
        /// <returns>Message.</returns>
        Message Send(string From, string To, string CC, string BCC, string Subject, string Body, bool IsHTML);
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="From">The sender Email address.</param>
        /// <param name="To">The receiver Email address.</param>
        /// <param name="CC">The Email addresses to copy.</param>
        /// <param name="BCC">The Email addresses to blind copy.</param>
        /// <param name="Subject">The subject of the Email.</param>
        /// <param name="Body">The text of the Email.</param>
        /// <param name="IsHTML">if set to <c>true</c> the Email will be sent as HTML; otherwise, as plain text.</param>
        /// <param name="fileNames">The file names of the files that will be attached to the Email.</param>
        /// <returns>Message.</returns>
        Message Send(string From, string To, string CC, string BCC, string Subject, string Body, bool IsHTML, List<string> fileNames);
        #endregion
    }
}