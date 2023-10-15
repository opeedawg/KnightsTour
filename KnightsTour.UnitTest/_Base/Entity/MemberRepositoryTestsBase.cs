// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : MemberRepositoryTestsBase.cs
// ************************************************************************

using System;

using KnightsTour;
using KnightsTour.CoreLibrary.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Entity
{
    /// <summary>
    /// Tests against the Member repository.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class MemberRepositoryTestsBase : DataTestBase<int?>
    {
        #region Member repository tests Methods

        /// <summary>
        /// Description for Member_ Has Storage Handler.
        /// </summary>
        [TestMethod]
        public void Member_HasStorageHandler()
        {
            EntityRepository_HasStorageHandler<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get By Id.
        /// </summary>
        [TestMethod]
        public void Member_GetById()
        {
            EntityRepository_GetById<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get By Ids.
        /// </summary>
        [TestMethod]
        public void Member_GetByIds()
        {
            EntityRepository_GetByIds<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get All.
        /// </summary>
        [TestMethod]
        public void Member_GetAll()
        {
            EntityRepository_GetAll<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get All_ By Condition.
        /// </summary>
        [TestMethod]
        public void Member_GetAll_ByCondition()
        {
            EntityRepository_GetAll_ByCondition<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get By F K.
        /// </summary>
        [TestMethod]
        public void Member_GetByFK()
        {
            EntityRepository_GetByFK<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get By F Ks.
        /// </summary>
        [TestMethod]
        public void Member_GetByFKs()
        {
            EntityRepository_GetByFKs<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Insert_ Single.
        /// </summary>
        [TestMethod]
        public void Member_Insert_Single()
        {
            EntityRepository_Insert_Single<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Insert_ Multiple.
        /// </summary>
        [TestMethod]
        public void Member_Insert_Multiple()
        {
            EntityRepository_Insert_Multiple<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Update_ Single.
        /// </summary>
        [TestMethod]
        public void Member_Update_Single()
        {
            EntityRepository_Update_Single<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Update_ Multiple.
        /// </summary>
        [TestMethod]
        public void Member_Update_Multiple()
        {
            EntityRepository_Update_Multiple<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Delete_ By Id.
        /// </summary>
        [TestMethod]
        public void Member_Delete_ById()
        {
            EntityRepository_Delete_ById<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Delete_ By Ids.
        /// </summary>
        [TestMethod]
        public void Member_Delete_ByIds()
        {
            EntityRepository_Delete_ByIds<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Delete_ By Entity.
        /// </summary>
        [TestMethod]
        public void Member_Delete_ByEntity()
        {
            EntityRepository_Delete_ByEntity<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Delete_ By Entities.
        /// </summary>
        [TestMethod]
        public void Member_Delete_ByEntities()
        {
            EntityRepository_Delete_ByEntities<KnightsTour.Member, KnightsTour.MemberLite>();
        }

        /// <summary>
        /// Description for Member_ Get All_ By Predicate.
        /// </summary>
        [TestMethod]
        public void Member_GetAll_ByPredicate()
        {
            if (GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(EntityProperty.RecordCount) > 0)
            {
                int? maxId = GetEntityProperty<KnightsTour.Member, KnightsTour.MemberLite>(EntityProperty.LastId);
                EntityRepository_GetAll_ByPredicate<KnightsTour.Member, KnightsTour.MemberLite>(a => a.MemberId < maxId);
            }
        }
        #endregion Member repository tests Methods

    } // Class
} // Namespace