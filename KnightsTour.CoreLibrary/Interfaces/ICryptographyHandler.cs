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
// File             : ICryptographyHandler.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Interface ICryptographyHandler
    /// </summary>
    public interface ICryptographyHandler
    {
        #region Properties
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        string Key { get; }
        /// <summary>
        /// Gets the salt for the hashing algorithm.
        /// </summary>
        /// <value>The salt.</value>
        string Salt { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Hashes the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>The hashed value of the plain text.</returns>
        string Hash(string plainText);
        /// <summary>
        /// Determines whether the hashed value of the specified plain text maches the specified hash.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="hash">The hash.</param>
        /// <returns><c>true</c> if the hashed value of the specified plain text maches the specified hash; otherwise, <c>false</c>.</returns>
        bool IsHashMatch(string plainText, string hash);
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>The encrypted text.</returns>
        string Encrypt(string plainText);
        /// <summary>
        /// Decrypts the specified encrypted text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns>The decrypted text.</returns>
        string Decrypt(string encryptedText);
        #endregion
    }
}