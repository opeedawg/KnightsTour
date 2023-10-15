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
// Created          : January 13, 2023 7:25:02 AM
// File             : TableJoinInput.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    public class TableJoinInput : InputObjectGraphType<KnightsTour.CoreLibrary.TableJoin>
    {
        #region Constructor(s)
        /// <summary>
        /// Input yype configuration for passing in table join details.
        /// Usage like:
        /// </summary>
        /// <example>
        /// tableJoins: [
        ///     {joinTable: "Client", joinColumn: "ClientId", primaryColumn: "ClientId"},
        ///     {joinTable: "User", joinColumn: "UserId", primaryColumn: "CreatorId"}
        /// ]
        /// </example>
        /// <param name="data">The data model associated with the GraphQL Schema</param>
        public TableJoinInput(KnightsTourData data)
        {
            Name = "Table join input";
            Description = "Allows the input of join details on a query.";

            // Project property mapping.
            Field(x => x.JoinTable).Description("The table to join on.");
            Field(x => x.PrimaryColumn).Description("The primary table join column.");
            Field(x => x.JoinColumn).Description("The join table column to join on.");
            Field(x => x.JoinType, nullable: true).Description("The join type, defaulted to INNER if not defined.");
        }
        #endregion Constructor(s)
    } //Class
} //Namespace