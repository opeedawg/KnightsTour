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
// Created          : October 21, 2023 9:55:34 AM
// File             : ExceptionHandlerBase.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// Class ExceptionHandlerBase.
    /// </summary>
    public abstract class ExceptionHandlerBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerBase"/> class.
        /// </summary>
        public ExceptionHandlerBase()
        {
            HandlingOptions_New = new Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction>();
            HandlingOptions_Known = new Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the handling options new.
        /// </summary>
        /// <value>The handling options new.</value>
        public Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction> HandlingOptions_New { get; set; }
        /// <summary>
        /// Gets or sets the handling options known.
        /// </summary>
        /// <value>The handling options known.</value>
        public Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction> HandlingOptions_Known { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the handler new.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="option">The option.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddHandler_New(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction option)
        {
            if (HandlingOptions_New.ContainsKey(tier))
            {
                if (HandlingOptions_New[tier] != option)
                {
                    HandlingOptions_New[tier] = option;
                    return true;
                }
            }
            else
            {
                HandlingOptions_New.Add(tier, option);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Adds the handler known.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="option">The option.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddHandler_Known(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction option)
        {
            if (HandlingOptions_Known.ContainsKey(tier))
            {
                if (HandlingOptions_Known[tier] != option)
                {
                    HandlingOptions_Known[tier] = option;
                    return true;
                }
            }
            else
            {
                HandlingOptions_Known.Add(tier, option);
                return true;
            }
            return false;
        }
        #endregion

        #region Private support methods
        #endregion
    }
}