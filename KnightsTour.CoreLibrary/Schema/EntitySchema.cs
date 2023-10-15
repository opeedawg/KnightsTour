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
// File             : EntitySchema.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KnightsTour.CoreLibrary.Enumerations;
using Newtonsoft.Json;

namespace KnightsTour.CoreLibrary
{
    public class EntitySchema
    {
        public EntitySchema()
        {
            Properties = new List<PropertySchema>();
            Relationships = new List<RelationshipSchema>();
            Attributes = new List<AttributeSchema>();
        }
        public string Name { get; set; }
        public string DbName { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public List<PropertySchema> Properties { get; set; }
        public List<RelationshipSchema> Relationships { get; set; }
        public List<AttributeSchema> Attributes { get; set; }
        public bool RequiresQuotes { get; set; }
    }
}