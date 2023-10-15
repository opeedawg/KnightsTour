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
// File             : StorageStatement.cs
// ************************************************************************

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The SQLStatement class.
    /// </summary>
    public class StorageStatement: IStorageStatement
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageStatement"/> class.
        /// </summary>
        public StorageStatement()
        {
            ConnectionInformation = null;
            Parameters = new List<IParameter>();
            Parameter = null;
            CommandType = CommandType.Text;
            TimeoutSeconds = 30;
            AttemptToManageCache = true;
            Condition = null;
            NonSQLExecuteActionType = Enumerations.NonSQLExecuteActionType.None;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the SQL.
        /// </summary>
        /// <value>The SQL.</value>
        public string Statement { get; set; }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public List<IParameter> Parameters { get; set; }
        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        public IParameter Parameter { get; set; }
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionInformation { get; set; }
        /// <summary>
        /// Gets or sets the type of the command.
        /// </summary>
        /// <value>The type of the command.</value>
        [JsonIgnore]
        public CommandType CommandType { get; set; }
        /// <summary>
        /// Gets the command type string.
        /// </summary>
        /// <value>The command type string.</value>
        public string CommandTypeString
        {
            get
            {
                return CommandType.ToString();
            }
        }
        /// <summary>
        /// Gets or sets the timeout seconds.
        /// </summary>
        /// <value>The timeout seconds.</value>
        public int TimeoutSeconds { get; set; }
        /// <summary>
        /// Gets or sets the time out value.
        /// </summary>
        /// <value>The timeout value.</value>
        public bool AttemptToManageCache { get; set; }
        /// <summary>
        /// Gets or sets the AttemptToManageCache.
        /// </summary>
        public IRetrievalCondition Condition{ get; set; }
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public Enumerations.NonSQLExecuteActionType NonSQLExecuteActionType { get; set; }
        #endregion
    }
}