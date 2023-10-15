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
// File             : RuleValidator.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using KnightsTour.CoreLibrary;

namespace KnightsTour
{
    /// <summary>
    /// Class FieldValidation.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.IRuleValidator" />
    public class RuleValidator : KnightsTour.CoreLibrary.IRuleValidator
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleValidator "/> class.
        /// </summary>
        public RuleValidator(string groupId)
        {
            GroupId = groupId;
            Fields = new List<KeyValuePair<string, string>>();
        }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the rules group id.
        /// </summary>
        /// <value>
        /// The rule group id (unique guid).
        /// </value>
        public string GroupId { get; set; }
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        public string Table { get; set; }
        /// <summary>
        /// Gets or sets the list of fields
        /// </summary>
        /// <value>The name of the field.</value>
        public List<KeyValuePair<string, string>> Fields { get; set; }
        #endregion

        #region Methods        
        /// <summary>Validates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="schema">The db schema name for the asscociated table.</param>
        /// <param name="isInsert"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public IActionResponse Validate<TPk>(object entity, string schema, bool isInsert, IStorageHandler handler = null)
        {
            IActionResponse response = new ActionResponse();

            //Construct the query
            if (handler == null)
                handler = StorageProvider.GetHandler();

            List<IParameter> parameters = new List<IParameter>();
            string sql = $"SELECT * FROM {StorageProvider.GetTableSQL(KnightsTour.EntityMapper.EntityNameTransformation[Table], schema)} WHERE ";
            foreach(KeyValuePair<string, string> field in Fields)
            {
                //Use reflection to get the value on the object
                dynamic value = ReflectionAssistant.GetValue<object, dynamic>(entity, field.Key);
                sql += $"{StorageProvider.GetColumnSQL(field.Value)} = @{field.Key}Param AND ";
                parameters.Add(new GenericParameter($"@{field.Key}Param", value));
            }
            sql = sql.Substring(0, sql.Length - 4); //Remove the final "AND "

            //Assume the object implements IEntity
            IEntity<TPk> iEntity = (IEntity<TPk>)entity;
            if (!isInsert && iEntity.Id != null)
                sql += $"AND {StorageProvider.GetColumnSQL(iEntity.PrimaryKeyField)} <> {iEntity.Id}";

            List<dynamic> rows = handler.GetRecords(new StorageStatement { Statement = sql, Parameters = parameters }).ToList();
            if (rows.Count > 0)
            {
                if (Fields.Count == 1)
                    response.Messages.Add(new Message($"The property '{Fields[0].Key}' must be unique on entity '{Table}'.  The data '{ReflectionAssistant.GetValue<object, dynamic>(entity, Fields[0].Key)}' already exists.", KnightsTour.CoreLibrary.Enumerations.MessageType.Negative));
                else if (Fields.Count > 1)
                    response.Messages.Add(new Message($"The property combination of '{string.Join(",", Fields.Select(x => x.Key))}' must be unique on entity '{Table}'.  The data combination submitted already exists.", KnightsTour.CoreLibrary.Enumerations.MessageType.Negative));
                else //This should not be possible, but just in case I guess for development purposes
                    response.Messages.Add(new Message($"Unhandled rule violation: {sql}", KnightsTour.CoreLibrary.Enumerations.MessageType.Negative));
            }

            return response;
        }
        #endregion
    }
}