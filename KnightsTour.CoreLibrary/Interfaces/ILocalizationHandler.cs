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
// File             : ILocalizationHandler.cs
// ************************************************************************

using System;
using System.Globalization;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The ILocalization interface.
    /// </summary>
    public interface ILocalizationHandler
    {
        #region Properties
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture information.</value>
        CultureInfo Culture { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Formats the currency.
        /// </summary>
        /// <param name="number">The number value.</param>
        /// <param name="format">The currency format.</param>
        /// <returns>The formatted currency string.</returns>
        string FormatCurrency(decimal? number, string format = null);
        /// <summary>
        /// Formats the date.
        /// </summary>
        /// <param name="date">The date value.</param>
        /// <param name="format">The date format.</param>
        /// <returns>The formatted date string.</returns>
        string FormatDate(DateTime? date, string format = null);
        #endregion
    }
}