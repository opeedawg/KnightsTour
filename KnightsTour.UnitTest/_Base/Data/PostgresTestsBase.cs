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
// File             : PostgresTestsBase.cs
// ************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using KnightsTour;

namespace KnightsTourUnitTests.Data
{
    [TestClass]
    public class PostgresTestsBase : PostgresTestSupport
    {
        #region Initialization and Cleanup routines
        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [ClassInitialize]
        public static new void ClassInit(TestContext context)
        {
            PostgresTestSupport.ClassInit(context);
        }
        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [ClassCleanup]
        public static new void ClassCleanup()
        {
            PostgresTestSupport.ClassCleanup();
        }
        #endregion

        #region Handler Tests
        [TestMethod]
        public void Handler_Initialize()
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);
            Assert.AreEqual(500, handler.InsertBlockSize);
            Assert.AreEqual(500, handler.DeleteBlockSize);
            Assert.AreEqual(KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerInitialization", null), handler.ConnectionInformation);
        }
        [TestMethod]
        public void Handler_GetRecords()
        {
            ResetTestTableData();

            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);
            int recordCount = 0;
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);
                recordCount++;
            }
            Assert.IsTrue(recordCount > 0);
        }
        [TestMethod]
        public void Handler_RetrievalCondition_Where()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);

            #region All records
            int totalRecords = 0;
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);
                totalRecords++;
            }
            Assert.IsTrue(totalRecords > 0);
            #endregion

            #region With a where filter
            int filteredRecords = 0;
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLWhere = "\"TestTable2Id\" = @fk" },
                Parameter = new KnightsTour.CoreLibrary.GenericParameter("@fk", 1)
            };
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);
                filteredRecords++;
            }
            Assert.IsTrue(filteredRecords > 0);
            Assert.IsTrue(filteredRecords < totalRecords);
            #endregion
        }
        [TestMethod]
        public void Handler_RetrievalCondition_Order_DESC()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);

            #region With an ORDER BY DESC clause
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLOrderBy = "\"TestTable2Id\" DESC" }
            };
            int lastFKId = int.MaxValue;
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);
                int newFKId = record.ValueAs<int>("TestTable2Id");
                Assert.IsTrue(newFKId <= lastFKId);
                lastFKId = newFKId;
            }
            #endregion
        }
        [TestMethod]
        public void Handler_RetrievalCondition_Order_ASC()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);

            #region With an ORDER BY ASC clause
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLOrderBy = "\"TestTable2Id\" ASC" }
            };
            int lastFKId = 0;
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);
                int newFKId = record.ValueAs<int>("TestTable2Id");
                Assert.IsTrue(newFKId >= lastFKId);
                lastFKId = newFKId;
            }
            #endregion
        }
        [TestMethod]
        public void Handler_RetrievalCondition_GroupBy()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);

            #region With a GROUP BY clause
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FKCount, b.\"Name\" FROM {StorageProvider.GetTableSQL("TestTable1")} a INNER JOIN {StorageProvider.GetTableSQL("TestTable2")} b ON a.\"TestTable2Id\" = b.\"TestTable2Id\"",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLGroupBy = "b.\"Name\"" }
            };
            long recordCount = 0;
            List<string> fkNames = new List<string>();
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);

                //Validate the group by Name worked by creating and checking against a unique list.
                string bankName = record.ValueAs<string>("Name");
                Assert.IsFalse(fkNames.Contains(bankName));
                fkNames.Add(bankName);
                recordCount++;
            }
            Assert.AreEqual(recordCount, fkNames.Count);
            Assert.IsTrue(recordCount > 0);
            #endregion
        }
        [TestMethod]
        public void Handler_RetrievalCondition_Having()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);

            #region With a HAVING clause
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FKCount, b.\"Name\" FROM {StorageProvider.GetTableSQL("TestTable1")} a INNER JOIN {StorageProvider.GetTableSQL("TestTable2")} b ON a.\"TestTable2Id\" = b.\"TestTable2Id\"",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition
                {
                    SQLGroupBy = "b.\"Name\"",
                    SQLHaving = "Count(0) < 3"
                }
            };
            foreach (IDataRecord record in handler.GetRecords(statement))
            {
                Assert.IsTrue(record.FieldCount > 0);
                Assert.IsTrue(record.ValueAs<int>("FKCount") < 3);
            }
            #endregion
        }
        [TestMethod]
        public void Handler_GetRecord()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLWhere = "\"TestTable1Id\" = @id" },
                Parameter = new KnightsTour.CoreLibrary.GenericParameter("@id", 4)
            };
            DataRow record = handler.GetRecord(statement);
            Assert.IsNotNull(record);
            Assert.AreEqual(record.ValueAs<int>("TestTable1Id"), 4);
        }
        [TestMethod]
        public void Handler_GetDataSet()
        {
            ResetTestTableData();
            PostgreSQLStorageHandler handler = (PostgreSQLStorageHandler)StorageProvider.GetHandler();

            Assert.IsNotNull(handler);
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT * FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            DataSet dataSet = handler.GetDataSet(statement);
            Assert.IsNotNull(dataSet);
            Assert.IsTrue(dataSet.Tables.Count > 0);
            Assert.IsTrue(dataSet.Tables[0].Rows.Count > 0);
        }
        [TestMethod]
        public void Handler_GetValue()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            long recordCount = handler.GetValue<long>(statement);
            Assert.IsTrue(recordCount > 0);
        }
        [TestMethod]
        public void Handler_AddRecord()
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            Assert.IsNotNull(handler);
            int? newId1 = InsertTest1();
            Assert.IsTrue(newId1 > 0);

            int? newId2 = InsertTest2();
            Assert.IsTrue(newId2 > 0);

            Assert.IsTrue(newId2 > newId1);
        }
        [TestMethod]
        public void Handler_Execute_Delete()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            Assert.IsNotNull(handler);

            #region Verify that some records exist in the Island table
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            long recordCount = handler.GetValue<long>(statement);
            Assert.IsTrue(recordCount > 0);
            #endregion

            //Delete all the records
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"DELETE FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            long modifiedCount = handler.Execute(statement);

            Assert.IsTrue(modifiedCount > 0);
            Assert.AreEqual(modifiedCount, recordCount);
        }
        [TestMethod]
        public void Handler_Execute_Update()
        {
            ResetTestTableData();
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            Assert.IsNotNull(handler);

            #region Verify that some records exist in the Island table
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT COUNT(0) FROM {StorageProvider.GetTableSQL("TestTable1")}"
            };
            long recordCount = handler.GetValue<long>(statement);
            Assert.IsTrue(recordCount > 0);
            #endregion

            #region Grab the first record
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT  \"TestTable1Id\", \"Name\" FROM {StorageProvider.GetTableSQL("TestTable1")} ORDER BY \"TestTable1Id\" DESC  LIMIT 1"
            };
            DataRow row = handler.GetRecord(statement);
            int id = row.ValueAs<int>("TestTable1Id");
            string originalName = row.ValueAs<string>("Name");
            #endregion

            #region Update the record with a new name
            string newName = originalName + " modified";
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"UPDATE {StorageProvider.GetTableSQL("TestTable1")} SET {StorageProvider.GetColumnSQL("Name")} = @name",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLWhere = $"{StorageProvider.GetColumnSQL("TestTable1Id")} = @id" },
                Parameters = new List<KnightsTour.CoreLibrary.IParameter> {
                    new KnightsTour.CoreLibrary.GenericParameter("@name", newName),
                    new KnightsTour.CoreLibrary.GenericParameter("@id", id)
                }
            };
            //Actually do the update
            handler.Execute(statement);
            #endregion

            #region Verify the record has been updated.
            statement = new KnightsTour.CoreLibrary.StorageStatement
            {
                Statement = $"SELECT \"Name\" FROM {StorageProvider.GetTableSQL("TestTable1")}",
                Condition = new KnightsTour.CoreLibrary.RetrievalCondition { SQLWhere = $"{StorageProvider.GetColumnSQL("TestTable1Id")} = @id" },
                Parameter = new KnightsTour.CoreLibrary.GenericParameter("@id", id)
            };
            row = handler.GetRecord(statement);
            Assert.AreNotEqual(originalName, newName);
            Assert.AreEqual(newName, row.ValueAs<string>("Name").Trim());
            #endregion
        }
        #endregion
    }
}