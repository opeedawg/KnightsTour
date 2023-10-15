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
// File             : ICustomValidator.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The ICustomValidator interface.
    /// </summary>
    public interface ICustomValidator
    {
        #region Properties
        /// <summary>Gets or sets the extended data.</summary>
        /// <value>The extended data.</value>
        Dictionary<string, object> ExtendedData { get; set; }
        /// <summary>Gets or sets the unique identifer.</summary>
        /// <value>The unique identifer.</value>
        string UniqueIdentifer { get; set; }
        /// <summary>Gets or sets the table.</summary>
        /// <value>The table.</value>
        string Table { get; set; }
        #endregion

        #region Methods
        /// <summary>Validates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isInsert">if set to <c>true</c> [is insert].</param>
        /// <returns></returns>
        IActionResponse Validate(object entity, bool isInsert);
        #endregion
    }
}