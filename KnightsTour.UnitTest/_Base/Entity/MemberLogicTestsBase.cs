// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : MemberLogicTestsBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Entity
{
    /// <summary>
    /// Tests against the MemberLogic support class.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class MemberLogicTestsBase : DataTestBase<int?>
    {
        #region Member logic tests Methods

        /// <summary>
        /// Description for Member Logic_ Has Repository.
        /// </summary>
        [TestMethod]
        public void MemberLogic_HasRepository()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            KnightsTour.CoreLibrary.IRepository<KnightsTour.Member, KnightsTour.MemberLite, int?> repository = logic.Repository;
            Assert.IsNotNull(repository);
        }

        /// <summary>
        /// Description for Member Logic_ Has Storage Handler.
        /// </summary>
        [TestMethod]
        public void MemberLogic_HasStorageHandler()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            KnightsTour.CoreLibrary.IStorageHandler handler = logic.StorageHandler;
            Assert.IsNotNull(handler);
        }

        /// <summary>
        /// Description for Member Logic_ Get By Id.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetById()
        {
            EntityRepository_GetById<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member Logic_ Get By Ids.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetByIds()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount) > 1)
            {
                int? firstId = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.FirstId);
                int? lastId = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.LastId);
                List<int?> ids = new List<int?>() { firstId, lastId };

                List<KnightsTour.Member> members = logic.GetByIds(ids).ToList();
                Assert.IsNotNull(members);
                Assert.AreEqual(members.Count, 2);
                members = members.OrderBy(x => x.Id).ToList();
                Assert.AreEqual(members[0].Id, firstId);
                Assert.AreEqual(members[1].Id, lastId);
            }
        }

        /// <summary>
        /// Description for Member Logic_ Get All.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetAll()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
            if (totalRecords > 0)
            {
                List<KnightsTour.Member> members = logic.GetAll().ToList();
                Assert.IsTrue(members.Count > 0);
                Assert.IsTrue(members.Count >= totalRecords);
            }
        }

        /// <summary>
        /// Description for Member Logic_ Get All_ By Condition.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetAll_ByCondition()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            string pk = new KnightsTour.Member().PrimaryKeyField;

            long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
            if (totalRecords > 1)
            {
                int? maxId = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.LastId);
                List<KnightsTour.Member> members = logic.GetAll(new KnightsTour.CoreLibrary.RetrievalCondition { SQLWhere = $"{StorageProvider.GetColumnSQL(pk)} < {maxId}" }).ToList();
                Assert.IsTrue(members.Count > 0);
                Assert.IsTrue(members.Count < totalRecords);
            }
        }

        /// <summary>
        /// Description for Member Logic_ Get All_ By Predicate.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetAll_ByPredicate()
        {
            long totalRecords = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount);
            if (totalRecords > 0)
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
                int? maxId = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.LastId);
                EntityRepository_GetAll_ByPredicate<KnightsTour.Member, KnightsTour.MemberLite>(a => a.MemberId < maxId);

                if (totalRecords > 1)
                {
                    List<KnightsTour.Member> members = logic.GetAll(a => a.MemberId < maxId).ToList();
                    Assert.IsTrue(members.Count > 0);
                    Assert.IsTrue(members.Count < totalRecords);
                }
            }
        }

        /// <summary>
        /// Description for Member Logic_ Get All_ By F K.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetAll_ByFK()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            foreach (string property in EntityMapper.FKNames(new KnightsTour.Member().EntityName))
            {
                // Get some valid FK Values.
                foreach (int? fkValue in StorageProvider.GetFKValues<KnightsTour.Member, KnightsTour.MemberLite, int?>(property))
                {
                    List<KnightsTour.Member> members = logic.GetByFK(property, fkValue, new KnightsTour.CoreLibrary.RetrievalCondition { SQLOrderBy = property, Skip = 0, Take = MaxFKQuantity }).ToList();
                    Assert.IsTrue(members.Count > 0);
                    Assert.IsTrue(members.Count <= MaxFKQuantity);
                }
            }
        }

        /// <summary>
        /// Description for Member Logic_ Get All_ By F Ks.
        /// </summary>
        [TestMethod]
        public void MemberLogic_GetAll_ByFKs()
        {
            KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
            foreach (string property in EntityMapper.FKNames(new KnightsTour.Member().EntityName))
            {
                // Get some valid FK Values.
                List<KnightsTour.Member> members = logic.GetByFKs(property, KnightsTour.StorageProvider.GetFKValues<KnightsTour.Member, KnightsTour.MemberLite, int?>(property), new KnightsTour.CoreLibrary.RetrievalCondition { SQLOrderBy = property, Skip = 0, Take = MaxFKQuantity }).ToList();
                Assert.IsTrue(members.Count > 0);
                Assert.IsTrue(members.Count <= MaxFKQuantity);
            }
        }

        /// <summary>
        /// Description for Member Logic_ Insert_ Single.
        /// </summary>
        [TestMethod]
        public void MemberLogic_Insert_Single()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
            }
        }

        /// <summary>
        /// Description for Member Logic_ Insert_ Multiple.
        /// </summary>
        [TestMethod]
        public void MemberLogic_Insert_Multiple()
        {
            // Block size larger than the number of accounts.
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                List<KnightsTour.Member> members = CreateEntities<KnightsTour.Member>(BulkTestQuantity);

                Assert.IsNotNull(members);
                Assert.IsTrue(members.Count == BulkTestQuantity);
                foreach (KnightsTour.Member member in members)
                {
                    Assert.IsTrue(member.IsNew);
                }

                // If the primary key insertion type is manual, then configure some values now.
                if (members[0].PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual)
                {
                    foreach (KnightsTour.Member member in members)
                    {
                        member.Id = GetRandomValue<int?>();
                    }
                }

                KnightsTour.CoreLibrary.IActionResponse response = logic.Insert(members, 500);
                Assert.IsTrue(response.IsValid);

                // Block size less than the number of accounts.
                members = CreateEntities<KnightsTour.Member>(BulkTestQuantity);

                Assert.IsNotNull(members);
                Assert.IsTrue(members.Count == BulkTestQuantity);
                foreach (KnightsTour.Member member in members)
                {
                    Assert.IsTrue(member.IsNew);
                }

                // If the primary key insertion type is manual, then configure some values now.
                if (members[0].PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual)
                {
                    foreach (KnightsTour.Member member in members)
                    {
                        member.Id = GetRandomValue<int?>();
                    }
                }

                response = logic.Insert(members, BulkTestQuantity - 1);
                Assert.IsTrue(response.IsValid);
            }
        }

        /// <summary>
        /// Description for Member Logic_ Update_ Single.
        /// </summary>
        [TestMethod]
        public void MemberLogic_Update_Single()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                #region Create and insert a new member
                KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
                #endregion

                #region Now let's update that newly created member
                if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasStringField))
                {
                    string stringField = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.StringField);
                    string currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Member, string>(member, stringField);
                    string newValue = "modified";
                    if (string.IsNullOrEmpty(currentValue))
                    {
                        newValue = currentValue + " modified.";
                        if (currentValue.StartsWith("a"))
                        {
                            newValue = currentValue.Replace("a", "z");
                        }
                    }
                    KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Member>(member, stringField, newValue);
                    KnightsTour.CoreLibrary.IActionResponse updateResponse = logic.Update(member);
                    Assert.IsTrue(updateResponse.IsValid);
                }
                else if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasIntField))
                {
                    string intField = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.IntField);
                    int currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Member, int>(member, intField);
                    int newValue = currentValue + 1;
                    KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Member>(member, intField, newValue);
                    KnightsTour.CoreLibrary.IActionResponse updateResponse = logic.Update(member);
                    Assert.IsTrue(updateResponse.IsValid);
                }
                #endregion
            }
        }

        /// <summary>
        /// Description for Member Logic_ Update_ Multiple.
        /// </summary>
        [TestMethod]
        public void MemberLogic_Update_Multiple()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                string pk = new KnightsTour.Member().PrimaryKeyField;

                if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.RecordCount) > 0)
                {
                    List<KnightsTour.Member> members = logic.GetAll(new KnightsTour.CoreLibrary.RetrievalCondition
                    {
                        SQLOrderBy = StorageProvider.GetColumnSQL(pk),
                        Skip = 0,
                        Take = BulkTestQuantity
                    }).ToList();

                    Assert.IsTrue(members.Count > 0);

                    // Modify each account.
                    bool modified = false;
                    foreach (KnightsTour.Member member in members)
                    {
                        if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasStringField))
                        {
                            string stringField = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.StringField);
                            string currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Member, string>(member, stringField);
                            string newValue = "modified";
                            if (string.IsNullOrEmpty(currentValue))
                            {
                                newValue = currentValue + " modified.";
                                if (currentValue.StartsWith("a"))
                                {
                                    newValue = currentValue.Replace("a", "z");
                                }
                            }
                            KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Member>(member, stringField, newValue);
                            modified = true;
                        }
                        else if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.HasIntField))
                        {
                            string intField = GetEntityProperty<KnightsTour.Member, MemberLite>(KnightsTour.CoreLibrary.Enumerations.EntityProperty.IntField);
                            int currentValue = KnightsTour.CoreLibrary.ReflectionAssistant.GetValue<KnightsTour.Member, int>(member, intField);
                            int newValue = currentValue + 1;
                            KnightsTour.CoreLibrary.ReflectionAssistant.SetValue<KnightsTour.Member>(member, intField, newValue);
                            modified = true;
                        }
                    }
                    if (modified)
                    {
                        KnightsTour.CoreLibrary.IActionResponse updateResponse = logic.Update(members);
                        Assert.IsTrue(updateResponse.IsValid);
                    }
                }
            }

        }

        /// <summary>
        /// Description for Member Logic_ Delete By Id.
        /// </summary>
        [TestMethod]
        public void MemberLogic_DeleteById()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                #region Create and insert a new member
                KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
                #endregion

                #region Now let's delete that newly created member by it's id
                KnightsTour.CoreLibrary.IActionResponse deleteResponse = logic.Delete(member.Id.Value);
                Assert.IsTrue(deleteResponse.IsValid);
                #endregion
            }
        }

        /// <summary>
        /// Description for Member Logic_ Delete By Ids.
        /// </summary>
        [TestMethod]
        public void MemberLogic_DeleteByIds()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                #region Create and insert some new members
                List<int?> newIds = new List<int?>();
                for (int i = 0; i < BulkTestQuantity; i++)
                {
                    KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
                    newIds.Add(member.Id.Value);
                }
                Assert.IsTrue(newIds.Count == BulkTestQuantity);
                #endregion

                #region Now let's delete that newly cretaed member by it's id
                KnightsTour.CoreLibrary.IActionResponse deleteResponse = logic.Delete(newIds);
                Assert.IsTrue(deleteResponse.IsValid);
                #endregion
            }
        }

        /// <summary>
        /// Description for Member Logic_ Delete By Entity.
        /// </summary>
        [TestMethod]
        public void MemberLogic_DeleteByEntity()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                #region Create and insert a new member
                KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
                #endregion

                #region Now let's delete that newly created member by it's id
                KnightsTour.CoreLibrary.IActionResponse deleteResponse = logic.Delete(member);
                Assert.IsTrue(deleteResponse.IsValid);
                #endregion
            }
        }

        /// <summary>
        /// Description for Member Logic_ Delete By Entities.
        /// </summary>
        [TestMethod]
        public void MemberLogic_DeleteByEntities()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                #region Create and insert some new members
                List<KnightsTour.Member> newEntities = new List<KnightsTour.Member>();
                for (int i = 0; i < BulkTestQuantity; i++)
                {
                    KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
                    newEntities.Add(member);
                }
                Assert.IsTrue(newEntities.Count == BulkTestQuantity);
                #endregion

                #region Now let's delete that newly created member by it's id
                KnightsTour.CoreLibrary.IActionResponse deleteResponse = logic.Delete(newEntities);
                Assert.IsTrue(deleteResponse.IsValid);
                #endregion
            }
        }

        /// <summary>
        /// Description for Member Logic_ Delete_ Cascade.
        /// </summary>
        [TestMethod]
        public void MemberLogic_Delete_Cascade()
        {
            using (var transactionScope = new TransactionScope())
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);

                #region Create and insert a new member
                KnightsTour.Member member = InsertEntity<KnightsTour.Member, KnightsTour.MemberLite>();
                #endregion

                #region Now let's delete that newly created member by it's id
                KnightsTour.CoreLibrary.IActionResponse deleteResponse = logic.DeleteCascade(member.Id.Value);
                Assert.IsTrue(deleteResponse.IsValid);
                #endregion
            }
        }

        /// <summary>
        /// Description for Member Logic_ Delete_ By F K.
        /// </summary>
        [TestMethod]
        public void MemberLogic_Delete_ByFK()
        {
            EntityMetaData meta = new EntityMetaData(KnightsTour.Enumerations.EntityName.Member, UserName);

            if (meta.Dependencies.Count > 0)
            {
                Assert.Inconclusive("Delete by FK is not possible due to dependencies.");
            }
            else
            {
                KnightsTour.MemberLogic logic = new KnightsTour.MemberLogic(UserName);
                using (var transactionScope = new TransactionScope())
                {
                    foreach (string property in EntityMapper.FKNames(new KnightsTour.Member().EntityName))
                    {
                        // Get some valid FK Values.
                        foreach (int fkValue in StorageProvider.GetFKValues<KnightsTour.Member, KnightsTour.MemberLite, int?>(property))
                        {
                            KnightsTour.CoreLibrary.IActionResponse deleteResponse = logic.DeleteByFK(property, fkValue);
                            Assert.IsTrue(deleteResponse.IsValid);
                        }
                    }
                }
            }
        }
        #endregion Member logic tests Methods

    } // Class
} // Namespace