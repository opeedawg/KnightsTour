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
// Created          : October 14, 2023 11:18:11 AM
// File             : CustomValidatorBase.cs
// ************************************************************************

using KnightsTour.CoreLibrary;
using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// Helper class to implement custom valiators.
    /// </summary>
    public abstract class CustomValidatorBase
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="CustomValidatorBase"/> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="table">The table.</param>
        public CustomValidatorBase(string id, string table)
        {
            UniqueIdentifer = id;
            Table = table;
        }
        #endregion

        #region Properties
        /// <summary>Gets or sets the extended data.</summary>
        /// <value>The extended data.</value>
        public Dictionary<string, object> ExtendedData { get; set; }
        /// <summary>Gets or sets the unique identifer.</summary>
        /// <value>The unique identifer.</value>
        public string UniqueIdentifer { get; set; }
        /// <summary>Gets or sets the table.</summary>
        /// <value>The table.</value>
        public string Table { get; set; }
        #endregion
    }
}