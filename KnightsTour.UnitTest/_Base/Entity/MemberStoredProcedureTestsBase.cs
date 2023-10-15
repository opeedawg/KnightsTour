// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : MemberStoredProcedureTestsBase.cs
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
    /// Tests against the Member entity stored procedures.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class MemberStoredProcedureTestsBase : DataTestBase<int?>
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

        #region Member stored procedure tests Methods

        /// <summary>
        /// Description for Member_ Stored Procedure_ Create.
        /// </summary>
        [TestMethod]
        public void Member_StoredProcedure_Create()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "MemberInsert"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    // This creates a new, fully populated yet randomized entity.
                    KnightsTour.Member member = GetNewEntity<KnightsTour.Member>();

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.MemberInsert.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["MemberInsert"],
                        Parameters = new List<IParameter>
                        {
                            new KnightsTour.CoreLibrary.GenericParameter("@EmailAddress", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.EmailAddress)),
                            new KnightsTour.CoreLibrary.GenericParameter("@ConfirmationDate", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.ConfirmationDate)),
                            new KnightsTour.CoreLibrary.GenericParameter("@DisplayName", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.DisplayName)),
                            new KnightsTour.CoreLibrary.GenericParameter("@Password", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.Password)),
                            new KnightsTour.CoreLibrary.GenericParameter("@UserInitials", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.UserInitials)),
                            new KnightsTour.CoreLibrary.GenericParameter("@Code", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.Code)),
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
                Assert.Inconclusive("The stored procedure 'MemberInsert' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Member_ Stored Procedure_ Update.
        /// </summary>
        [TestMethod]
        public void Member_StoredProcedure_Update()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "MemberUpdate"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
                    int? idToSelect = null;

                    // This creates a new, fully populated yet randomized entity.
                    KnightsTour.Member member = GetNewEntity<KnightsTour.Member>();

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        try
                        {
                            IActionResponse insertResponse = new MemberLogic("Unit test").Insert(member);

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
                        idToSelect = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                        member = new MemberLogic("Unit test").GetById(idToSelect);
                    }
                    #endregion

                    #region Dynamically update the newly created member
                    if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasStringField))
                    {
                        string stringField = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.StringField);
                        string currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Member, string>(member, stringField);
                        string newValue = "modified";
                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            newValue = currentValue + " modified.";
                            if (currentValue.StartsWith("a"))
                            {
                                newValue = currentValue.Replace("a", "z");
                            }
                        }
                        KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Member>(member, stringField, newValue);
                    }
                    else if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasIntField))
                    {
                        string intField = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.IntField);
                        int currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Member, int>(member, intField);
                        int newValue = currentValue + 1;
                        KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Member>(member, intField, newValue);
                    }
                    #endregion

                    // Update the object using the stored procedure.
                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.MemberUpdate.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["MemberUpdate"],
                        Parameters = new List<IParameter>
                        {
                            new KnightsTour.CoreLibrary.GenericParameter("@MemberId", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.MemberId)),
                            new KnightsTour.CoreLibrary.GenericParameter("@CreateDate", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.CreateDate)),
                            new KnightsTour.CoreLibrary.GenericParameter("@EmailAddress", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.EmailAddress)),
                            new KnightsTour.CoreLibrary.GenericParameter("@ConfirmationDate", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.ConfirmationDate)),
                            new KnightsTour.CoreLibrary.GenericParameter("@DisplayName", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.DisplayName)),
                            new KnightsTour.CoreLibrary.GenericParameter("@Password", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.Password)),
                            new KnightsTour.CoreLibrary.GenericParameter("@UserInitials", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.UserInitials)),
                            new KnightsTour.CoreLibrary.GenericParameter("@Code", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.Code)),
                            new KnightsTour.CoreLibrary.GenericParameter("@IsAdministrator", member.GetDBValue(KnightsTour.Enumerations.MemberProperty.IsAdministrator)),
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
                Assert.Inconclusive("The stored procedure 'MemberUpdate' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Member_ Stored Procedure_ Get By Id.
        /// </summary>
        [TestMethod]
        public void Member_StoredProcedure_GetById()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "MemberGetById"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
                    int? idToSelect = null;

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        // This creates a new, fully populated yet randomized entity.
                        KnightsTour.Member member = GetNewEntity<KnightsTour.Member>();

                        try
                        {
                            IActionResponse insertResponse = new MemberLogic("Unit test").Insert(member);

                            if (!insertResponse.IsValid)
                            {
                                Assert.Fail(insertResponse.Messages.Where(m => m.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative).First().Content);
                            }
                            else
                            {
                                totalRecords = 1;
                                idToSelect = member.MemberId;
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
                        idToSelect = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                    }
                    #endregion

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.MemberGetById.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["MemberGetById"],
                        Parameter = new KnightsTour.CoreLibrary.GenericParameter("@MemberId", idToSelect),
                    };

                    KnightsTour.Member record = new KnightsTour.Member(StorageHandler.GetRecord(statement));

                    // Validate the record pk returned matches the expected identifier.
                    Assert.AreEqual(record.MemberId, idToSelect);
                }
            }
            else
            {
                Assert.Inconclusive("The stored procedure 'MemberGetById' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Member_ Stored Procedure_ Get All.
        /// </summary>
        [TestMethod]
        public void Member_StoredProcedure_GetAll()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "MemberGetAll"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        // This creates a new, fully populated yet randomized entity.
                        KnightsTour.Member member = GetNewEntity<KnightsTour.Member>();

                        try
                        {
                            IActionResponse insertResponse = new MemberLogic("Unit test").Insert(member);

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
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.MemberGetAll.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["MemberGetAll"],
                    };

                    List<KnightsTour.Member> records = new List<KnightsTour.Member>();
                    foreach (dynamic dataRow in StorageHandler.GetRecords(statement))
                    {
                        records.Add(new KnightsTour.Member(dataRow));
                    }

                    // Validate the total number of records returned match the total number of rows known to exist.
                    Assert.AreEqual(totalRecords, records.Count);
                }
            }
            else
            {
                Assert.Inconclusive("The stored procedure 'MemberGetAll' could not be verified to exist.");
            }
        }

        /// <summary>
        /// Description for Member_ Stored Procedure_ Delete.
        /// </summary>
        [TestMethod]
        public void Member_StoredProcedure_Delete()
        {
            // Verify that the stored procedure exists.
            if (Enum.IsDefined(typeof(KnightsTour.Enumerations.StoredProcedure), "MemberDelete"))
            {
                using (var transactionScope = new TransactionScope())
                {
                    #region Data validation
                    long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
                    int? idToDelete = null;

                    // Insert a new record if required to validate this test.
                    if (totalRecords == 0)
                    {
                        // This creates a new, fully populated yet randomized entity.
                        KnightsTour.Member member = GetNewEntity<KnightsTour.Member>();

                        try
                        {
                            IActionResponse insertResponse = new MemberLogic("Unit test").Insert(member);

                            if (!insertResponse.IsValid)
                            {
                                Assert.Fail(insertResponse.Messages.Where(m => m.Type == KnightsTour.CoreLibrary.Enumerations.MessageType.Negative).First().Content);
                            }
                            else
                            {
                                totalRecords = 1;
                                idToDelete = member.MemberId;
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
                        idToDelete = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                    }
                    #endregion

                    StorageStatement statement = new StorageStatement()
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        // In production, the StoredProcedureTransformation should be referenced by the StoredProcedure enumeration list, for example:.
                        // Statement = EntityMapper.StoredProcedureTransformation[KnightsTour.Enumerations.StoredProcedure.MemberDelete.ToString()];
                        Statement = EntityMapper.StoredProcedureTransformation["MemberDelete"],
                        Parameter = new KnightsTour.CoreLibrary.GenericParameter("@MemberId", idToDelete),
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
                Assert.Inconclusive("The stored procedure 'MemberDelete' could not be verified to exist.");
            }
        }
        #endregion Member stored procedure tests Methods

    } // Class
} // Namespace