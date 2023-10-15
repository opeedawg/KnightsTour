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
// File             : RetrievalCondition.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class Conditions.
    /// </summary>
    public class RetrievalCondition : IRetrievalCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrievalCondition "/> class.
        /// </summary>
        public RetrievalCondition ()
        {
            SQLWhere = null;
            SQLOrderBy = null;
            SQLGroupBy = null;
            SQLHaving = null;
            Skip = null;
            Take = null;
            Columns = "*";
            NonSQLWhere = new WhereSet();
            NonSQLOrderBy = new List<IOrderByClause>();
            TableJoins = new List<TableJoin>();
        }
        /// <summary>
        /// Gets or sets the table joins
        /// </summary>
        /// <value>The table join objects</value>
        public List<TableJoin> TableJoins { get; set; }
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        /// <value>The where.</value>
        public string SQLWhere { get; set; }
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>The order by.</value>
        public string SQLOrderBy { get; set; }
        /// <summary>
        /// The group by clause.
        /// </summary>
        public string SQLGroupBy { get; set; }
        /// <summary>
        /// The having cluase
        /// </summary>
        public string SQLHaving { get; set; }
        /// <summary>
        /// Gets or sets the skip.
        /// </summary>
        /// <value>The skip.</value>
        public int? Skip { get; set; }
        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        /// <value>The take.</value>
        public int? Take { get; set; }
        /// <summary>
        /// A list of columns to include in the Non-SQL return set.
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string CacheKey()
        {
            string serialized = string.Empty;
            if (!string.IsNullOrEmpty(SQLWhere))
                serialized += SQLWhere.Replace(" ", "").ToUpper();
            if (!string.IsNullOrEmpty(SQLOrderBy))
                serialized += SQLOrderBy.ToUpper();
            if (!string.IsNullOrEmpty(Columns))
                serialized += Columns.ToUpper();
            if (Skip.HasValue)
                serialized += Skip;
            if (Take.HasValue)
                serialized += Take;

            return serialized;
        }
        /// <summary>
        /// This defines the where clause or filter for non-sql based storage providers.
        /// </summary>
        public IWhereSet NonSQLWhere { get; set; }
        /// <summary>
        /// This defines the order by clause for non-sql based storage providers.
        /// </summary>
        public List<IOrderByClause> NonSQLOrderBy { get; set; }
    }
}