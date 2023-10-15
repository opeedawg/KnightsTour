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
// File             : PropertySchema.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KnightsTour.CoreLibrary.Enumerations;
using Newtonsoft.Json;

namespace KnightsTour.CoreLibrary
{
    public class PropertySchema
	{
		public PropertySchema()
		{
			Attributes = new List<AttributeSchema>();
		}
		public string Name { get; set; }
		public string DbName { get; set; }
		public bool IsSortable { get; set; }
		public string Label { get; set; }
		public string DataType { get; set; }
		public bool IsMandatory { get; set; }
		public bool IsPrimaryKey { get; set; }
		public bool IsForeignKey { get; set; }
		public PropertyDefaultSchema InsertDefault { get; set; }
		public PropertyDefaultSchema UpdateDefault { get; set; }
		public string ForeignEntityName { get; set; }
		public string ForeignPropertyName { get; set; }
		public string ForeignEntityDbName { get; set; }
		public string ForeignPropertyDbName { get; set; }
		public string ForeignEntityNameRelationship { get; set; }
		public string ForeignEntityNameExplicit { get; set; }
		public bool RequiresQuotes { get; set; }

		public List<AttributeSchema> Attributes { get; set; }
	}
}