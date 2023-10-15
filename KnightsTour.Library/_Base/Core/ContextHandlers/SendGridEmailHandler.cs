// © 2020 DXterity Solutions
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
// Author           : DXterity8 Version 8.4
// Created          : April 6, 2020 9:21:35 AM
// File             : EmailHandler.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KnightsTour
{
    /// <summary>
    /// Class EmailHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.IEmailHandler" />
    public class SendGridEmailHandler : KnightsTour.CoreLibrary.IEmailHandler
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SendGridEmailHandler"/> class.
        /// </summary>
        public SendGridEmailHandler()
        {
            ApiKey = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("SendGridApiKey", "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");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SendGridEmailHandler" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public SendGridEmailHandler(string apiKey)
        {
            ApiKey = apiKey;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey { get; set; }
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
                if (!string.IsNullOrEmpty(ApiKey))
                {
                    MailMessage msgMail = new MailMessage();
                    msgMail.From = new MailAddress(fromAddress);
                    msgMail.Subject = subject;
                    msgMail.Body = body;
                    foreach (string fileName in fileNames)
                        msgMail.Attachments.Add(new System.Net.Mail.Attachment(fileName));


                    msgMail.IsBodyHtml = isHTML;

                    var client = new SendGridClient(ApiKey);
                    var msg = new SendGridMessage()
                    {
                        From = new EmailAddress(fromAddress, "DXterity Administration"),
                        Subject = subject
                    };
                    if (isHTML)
                        msg.HtmlContent = body;
                    else
                        msg.PlainTextContent = body;

                    #region Addresses
                    List<string> addresses = toAddress.Split(';').ToList();
                    foreach (string address in addresses)
                    {
                        if (!string.IsNullOrEmpty(address))
                            msg.AddTo(new EmailAddress(address));
                    }

                    if (!string.IsNullOrEmpty(ccAddress))
                    {
                        addresses = ccAddress.Split(';').ToList();
                        foreach (string address in addresses)
                        {
                            if (!string.IsNullOrEmpty(address))
                                msg.AddCc(new EmailAddress(address));
                        }
                    }

                    if (!string.IsNullOrEmpty(bccAddress))
                    {
                        addresses = bccAddress.Split(';').ToList();
                        foreach (string address in addresses)
                        {
                            if (!string.IsNullOrEmpty(address))
                                msg.AddBcc(new EmailAddress(address));
                        }
                    }
                    #endregion

                    var response = client.SendEmailAsync(msg).Result;

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