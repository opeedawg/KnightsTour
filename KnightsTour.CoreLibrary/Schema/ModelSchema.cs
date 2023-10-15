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
// File             : ModelSchema.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KnightsTour.CoreLibrary.Enumerations;
using Newtonsoft.Json;

namespace KnightsTour.CoreLibrary
{
    public class ModelSchema
    {
        public string Version { get; set; }
        public ProjectSchema Project { get; set; }

        public List<EntitySchema> Entities { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string StoredProcedurePrefix { get; set; }
        public bool UseStoredProcedure { get; set; }

        public ModelSchema()
        {
            Entities = new List<EntitySchema>();
            Project = new ProjectSchema();
        }
    }
}