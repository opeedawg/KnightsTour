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
// File             : GroupDetailType.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    public class GroupDetailType : ObjectGraphType<GroupDetail>
    {
        #region Constructor(s)
        /// <summary>
        /// Type configuration for access to the grouping details.
        /// </summary>
        /// <param name="data">The data model associated with the GraphQL Schema</param>
        public GroupDetailType(KnightsTourData data)
        {
            Name = "GroupDetail";
            Description = "The GraphQL class that maps and exposes properties and references from the Group Detail entity.";

            // Project property mapping.
            Field(x => x.GroupProperty).Description("The group property");
            Field(x => x.FkProperty1, nullable: true).Description("The optional primary foreign key reference property");
            Field(x => x.FkProperty2, nullable: true).Description("The optional secondary foreign key reference property");
        }
        #endregion Constructor(s)

    } //Class
} //Namespace