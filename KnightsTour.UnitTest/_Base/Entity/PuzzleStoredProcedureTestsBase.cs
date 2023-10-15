// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : PuzzleStoredProcedureTestsBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using KnightsTour;
using KnightsTour.CoreLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.StoredProcedure
{
    /// <summary>
    /// Tests against the Puzzle entity stored procedures.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class PuzzleStoredProcedureTestsBase : DataTestBase<int?>
    {
        #region Declarations
        static SQLServerStorageHandler storageHandler = null; // A universal storage handler to support these stored procedure tests.
        #endregion Declarations

        #region Properties

        /// <summary>
        /// A universal storage handler to support these stored procedure tests.
        /// </summary>
        /// <value>
        /// The storage handler.
        /// </value>
        static SQLServerStorageHandler StorageHandler
        {
            get
            {
                if (storageHandler == null)
                {
                    storageHandler = (SQLServerStorageHandler)StorageProvider.GetHandler();
                }
                return storageHandler;
            }
        }
        #endregion Properties

        #region Puzzle stored procedure tests Methods

        /// <summary>
        /// Description for Puzzle_ Stored Procedure_ Create.
        /// </summary>
        [TestMethod]
        public void Puzzle_StoredProcedure_Create()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "PuzzleInsert"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    // This creates a new, fully populated yet randomized entity.
                    KnightsTour.Puzzle puzzle = GetNewEntity<KnightsTour.Puzzle>();

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.PuzzleInsert.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["PuzzleInsert"],
                        Parameters = new List<IParameter>
                        {
                            new KnightsTour.CoreLibrary.GenericParameter("@BoardId", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.BoardId)),
                            new KnightsTour.CoreLibrary.GenericParameter("@DifficultyLevelId", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.DifficultyLevelId)),
                            new KnightsTour.CoreLibrary.GenericParameter("@Path", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.Path)),
                            new KnightsTour.CoreLibrary.GenericParameter("@PuzzleOfTheDayDate", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.PuzzleOfTheDayDate)),
                        }
                    };

                    try
                    {
                        int? pkValueReturned = StorageHandler.GetValue<int?>(statement);
                        Assert.IsNotNull(pkValueReturned);
                    }
                    catch (Exception exception)
                    {
                        if (IsKeyConstraintException(exception))
                        {
                            Assert.Inconclusive("Data constraint violated or invalid trigger code detected.");
                        }

                        Assert.Fail(exception.Message);
                    }
                } // Transaction scope.
            } // Enum defined.
            else
            {
                Assert.Inconclusive("The stored procedure 'PuzzleInsert' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Puzzle_ Stored Procedure_ Update.
        /// </summary>
        [TestMethod]
        public void Puzzle_StoredProcedure_Update()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "PuzzleUpdate"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
                    int? idToSelect = null;

                    // This creates a new, fully populated yet randomized entity.
                    KnightsTour.Puzzle puzzle = GetNewEntity<KnightsTour.Puzzle>();

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        try
                        {
                            IActionResponse insertResponse = new PuzzleLogic("Unit test").Insert(puzzle);

                            if (!insertResponse.IsValid)
                            {
                                Assert.Fail(insertResponse.Messages.Where(m => m.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative).First().Content);
                            }
                        }
                        catch (Exception exception)
                        {
                            if (IsKeyConstraintException(exception))
                            {
                                Assert.Inconclusive("Unit test passed, unique data constraints check kicked in and verified");
                            }

                            Assert.Fail(exception.Message);
                        }
                    }
                    else
                    {
                        idToSelect = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                        puzzle = new PuzzleLogic("Unit test").GetById(idToSelect);
                    }
                    #endregion

                    #region Dynamically update the newly created puzzle
                    if (GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasStringField))
                    {
                        string stringField = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.StringField);
                        string currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Puzzle, string>(puzzle, stringField);
                        string newValue = "modified";
                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            newValue = currentValue + " modified.";
                            if (currentValue.StartsWith("a"))
                            {
                                newValue = currentValue.Replace("a", "z");
                            }
                        }
                        KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Puzzle>(puzzle, stringField, newValue);
                    }
                    else if (GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasIntField))
                    {
                        string intField = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.IntField);
                        int currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Puzzle, int>(puzzle, intField);
                        int newValue = currentValue + 1;
                        KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Puzzle>(puzzle, intField, newValue);
                    }
                    #endregion

                    // Update the object using the stored procedure.
                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.PuzzleUpdate.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["PuzzleUpdate"],
                        Parameters = new List<IParameter>
                        {
                            new KnightsTour.CoreLibrary.GenericParameter("@PuzzleId", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.PuzzleId)),
                            new KnightsTour.CoreLibrary.GenericParameter("@PuzzleCode", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.PuzzleCode)),
                            new KnightsTour.CoreLibrary.GenericParameter("@BoardId", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.BoardId)),
                            new KnightsTour.CoreLibrary.GenericParameter("@DifficultyLevelId", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.DifficultyLevelId)),
                            new KnightsTour.CoreLibrary.GenericParameter("@Path", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.Path)),
                            new KnightsTour.CoreLibrary.GenericParameter("@PuzzleOfTheDayDate", puzzle.GetDBValue(KnightsTour.Enumerations.PuzzleProperty.PuzzleOfTheDayDate)),
                        }
                    };

                    try
                    {
                        int recordsUpdated = StorageHandler.Execute(statement);

                        // Validate the record was in fact updated.
                        Assert.AreEqual(recordsUpdated, 1);
                    }
                    catch (Exception exception)
                    {
                        if (IsKeyConstraintException(exception))
                        {
                            Assert.Inconclusive("Data constraint violated or invalid trigger code detected.");
                        }

                        Assert.Fail(exception.Message);
                    }
                } // Transaction scope.
            } // Enum defined.
            else
            {
                Assert.Inconclusive("The stored procedure 'PuzzleUpdate' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Puzzle_ Stored Procedure_ Get By Id.
        /// </summary>
        [TestMethod]
        public void Puzzle_StoredProcedure_GetById()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "PuzzleGetById"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
                    int? idToSelect = null;

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        // This creates a new, fully populated yet randomized entity.
                        KnightsTour.Puzzle puzzle = GetNewEntity<KnightsTour.Puzzle>();

                        try
                        {
                            IActionResponse insertResponse = new PuzzleLogic("Unit test").Insert(puzzle);

                            if (!insertResponse.IsValid)
                            {
                                Assert.Fail(insertResponse.Messages.Where(m => m.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative).First().Content);
                            }
                            else
                            {
                                totalRecords = 1;
                                idToSelect = puzzle.PuzzleId;
                            }
                        }
                        catch (Exception exception)
                        {
                            if (IsKeyConstraintException(exception))
                            {
                                Assert.Inconclusive("Data constraint violated or invalid trigger code detected.");
                            }

                            Assert.Fail(exception.Message);
                        }
                    }
                    else
                    {
                        idToSelect = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                    }
                    #endregion

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.PuzzleGetById.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["PuzzleGetById"],
                        Parameter = new KnightsTour.CoreLibrary.GenericParameter("@PuzzleId", idToSelect),
                    };

                    KnightsTour.Puzzle record = new KnightsTour.Puzzle(StorageHandler.GetRecord(statement));

                    // Validate the record pk returned matches the expected identifier.
                    Assert.AreEqual(record.PuzzleId, idToSelect);
                }
            }
            else
            {
                Assert.Inconclusive("The stored procedure 'PuzzleGetById' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Puzzle_ Stored Procedure_ Get All.
        /// </summary>
        [TestMethod]
        public void Puzzle_StoredProcedure_GetAll()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "PuzzleGetAll"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        // This creates a new, fully populated yet randomized entity.
                        KnightsTour.Puzzle puzzle = GetNewEntity<KnightsTour.Puzzle>();

                        try
                        {
                            IActionResponse insertResponse = new PuzzleLogic("Unit test").Insert(puzzle);

                            if (!insertResponse.IsValid)
                            {
                                Assert.Fail(insertResponse.Messages.Where(m => m.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative).First().Content);
                            }
                            else
                            {
                                totalRecords = 1;
                            }
                        }
                        catch (Exception exception)
                        {
                            if (IsKeyConstraintException(exception))
                            {
                                Assert.Inconclusive("Data constraint violated or invalid trigger code detected.");
                            }

                            Assert.Fail(exception.Message);
                        }
                    }
                    #endregion

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.PuzzleGetAll.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["PuzzleGetAll"],
                    };

                    List<KnightsTour.Puzzle> records = new List<KnightsTour.Puzzle>();
                    foreach (dynamic dataRow in StorageHandler.GetRecords(statement))
                    {
                        records.Add(new KnightsTour.Puzzle(dataRow));
                    }

                    // Validate the total number of records returned match the total number of rows known to exist.
                    Assert.AreEqual(totalRecords, records.Count);
                }
            }
            else
            {
                Assert.Inconclusive("The stored procedure 'PuzzleGetAll' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Puzzle_ Stored Procedure_ Delete.
        /// </summary>
        [TestMethod]
        public void Puzzle_StoredProcedure_Delete()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "PuzzleDelete"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
                    int? idToDelete = null;

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        // This creates a new, fully populated yet randomized entity.
                        KnightsTour.Puzzle puzzle = GetNewEntity<KnightsTour.Puzzle>();

                        try
                        {
                            IActionResponse insertResponse = new PuzzleLogic("Unit test").Insert(puzzle);

                            if (!insertResponse.IsValid)
                            {
                                Assert.Fail(insertResponse.Messages.Where(m => m.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative).First().Content);
                            }
                            else
                            {
                                totalRecords = 1;
                                idToDelete = puzzle.PuzzleId;
                            }
                        }
                        catch (Exception exception)
                        {
                            if (IsKeyConstraintException(exception))
                            {
                                Assert.Inconclusive("Unit test passed, unique data constraints check kicked in and verified");
                            }

                            Assert.Fail(exception.Message);
                        }
                    }
                    else
                    {
                        idToDelete = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                    }
                    #endregion

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.PuzzleDelete.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["PuzzleDelete"],
                        Parameter = new KnightsTour.CoreLibrary.GenericParameter("@PuzzleId", idToDelete),
                    };

                    try
                    {
                        int recordsDeleted = StorageHandler.Execute(statement);

                        // Validate the record was in fact deleted.
                        Assert.AreEqual(recordsDeleted, 1);
                    }
                    catch (Exception exception)
                    {
                        if (IsKeyConstraintException(exception))
                        {
                            Assert.Inconclusive("Data constraint violated or invalid trigger code detected.");
                        }
                    }
                }
            }
            else
            {
                Assert.Inconclusive("The stored procedure 'PuzzleDelete' could not be verified to exist.");
            }
        }
        #endregion Puzzle stored procedure tests Methods

    } // Class
} // Namespace