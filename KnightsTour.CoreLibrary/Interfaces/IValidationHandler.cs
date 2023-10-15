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
// File             : IValidationHandler.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The IValidationHandler interface.
    /// </summary>
    public interface IValidationHandler
    {
        #region Properties
        /// <summary>
        /// Gets or sets the field configuration.
        /// </summary>
        /// <value>The field configurations.</value>
        Dictionary<string, Dictionary<string, IFieldValidator>> FieldConfiguration { get; set; }
        /// <summary>
        /// Gets or sets the rule configuration.
        /// </summary>
        /// <value>The rule configurations.</value>
        Dictionary<string, List<IRuleValidator>> RuleConfiguration { get; set; }
        /// <summary>
        /// Gets or sets the custom configuration.
        /// </summary>
        /// <value>The custom configurations.</value>
        Dictionary<string, List<ICustomValidator>> CustomConfiguration { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds or updates the field validators to the configuration.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validators">The field validators.</param>
        void AddOrUpdate(string table, IEntityValidator entityValidation);
        /// <summary>
        /// Adds or updates the field validator to the configuration.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validator">The validator.</param>
        void AddOrUpdate(string table, IFieldValidator validator);
        /// <summary>
        /// Adds or updates the rule validator to the configuration.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validator">The rule validator.</param>
        void AddOrUpdate(string table, IRuleValidator validator);
        /// <summary>
        /// Adds or updates the custom validator to the configuration.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validator">The custom validator.</param>
        void AddOrUpdate(string table, ICustomValidator validator);
        /// <summary>
        /// Removes the specified field name from the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        void Remove(string table, string fieldName);
        /// <summary>
        /// Removes the specified field name from the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        void Remove(string table);
        /// <summary>
        /// Checks it the field exists in the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns><c>true</c> if the field exists in the table, <c>false</c> otherwise.</returns>
        bool Exists(string table, string fieldName);
        /// <summary>
        /// Checks it the field exists in the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns><c>true</c> if the field exists in the table, <c>false</c> otherwise.</returns>
        bool Exists(string table);
        /// <summary>
        /// Gets the field validators configured on the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List of field validators.</returns>
        List<IFieldValidator> GetFieldValidators(string table);
        /// <summary>
        /// Gets the field validator configured on the table and field.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>The field validator.</returns>
        IFieldValidator GetFieldValidator(string table, string fieldName);
        /// <summary>
        /// Gets the rule validators configured on the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List of field validators.</returns>
        List<IRuleValidator> GetRuleValidators(string table);
        /// <summary>
        /// Gets the custom validators configured on the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List of field validators.</returns>
        List<ICustomValidator> GetCustomValidators(string table);
        /// <summary>
        /// Validates the table fields.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="tableObject">The table object.</param>
        /// <param name="isInsert">if set to <c>true</c> perform the validation when text is inserted into the field.</param>
        /// <returns>The response to the action.</returns>
        ActionResponse ValidateEntity<TPk>(string table, string schema, object tableObject, bool isInsert = false);
        /// <summary>
        /// Validates the field.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="isInsert">if set to <c>true</c> perform the validation when text is inserted into the field.</param>
        /// <returns>ActionResponse.</returns>
        ActionResponse ValidateField(string table, string fieldName, object fieldValue, bool isInsert = false);
        /// <summary>Gets or sets a value indicating whether [all or nothing].</summary>
        /// <value>
        ///   <c>true</c> if [all or nothing]; otherwise, <c>false</c>.</value>
        bool AllOrNothing { get; set; }
        #endregion
    }
}