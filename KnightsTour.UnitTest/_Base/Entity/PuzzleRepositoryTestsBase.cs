// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : PuzzleRepositoryTestsBase.cs
// ************************************************************************

using System;

using KnightsTour;
using KnightsTour.CoreLibrary.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Entity
{
    /// <summary>
    /// Tests against the Puzzle repository.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class PuzzleRepositoryTestsBase : DataTestBase<int?>
    {
        #region Puzzle repository tests Methods

        /// <summary>
        /// Description for Puzzle_ Has Storage Handler.
        /// </summary>
        [TestMethod]
        public void Puzzle_HasStorageHandler()
        {
            EntityRepository_HasStorageHandler<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get By Id.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetById()
        {
            EntityRepository_GetById<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get By Ids.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetByIds()
        {
            EntityRepository_GetByIds<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get All.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetAll()
        {
            EntityRepository_GetAll<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get All_ By Condition.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetAll_ByCondition()
        {
            EntityRepository_GetAll_ByCondition<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get By F K.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetByFK()
        {
            EntityRepository_GetByFK<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get By F Ks.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetByFKs()
        {
            EntityRepository_GetByFKs<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Insert_ Single.
        /// </summary>
        [TestMethod]
        public void Puzzle_Insert_Single()
        {
            EntityRepository_Insert_Single<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Insert_ Multiple.
        /// </summary>
        [TestMethod]
        public void Puzzle_Insert_Multiple()
        {
            EntityRepository_Insert_Multiple<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Update_ Single.
        /// </summary>
        [TestMethod]
        public void Puzzle_Update_Single()
        {
            EntityRepository_Update_Single<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Update_ Multiple.
        /// </summary>
        [TestMethod]
        public void Puzzle_Update_Multiple()
        {
            EntityRepository_Update_Multiple<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Delete_ By Id.
        /// </summary>
        [TestMethod]
        public void Puzzle_Delete_ById()
        {
            EntityRepository_Delete_ById<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Delete_ By Ids.
        /// </summary>
        [TestMethod]
        public void Puzzle_Delete_ByIds()
        {
            EntityRepository_Delete_ByIds<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Delete_ By Entity.
        /// </summary>
        [TestMethod]
        public void Puzzle_Delete_ByEntity()
        {
            EntityRepository_Delete_ByEntity<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Delete_ By Entities.
        /// </summary>
        [TestMethod]
        public void Puzzle_Delete_ByEntities()
        {
            EntityRepository_Delete_ByEntities<KnightsTour.Puzzle, KnightsTour.PuzzleLite>();
        }

        /// <summary>
        /// Description for Puzzle_ Get All_ By Predicate.
        /// </summary>
        [TestMethod]
        public void Puzzle_GetAll_ByPredicate()
        {
            if (GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(EntityProperty.RecordCount) > 0)
            {
                int? maxId = GetEntityProperty<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(EntityProperty.LastId);
                EntityRepository_GetAll_ByPredicate<KnightsTour.Puzzle, KnightsTour.PuzzleLite>(a => a.PuzzleId < maxId);
            }
        }
        #endregion Puzzle repository tests Methods

    } // Class
} // Namespace