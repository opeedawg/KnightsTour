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
// Created          : October 21, 2023 9:55:34 AM
// File             : EmailHandler.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace KnightsTour
{
    /// <summary>
    /// Class EmailHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.IEmailHandler" />
    public class EmailHandler: KnightsTour.CoreLibrary.IEmailHandler
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailHandler"/> class.
        /// </summary>
        public EmailHandler()
        {
            Server = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("SMTPServer", string.Empty);
            User = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("SMTPUser", string.Empty);
            Password = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("SMTPPassword", string.Empty);
            Port = KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt("SMTPPort", 0);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailHandler"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="port">The port.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public EmailHandler(string server, int port, string userName, string password)
        {
            Server = server;
            Port = port;
            User = userName;
            Password = password;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public string Server { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public string User { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        public int Port { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="fromAddress">From.</param>
        /// <param name="toAddress">To.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <returns>Message.</returns>
        public KnightsTour.CoreLibrary.Message Send(string fromAddress, string toAddress, string subject, string body)
        {
            return Send(fromAddress, toAddress, string.Empty, string.Empty, subject, body, true);
        }
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="fromAddress">From.</param>
        /// <param name="toAddress">To.</param>
        /// <param name="ccAddress">The cc.</param>
        /// <param name="bccAddress">The BCC.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <returns>Message.</returns>
        public KnightsTour.CoreLibrary.Message Send(string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string body)
        {
            return Send(fromAddress, toAddress, ccAddress, bccAddress, subject, body, true);
        }
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="fromAddress">From.</param>
        /// <param name="toAddress">To.</param>
        /// <param name="ccAddress">The cc.</param>
        /// <param name="bccAddress">The BCC.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHTML">if set to <c>true</c> [is HTML].</param>
        /// <returns>Message.</returns>
        public KnightsTour.CoreLibrary.Message Send(string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string body, bool isHTML)
        {
            return Send(fromAddress, toAddress, ccAddress, bccAddress, subject, body, isHTML, new List<string>());
        }
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="fromAddress">From.</param>
        /// <param name="toAddress">To.</param>
        /// <param name="ccAddress">The cc.</param>
        /// <param name="bccAddress">The BCC.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHTML">if set to <c>true</c> [is HTML].</param>
        /// <param name="fileNames">The file names.</param>
        /// <returns>Message.</returns>
        public KnightsTour.CoreLibrary.Message Send(string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string body, bool isHTML, List<string> fileNames)
        {
            try
            {
                if (!string.IsNullOrEmpty(Server) && Port > 0 && !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password))
                {
                    MailMessage msgMail = new MailMessage();
                    msgMail.From = new MailAddress(fromAddress);
                    msgMail.Subject = subject;
                    msgMail.Body = body;
                    foreach (string fileName in fileNames)
                        msgMail.Attachments.Add(new Attachment(fileName));

                    List<string> addresses = toAddress.Split(';').ToList();
                    foreach (string address in addresses)
                    {
                        if (!string.IsNullOrEmpty(address))
                            msgMail.To.Add(address);
                    }

                    if (!string.IsNullOrEmpty(ccAddress))
                    {
                        addresses = ccAddress.Split(';').ToList();
                        foreach (string address in addresses)
                        {
                            if (!string.IsNullOrEmpty(address))
                                msgMail.CC.Add(address);
                        }
                    }

                    if (!string.IsNullOrEmpty(bccAddress))
                    {
                        addresses = bccAddress.Split(';').ToList();
                        foreach (string address in addresses)
                        {
                            if (!string.IsNullOrEmpty(address))
                                msgMail.Bcc.Add(address);
                        }
                    }

                    msgMail.IsBodyHtml = isHTML;

                    SmtpClient mail = new SmtpClient(Server, Port);
                    mail.UseDefaultCredentials = false;
                    mail.Credentials = new System.Net.NetworkCredential(User, Password);
                    mail.EnableSsl = true;
                    mail.Timeout = 100000;
                    mail.Send(msgMail);

                    return new KnightsTour.CoreLibrary.Message("Mail Sent Successfully", KnightsTour.CoreLibrary.Enumerations.MessageType.Positive);
                }
                else
                    return new KnightsTour.CoreLibrary.Message("Insufficient configuration settings to send email.  Please check your contextual settings.", KnightsTour.CoreLibrary.Enumerations.MessageType.Negative);
            }
            catch (Exception exception)
            {
                return new KnightsTour.CoreLibrary.Message(exception);
            }
        }
        #endregion
    }
}