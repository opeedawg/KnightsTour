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
// File             : ObjectInCache.cs
// ************************************************************************

using System;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class ObjectInCache.
    /// </summary>
    public class ObjectInCache : IObjectInCache
    {
        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectInCache"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="staleLimit">The stale limit.</param>
        /// <param name="data">The data.</param>
        public ObjectInCache(string key, TimeSpan staleLimit, object data, DateTime? lastUpdate = null)
        {
            Key = key;
            StaleLimit = staleLimit;
            Data = data;
            ObjectReadHits = 0;
            WriteHits = 0;
            KeyReadHits = 0;
            LastUpdate = lastUpdate;
        }
        /// <summary>Determines whether the specified data hash is stale.</summary>
        /// <param name="dataHash">The data hash.</param>
        /// <returns>
        ///   <c>true</c> if the specified data hash is stale; otherwise, <c>false</c>.</returns>
        public bool IsStale(DateTime? lastUpdate)
        {
            return !lastUpdate.HasValue || lastUpdate.Value.Year == 1 || !LastRefresh.HasValue || DateTime.UtcNow.Subtract(LastRefresh.Value) > StaleLimit || LastUpdate != lastUpdate;
        }
        #endregion

        #region Declarations
        /// <summary>
        /// The data
        /// </summary>
        object data;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; private set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public object Data
        {
            get
            {
                ObjectReadHits++;
                KeyReadHits++;
                return data;
            }
            set
            {
                data = value;
                WriteHits++;
                ObjectReadHits = 0;
                LastRefresh = DateTime.UtcNow;
            }
        }
        /// <summary>Gets or sets the data hash.</summary>
        /// <value>The data hash.</value>
        public DateTime? LastUpdate { get; set; }
        /// <summary>
        /// Gets or sets the last refresh.
        /// </summary>
        /// <value>The last refresh.</value>
        public DateTime? LastRefresh { get; set; }
        /// <summary>
        /// Gets the stale limit.
        /// </summary>
        /// <value>The stale limit.</value>
        public TimeSpan StaleLimit { get; private set; }
        /// <summary>
        /// Gets or sets the write hits.
        /// </summary>
        /// <value>The write hits.</value>
        public int WriteHits { get; set; }
        /// <summary>
        /// Gets or sets the read hits for this object.
        /// </summary>
        /// <value>The read hits.</value>
        public int ObjectReadHits { get; set; }
        /// <summary>
        /// Gets or sets the read hits for this key.
        /// </summary>
        /// <value>The read hits.</value>
        public int KeyReadHits { get; set; }
        #endregion
    }
}