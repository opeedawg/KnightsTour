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
// File             : AssistantTestsBase.cs
// ************************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Dynamic;

namespace KnightsTourUnitTests
{
    [TestClass]
    public class AssistantTestsBase : DataTestBase<int?>
    {
        #region ReflectionAssistant Tests
        [TestMethod]
        public void Reflection_HasProperty()
        {
            DummyClass dummyClass = GetNewEntity<DummyClass>();

            Assert.IsTrue(KnightsTour.CoreLibrary.ReflectionAssistant.HasProperty<DummyClass>(dummyClass, "FK1"));
            Assert.IsTrue(KnightsTour.CoreLibrary.ReflectionAssistant.HasProperty<DummyClass>(dummyClass, "Amount"));
            Assert.IsFalse(KnightsTour.CoreLibrary.ReflectionAssistant.HasProperty<DummyClass>(dummyClass, "fk2"));
            Assert.IsFalse(KnightsTour.CoreLibrary.ReflectionAssistant.HasProperty<DummyClass>(dummyClass, "YourMom"));
        }
        [TestMethod]
        public void Reflection_SetValue()
        {
            DummyClass dummyClass = GetNewEntity<DummyClass>();

            string originalDescription = dummyClass.Description;
            string newDescription = originalDescription + " your Mom!";

            KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<DummyClass>(dummyClass, "Description", newDescription);

            Assert.AreNotEqual(originalDescription, newDescription);
            Assert.AreNotEqual(dummyClass.Description, originalDescription);
            Assert.AreEqual(dummyClass.Description, newDescription);
        }
        [TestMethod]
        public void Reflection_GetValue()
        {
            DummyClass dummyClass = GetNewEntity<DummyClass>();

            string description = dummyClass.Description;
            int? fk1 = dummyClass.FK1;

            Assert.AreEqual(description, KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<DummyClass, string>(dummyClass, "Description"));
            Assert.AreEqual(fk1, KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<DummyClass, int?>(dummyClass, "FK1"));

            var ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<DummyClass, decimal>(dummyClass, "Description"));
            Assert.AreEqual(ex.Message, "Property 'Description' of type String can not be assigned to type Decimal.");
        }
        [TestMethod]
        public void Reflection_GetMethodAttributes()
        {
            StackTrace trace = new StackTrace();
            KnightsTour.CoreLibrary.MethodAttributeAssistant attributes = KnightsTour.CoreLibrary.ReflectionAssistant.GetMethodAttributes(trace, 0);
            Assert.AreEqual(attributes.NameSpace, "KnightsTourUnitTests");
            Assert.AreEqual(attributes.Class, "AssistantTestsBase");
            Assert.AreEqual(attributes.Method, "Reflection_GetMethodAttributes");
            Assert.IsTrue(attributes.Assembly.EndsWith("KnightsTour.UnitTest.dll"));
        }
        #endregion

        #region KnightsTour.CoreLibrary.SearchAssistant Tests
        [TestMethod]
        public void Search_GetStringBetween1()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            searchAssistant.StartSearchString = "<title>";
            searchAssistant.EndSearchString = "</title>";
            Assert.AreEqual("Test Document", searchAssistant.GetStringBetween());
            searchAssistant.StartSearchString = "<table>";
            searchAssistant.EndSearchString = "</table>";
            Assert.AreEqual(string.Empty, searchAssistant.GetStringBetween());
        }
        [TestMethod]
        public void Search_GetStringBetween2()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());

            Assert.AreEqual("This is a div", searchAssistant.GetStringBetween("<div>", "</div>"));
            Assert.AreEqual(string.Empty, searchAssistant.GetStringBetween("<table>", "</table>"));
        }
        [TestMethod]
        public void Search_GetStringBetween3()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());

            Assert.AreEqual("Test Document", searchAssistant.GetStringBetween("<title>", "</title>", 0));
            Assert.AreEqual(string.Empty, searchAssistant.GetStringBetween("<title>", "</title>", 50));
        }
        [TestMethod]
        public void Search_GetNextCharacters1()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            searchAssistant.StartSearchString = "<title>";
            Assert.AreEqual("Test", searchAssistant.GetNextCharacters(4));
            searchAssistant.StartSearchString = "<table>";
            Assert.AreEqual(string.Empty, searchAssistant.GetNextCharacters(1));
        }
        [TestMethod]
        public void Search_GetNextCharacters2()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            Assert.AreEqual("Test", searchAssistant.GetNextCharacters("<title>", 4));
            Assert.AreEqual(string.Empty, searchAssistant.GetNextCharacters("<table>", 1));
        }
        [TestMethod]
        public void Search_GetNextCharacters3()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            Assert.AreEqual("Test", searchAssistant.GetNextCharacters("<title>", 4, 0));
            Assert.AreEqual(string.Empty, searchAssistant.GetNextCharacters("<title>", 4, 50));
        }
        [TestMethod]
        public void Search_GetStringsBetween1()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            List<string> subStrings = searchAssistant.GetStringsBetween("<p>", "</p>");
            Assert.AreEqual(subStrings.Count, 5);
            subStrings = searchAssistant.GetStringsBetween("<table>", "</table>");
            Assert.AreEqual(subStrings.Count, 0);
            subStrings = searchAssistant.GetStringsBetween("<span>", "</span>");
            Assert.AreEqual(subStrings.Count, 2);
        }
        [TestMethod]
        public void Search_GetStringsBetween2()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            List<string> subStrings = searchAssistant.GetStringsBetween("<p>", "</p>", 1);
            Assert.AreEqual(subStrings.Count, 5);
            subStrings = searchAssistant.GetStringsBetween("<p>", "</p>", 100);
            Assert.AreEqual(subStrings.Count, 3);
            subStrings = searchAssistant.GetStringsBetween("<p>", "</p>", 10000);
            Assert.AreEqual(subStrings.Count, 0);
        }
        [TestMethod]
        public void Search_GetAssistantBetween1()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());
            searchAssistant.StartSearchString = "<title>";
            searchAssistant.EndSearchString = "</title>";
            Assert.AreEqual("Test Document", searchAssistant.GetAssistantBetween().SearchText);
            searchAssistant.StartSearchString = "<table>";
            searchAssistant.EndSearchString = "</table>";
            Assert.AreEqual(string.Empty, searchAssistant.GetAssistantBetween().SearchText);
        }
        [TestMethod]
        public void Search_GetAssistantBetween2()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());

            Assert.AreEqual("This is a div", searchAssistant.GetAssistantBetween("<div>", "</div>").SearchText);
            Assert.AreEqual(string.Empty, searchAssistant.GetAssistantBetween("<table>", "</table>").SearchText);
        }
        [TestMethod]
        public void Search_GetAssistantBetween3()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());

            Assert.AreEqual("Test Document", searchAssistant.GetAssistantBetween("<title>", "</title>", 0).SearchText);
            Assert.AreEqual(string.Empty, searchAssistant.GetAssistantBetween("<title>", "</title>", 50).SearchText);
            KnightsTour.CoreLibrary.SearchAssistant subAssistant = searchAssistant.GetAssistantBetween("<head>", "</head>", 0);
            Assert.AreEqual("Test Document", subAssistant.GetStringBetween("<title>", "</title>"));
        }
        [TestMethod]
        public void Search_GetAssistantsBetween()
        {
            KnightsTour.CoreLibrary.SearchAssistant searchAssistant = new KnightsTour.CoreLibrary.SearchAssistant(GetHTMLPage());

            Assert.AreEqual(5, searchAssistant.GetAssistantsBetween("<p>", "</p>").Count);
            Assert.AreEqual(1, searchAssistant.GetAssistantsBetween("<div>", "</div>").Count);
            Assert.AreEqual(0, searchAssistant.GetAssistantsBetween("<table>", "</table>").Count);

            List<KnightsTour.CoreLibrary.SearchAssistant> subAssistants = searchAssistant.GetAssistantsBetween("<span>", "</span>");
            Assert.AreEqual(2, subAssistants.Count);
            foreach (KnightsTour.CoreLibrary.SearchAssistant subAssistant in subAssistants)
            {
                Assert.AreEqual(3, subAssistant.GetStringsBetween("<a", "</a>").Count);
                Assert.AreEqual(3, subAssistant.GetAssistantsBetween("<a", "</a>").Count);
            }
        }
        #endregion

        #region KnightsTour.CoreLibrary.ConfigurationAssistant Tests
        [TestMethod]
        public void Configuration_GetString()
        {
            string result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("appSettingString");
            Assert.AreEqual(result, "Test String");
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("appSettingInt");
            Assert.AreEqual(result, "123");
            string appSettingKey = "doesNotExist";
            string badConfig = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString(appSettingKey);
            Assert.IsNull(badConfig);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString(appSettingKey, "Your mom");
            Assert.AreEqual(result, "Your mom");
        }
        [TestMethod]
        public void Configuration_GetInt()
        {
            int result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt("appSettingInt");
            Assert.AreEqual(result, 123);
            var ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt("appSettingString"));
            Assert.AreEqual(ex.Message, $"Unable to parse Application Setting 'appSettingString' as integer.");
            ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt("appSettingDecimal"));
            Assert.AreEqual(ex.Message, $"Unable to parse Application Setting 'appSettingDecimal' as integer.");
            ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt("appSettingBooleanTrue1"));
            Assert.AreEqual(ex.Message, $"Unable to parse Application Setting 'appSettingBooleanTrue1' as integer.");
            string appSettingKey = "doesNotExist";
            ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt(appSettingKey));
            Assert.AreEqual(ex.Message, $"Missing expected integer Application Setting '{appSettingKey}' and no default value provided.");
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetInt(appSettingKey, 666);
            Assert.AreEqual(result, 666);
        }
        [TestMethod]
        public void Configuration_GetDecimal()
        {
            decimal result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetDecimal("appSettingDecimal");
            Assert.AreEqual(result, 123.456M);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetDecimal("appSettingInt");
            Assert.AreEqual(result, 123);
            var ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetDecimal("appSettingString"));
            Assert.AreEqual(ex.Message, $"Unable to parse Application Setting 'appSettingString' as decimal.");
            ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetDecimal("appSettingBooleanTrue1"));
            Assert.AreEqual(ex.Message, $"Unable to parse Application Setting 'appSettingBooleanTrue1' as decimal.");
            string appSettingKey = "doesNotExist";
            ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetDecimal(appSettingKey));
            Assert.AreEqual(ex.Message, $"Missing expected decimal Application Setting '{appSettingKey}' and no default value provided.");
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetDecimal(appSettingKey, 666.777M);
            Assert.AreEqual(result, 666.777M);
        }
        [TestMethod]
        public void Configuration_GetBoolean()
        {
            bool result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanTrue1");
            Assert.IsTrue(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanTrue2");
            Assert.IsTrue(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanTrue3");
            Assert.IsTrue(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanTrue4");
            Assert.IsTrue(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanFalse1");
            Assert.IsFalse(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanFalse2");
            Assert.IsFalse(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanFalse3");
            Assert.IsFalse(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingBooleanFalse4");
            Assert.IsFalse(result);

            //Anything that is not "true" should be returned as false.
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean("appSettingString");
            Assert.IsFalse(result);

            string appSettingKey = "doesNotExist";
            Exception ex = Assert.ThrowsException<Exception>(() => KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean(appSettingKey));
            Assert.AreEqual(ex.Message, $"Missing expected boolean Application Setting '{appSettingKey}' and no default value provided.");
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean(appSettingKey, true);
            Assert.IsTrue(result);
            result = KnightsTour.CoreLibrary.ConfigurationAssistant.GetBoolean(appSettingKey, false);
            Assert.IsFalse(result);
        }
        #endregion

        #region KnightsTour.CoreLibrary.XMLAssistant Tests
        [TestMethod]
        public void XML_IsSimpleType()
        {
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(int)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(string)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(DateTime)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(Guid)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(char)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(byte)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(bool)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(Single)));
            Assert.IsTrue(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(long)));

            Assert.IsFalse(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(DummyClass)));
            Assert.IsFalse(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(byte[])));
            Assert.IsFalse(KnightsTour.CoreLibrary.XMLAssistant.IsSimpleType(typeof(List<int>)));
        }
        [TestMethod]
        public void XML_Serialize()
        {
            string xmlString = KnightsTour.CoreLibrary.XMLAssistant.Serialize(GetNewEntity<DummyClass>());
            Assert.IsNotNull(xmlString);
            Assert.IsTrue(xmlString.Contains("</DummyClass>"));
            foreach (DummyClassProperties property in Enum.GetValues(typeof(DummyClassProperties)))
            {
                if (property != DummyClassProperties.All)
                {
                    Assert.IsTrue(xmlString.Contains(property.ToString()));
                }
            }
        }
        [TestMethod]
        public void XML_ToXML()
        {
            XmlDocument xml = KnightsTour.CoreLibrary.XMLAssistant.ToXML(GetNewEntity<DummyClass>());
            Assert.AreEqual(xml.ChildNodes.Count, 2);
            Assert.IsTrue(xml.ChildNodes[1].HasChildNodes);
        }
        [TestMethod]
        public void XML_Deserialize()
        {
            string xmlString = KnightsTour.CoreLibrary.XMLAssistant.Serialize(GetNewEntity<DummyClass>());

            DummyClass dummyClass = KnightsTour.CoreLibrary.XMLAssistant.Deserialize<DummyClass>(xmlString);
            Assert.IsNotNull(dummyClass);
            Assert.IsTrue(dummyClass.FK1 > 0);
            Assert.IsTrue(dummyClass.Amount > 0);
            Assert.IsTrue(dummyClass.Description.Length > 0);
        }
        #endregion

        #region ExpandObjectAssistant Tests
        [TestMethod]
        public void ExpandObject_Serialize()
        {
            ExpandoObject eo = KnightsTour.CoreLibrary.ExpandoObjectAssistant.Serialize<DummyClass>(GetNewEntity<DummyClass>());
            Assert.IsNotNull(eo);
            IDictionary<string, object> eoDict = (IDictionary<string, object>)eo;
            foreach (DummyClassProperties property in Enum.GetValues(typeof(DummyClassProperties)))
            {
                if (property != DummyClassProperties.All)
                {
                    Assert.IsTrue(eoDict.ContainsKey(property.ToString()));
                }
            }
        }
        [TestMethod]
        public void ExpandObject_Deserialize()
        {
            dynamic dynamicDummyClass = new ExpandoObject();
            dynamicDummyClass.PK = 1;
            dynamicDummyClass.FK1 = 2;
            dynamicDummyClass.FK2 = 3;
            dynamicDummyClass.Amount = 4.5M;
            dynamicDummyClass.NullableDateTime = null;
            dynamicDummyClass.SomeFlag = true;
            dynamicDummyClass.Description = "Some description";
            dynamicDummyClass.CreateDate = new DateTime(2019, 1, 1);

            DummyClass dummyClass = KnightsTour.CoreLibrary.ExpandoObjectAssistant.Deserialize<DummyClass>(dynamicDummyClass);
            Assert.IsNotNull(dummyClass);
            Assert.AreEqual(dummyClass.PK, 1);
            Assert.AreEqual(dummyClass.FK1, 2);
            Assert.AreEqual(dummyClass.FK2, 3);
            Assert.AreEqual(dummyClass.Amount, 4.5M);
            Assert.AreEqual(dummyClass.NullableDateTime, null);
            Assert.AreEqual(dummyClass.SomeFlag, true);
            Assert.AreEqual(dummyClass.Description, "Some description");
            Assert.AreEqual(dummyClass.CreateDate, new DateTime(2019, 1, 1));
        }
        #endregion

        #region KnightsTour.CoreLibrary.TextAssistant Tests
        [TestMethod]
        public void Text_BeginsWithAVowel()
        {
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("elephant"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Ant"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Elephant"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Iguana"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Octopus"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Unicorn"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Yak"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("cat"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel("Cat"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel(""));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.BeginsWithAVowel(null));
        }
        [TestMethod]
        public void Text_SplitOnCapitals()
        {
            Assert.AreEqual("This Is Pascal Case", KnightsTour.CoreLibrary.TextAssistant.SplitOnCapitals("ThisIsPascalCase"));
            Assert.AreEqual("this Is Camel Case", KnightsTour.CoreLibrary.TextAssistant.SplitOnCapitals("thisIsCamelCase"));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.SplitOnCapitals("Cat"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.SplitOnCapitals("cat"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.SplitOnCapitals(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.SplitOnCapitals(null));
        }
        [TestMethod]
        public void Text_SplitOnUnderscore()
        {
            Assert.AreEqual("This Is Pascal Case", KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore("This_Is_Pascal_Case"));
            Assert.AreEqual("this Is Camel Case", KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore("this_Is_Camel_Case"));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore("Cat"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore("cat"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore("_cat"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore("_cat_"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.SplitOnUnderscore(null));
        }
        [TestMethod]
        public void Text_IsCapitalized()
        {
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsCapitalized("elephant"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsCapitalized("Elephant"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsCapitalized("1"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsCapitalized("_"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsCapitalized(""));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsCapitalized(null));
        }
        [TestMethod]
        public void Text_CapitalizeFirstLetter()
        {
            Assert.AreEqual("ThisIsPascalCase", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("ThisIsPascalCase"));
            Assert.AreEqual("ThisIsCamelCase", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("thisIsCamelCase"));
            Assert.AreEqual("Thisispascalcase", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("ThisIsPascalCase", true));
            Assert.AreEqual("Thisiscamelcase", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("thisIsCamelCase", true));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("Cat"));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("cat"));
            Assert.AreEqual("A", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("a"));
            Assert.AreEqual("A", KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter("A"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.CapitalizeFirstLetter(null));
        }
        [TestMethod]
        public void Text_CapitalizeEachWord()
        {
            Assert.AreEqual("This Is A Sentence.", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("this is a sentence."));
            Assert.AreEqual("This Is A Sentence.", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("  this is a sentence.  "));
            Assert.AreEqual("This Is A Sentence.", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("this_is_a_sentence."));
            Assert.AreEqual("This Is A Sentence.", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("this is a Sentence."));
            Assert.AreEqual("This Is A Sentence.", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("this_is_a_Sentence."));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("Cat"));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord("cat"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.CapitalizeEachWord(null));
        }
        [TestMethod]
        public void Text_DecapitalizeFirstLetter()
        {
            Assert.AreEqual("thisIsPascalCase", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("ThisIsPascalCase"));
            Assert.AreEqual("thisIsCamelCase", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("thisIsCamelCase"));
            Assert.AreEqual("thisispascalcase", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("ThisIsPascalCase", true));
            Assert.AreEqual("thisiscamelcase", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("thisIsCamelCase", true));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("Cat"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("cat"));
            Assert.AreEqual("a", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("A"));
            Assert.AreEqual("a", KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter("a"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.DecapitalizeFirstLetter(null));
        }
        [TestMethod]
        public void Text_PluralizeWord()
        {
            Assert.AreEqual("Bass", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("Bass"));
            Assert.AreEqual("Cats", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("Cat"));
            Assert.AreEqual("CATs", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("CAT"));
            Assert.AreEqual("COOKIES", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("COOKIES"));
            Assert.AreEqual("Flies", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("Fly"));
            Assert.AreEqual("Cookies", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("Cookie"));
            Assert.AreEqual("Walruses", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("Walrus"));
            Assert.AreEqual("Cookies", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("Cookies"));
            Assert.AreEqual("1s", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("1"));
            Assert.AreEqual("_s", KnightsTour.CoreLibrary.TextAssistant.PluralizeWord("_"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.PluralizeWord(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.PluralizeWord(null));
        }
        [TestMethod]
        public void Text_PastTenseWord()
        {
            Assert.AreEqual("Snaked", KnightsTour.CoreLibrary.TextAssistant.PastTenseWord("Snake"));
            Assert.AreEqual("SNAKEd", KnightsTour.CoreLibrary.TextAssistant.PastTenseWord("SNAKE"));
            Assert.AreEqual("Flied", KnightsTour.CoreLibrary.TextAssistant.PastTenseWord("Fly"));
            Assert.AreEqual("My", KnightsTour.CoreLibrary.TextAssistant.PastTenseWord("My"));
            Assert.AreEqual("1", KnightsTour.CoreLibrary.TextAssistant.PastTenseWord("1"));
            Assert.AreEqual("_", KnightsTour.CoreLibrary.TextAssistant.PastTenseWord("_"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.PastTenseWord(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.PastTenseWord(null));
        }
        [TestMethod]
        public void Text_IsAlpha()
        {
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("elephant"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("ELEPHANT"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("THIS IS A PHRASE"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("THIS IS A PHRASE", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("I am 44 years old"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlpha(" Lots    of     spaces"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("Tab\tseperator"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("Tab\tseperator", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("1"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha("_"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha(""));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlpha(null));
        }
        [TestMethod]
        public void Text_IsNumeric()
        {
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("1"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("0"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("1.2"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("123.456"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsNumeric(".1"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("1,123.22"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("$123.22"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("a"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("A"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("123A"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("a123"));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("123e10"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("8", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric("1.2", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric(".2", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric(""));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsNumeric(null));
        }
        [TestMethod]
        public void Text_ReturnOnlyNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i.ToString(), KnightsTour.CoreLibrary.TextAssistant.ReturnOnlyNumbers(i.ToString()));
                Assert.AreEqual(i.ToString(), KnightsTour.CoreLibrary.TextAssistant.ReturnOnlyNumbers($"{i.ToString()} dollars"));
                Assert.AreEqual(i.ToString(), KnightsTour.CoreLibrary.TextAssistant.ReturnOnlyNumbers($"I own {i.ToString()} dollars"));
            }
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.ReturnOnlyNumbers("Chris"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.ReturnOnlyNumbers(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.ReturnOnlyNumbers(null));
        }
        [TestMethod]
        public void Text_IsAlphaNumeric()
        {
            //Allow white space and decimals
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123abc"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123 456"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456 abc"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc def"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc\tdef"));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123\t.456"));

            //No white space allowed
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123", false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc", false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123abc", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123 456", false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456 abc", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc def", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc\tdef", false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123\t.456", false));

            //Allow white space but no decimals
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123", true, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc", true, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123abc", true, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123 456", true, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456", true, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456 abc", true, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc def", true, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc\tdef", true, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123\t.456", true, false));

            //Allow no white space and no decimals
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123", false, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc", false, false));
            Assert.IsTrue(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123abc", false, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123 456", false, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456", false, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123.456 abc", false, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc def", false, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("abc\tdef", false, false));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric("123\t.456", false, false));

            //other edge tests
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric(""));
            Assert.IsFalse(KnightsTour.CoreLibrary.TextAssistant.IsAlphaNumeric(null));
        }
        [TestMethod]
        public void Text_DePluralizeWord()
        {
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("Cat"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("cat"));
            Assert.AreEqual("Cat", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("Cats"));
            Assert.AreEqual("cat", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("cats"));
            Assert.AreEqual("bunny", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("bunnies"));
            Assert.AreEqual("status", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("statuses"));
            Assert.AreEqual("dexterous", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("dexterous"));
            Assert.AreEqual("status", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("status"));
            Assert.AreEqual("bass", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("bass"));
            Assert.AreEqual("cannabis", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("cannabis"));
            Assert.AreEqual("basis", KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord("basis"));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord(""));
            Assert.AreEqual(string.Empty, KnightsTour.CoreLibrary.TextAssistant.DePluralizeWord(null));
        }
        #endregion

        #region Private Support methods
        #endregion
    }
}