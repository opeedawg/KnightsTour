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
// File             : MessageTestsBase.cs
// ************************************************************************

using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Context
{
    [TestClass]
    public class MessageTestsBase
    {
        [TestMethod]
        public void HasMessages()
        {
            EnglishMessageHandler messageHandler = new EnglishMessageHandler();
            Assert.IsTrue(messageHandler.Messages.Count > 0);
        }
        [TestMethod]
        public void SetMessage()
        {
            EnglishMessageHandler messageHandler = new EnglishMessageHandler();
            AddMessage(messageHandler, "SetMessageUnitTest", "This is a test message.  Parameter 1: {0} Parameter 2 {1}");
        }
        [TestMethod]
        public void GetMessages()
        {
            EnglishMessageHandler messageHandler = new EnglishMessageHandler();

            //A custom message first
            string key = "GetMessageUnitTest";
            string parameter1 = "Bob";
            string parameter2 = "Sally";
            string message = "This is a test message.  Parameter 1: {0} Parameter 2 {1}";
            AddMessage(messageHandler, key, message);

            string populatedMessage = messageHandler.Get(key, parameter1, parameter2);
            Assert.AreEqual(string.Format(message, new object[] { parameter1, parameter2 }), populatedMessage);

            //Now a system message
            KnightsTour.CoreLibrary.Enumerations.SystemMessage systemMessage = KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdateTotal; //"{0}/{1} {2} record(s) updated."
            key = systemMessage.ToString();
            message = messageHandler.Messages[systemMessage.ToString()];
            populatedMessage = messageHandler.Get(systemMessage, "5","10","unit test");
            Assert.AreEqual(string.Format(message, new object[] { "5","10","unit test" }), populatedMessage);
        }
        [TestMethod]
        public void GetMessagesThroughResponse()
        {
            EnglishMessageHandler messageHandler = new EnglishMessageHandler();
            KnightsTour.CoreLibrary.Enumerations.SystemMessage systemMessage = KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdateTotal; //"{0}/{1} {2} record(s) updated."
            string parameter1 = "5";
            string parameter2 = "10";
            string parameter3 = "unit test";
            string message = messageHandler.Messages[systemMessage.ToString()];

            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse("unit test");
            response.Append(systemMessage, KnightsTour.CoreLibrary.Enumerations.MessageType.Positive, parameter1, parameter2, parameter3);

            string populatedMessage = messageHandler.Get(systemMessage, parameter1, parameter2, parameter3);

            Assert.AreEqual(response.Messages[0].Content, populatedMessage);
        }
        void AddMessage(KnightsTour.CoreLibrary.IMessageHandler messageHandler, string key, string message)
        {
            messageHandler.Set(key, message);
            Assert.IsTrue(messageHandler.Messages.ContainsKey(key));
            Assert.AreEqual(messageHandler.Messages[key], message);
        }
    }
}