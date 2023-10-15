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
// File             : ExtensionTestsBase.cs
// ************************************************************************

using System;
using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Dynamic;
using System.Data;

namespace KnightsTourUnitTests
{
    [TestClass]
    public class ExtensionTestsBase : DataTestBase<int?>
{
        [TestMethod]
        public void ColumnExists_IDataRecord()
        {
            using (IDataReader reader = new ListDataReader<DummyClass>(CreateEntities<DummyClass>(1)))
            {
                Assert.IsTrue(reader.ColumnExists("PK"));
                Assert.IsTrue(reader.ColumnExists("pk"));
                Assert.IsFalse(reader.ColumnExists("pk", false));

                Assert.IsTrue(reader.ColumnExists("Description"));
                Assert.IsTrue(reader.ColumnExists("description"));
                Assert.IsFalse(reader.ColumnExists("description", false));

                Assert.IsTrue(reader.ColumnExists("Amount"));
                Assert.IsTrue(reader.ColumnExists("amount"));
                Assert.IsFalse(reader.ColumnExists("amount", false));

                Assert.IsFalse(reader.ColumnExists("bad column"));
                Assert.IsFalse(reader.ColumnExists(null));
            }
        }
        [TestMethod]
        public void ColumnExists_IDataRow()
        {
            DataTable dt = CreateDataTable<DummyClass>(CreateEntities<DummyClass>(1));
            Assert.IsNotNull(dt);
            Assert.IsNotNull(dt.Rows);
            Assert.IsTrue(dt.Rows.Count > 0);

            DataRow dataRow = dt.Rows[0];

            Assert.IsTrue(dataRow.ColumnExists("PK"));
            Assert.IsTrue(dataRow.ColumnExists("pk"));
            Assert.IsFalse(dataRow.ColumnExists("pk", false));

            Assert.IsTrue(dataRow.ColumnExists("Description"));
            Assert.IsTrue(dataRow.ColumnExists("description"));
            Assert.IsFalse(dataRow.ColumnExists("description", false));

            Assert.IsTrue(dataRow.ColumnExists("Amount"));
            Assert.IsTrue(dataRow.ColumnExists("amount"));
            Assert.IsFalse(dataRow.ColumnExists("amount", false));

            Assert.IsFalse(dataRow.ColumnExists("bad column"));
            Assert.IsFalse(dataRow.ColumnExists(null));
        }
        [TestMethod]
        public void ColumnExists_Dynamic()
        {
            ExpandoObject expandoObject = KnightsTour.CoreLibrary.ExpandoObjectAssistant.Serialize<DummyClass>(GetNewEntity<DummyClass>());
            Assert.IsNotNull(expandoObject);

            Assert.IsTrue(expandoObject.ColumnExists("PK"));
            Assert.IsTrue(expandoObject.ColumnExists("pk"));
            Assert.IsFalse(expandoObject.ColumnExists("pk", false));

            Assert.IsTrue(expandoObject.ColumnExists("Description"));
            Assert.IsTrue(expandoObject.ColumnExists("description"));
            Assert.IsFalse(expandoObject.ColumnExists("description", false));

            Assert.IsTrue(expandoObject.ColumnExists("Amount"));
            Assert.IsTrue(expandoObject.ColumnExists("amount"));
            Assert.IsFalse(expandoObject.ColumnExists("amount", false));

            Assert.IsFalse(expandoObject.ColumnExists("bad column"));
            Assert.IsFalse(expandoObject.ColumnExists(null));
        }
        [TestMethod]
        public void ValueAs_IDataRecord()
        {
            using (IDataReader reader = new ListDataReader<DummyClass>(CreateEntities<DummyClass>(1)))
            {
                reader.Read();
                string description = reader.ValueAs<string>("Description");
                Assert.IsTrue(!string.IsNullOrEmpty(description));

                int? fk1 = reader.ValueAs<int?>("FK1");
                Assert.IsTrue(fk1.HasValue);
                Assert.IsTrue(fk1 >= 0);

                DateTime createDate = reader.ValueAs<DateTime>("CreateDate");
                Assert.IsNotNull(createDate);

                DateTime? nullableDate = reader.ValueAs<DateTime?>("NullableDateTime");
                Assert.IsNull(nullableDate);

                decimal amount = reader.ValueAs<decimal>("Amount");
                Assert.IsTrue(amount > 0);

                bool someFlag = reader.ValueAs<bool>("SomeFlag");
                Assert.IsNotNull(someFlag);
            }
        }
        [TestMethod]
        public void ValueAs_DataRow()
        {
            DataTable dt = CreateDataTable<DummyClass>(CreateEntities<DummyClass>(1));
            Assert.IsNotNull(dt);
            Assert.IsNotNull(dt.Rows);
            Assert.IsTrue(dt.Rows.Count > 0);

            DataRow dataRow = dt.Rows[0];

            string description = dataRow.ValueAs<string>("Description");
            Assert.IsTrue(!string.IsNullOrEmpty(description));

            int? fk1 = dataRow.ValueAs<int?>("FK1");
            Assert.IsTrue(fk1.HasValue);
            Assert.IsTrue(fk1 >= 0);

            DateTime createDate = dataRow.ValueAs<DateTime>("CreateDate");
            Assert.IsNotNull(createDate);

            DateTime? nullableDate = dataRow.ValueAs<DateTime?>("NullableDateTime");
            Assert.IsNull(nullableDate);

            decimal amount = dataRow.ValueAs<decimal>("Amount");
            Assert.IsTrue(amount > 0);

            bool someFlag = dataRow.ValueAs<bool>("SomeFlag");
            Assert.IsNotNull(someFlag);
        }
        [TestMethod]
        public void ValueAs_Dynamic()
        {
            ExpandoObject expandoObject = KnightsTour.CoreLibrary.ExpandoObjectAssistant.Serialize<DummyClass>(GetNewEntity<DummyClass>());
            Assert.IsNotNull(expandoObject);

            string description = expandoObject.ValueAs<string>("Description");
            Assert.IsTrue(!string.IsNullOrEmpty(description));

            int? fk1 = expandoObject.ValueAs<int?>("FK1");
            Assert.IsTrue(fk1.HasValue);
            Assert.IsTrue(fk1 >= 0);

            DateTime createDate = expandoObject.ValueAs<DateTime>("CreateDate");
            Assert.IsNotNull(createDate);

            DateTime? nullableDate = expandoObject.ValueAs<DateTime?>("NullableDateTime");
            Assert.IsNull(nullableDate);

            decimal amount = expandoObject.ValueAs<decimal>("Amount");
            Assert.IsTrue(amount > 0);

            bool someFlag = expandoObject.ValueAs<bool>("SomeFlag");
            Assert.IsNotNull(someFlag);
        }
        [TestMethod]
        public void SaveSQL_String()
        {
            string testInput = "Simple Test";
            Assert.AreEqual($"'{testInput}'", testInput.SafeSQL());

            testInput = "I haven't escaped my single quote!";
            Assert.AreEqual($"'{testInput.Replace("'", "''")}'", testInput.SafeSQL());

            testInput = null;
            Assert.AreEqual("NULL", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_DateTime()
        {
            DateTime testInput = new DateTime(2019, 12, 31);
            Assert.AreEqual($"'{testInput.ToString("yyyy-MM-dd HH:mm:ss")}'", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_DateTimeNullable()
        {
            DateTime? testInput = new DateTime(2019, 12, 31);
            Assert.AreEqual($"'{testInput.Value.ToString("yyyy-MM-dd HH:mm:ss")}'", testInput.SafeSQL());

            testInput = null;
            Assert.AreEqual("NULL", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_Boolean()
        {
            bool testInput = true;
            Assert.AreEqual("1", testInput.SafeSQL());
            testInput = false;
            Assert.AreEqual("0", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_BooleanNullable()
        {
            bool? testInput = true;
            Assert.AreEqual("1", testInput.SafeSQL());
            testInput = false;
            Assert.AreEqual("0", testInput.SafeSQL());
            testInput = null;
            Assert.AreEqual("NULL", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_Decimal()
        {
            decimal testInput = 123.45M;
            Assert.AreEqual(testInput.ToString(), testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_DecimalNullable()
        {
            decimal? testInput = 123.45M;
            Assert.AreEqual(testInput.Value.ToString(), testInput.SafeSQL());
            testInput = null;
            Assert.AreEqual("NULL", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_Int()
        {
            int testInput = 123;
            Assert.AreEqual(testInput.ToString(), testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_IntNullable()
        {
            int? testInput = 123;
            Assert.AreEqual(testInput.Value.ToString(), testInput.SafeSQL());
            testInput = null;
            Assert.AreEqual("NULL", testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_Long()
        {
            long testInput = long.MaxValue;
            Assert.AreEqual(testInput.ToString(), testInput.SafeSQL());
        }
        [TestMethod]
        public void SaveSQL_LongNullable()
        {
            long? testInput = long.MaxValue;
            Assert.AreEqual(testInput.Value.ToString(), testInput.SafeSQL());
            testInput = null;
            Assert.AreEqual("NULL", testInput.SafeSQL());
        }
        [TestMethod]
        public void ToSQLList()
        {
            List<int> testInput = new List<int>() { 1, 2, 3 };
            Assert.AreEqual("(1,2,3)", testInput.ToSQLList());
        }
        [TestMethod]
        public void IsSameType()
        {
            int? nullableInt1 = 0;
            int? nullableInt2 = null;
            int nonNullableInt1 = 0;
            int nonNullableInt2 = 0;
            string string1 = "";
            string string2 = null;
            Assert.IsTrue(nonNullableInt1.IsSameType(nonNullableInt2));
            Assert.IsTrue(nullableInt1.IsSameType(nonNullableInt1));
            Assert.IsFalse(string1.IsSameType(nonNullableInt1));
            Assert.IsFalse(string1.IsSameType(nullableInt1));
            Assert.IsTrue(string1.IsSameType(string2));
            Assert.IsTrue(nullableInt1.IsSameType(nullableInt2));
        }
    }
}