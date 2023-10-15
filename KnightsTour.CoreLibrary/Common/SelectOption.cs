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
// File             : SelectOption.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
  /// <summary>
  /// The SelectOption class.
  /// </summary>
  public class SelectOption
  {
    /// <summary>
    /// Constructs OrderByClause object using the specified property.
    /// </summary>
    /// <param name="property">The property.</param>
    public SelectOption(string key) : this(key, key)
    {
    }
    /// <summary>
    /// Constructs OrderByClause object using the specified property and direction.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="direction">The direction.</param>
    public SelectOption(string key, string value)
    {
      Value = key;
      Label = value;
    }

    /// <summary>
    /// The hidden ID portion of the select option.
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// The human visible value related to the id.
    /// </summary>
    public string Label { get; set; }
  }
}