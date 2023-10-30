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
// Created          : October 26, 2023 9:31:46 AM
// File             : FieldValidatorBase.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Class FieldValidatorBase.
    /// </summary>
    public abstract class FieldValidatorBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValidatorBase"/> class.
        /// </summary>
        public FieldValidatorBase()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        public string Table { get; set; }
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }
        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>The type of the object.</value>
        public Type ObjectType { get; set; }
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public string FormatDescription { get; set; }
        /// <summary>
        /// Gets or sets the length minimum.
        /// </summary>
        /// <value>The length minimum.</value>
        public int? MinimumLength { get; set; }
        /// <summary>
        /// Gets or sets the length maximum.
        /// </summary>
        /// <value>The length maximum.</value>
        public int? MaximumLength { get; set; }
        /// <summary>
        /// Gets or sets the value minimum.
        /// </summary>
        /// <value>The value minimum.</value>
        public dynamic MinimumValue { get; set; }
        /// <summary>
        /// Gets or sets the value maximum.
        /// </summary>
        /// <value>The value maximum.</value>
        public dynamic MaximumValue { get; set; }
        /// <summary>
        /// Gets or sets the regular expression.
        /// </summary>
        /// <value>The regular expression.</value>
        public string RegularExpression { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [mandatory on insert].
        /// </summary>
        /// <value><c>true</c> if [mandatory on insert]; otherwise, <c>false</c>.</value>
        public bool MandatoryOnInsert { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [mandatory on update].
        /// </summary>
        /// <value><c>true</c> if [mandatory on update]; otherwise, <c>false</c>.</value>
        public bool MandatoryOnUpdate { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}