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
// File             : IParameter.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// A generic parameter used to avoid SQL injection.
    /// This parameter will be type cast to the specific storage handler type on execution.
    /// </summary>
    public interface IParameter
    {
        #region Properties
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The value of the parameter.
        /// </summary>
        object Value { get; set; }
        /// <summary>
        /// The value of the parameter.
        /// </summary>
        string DataType { get; set; }
        #endregion
    }
}