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
// File             : GenericParameter.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The GenericParameter class.
    /// </summary>
    public class GenericParameter : IParameter
    {
        /// <summary>
        /// Constructs GenericParameter object using the specified name and value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dataType">Type of the data (optional).</param>
        public GenericParameter(string name, object value, string dataType = null)
        {
            Name = name;
            Value = value;
            DataType = dataType;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        public string DataType { get; set; }
    }
}