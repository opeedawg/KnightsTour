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
// Created          : January 13, 2023 7:25:01 AM
// File             : AESCryptographyHandler.cs
// ************************************************************************

using BCrypt;
using System;
using System.Security.Cryptography;
using System.Text;

namespace KnightsTour
{
    /// <summary>
    /// Class AESCryptographyHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.ICryptographyHandler" />
    /// <remarks>Credit to: https://www.c-sharpcorner.com/article/introduction-to-aes-and-des-encryption-algorithms-in-net/</remarks>
    public class AESCryptographyHandler: KnightsTour.CoreLibrary.ICryptographyHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AESCryptographyHandler"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public AESCryptographyHandler(string key)
        {
            Key = key;
            Salt = BCryptHelper.GenerateSalt();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; private set; }
        /// <summary>
        /// Gets the salt for the hashing algorithm.
        /// </summary>
        /// <value>The salt.</value>
        public string Salt { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Hashes the specified string data.
        /// Uses the Knuth hash.
        /// </summary>
        /// <param name="plainText">The string data.</param>
        /// <returns>UInt64.</returns>
        public string Hash(string plainText)
        {
            return BCryptHelper.HashPassword(plainText, Salt);
        }
        /// <summary>
        /// Determines whether [is hash match] [the specified plain text].
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="hash">The hash.</param>
        /// <returns><c>true</c> if [is hash match] [the specified plain text]; otherwise, <c>false</c>.</returns>
        public bool IsHashMatch(string plainText, string hash)
        {
            return BCryptHelper.CheckPassword(plainText, hash);
        }
        /// <summary>
        /// Encrypts the specified string data.
        /// </summary>
        /// <param name="plainText">The string data.</param>
        /// <returns>System.String.</returns>
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;

            RijndaelManaged objrij = new RijndaelManaged();
            //set the mode for operation of the algorithm   
            objrij.Mode = CipherMode.CBC;
            //set the padding mode used in the algorithm.   
            objrij.Padding = PaddingMode.PKCS7;
            //set the size, in bits, for the secret key.   
            objrij.KeySize = 0x80;
            //set the block size in bits for the cryptographic operation.    
            objrij.BlockSize = 0x80;
            //set the symmetric key that is used for encryption & decryption.    
            byte[] passBytes = Encoding.UTF8.GetBytes(Key);
            //set the initialization vector (IV) for the symmetric algorithm    
            byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);

            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;

            //Creates symmetric AES object with the current key and initialization vector IV.    
            ICryptoTransform objtransform = objrij.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(plainText);
            //Final transform the test string.  
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }
        /// <summary>
        /// Decrypts the specified string data.
        /// </summary>
        /// <param name="encryptedText">The string data.</param>
        /// <returns>System.String.</returns>
        public string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return encryptedText;

            RijndaelManaged objrij = new RijndaelManaged();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;

            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;
            byte[] encryptedTextByte = Convert.FromBase64String(encryptedText);
            byte[] passBytes = Encoding.UTF8.GetBytes(Key);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);  //it will return readable string  
        }
        #endregion
    }
}