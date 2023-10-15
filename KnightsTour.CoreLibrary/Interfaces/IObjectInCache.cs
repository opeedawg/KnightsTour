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
// File             : IObjectInCache.cs
// ************************************************************************

using System;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Represents a single element in cache and all its attributes.
    /// </summary>
    public interface IObjectInCache
    {
        #region Properties
        /// <summary>
        /// The actual object in cache.
        /// </summary>
        object Data { get; set; }
        /// <summary>
        /// The objects cache key.
        /// </summary>
        string Key { get; }
        /// <summary>
        /// The number of times this object key as been accessed.
        /// </summary>
        int KeyReadHits { get; set; }
        /// <summary>
        /// The last time this object was refreshed (null if never)
        /// </summary>
        DateTime? LastRefresh { get; set; }
        /// <summary>
        /// The number of times this object as been accessed.
        /// </summary>
        int ObjectReadHits { get; set; }
        /// <summary>
        /// The maximum time span that this object can exist before it becomes stale.
        /// </summary>
        TimeSpan StaleLimit { get; }
        /// <summary>
        /// The number of times this cache element has been updated.
        /// </summary>
        int WriteHits { get; set; }
        #endregion

        #region Methods
        /// <summary>Determines whether the specified data hash is stale.</summary>
        /// <param name="lastUpdate">The last known update of the table data.</param>
        /// <returns>
        ///   <c>true</c> if the specified data hash is stale; otherwise, <c>false</c>.</returns>
        bool IsStale(DateTime? lastUpdate);
        #endregion
    }
}