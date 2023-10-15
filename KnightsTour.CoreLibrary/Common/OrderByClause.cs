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
// File             : OrderByClause.cs
// ************************************************************************


namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The OrderByClause class.
    /// </summary>
    public class OrderByClause : IOrderByClause
    {
        /// <summary>
        /// Constructs OrderByClause object using the specified property.
        /// </summary>
        /// <param name="property">The property.</param>
        public OrderByClause(string property) : this(property, Enumerations.OrderByDirection.Ascending) {
        }
        /// <summary>
        /// Constructs OrderByClause object using the specified property and direction.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="direction">The direction.</param>
        public OrderByClause(string property, Enumerations.OrderByDirection direction)
        {
            Property = property;
            Direction = direction;
        }
        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        public Enumerations.OrderByDirection Direction { get; set; }
    }
}