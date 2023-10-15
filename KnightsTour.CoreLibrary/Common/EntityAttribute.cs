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
// File             : EntityAttribute.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Entity attributes used to assist unit testing
    /// </summary>
   public class EntityAttribute<TPk>
{
        /// <summary>
        /// The total number of records.
        /// </summary>
        public long RecordCount { get; set; }
        /// <summary>
        /// The first PK if it exists.
        /// </summary>
        public TPk FirstId { get; set; }
        /// <summary>
        /// The last PK if it exists.
        /// </summary>
        public TPk LastId { get; set; }
        /// <summary>
        /// True if the entity has a writeable string field.
        /// </summary>
        public bool HasStringField { get; set; }
        /// <summary>
        /// If the entity has a writeable string field, this is the property name.
        /// </summary>
        public string StringField { get; set; }
        /// <summary>
        /// True if the entity has a writeable Int32 field.
        /// </summary>
        public bool HasIntField { get; set; }
        /// <summary>
        /// If the entity has a writeable non-PK Int32 field, this is the property name.
        /// </summary>
        public string IntField { get; set; }
    }
}