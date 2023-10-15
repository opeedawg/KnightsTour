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
// File             : OracleTestSupport.cs
// ************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KnightsTour;

namespace KnightsTourUnitTests
{
    public abstract class OracleTestSupport : DataTestBase<int?>
{
        #region Initialization and Cleanup routines
        [TestInitialize]
        public void TestInit()
        {
            //Make sure the app config is configured.
            string storageHandlerType = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerType", null);
            if (storageHandlerType != KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle.ToString())
                Assert.Inconclusive($"Test not run.  StorageHandlerType configured to '{StorageProvider.StorageHandlerType}'");
        }
        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            //Make sure the app config is configured.
            string storageHandlerType = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerType", null);
            if (storageHandlerType != KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.Oracle.ToString())
                Assert.Inconclusive($"Test not run.  StorageHandlerType configured to '{StorageProvider.StorageHandlerType}'");

            string storageHandlerInitialization = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerInitialization", null);

            //Test the connection
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            handler.GetValue<decimal>(new KnightsTour.CoreLibrary.StorageStatement { Statement = "SELECT 1 FROM DUAL" });

            //If no exceptions have been raised by this time then go ahead and verify the temp tables exist.

            DropTestTables();

            //Create the test tables
            CreateTestTables();

            EntityAttributesCache = new Dictionary<string, KnightsTour.CoreLibrary.EntityAttribute<int?>>();
        }

        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            DropTestTables();
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        protected static bool SequenceExists(string sequenceName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            try
            {
                return handler.GetValue<decimal>(new KnightsTour.CoreLibrary.StorageStatement() { Statement = $"SELECT COUNT(0) FROM USER_SEQUENCES WHERE SEQUENCE_NAME = '{sequenceName}'" }) > 0;
            }
            catch
            {
            }
            return false;
        }
        protected static bool TriggerExists(string triggerName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            try
            {
                return handler.GetValue<decimal>(new KnightsTour.CoreLibrary.StorageStatement() { Statement = $"SELECT COUNT(0) FROM USER_TRIGGERS WHERE TRIGGER_NAME = '{triggerName}'" }) > 0;
            }
            catch
            {
            }
            return false;
        }
        protected static bool TableExists(string tableName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            try
            {
                return handler.GetValue<decimal>(new KnightsTour.CoreLibrary.StorageStatement() { Statement = $"select count(*) from user_tables where table_name = '{tableName}'" }) > 0;
            }
            catch
            {
                try
                {
                    return handler.GetValue<decimal>(new KnightsTour.CoreLibrary.StorageStatement() { Statement = $"select 1 from {StorageProvider.GetTableSQL(tableName)} where 1 = 0" }) == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
        protected static void DropTrigger(string triggerName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = $"DROP TRIGGER {StorageProvider.GetTableSQL(triggerName)}" });
        }
        protected static void DropSequence(string sequenceName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = $"DROP SEQUENCE {StorageProvider.GetTableSQL(sequenceName)}" });
        }
        protected static void DropTable(string tableName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = $"DROP TABLE {StorageProvider.GetTableSQL(tableName)}" });
        }
        protected static void DropTestTables()
        {
            //Drop triggers if they exist
            if (TriggerExists("TestTable1_SEQ_TR")) DropTrigger("TestTable1_SEQ_TR");
            if (TriggerExists("TestTable2_SEQ_TR")) DropTrigger("TestTable2_SEQ_TR");

            //DROP Sequences if they exist
            if (SequenceExists("TestTable1_SEQ")) DropSequence("TestTable1_SEQ");
            if (SequenceExists("TestTable2_SEQ")) DropSequence("TestTable2_SEQ");

            //Drop the test tables if they exist
            if (TableExists("TestTable1")) DropTable("TestTable1");
            if (TableExists("TestTable2")) DropTable("TestTable2");
        }
        protected static void CreateTestTables()
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            //Table 1
            string sql = "CREATE TABLE \"TestTable1\"( ";
            sql += "\"TestTable1Id\" numeric(10) NOT NULL, ";
            sql += "\"Name\" varchar2(1000) NOT NULL, ";
            sql += "\"TestTable2Id\" numeric(10) NOT NULL, ";
            sql += "\"CreateDate\" DATE NOT NULL, ";
            sql += "CONSTRAINT TestTable1Id_pk PRIMARY KEY (\"TestTable1Id\")";
            sql += ")";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            //Table 1 trigger
            sql = "create or replace TRIGGER \"TestTable1_SEQ_TR\" BEFORE INSERT ON \"TestTable1\" FOR EACH ROW WHEN(NEW.\"TestTable1Id\" IS NULL) BEGIN SELECT \"TestTable1_SEQ\".NEXTVAL INTO :NEW.\"TestTable1Id\" FROM DUAL; END;";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            //Table 2
            sql = "CREATE TABLE \"TestTable2\"( ";
            sql += "\"TestTable2Id\" numeric(10) NOT NULL, ";
            sql += "\"Name\" varchar2(1000) NOT NULL, ";
            sql += "\"CreateDate\" DATE NOT NULL, ";
            sql += "CONSTRAINT TestTable2Id_pk PRIMARY KEY (\"TestTable2Id\")";
            sql += ")";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            //Table 2 trigger
            sql = "create or replace TRIGGER \"TestTable2_SEQ_TR\" BEFORE INSERT ON \"TestTable2\" FOR EACH ROW WHEN(NEW.\"TestTable2Id\" IS NULL) BEGIN SELECT \"TestTable2_SEQ\".NEXTVAL INTO :NEW.\"TestTable2Id\" FROM DUAL; END;";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            //Constraints
            //alter table foo modify(col2 varchar2(10) default 'foo');
            sql = "ALTER TABLE \"TestTable1\" MODIFY (\"CreateDate\" DATE DEFAULT CURRENT_TIMESTAMP)";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            sql = "ALTER TABLE \"TestTable2\" MODIFY (\"CreateDate\" DATE DEFAULT CURRENT_TIMESTAMP)";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            sql = "ALTER TABLE \"TestTable1\" ADD FOREIGN KEY(\"TestTable2Id\") REFERENCES \"TestTable2\"(\"TestTable2Id\")";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            ResetTestTableData();
        }
        protected static void ResetTestTableData()
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            //Delete the existing test table 1 data
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = "DELETE FROM \"TestTable1\"" };
            handler.Execute(statement);
            //Reset the seed
            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = "TRUNCATE TABLE \"TestTable1\"" };
            handler.Execute(statement);
            //Delete the existing test table 2 data
            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = "DELETE FROM \"TestTable2\"" };
            handler.Execute(statement);

            //Drop sequences
            if (SequenceExists("TestTable1_SEQ")) DropSequence("TestTable1_SEQ");
            if (EntityMapper.SequenceMapper.ContainsKey("TestTable1")) EntityMapper.SequenceMapper.Values.Remove("TestTable1");
            if (SequenceExists("TestTable2_SEQ")) DropSequence("TestTable2_SEQ");
            if (EntityMapper.SequenceMapper.ContainsKey("TestTable2")) EntityMapper.SequenceMapper.Values.Remove("TestTable2");

            //Table 1 sequence
            string sql = "CREATE SEQUENCE \"TestTable1_SEQ\" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            EntityMapper.SequenceMapper.GetOrAdd("TestTable1", "TestTable1_SEQ");

            //Table 2 sequence
            sql = "CREATE SEQUENCE \"TestTable2_SEQ\" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            EntityMapper.SequenceMapper.GetOrAdd("TestTable2", "TestTable2_SEQ");

            //Insert new data
            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = "INSERT INTO \"TestTable2\" (\"Name\", \"TestTable2Id\") SELECT 'Red', 1 FROM DUAL UNION ALL SELECT 'Blue', 2 FROM DUAL UNION ALL SELECT 'Green', 3 FROM DUAL UNION ALL SELECT 'Orange', 4 FROM DUAL" };
            handler.Execute(statement);

            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = "INSERT INTO \"TestTable1\" (\"Name\", \"TestTable2Id\") SELECT 'Car', 1 FROM DUAL UNION ALL SELECT 'Car', 2 FROM DUAL UNION ALL SELECT 'Bike', 1 FROM DUAL UNION ALL SELECT 'Bike', 2 FROM DUAL UNION ALL SELECT 'Bike', 3 FROM DUAL UNION ALL SELECT 'Plane 1', 2 FROM DUAL UNION ALL SELECT 'Plane 2', 4 FROM DUAL UNION ALL SELECT 'Shirt 1', 1 FROM DUAL UNION ALL SELECT 'Shirt 2', 1 FROM DUAL UNION ALL SELECT 'Shirt 3', 3 FROM DUAL UNION ALL SELECT 'Shirt 4', 2 FROM DUAL" };
            handler.Execute(statement);
        }
        #endregion

        #region Support methods
        protected int? InsertTest1()
        {
            return InsertTest("Hair 1", 1);
        }
        protected int? InsertTest2()
        {
            return InsertTest("Hair 2", 3);
        }
        protected int? InsertTest(string name, int fkId)
        {
            TestTable1 testTable = new TestTable1 { Name = name, TestTable2Id = fkId, PKInsertConfiguration = KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Sequence };

            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            return handler.AddRecord<int?>(testTable);
        }
        #endregion
    }
}