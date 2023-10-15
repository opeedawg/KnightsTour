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
// File             : SQLServerTestSupport.cs
// ************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KnightsTour;
using System;

namespace KnightsTourUnitTests
{
    public abstract class SQLServerTestSupport : DataTestBase<int?>
{
        #region Initialization and Cleanup routines
        [TestInitialize]
        public void TestInit()
        {
            //Make sure the app config is configured.
            string storageHandlerType = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerType", null);
            if (storageHandlerType != KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer.ToString())
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
            if (storageHandlerType != KnightsTour.CoreLibrary.Enumerations.StorageHandlerType.SQLServer.ToString())
                Assert.Inconclusive($"Test not run.  StorageHandlerType configured to '{StorageProvider.StorageHandlerType}'");

            string storageHandlerInitialization = KnightsTour.CoreLibrary.ConfigurationAssistant.GetString("StorageHandlerInitialization", null);

            //Test the connection
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            handler.GetValue<int>(new KnightsTour.CoreLibrary.StorageStatement { Statement = "SELECT 1" });

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
        protected static bool TableExists(string tableName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            try
            {
                return handler.GetValue<int>(new KnightsTour.CoreLibrary.StorageStatement() { Statement = $"select case when exists((select * from information_schema.tables where table_name = '{tableName}')) then 1 else 0 end" }) == 1;
            }
            catch
            {
                try
                {
                    return handler.GetValue<int>(new KnightsTour.CoreLibrary.StorageStatement() { Statement = $"select 1 from {StorageProvider.GetTableSQL(tableName)} where 1 = 0" }) == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
        protected static void DropTable(string tableName)
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = $"DROP TABLE {StorageProvider.GetTableSQL(tableName)}" });
        }
        protected static void DropTestTables()
        {
            //Drop the test tables if they exist
            if (TableExists("TestTable1")) DropTable("TestTable1");
            if (TableExists("TestTable2")) DropTable("TestTable2");
        }
        protected static void CreateTestTables()
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            //Table 1
            string sql = "CREATE TABLE [dbo].[TestTable1]( ";
            sql += "[TestTable1Id][int] IDENTITY(1, 1) NOT NULL, ";
            sql += "[Name] [nvarchar] (max) NOT NULL, ";
            sql += "[TestTable2Id] [int] NOT NULL, ";
            sql += "[CreateDate] [datetime] NOT NULL, ";
            sql += "CONSTRAINT[PK_TestTable1] PRIMARY KEY CLUSTERED ";
            sql += "([TestTable1Id] ASC ";
            sql += ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY] ";
            sql += ") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            //Table 2
            sql = "CREATE TABLE [dbo].[TestTable2]( ";
            sql += "[TestTable2Id][int] NOT NULL, ";
            sql += "[Name] [nvarchar] (max) NOT NULL, ";
            sql += "[CreateDate] [datetime] NOT NULL, ";
            sql += "CONSTRAINT[PK_TestTable2] PRIMARY KEY CLUSTERED ";
            sql += "([TestTable2Id] ASC ";
            sql += ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY] ";
            sql += ") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY] ";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            //Constraints
            sql = "ALTER TABLE [dbo].[TestTable1] ADD  CONSTRAINT [DF_TestTable1_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            sql = "ALTER TABLE[dbo].[TestTable2] ADD CONSTRAINT[DF_TestTable2_CreateDate]  DEFAULT(getdate()) FOR[CreateDate]";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            sql = "ALTER TABLE[dbo].[TestTable1]  WITH CHECK ADD CONSTRAINT[FK_TestTable1_TestTable2] FOREIGN KEY([TestTable2Id]) REFERENCES[dbo].[TestTable2]([TestTable2Id])";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });
            sql = "ALTER TABLE[dbo].[TestTable1] CHECK CONSTRAINT[FK_TestTable1_TestTable2]";
            handler.Execute(new KnightsTour.CoreLibrary.StorageStatement { Statement = sql });

            ResetTestTableData();
        }
        protected static void ResetTestTableData()
        {
            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();

            //Delete the existing test table 1 data
            KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = $"DELETE FROM {StorageProvider.GetTableSQL("TestTable1")}" };
            handler.Execute(statement);
            //Reset the seed
            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = $"TRUNCATE TABLE {StorageProvider.GetTableSQL("TestTable1")}" };
            handler.Execute(statement);
            //Delete the existing test table 2 data
            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = $"DELETE FROM {StorageProvider.GetTableSQL("TestTable2")}" };
            handler.Execute(statement);

            //Insert new data
            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = $"INSERT INTO {StorageProvider.GetTableSQL("TestTable2")} ({StorageProvider.GetColumnSQL("Name")}, {StorageProvider.GetColumnSQL("TestTable2Id")}) VALUES ('Red', 1), ('Blue', 2), ('Green', 3), ('Orange', 4)" };
            handler.Execute(statement);

            statement = new KnightsTour.CoreLibrary.StorageStatement { Statement = $"INSERT INTO {StorageProvider.GetTableSQL("TestTable1")} ({StorageProvider.GetColumnSQL("Name")}, {StorageProvider.GetColumnSQL("TestTable2Id")}) VALUES ('Car', 1), ('Car', 2), ('Bike', 1), ('Bike', 2), ('Bike', 3), ('Plane 1', 2), ('Plane 2', 4), ('Shirt 1', 1), ('Shirt 2', 1), ('Shirt 3', 3), ('Shirt 4', 2)" };
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
            TestTable1 testTable = new TestTable1 { Name = name, TestTable2Id = fkId };

            KnightsTour.CoreLibrary.IStorageHandler handler = StorageProvider.GetHandler();
            return handler.AddRecord<int?>(testTable, null, true);
        }
        #endregion
    }
}