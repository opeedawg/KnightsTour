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
// File             : IRetrievalCondition.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Defines conditions for a StorageStatement filter.
    /// </summary>
    public interface IRetrievalCondition
    {
        #region Properties
        /// <summary>
        /// Optionally defines table joins on the query
        /// </summary>
        List<TableJoin> TableJoins { get; set; }
        /// <summary>
        /// For SQL storages, the where clause SQL (not including the WHERE syntax)
        /// </summary>
        string SQLWhere { get; set; }
        /// <summary>
        /// For SQL storages, the order by clause SQL (not including the ORDER BY syntax)
        /// </summary>
        string SQLOrderBy { get; set; }
        /// <summary>
        /// For SQL storages, the group by clause SQL (not including the GROUP BY syntax)
        /// </summary>
        string SQLGroupBy { get; set; }
        /// <summary>
        /// For SQL storages, the order by clause SQL (not including the ORDER BY syntax)
        /// </summary>
        string SQLHaving { get; set; }
        /// <summary>
        /// For Non-SQL storages, this represents the HAVING clause (not including the HAVING BY syntax)
        /// </summary>
        IWhereSet NonSQLWhere { get; set; }
        /// <summary>
        /// For Non-SQL storages this represents a collection of order by clauses.
        /// </summary>
        List<IOrderByClause> NonSQLOrderBy { get; set; }
        /// <summary>
        /// To support pagination, you can configure this to skip a certain number of records in the response, usually used in conjunction with Take.
        /// </summary>
        int? Skip { get; set; }
        /// <summary>
        /// To support pagination, you can configure this to only take a certain number of records, usually used in conjunction with Skip.
        /// </summary>
        int? Take { get; set; }
        /// <summary>
        /// The columns you wish populated in the result set.  If null or blank, all columns will be returned.
        /// </summary>
        string Columns { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// A cache key to assist with cache management.
        /// </summary>
        /// <returns></returns>
        string CacheKey();
        #endregion
    }
}