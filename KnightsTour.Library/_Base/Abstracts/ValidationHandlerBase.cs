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
// File             : ValidationHandlerBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KnightsTour
{
    /// <summary>
    /// Class ValidationHandlerBase.
    /// </summary>
    public abstract class ValidationHandlerBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationHandlerBase"/> class.
        /// </summary>
        public ValidationHandlerBase()
        {
            try
            {
                //Initialize the collections
                FieldConfiguration = new Dictionary<string, Dictionary<string, KnightsTour.CoreLibrary.IFieldValidator>>();
                RuleConfiguration = new Dictionary<string, List<KnightsTour.CoreLibrary.IRuleValidator>>();
                CustomConfiguration = new Dictionary<string, List<KnightsTour.CoreLibrary.ICustomValidator>>();

            //By default add all the entity object validator classes
				AddOrUpdate("Board", new BoardValidation());
				AddOrUpdate("DifficultyLevel", new DifficultyLevelValidation());
				AddOrUpdate("EventHistory", new EventHistoryValidation());
				AddOrUpdate("EventType", new EventTypeValidation());
				AddOrUpdate("Member", new MemberValidation());
				AddOrUpdate("Puzzle", new PuzzleValidation());
				AddOrUpdate("Solution", new SolutionValidation());

            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Dictionary<string, Dictionary<string, KnightsTour.CoreLibrary.IFieldValidator>> FieldConfiguration { get; set; }
        /// <summary>Gets or sets the rule configuration.</summary>
        /// <value>The rule configuration.</value>
        public Dictionary<string,List<KnightsTour.CoreLibrary.IRuleValidator>> RuleConfiguration { get; set; }
        /// <summary>Gets or sets the custom configuration.</summary>
        /// <value>The custom configuration.</value>
        public Dictionary<string, List<KnightsTour.CoreLibrary.ICustomValidator>> CustomConfiguration { get; set; }
        /// <summary>Gets or sets a value indicating whether [all or nothing].</summary>
        /// <value>
        ///   <c>true</c> if [all or nothing]; otherwise, <c>false</c>.</value>
        public bool AllOrNothing { get; set; } = true;
        #endregion

        #region Methods
        /// <summary>Adds the or update.</summary>
        /// <param name="table">The table.</param>
        /// <param name="entityValidator">The entity validator.</param>
        public void AddOrUpdate(string table, KnightsTour.CoreLibrary.IEntityValidator entityValidator)
        {
            try
            {
                foreach(KnightsTour.CoreLibrary.IFieldValidator validator in entityValidator.FieldValidations)
                    AddOrUpdate(table, validator);
                foreach (KnightsTour.CoreLibrary.IRuleValidator validator in entityValidator.RuleValidations)
                    AddOrUpdate(table, validator);
                foreach (KnightsTour.CoreLibrary.ICustomValidator validator in entityValidator.CustomValidations)
                    AddOrUpdate(table, validator);
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validator">The validator.</param>
        public void AddOrUpdate(string table, KnightsTour.CoreLibrary.IFieldValidator validator)
        {
            try
            {
                validator.Table = table.ToString();
                if (FieldConfiguration.ContainsKey(table))
                {
                    if (FieldConfiguration[table].ContainsKey(validator.FieldName))
                    {
                        //Update the existing record
                        FieldConfiguration[table][validator.FieldName] = validator;
                    }
                    else
                    {
                        //Add a new record
                        FieldConfiguration[table].Add(validator.FieldName, validator);
                    }
                }
                else
                {
                    FieldConfiguration.Add(table, new Dictionary<string, KnightsTour.CoreLibrary.IFieldValidator>());
                    FieldConfiguration[table].Add(validator.FieldName, validator);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Adds or updates the rule validator.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validator">The rule validator.</param>
        public void AddOrUpdate(string table, KnightsTour.CoreLibrary.IRuleValidator validator)
        {
            try
            {
                validator.Table = table.ToString();
                if (RuleConfiguration.ContainsKey(table))
                {
                    KnightsTour.CoreLibrary.IRuleValidator existingValidator = RuleConfiguration[table].FirstOrDefault(v => v.GroupId == validator.GroupId);
                    if(existingValidator != null)
                    {
                        //Update the existing record
                        existingValidator = validator;
                    }
                    else
                    {
                        //Add a new record
                        RuleConfiguration[table].Add(validator);
                    }
                }
                else
                {
                    RuleConfiguration.Add(table, new List<KnightsTour.CoreLibrary.IRuleValidator>());
                    RuleConfiguration[table].Add(validator);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Adds or updates the custom validator.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="validator">The custom validator.</param>
        public void AddOrUpdate(string table, KnightsTour.CoreLibrary.ICustomValidator validator)
        {
            try
            {
                validator.Table = table.ToString();
                if (CustomConfiguration.ContainsKey(table))
                {
                    KnightsTour.CoreLibrary.ICustomValidator existingValidator = CustomConfiguration[table].FirstOrDefault(v => v.UniqueIdentifer == validator.UniqueIdentifer);
                    if (existingValidator != null)
                    {
                        //Update the existing record
                        existingValidator = validator;
                    }
                    else
                    {
                        //Add a new record
                        CustomConfiguration[table].Add(validator);
                    }
                }
                else
                {
                    CustomConfiguration.Add(table, new List<KnightsTour.CoreLibrary.ICustomValidator>());
                    CustomConfiguration[table].Add(validator);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Removes the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        public void Remove(string table, string fieldName)
        {
            try
            {
                if (Exists(table, fieldName))
                {
                    //Remove it if it exists
                    FieldConfiguration[table].Remove(fieldName);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Removes the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void Remove(string table)
        {
            try
            {
                if (FieldConfiguration.ContainsKey(table)) FieldConfiguration.Remove(table);
                if (RuleConfiguration.ContainsKey(table)) RuleConfiguration.Remove(table);
                if (CustomConfiguration.ContainsKey(table)) CustomConfiguration.Remove(table);
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Verifies the specified table adn field name combination exists.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns><c>true</c> if both table and field name exist, <c>false</c> otherwise.</returns>
        public bool Exists(string table, string fieldName)
        {
            return FieldConfiguration.ContainsKey(table) && FieldConfiguration[table].ContainsKey(fieldName);
        }
        /// <summary>Existses the specified table.</summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        public bool Exists(string table)
        {
            return FieldConfiguration.ContainsKey(table) || RuleConfiguration.ContainsKey(table) || CustomConfiguration.ContainsKey(table);
        }
        /// <summary>
        /// Gets the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List&lt;IFieldValidator&gt;.</returns>
        public List<KnightsTour.CoreLibrary.IFieldValidator> GetFieldValidators(Enumerations.EntityName table)
        {
            return GetFieldValidators(table.ToString());
        }
        /// <summary>
        /// Gets the field validators configured on the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List&lt;IFieldValidator&gt;.</returns>
        public List<KnightsTour.CoreLibrary.IFieldValidator> GetFieldValidators(string table)
        {
            if (!FieldConfiguration.ContainsKey(table))
                FieldConfiguration.Add(table, new Dictionary<string, KnightsTour.CoreLibrary.IFieldValidator>());

            return FieldConfiguration[table].Values.ToList();
        }
        /// <summary>
        /// Gets the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>IFieldValidator.</returns>
        public KnightsTour.CoreLibrary.IFieldValidator GetFieldValidator(string table, string fieldName)
        {
            if (Exists(table, fieldName))
                return FieldConfiguration[table][fieldName];

            return null;
        }
        /// <summary>
        /// Gets the rule validators configured on the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List&lt;IRuleValidator&gt;.</returns>
        public List<KnightsTour.CoreLibrary.IRuleValidator> GetRuleValidators(string table)
        {
            if (!RuleConfiguration.ContainsKey(table))
                RuleConfiguration.Add(table, new List<KnightsTour.CoreLibrary.IRuleValidator>());

            return RuleConfiguration[table];
        }
        /// <summary>
        /// Gets the custom validators configured on the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>List&lt;ICustomValidator&gt;.</returns>
        public List<KnightsTour.CoreLibrary.ICustomValidator> GetCustomValidators(string table)
        {
            if (!CustomConfiguration.ContainsKey(table))
                CustomConfiguration.Add(table, new List<KnightsTour.CoreLibrary.ICustomValidator>());

            return CustomConfiguration[table];
        }
        /// <summary>
        /// Validates the table fields.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="schema">The table schema.</param>
        /// <param name="tableObject">The table object.</param>
        /// <param name="isInsert">if set to <c>true</c> [is insert].</param>
        /// <returns>ActionResponse.</returns>
        public KnightsTour.CoreLibrary.ActionResponse ValidateEntity<TPk>(string table, string schema, object tableObject, bool isInsert = false)
        {
            KnightsTour.CoreLibrary.ActionResponse response = new KnightsTour.CoreLibrary.ActionResponse($"Field validation for table '{table.ToString()}'");
            foreach (KnightsTour.CoreLibrary.IFieldValidator validator in GetFieldValidators(table))
            {
                PropertyInfo info = GetPropertyInfo(tableObject, validator.FieldName);
                if (info != null)
                {
                    object val = GetPropValue(tableObject, info);
                    response.Append(validator.Validate(val, isInsert));
                }
            }
            foreach (KnightsTour.CoreLibrary.IRuleValidator validator in GetRuleValidators(table))
            {
                response.Append(validator.Validate<TPk>(tableObject, schema, isInsert));
            }
            foreach (KnightsTour.CoreLibrary.ICustomValidator validator in GetCustomValidators(table))
            {
                response.Append(validator.Validate(tableObject, isInsert));
            }

            return response;
        }
        /// <summary>
        /// Validates the field.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="isInsert">if set to <c>true</c> [is insert].</param>
        /// <returns>ActionResponse.</returns>
        public KnightsTour.CoreLibrary.ActionResponse ValidateField(string table, string fieldName, object fieldValue, bool isInsert = false)
        {
            if(Exists(table, fieldName))
                return GetFieldValidator(table, fieldName).Validate(fieldValue, isInsert);

            return new KnightsTour.CoreLibrary.ActionResponse();
        }
        /// <summary>
        /// Gets the property information.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>PropertyInfo.</returns>
        PropertyInfo GetPropertyInfo(object sourceObject, string propertyName)
        {
            return sourceObject.GetType().GetProperty(propertyName);
        }
        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>System.Object.</returns>
        object GetPropValue(object sourceObject, PropertyInfo propertyInfo)
        {
            return propertyInfo.GetValue(sourceObject, null);
        }
        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        object GetPropValue(object sourceObject, string propertyName)
        {
            PropertyInfo info = GetPropertyInfo(sourceObject, propertyName);
            if (info != null)
                return info.GetValue(sourceObject, null);
            else
                throw new NotImplementedException($"Property '{propertyName}' does not exist in class '{sourceObject.GetType().Name}'");
        }
        #endregion
    }
}