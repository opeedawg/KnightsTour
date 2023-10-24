// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:55:34 AM
// File             : PuzzleLogicBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Transactions;

namespace KnightsTour
{
    /// <summary>
    /// Base puzzle logic support methods.  Implements both <seealso cref="KnightsTour.CoreLibrary.IRepository{T,TLite, TPk}" /> and <seealso cref="KnightsTour.CoreLibrary.IEntityLogic{T,TLite, TPk}" />
    /// Generated On: October 21, 2023 at 9:55:34 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class supports basic and extended CRUD access - agnostic to supporting both cache and direct database access.
    /// This class is abstract and is meant to only be inherited and accessed via <seealso cref="PuzzleLogic" /> class.
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    public abstract class PuzzleLogicBase : LogicBase<KnightsTour.Puzzle, KnightsTour.PuzzleLite, int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the configured repository.
        /// </summary>
        /// <param name="userName">The user using this class.</param>
        /// <example>
        /// <code>
        /// PuzzleLogicBase PuzzleLogic = new PuzzleLogic(userName);
        /// </code>
        /// </example>
        public PuzzleLogicBase(string userName) : base(Enumerations.EntityName.Puzzle, userName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the passed handler.
        /// </summary>
        /// <param name="handler">A storage handler.</param>
        /// <param name="userName">The user using this class.</param>
        public PuzzleLogicBase(KnightsTour.CoreLibrary.IStorageHandler handler, string userName) : base(Enumerations.EntityName.Puzzle, handler, userName)
        {
        }
        #endregion Constructor(s)

        #region Methods

        /// <summary>
        /// Inserts the Puzzle and also checks to insert all the FK objects as well.
        /// </summary>
        /// <param name="puzzle">The <see cref="Puzzle"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public KnightsTour.CoreLibrary.IActionResponse InsertCascade(Puzzle puzzle)
        {
            KnightsTour.CoreLibrary.IActionResponse response = new KnightsTour.CoreLibrary.ActionResponse("Flat puzzle insert");

            using (var transactionScope = new TransactionScope())
            {

                // Check to see if the board needs to be inserted.
                if (!puzzle.BoardId.HasValue && puzzle.Board != null)
                {
                    response.Append(new BoardLogic(UserName).InsertCascade(puzzle.Board));
                    if (!response.IsValid)
                    {
                        return response;
                    }
                    else
                    {
                        puzzle.BoardId = puzzle.Board.BoardId;
                    }
                }

                // Check to see if the difficulty level needs to be inserted.
                if (!puzzle.DifficultyLevelId.HasValue && puzzle.DifficultyLevel != null)
                {
                    response.Append(new DifficultyLevelLogic(UserName).InsertCascade(puzzle.DifficultyLevel));
                    if (!response.IsValid)
                    {
                        return response;
                    }
                    else
                    {
                        puzzle.DifficultyLevelId = puzzle.DifficultyLevel.DifficultyLevelId;
                    }
                }

                // Insert the hydrated object.
                response.Append(new PuzzleLogic(UserName).Insert(puzzle));

                // Complete the transaction if everything worked as expected with no errors.
                if (response.IsValid)
                {
                    transactionScope.Complete();
                }

            }

            // Return the response.
            return response;
        }

        /// <summary>
        /// Inserts the Puzzle.
        /// </summary>
        /// <param name="puzzle">The <see cref="Puzzle"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public new KnightsTour.CoreLibrary.IActionResponse Insert(Puzzle puzzle)
        {
            // Configured insert defaults.
            puzzle.PuzzleCode = Guid.NewGuid();

            // Encryption requested on these field(s).

            // Call the base method.
            return base.Insert(puzzle);
        }
        #endregion Methods

    } // Class
} // Namespace