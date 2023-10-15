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
// Created          : March 19, 2023 7:56:06 AM
// File             : LocalizationTestsBase.cs
// ************************************************************************

using System;
using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace KnightsTourUnitTests.Context
{
    [TestClass]
    public class LocalizationTestsBase
    {
        #region Declarations
        CultureInfo enUSculture = new CultureInfo("en-US");
        CultureInfo frFRculture = new CultureInfo("fr-FR");
        #endregion

        [TestMethod]
        public void Initialization()
        {
            KnightsTour.CoreLibrary.ILocalizationHandler localizationHandler = new LocalizationHandler(enUSculture);
            Assert.AreEqual(localizationHandler.Culture, enUSculture);
            localizationHandler.Culture = frFRculture;
            Assert.AreEqual(localizationHandler.Culture, frFRculture);
        }
        [TestMethod]
        public void FormatCurreny()
        {
            //US English
            decimal amount1 = 123.45M;
            decimal amount2 = 456789M;
            KnightsTour.CoreLibrary.ILocalizationHandler localizationHandler = new LocalizationHandler(enUSculture);
            Assert.AreEqual(localizationHandler.Culture, enUSculture);
            Assert.AreEqual("$123.45", localizationHandler.FormatCurrency(amount1));
            Assert.AreEqual("$456,789.00", localizationHandler.FormatCurrency(amount2));

            localizationHandler.Culture = frFRculture;
            Assert.AreEqual(localizationHandler.Culture, frFRculture);
            string curr1 = localizationHandler.FormatCurrency(amount1);
            string curr2 = localizationHandler.FormatCurrency(amount2);

            Assert.AreEqual("123,45 €", localizationHandler.FormatCurrency(amount1));
            Assert.AreEqual("456 789,00 €", localizationHandler.FormatCurrency(amount2));
        }
        [TestMethod]
        public void FormatDate()
        {
            //US English
            DateTime date1 = new DateTime(1999, 12, 31);
            DateTime date2 = new DateTime(2019, 1, 1, 23, 59, 59);

            KnightsTour.CoreLibrary.ILocalizationHandler localizationHandler = new LocalizationHandler(enUSculture);
            Assert.AreEqual(localizationHandler.Culture, enUSculture);
            Assert.AreEqual("12/31/1999 12:00 AM", localizationHandler.FormatDate(date1));
            Assert.AreEqual("1/1/2019 11:59 PM", localizationHandler.FormatDate(date2));
            Assert.AreEqual("12/31/1999 12:00:00 AM", localizationHandler.FormatDate(date1, "MM\\/dd\\/yyyy hh:mm:ss tt"));
            Assert.AreEqual("01/01/2019 11:59:59 PM", localizationHandler.FormatDate(date2, "MM\\/dd\\/yyyy hh:mm:ss tt"));
            Assert.AreEqual("01/01/2019 23:59:59", localizationHandler.FormatDate(date2, "MM\\/dd\\/yyyy HH:mm:ss"));

            localizationHandler.Culture = frFRculture;
            Assert.AreEqual(localizationHandler.Culture, frFRculture);
            Assert.AreEqual("31/12/1999 00:00", localizationHandler.FormatDate(date1));
            Assert.AreEqual("01/01/2019 23:59", localizationHandler.FormatDate(date2));
            Assert.AreEqual("1999-12-31 12:00:00 AM", localizationHandler.FormatDate(date1, "yyyy-MM-dd hh:mm:ss tt"));
            Assert.AreEqual("2019-01-01 11:59:59 PM", localizationHandler.FormatDate(date2, "yyyy-MM-dd hh:mm:ss tt"));
            Assert.AreEqual("2019-01-01 23:59:59", localizationHandler.FormatDate(date2, "yyyy-MM-dd HH:mm:ss"));
        }
    }
}