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
// File             : EntityFilter.cs
// ************************************************************************

using KnightsTour.CoreLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.CoreLibrary
{
  public class EntityFilter
  {
    public EntityFilter(int pageIndex, int pageSize, string defaultSortColumn, List<string> textFields = null, List<SqlFilter> filters = null, string orderBy = null, string textFilter = null)
    {
      PageIndex = pageIndex;
      PageSize = pageSize;
      TextColumns = new List<string>();
      if (textFields != null)
        TextColumns = textFields;
      Filters = new List<SqlFilter>();
      if (filters != null)
        Filters = filters;
      OrderBys = new List<string>();
      if (!string.IsNullOrEmpty(orderBy))
        OrderBys.Add(orderBy);
      TextFilter = textFilter;
      DefaultSortColumn = defaultSortColumn;
    }

    #region Properties
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public List<SqlFilter> Filters { get; set; }
    public List<string> OrderBys { get; set; }
    public string TextFilter { get; set; }
    public string DefaultSortColumn { get; set; }
    public List<string> TextColumns { get; set; }
    #endregion
  }
}