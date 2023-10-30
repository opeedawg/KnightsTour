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
// File             : LocalizationHandler.cs
// ************************************************************************

using System;
using System.Globalization;

namespace KnightsTour
{
    /// <summary>
    /// Class LocalizationHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.ILocalizationHandler" />
    public class LocalizationHandler: KnightsTour.CoreLibrary.ILocalizationHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationHandler"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public LocalizationHandler(CultureInfo culture)
        {
            Culture = culture;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        public CultureInfo Culture { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Formats the currency.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        public string FormatCurrency(decimal? number, string format = null)
        {
            if (number.HasValue)
            {
                if (format != null)
                    return number.Value.ToString(format);
                else
                    return String.Format(Culture, "{0:C}", number.Value);
            }
            return string.Empty;
        }
        /// <summary>
        /// Formats the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        public string FormatDate(DateTime? date, string format = null)
        {
            if (date.HasValue)
            {
                if (format != null)
                    return date.Value.ToString(format);
                else
                    return date.Value.ToString("g", Culture);
            }
            return string.Empty;
        }
        #endregion
    }
}