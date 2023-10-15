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
// File             : IWhereSet.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// A recursive definition of a Non-SQL where set.
    /// This can be either a collection of clauses or another collection of sets.
    /// Either way (clauses or sets) the conditions are related to a specific operator (AND or OR) UNLESS in the special case where there is only a single clause.
    /// </summary>
    public interface IWhereSet
    {
        #region Properties
        /// <summary>
        /// A collection of where clauses.  Defining this means it is a "low level" or fundamental where set.
        /// </summary>
        List<IWhereClause> Clauses { get; set; }
        /// <summary>
        /// A collection of other where sets.  Defining this means it is a meta set and will be recursively analysed.
        /// </summary>
        List<IWhereSet> Sets { get; set; }
        /// <summary>
        /// Either the OR or AND operator.
        /// </summary>
        Enumerations.WhereOperator Operator { get; set; }
        #endregion
    }
}