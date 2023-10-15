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
// File             : CollectionFilter.cs
// ************************************************************************

using Microsoft.AspNetCore.Http;
using System.Web;

namespace WebAPI.RestControllers
{
    /// <summary>A collection filter to apply generic pagination and sorting to Rest API calls.</summary>
    public class CollectionFilter
    {
        /// <summary>Initializes a new instance of the <see cref="CollectionFilter"/> class.</summary>
        /// <param name="request">The request.</param>
        /// <param name="defaultPageSize">Default size of the page.</param>
        public CollectionFilter(HttpRequest request, int defaultPageSize)
        {
            #region Collect the parameters
            IQueryCollection collection = request.Query;
            string pageSize = null;
            string page = null;
            string orderBy = null;
            if (collection.ContainsKey("pageSize")) pageSize = collection["pageSize"];
            if (collection.ContainsKey("page")) page = collection["page"];
            if (collection.ContainsKey("orderBy")) orderBy = collection["orderBy"];

            if (pageSize != null && int.TryParse(pageSize, out int result))
            {
                PageSize = result;
            }
            else
            {
                PageSize = defaultPageSize;
            }
            if (page != null && int.TryParse(page, out result))
            {
                Page = result;
            }
            else
            {
                Page = 0;
            }
            if (orderBy != null)
            {
                OrderBy = orderBy;
            }
            #endregion
        }
        /// <summary>Gets the skip.</summary>
        /// <value>The skip.</value>
        public int Skip
        {
            get
            {
                return Page * PageSize;
            }
        }
        /// <summary>Gets or sets the order by.</summary>
        /// <value>The order by.</value>
        public string OrderBy { get; set; }
        /// <summary>Gets or sets the page.</summary>
        /// <value>The page.</value>
        public int Page { get; set; }
        /// <summary>Gets or sets the size of the page.</summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }
        /// <summary>Gets a value indicating whether this instance has sort.</summary>
        /// <value>
        ///   <c>true</c> if this instance has sort; otherwise, <c>false</c>.</value>
        public bool HasSort
        {
            get
            {
                return !string.IsNullOrEmpty(OrderBy);
            }
        }
        /// <summary>Gets a value indicating whether this instance has pagination.</summary>
        /// <value>
        ///   <c>true</c> if this instance has pagination; otherwise, <c>false</c>.</value>
        public bool HasPagination
        {
            get
            {
                return PageSize > 0;
            }
        }
    }
}