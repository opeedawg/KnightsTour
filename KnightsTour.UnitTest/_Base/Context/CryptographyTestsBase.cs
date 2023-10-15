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
// File             : CryptographyTestsBase.cs
// ************************************************************************

using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Context
{
    [TestClass]
    public class CryptographyTestsBase
    {
        string key = "6C7E39E5DA3E52396457546C81898";
        [TestMethod]
        public void Initialization()
        {
            KnightsTour.CoreLibrary.ICryptographyHandler handler = new AESCryptographyHandler(key);
            Assert.IsFalse(string.IsNullOrEmpty(handler.Key));
            Assert.IsFalse(string.IsNullOrEmpty(handler.Salt));
        }
        [TestMethod]
        public void Hash()
        {
            KnightsTour.CoreLibrary.ICryptographyHandler handler = new AESCryptographyHandler(key);
            string plainText = "password";
            string hashedText = handler.Hash(plainText);
            Assert.IsFalse(string.IsNullOrEmpty(hashedText));
            Assert.AreNotEqual(hashedText, plainText);
        }
        [TestMethod]
        public void IsHashMatch()
        {
            KnightsTour.CoreLibrary.ICryptographyHandler handler = new AESCryptographyHandler(key);
            string plainText = "password";
            string hashedText = handler.Hash(plainText);
            Assert.IsFalse(string.IsNullOrEmpty(hashedText));
            Assert.AreNotEqual(hashedText, plainText);
            Assert.IsTrue(handler.IsHashMatch(plainText, hashedText));
        }
        [TestMethod]
        public void Encrypt()
        {
            KnightsTour.CoreLibrary.ICryptographyHandler handler = new AESCryptographyHandler(key);
            string plainText = "password";
            string encryptedText = handler.Encrypt(plainText);
            Assert.AreNotEqual(encryptedText, plainText);
        }
        [TestMethod]
        public void Decrypt()
        {
            KnightsTour.CoreLibrary.ICryptographyHandler handler = new AESCryptographyHandler(key);
            string plainText = "password";
            string encryptedText = handler.Encrypt(plainText);
            Assert.AreNotEqual(encryptedText, plainText);
            Assert.AreEqual(handler.Decrypt(encryptedText), plainText);
        }
    }
}