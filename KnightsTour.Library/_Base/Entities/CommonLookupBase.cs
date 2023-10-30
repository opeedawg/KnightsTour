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
// Created          : October 26, 2023 9:31:46 AM
// File             : CommonLookupBase.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// This represents the fields common to all lookup tables.
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified.
    /// </remarks>
    public abstract class CommonLookupBase<TPk> : KnightsTour.CoreLibrary.EntityBase<TPk>
{
        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive
        {
            get;
            set;
        }
        #endregion Properties

    } //Class
} //Namespace