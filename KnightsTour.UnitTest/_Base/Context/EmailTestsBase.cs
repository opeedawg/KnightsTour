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
// Created          : March 19, 2023 7:56:06 AM
// File             : EmailTestsBase.cs
// ************************************************************************

using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Context
{
    [TestClass]
    public class EmailTestsBase
    {
        #region Declarations
        string FromAddress = "from@domain.com";
        string ToAddress = "to@domain.com";
        string CCAddress = "cc@domain.com";
        string BCCAddress = "bcc@domain.com";
        #endregion

        #region Initialization and Cleanup routines
        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            KnightsTour.CoreLibrary.IEmailHandler handler = new EmailHandler();
            if (string.IsNullOrEmpty(handler.Server))
                Assert.Inconclusive("Insufficient SMTP configuration to test Email Context.  Missing 'SMTPServer'.");
            if (string.IsNullOrEmpty(handler.User))
                Assert.Inconclusive("Insufficient SMTP configuration to test Email Context.  Missing 'SMTPUser'.");
            if (string.IsNullOrEmpty(handler.Password))
                Assert.Inconclusive("Insufficient SMTP configuration to test Email Context.  Missing 'SMTPPassword'.");
            if (handler.Port <= 0)
                Assert.Inconclusive("Insufficient SMTP configuration to test Email Context.  Missing 'SMTPPort'.");
        }
        #endregion

        [TestMethod]
        public void Send()
        {
            KnightsTour.CoreLibrary.IEmailHandler messageHandler = new EmailHandler();
            KnightsTour.CoreLibrary.Message message = messageHandler.Send(FromAddress, ToAddress, "Send Unit Test", "Message body");
            if (message.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative && (message.Content.Contains("Authentication Required") || message.Content.Contains("Insufficient configuration")))
            {
                Assert.Inconclusive("Invalid SMTP settings.");
            }
            else
            {
                Assert.AreEqual(message.Type, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive);
            }
        }
        [TestMethod]
        public void SendMultiple()
        {
            KnightsTour.CoreLibrary.IEmailHandler messageHandler = new EmailHandler();
            KnightsTour.CoreLibrary.Message message = messageHandler.Send(FromAddress, $"{ToAddress};{CCAddress}", "Send Unit Test", "Message body");
            if (message.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative && (message.Content.Contains("Authentication Required") || message.Content.Contains("Insufficient configuration")))
            {
                Assert.Inconclusive("Invalid SMTP settings.");
            }
            else
            {
                Assert.AreEqual(message.Type, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive);
            }
        }
        [TestMethod]
        public void SendWithCC()
        {
            KnightsTour.CoreLibrary.IEmailHandler messageHandler = new EmailHandler();
            KnightsTour.CoreLibrary.Message message = messageHandler.Send(FromAddress, ToAddress, CCAddress, BCCAddress, "Send Unit Test", "Message body");
            if (message.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative && (message.Content.Contains("Authentication Required") || message.Content.Contains("Insufficient configuration")))
            {
                Assert.Inconclusive("Invalid SMTP settings.");
            }
            else
            {
                Assert.AreEqual(message.Type, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive);
            }
        }
        [TestMethod]
        public void SendAsHTML()
        {
            KnightsTour.CoreLibrary.IEmailHandler messageHandler = new EmailHandler();
            KnightsTour.CoreLibrary.Message message = messageHandler.Send(FromAddress, ToAddress, CCAddress, BCCAddress, "Send Unit Test", "Message body", false);
            if (message.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative && (message.Content.Contains("Authentication Required") || message.Content.Contains("Insufficient configuration")))
            {
                Assert.Inconclusive("Invalid SMTP settings.");
            }
            else
            {
                Assert.AreEqual(message.Type, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive);
                message = messageHandler.Send(FromAddress, ToAddress, CCAddress, BCCAddress, "Send Unit Test", "<h1>Message body</h1>", true);
                if (message.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative && (message.Content.Contains("Authentication Required") || message.Content.Contains("Insufficient configuration")))
                {
                    Assert.Inconclusive("Invalid SMTP settings.");
                }
                else
                {
                    Assert.AreEqual(message.Type, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive);
                }
            }
        }
    }
}