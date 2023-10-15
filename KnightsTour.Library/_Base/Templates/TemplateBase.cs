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
// Created          : October 14, 2023 11:18:11 AM
// File             : TemplateBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>Base template class which supports common replacements.</summary>
    public abstract class TemplateBase
    {
        #region Declarations
        Dictionary<string, string> commonVariables = null;
        #endregion

        #region Properties
        /// <summary>Gets the common replacements.  These are initiated at the time of the tempalte initialization - to reset - instantiate a new object.</summary>
        /// <value>The common replacements.</value>
        public Dictionary<string, string> CommonVariables
        {
            get
            {
                if (commonVariables == null)
                {
                    commonVariables = new Dictionary<string, string> {
                        { "YEAR", DateTime.Now.Year.ToString()},
                        { "DATE_LONG",DateTime.Now.ToLongDateString()},
                        { "DATE_SHORT",DateTime.Now.ToShortDateString()},
                        { "TIME_LONG", DateTime.Now.ToLongTimeString()},
                        { "TIME_SHORT", DateTime.Now.ToShortTimeString()},
                        { "DAY", DateTime.Now.Day.ToString()},
                        { "MONTH", DateTime.Now.ToString("MMMM")},
                        { "MONTH_NAME", DateTime.Now.Year.ToString()},
                        { "DAY_OF_WEEK", DateTime.Now.ToString("dddd")},
                        { "COMPANY", "27 Software"}
                    };
                }
                return commonVariables;
            }
        }
        #endregion
    }
}