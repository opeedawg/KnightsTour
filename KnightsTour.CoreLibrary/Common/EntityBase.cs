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
// File             : EntityBase.cs
// ************************************************************************

using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml.Serialization;
using KnightsTour.CoreLibrary.Enumerations;

namespace KnightsTour.CoreLibrary
{
    public delegate void IdSet();
    /// <summary>
    /// Abstract base class of all entities which also inherits <seealso cref="MethodWrappers" />.
    /// </summary>
    public abstract class EntityBase<TPk>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        public EntityBase()
        {
            UserName = "System";
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the primary key identifier.
        /// </summary>
        /// <value>The unique identifier for this entity.</value>
        [JsonIgnore]
        [XmlIgnore]
        public TPk Id { get; set; }
        /// <summary>
        /// The name of the entity.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public string EntityName { get; set; }
        /// <summary>
        /// The primary key field name for the entity.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public string PrimaryKeyField { get; set; }
        /// <summary>
        /// The primary key field name for the entity (formatted).
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public string PrimaryKeyFieldFormatted { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        /// <summary>Gets or sets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        /// <summary>Gets or sets the id of the executing user (used for concurrency management purposed).</summary>
        /// <value>The id of the executing user.</value>
        public int? ExecutingUserId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        /// <summary>Gets or sets the pk insert configuration.</summary>
        /// <value>The pk insert configuration.</value>
        public KnightsTour.CoreLibrary.Enumerations.InsertPKRule PKInsertConfiguration { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        /// <summary>
        /// Gets or sets the data type of the primary key.
        /// </summary>
        /// <value>
        /// The type of the primary key.
        /// </value>
        public PKType PrimaryKeyType { get; set; }
        #endregion

        #region Event related
        public event IdSet OnIdSet;
        /// <summary>
        /// Invoked when the generic Id field value is altered (set).
        /// </summary>
        protected virtual void IdSet()
        {
        // if OnIdSet is not null then call delegate.
        OnIdSet?.Invoke();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns only alpha characters.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="allowNumericInternal"></param>
        /// <returns></returns>
        public string OnlyAlpha(string text, bool allowNumericInternal = false)
        {
            if (string.IsNullOrEmpty(text)) return text;

            if (allowNumericInternal)
            {
                string newText = string.Empty;
                bool firstAlphaFound = false;
                foreach (char letter in text.ToCharArray())
                {
                    if ((firstAlphaFound && Char.IsNumber(letter)) || (Char.IsLetter(letter) || letter == '_'))
                    {
                        firstAlphaFound = true;
                        newText += letter;
                    }
                }
                return newText;
            }
            else
                return new String(text.Where(Char.IsLetter).ToArray());
        }
        #endregion    
    }
}