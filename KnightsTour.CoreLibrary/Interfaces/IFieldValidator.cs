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
// File             : IFieldValidator.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The IFieldValidator interface.
    /// </summary>
    public interface IFieldValidator
    {
        #region Properties
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        string Table { get; set; }
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        string FieldName { get; set; }
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        string FormatDescription { get; set; }
        /// <summary>
        /// Gets or sets the minimum length.
        /// </summary>
        /// <value>The minimum length.</value>
        int? MinimumLength { get; set; }
        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        int? MaximumLength { get; set; }
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        object MinimumValue { get; set; }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        object MaximumValue { get; set; }
        /// <summary>
        /// Gets or sets the regular expression.
        /// </summary>
        /// <value>The regular expression.</value>
        string RegularExpression { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [mandatory on insert].
        /// </summary>
        /// <value><c>true</c> if [mandatory on insert]; otherwise, <c>false</c>.</value>
        bool MandatoryOnInsert { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [mandatory on update].
        /// </summary>
        /// <value><c>true</c> if [mandatory on update]; otherwise, <c>false</c>.</value>
        bool MandatoryOnUpdate { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the defaults.
        /// </summary>
        void SetDefaults();
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isInsert">if set to <c>true</c> perform validation after text was inserted into the field.</param>
        /// <returns>ActionResponse.</returns>
        ActionResponse Validate(object value, bool isInsert = false);
        #endregion
    }
}