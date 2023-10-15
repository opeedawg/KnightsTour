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
// File             : WhereSet.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Contains a set of where clauses OR a set of other where sets.
    /// NOTE: This class should only ever have the Clauses set OR the Sets set - never both.
    /// NOTE: You may have a set with only a single clause.
    /// Recursively called as deep as required to deal with situations like:
    /// <code>
    /// A &amp;&amp; B
    /// A || B
    /// A &amp;&amp; (B || C)
    /// A || (B &amp;&amp; C)
    /// (A &amp;&amp; B) || (C &amp;&amp; D)
    /// etc.
    /// </code>
    /// </summary>
    public class WhereSet : IWhereSet
    {
        /// <summary>
        /// Constructs new WhereSet object.
        /// </summary>
        public WhereSet() : this(new List<IWhereClause>(), Enumerations.WhereOperator.And) { }
        /// <summary>
        /// Constructs new WhereSet object using where clause.
        /// </summary>
        /// <param name="clause">The clause.</param>
        public WhereSet(IWhereClause clause) : this(new List<IWhereClause>() { clause }, Enumerations.WhereOperator.And) { }
        /// <summary>
        /// Constructs new WhereSet object using where clause and where operator.
        /// </summary>
        /// <param name="clause">The clause.</param>
        /// <param name="whereOperator">The where parameter.</param>
        public WhereSet(IWhereClause clause, Enumerations.WhereOperator whereOperator) : this(new List<IWhereClause>() { clause}, whereOperator) { }
        /// <summary>
        /// Constructs new WhereSet object using list of where clauses and where operator.
        /// </summary>
        /// <param name="clauses">The clauses.</param>
        /// <param name="whereOperator">The operator.</param>
        public WhereSet(List<IWhereClause> clauses, Enumerations.WhereOperator whereOperator)
        {
            Clauses = clauses;
            Operator = whereOperator;
        }
        /// <summary>
        /// Gets or sets the list of clauses.
        /// </summary>
        public List<IWhereClause> Clauses { get; set; }
        /// <summary>
        /// Gets or sets the list of sets.
        /// </summary>
        public List<IWhereSet> Sets { get; set; }
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public Enumerations.WhereOperator Operator { get; set; }
    }
}