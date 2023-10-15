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
// File             : IStorageHandler.cs
// ************************************************************************

using System.Collections.Generic;
using System.Data;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Defines direct access to a particular storage mechanism.
    /// </summary>
    public interface IStorageHandler
    {
        #region Methods
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>IEnumerable&lt;IDataRecord&gt;.</returns>
        IEnumerable<dynamic> GetRecords(IStorageStatement statement);
        /// <summary>
        /// Executes the reader single.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>DataRow.</returns>
        dynamic GetRecord(IStorageStatement statement);
        /// <summary>
        /// Executes a command and returns the number of entities affected by the command.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>DataSet.</returns>
        int Execute(IStorageStatement statement);
        /// <summary>
        /// Executes a the scalar command and returns a single object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statement">The statement.</param>
        /// <returns>T.</returns>
        T GetValue<T>(IStorageStatement statement);
        /// <summary>Adds the record.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="overrideStoredprocedureUsage">Never use stored procedures, required for unit testing.</param>
        /// <returns></returns>
        TPk AddRecord<TPk>(IEntity<TPk> entity, string connectionString = null, bool overrideStoredprocedureUsage = false);
        /// <summary>
        /// Retrieves a data set.
        /// </summary>
        /// <param name="statement"></param>
        /// <returns></returns>
        DataSet GetDataSet(IStorageStatement statement);
        #endregion
        /// <summary>
        /// Creates a where clause given a filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <returns>An Sql query specific to the database technology.</returns>
        string GetWhereSql(EntityFilter filter);
        /// <summary>
        /// Creates an order by clause given a filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <param name="addOrderBySql">A flag to determine of the actual ORDER BY text should be added to the query or not.</param>
        /// <returns></returns>
        string GetOrderBySql(EntityFilter filter, bool addOrderBySql = false);
        /// <summary>
        /// Creates a pagination clause given a filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <returns>An Sql query specific to the database technology.</returns>
        string GetPaginationSql(EntityFilter filter);
        /// <summary>
        /// Creates the generic parameters that match the where clause filter.
        /// </summary>
        /// <param name="filter">The entity filter definition.</param>
        /// <returns></returns>
        List<IParameter> GetParameters(EntityFilter filter);

        #region Properties
        /// <summary>
        /// The information specific to the handlers connection.
        /// For SQL based data stores, the connection string; for Non-SQL typically a file path.
        /// </summary>
        string ConnectionInformation { get; set; }
        /// <summary>
        /// Gets or sets the maximum size of the insert block.
        /// </summary>
        /// <value>The size of the update block.</value>
        int InsertBlockSize { get; set; }
        /// <summary>
        /// Gets or sets the maximum size of the delete block.
        /// </summary>
        /// <value>The size of the delete block.</value>
        int DeleteBlockSize { get; set; }
        /// <summary>
        /// Does this handler return Dynamic Objects?
        /// </summary>
        bool ReturnsDynamicObjects { get; set; }
        /// <summary>Gets the pk insert configuration.</summary>
        /// <value>The pk insert configuration.</value>
        Enumerations.InsertPKRule PKInsertConfiguration { get;}
        #endregion
    }
}