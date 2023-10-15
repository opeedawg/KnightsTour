// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : EventTypeRepositoryTestsBase.cs
// ************************************************************************

using System;

using KnightsTour;
using KnightsTour.CoreLibrary.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Entity
{
    /// <summary>
    /// Tests against the EventType repository.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class EventTypeRepositoryTestsBase : DataTestBase<int?>
    {
        #region EventType repository tests Methods

        /// <summary>
        /// Description for Event Type_ Has Storage Handler.
        /// </summary>
        [TestMethod]
        public void EventType_HasStorageHandler()
        {
            EntityRepository_HasStorageHandler<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get By Id.
        /// </summary>
        [TestMethod]
        public void EventType_GetById()
        {
            EntityRepository_GetById<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get By Ids.
        /// </summary>
        [TestMethod]
        public void EventType_GetByIds()
        {
            EntityRepository_GetByIds<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get All.
        /// </summary>
        [TestMethod]
        public void EventType_GetAll()
        {
            EntityRepository_GetAll<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get All_ By Condition.
        /// </summary>
        [TestMethod]
        public void EventType_GetAll_ByCondition()
        {
            EntityRepository_GetAll_ByCondition<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get By F K.
        /// </summary>
        [TestMethod]
        public void EventType_GetByFK()
        {
            EntityRepository_GetByFK<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get By F Ks.
        /// </summary>
        [TestMethod]
        public void EventType_GetByFKs()
        {
            EntityRepository_GetByFKs<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Insert_ Single.
        /// </summary>
        [TestMethod]
        public void EventType_Insert_Single()
        {
            EntityRepository_Insert_Single<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Insert_ Multiple.
        /// </summary>
        [TestMethod]
        public void EventType_Insert_Multiple()
        {
            EntityRepository_Insert_Multiple<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Update_ Single.
        /// </summary>
        [TestMethod]
        public void EventType_Update_Single()
        {
            EntityRepository_Update_Single<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Update_ Multiple.
        /// </summary>
        [TestMethod]
        public void EventType_Update_Multiple()
        {
            EntityRepository_Update_Multiple<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Delete_ By Id.
        /// </summary>
        [TestMethod]
        public void EventType_Delete_ById()
        {
            EntityRepository_Delete_ById<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Delete_ By Ids.
        /// </summary>
        [TestMethod]
        public void EventType_Delete_ByIds()
        {
            EntityRepository_Delete_ByIds<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Delete_ By Entity.
        /// </summary>
        [TestMethod]
        public void EventType_Delete_ByEntity()
        {
            EntityRepository_Delete_ByEntity<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Delete_ By Entities.
        /// </summary>
        [TestMethod]
        public void EventType_Delete_ByEntities()
        {
            EntityRepository_Delete_ByEntities<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Get All_ By Predicate.
        /// </summary>
        [TestMethod]
        public void EventType_GetAll_ByPredicate()
        {
            if (GetEntityProperty<KnightsTour.EventType, KnightsTour.EventTypeLite>(EntityProperty.RecordCount) > 0)
            {
                int? maxId = GetEntityProperty<KnightsTour.EventType, KnightsTour.EventTypeLite>(EntityProperty.LastId);
                EntityRepository_GetAll_ByPredicate<KnightsTour.EventType, KnightsTour.EventTypeLite>(a => a.EventTypeId < maxId);
            }
        }
        #endregion EventType repository tests Methods

    } // Class
} // Namespace