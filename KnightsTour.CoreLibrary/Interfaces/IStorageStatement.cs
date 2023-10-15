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
// File             : IStorageStatement.cs
// ************************************************************************

using System.Collections.Generic;
using System.Data;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// A generic statement containing all required elements to be executed against a storage mechanism.
    /// </summary>
    public interface IStorageStatement
    {
        #region Properties
        /// <summary>
        /// For SQL storages mechanisms, usually a SQL statement.
        /// For Non-SQL storage mechanisms usually a type specific serialization of an object.
        /// </summary>
        string Statement { get; set; }
        /// <summary>
        /// A list of parameters that will be inserted into the statment to avoid SQL injection.
        /// </summary>
        List<IParameter> Parameters { get; set; }
        /// <summary>
        /// A handy quick way to add a single parameter.
        /// </summary>
        IParameter Parameter { get; set; }
        /// <summary>
        /// Either the connection string (for SQL sources) or a path (for non-sql sources).
        /// </summary>
        string ConnectionInformation { get; set; }
        /// <summary>
        /// An enumerated list of either Text, StoredProcedure or TableDirect.
        /// </summary>
        CommandType CommandType { get; set; }
        /// <summary>
        /// The number of seconds before the statement should timeout.
        /// </summary>
        int TimeoutSeconds { get; set; }
        /// <summary>
        /// Whether or not this statement should even attempt to manage any related cache.
        /// </summary>
        bool AttemptToManageCache { get; set; }
        /// <summary>
        /// A rich set of conditions and filters to apply to the statement.
        /// </summary>
        IRetrievalCondition Condition { get; set; }
        /// <summary>
        /// For non-sql executions, this will specify if the statement is either an Update or Delete statement.
        /// </summary>
        Enumerations.NonSQLExecuteActionType NonSQLExecuteActionType { get; set; }
        #endregion
    }
}