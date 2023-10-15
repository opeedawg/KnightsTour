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
// File             : TableJoin.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class Conditions.
    /// </summary>
    public class TableJoin : ITableJoin
    {
        public TableJoin()
        {
            JoinTable = string.Empty;
            PrimaryColumn = string.Empty;
            JoinColumn = string.Empty;
            JoinType = "INNER";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TableJoin "/> class.
        /// </summary>
        public TableJoin(string joinTable, string primaryColumn, string joinColumn, string joinType = "INNER")
        {
            JoinTable = joinTable;
            PrimaryColumn = primaryColumn;
            JoinColumn = joinColumn;
            JoinType = joinType;
        }

        public string JoinTable { get; set; }
        public string PrimaryColumn { get; set; }
        public string JoinColumn { get; set; }
        public string JoinType { get; set; }
    }
}