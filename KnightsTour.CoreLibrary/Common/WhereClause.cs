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
// File             : WhereClause.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The WhereClause class.
    /// </summary>
    public class WhereClause : IWhereClause
    {
        /// <summary>
        /// Constructs where clause using property and value.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        public WhereClause(string property, object value) : this(property, value, Enumerations.WhereCondition.Equals) { }
        /// <summary>
        /// Constructs where clause using property, value and condition.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <param name="condition">The condition.</param>
        public WhereClause(string property, object value, Enumerations.WhereCondition condition)
        {
            Property = property;
            Value = value;
            Condition = condition;
        }
        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public Enumerations.WhereCondition Condition { get; set; }
    }
}