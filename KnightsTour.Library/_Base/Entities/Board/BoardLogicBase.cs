// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:18:11 AM
// File             : BoardLogicBase.cs
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
    /// Base board logic support methods.  Implements both <seealso cref="KnightsTour.CoreLibrary.IRepository{T,TLite, TPk}" /> and <seealso cref="KnightsTour.CoreLibrary.IEntityLogic{T,TLite, TPk}" />
    /// Generated On: October 14, 2023 at 11:18:11 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class supports basic and extended CRUD access - agnostic to supporting both cache and direct database access.
    /// This class is abstract and is meant to only be inherited and accessed via <seealso cref="BoardLogic" /> class.
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    public abstract class BoardLogicBase : LogicBase<KnightsTour.Board, KnightsTour.BoardLite, int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the configured repository.
        /// </summary>
        /// <param name="userName">The user using this class.</param>
        /// <example>
        /// <code>
        /// BoardLogicBase BoardLogic = new BoardLogic(userName);
        /// </code>
        /// </example>
        public BoardLogicBase(string userName) : base(Enumerations.EntityName.Board, userName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the passed handler.
        /// </summary>
        /// <param name="handler">A storage handler.</param>
        /// <param name="userName">The user using this class.</param>
        public BoardLogicBase(KnightsTour.CoreLibrary.IStorageHandler handler, string userName) : base(Enumerations.EntityName.Board, handler, userName)
        {
        }
        #endregion Constructor(s)

        #region Methods

        /// <summary>
        /// Inserts the Board and also checks to insert all the FK objects as well.
        /// </summary>
        /// <param name="board">The <see cref="Board"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public KnightsTour.CoreLibrary.IActionResponse InsertCascade(Board board)
        {
            KnightsTour.CoreLibrary.IActionResponse response = new KnightsTour.CoreLibrary.ActionResponse("Flat board insert");

            using (var transactionScope = new TransactionScope())
            {

                // Check to see if the board needs to be inserted.
                if (!board.SourceBoardId.HasValue && board.Board != null)
                {
                    response.Append(new BoardLogic(UserName).InsertCascade(board.Board));
                    if (!response.IsValid)
                    {
                        return response;
                    }
                    else
                    {
                        board.SourceBoardId = board.Board.BoardId;
                    }
                }

                // Insert the hydrated object.
                response.Append(new BoardLogic(UserName).Insert(board));

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
        /// Inserts the Board.
        /// </summary>
        /// <param name="board">The <see cref="Board"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public new KnightsTour.CoreLibrary.IActionResponse Insert(Board board)
        {
            // Configured insert defaults.
            board.BoardCode = Guid.NewGuid();
            board.DiscoveryDate = DateTime.Now;

            // Encryption requested on these field(s).

            // Call the base method.
            return base.Insert(board);
        }
        #endregion Methods

    } // Class
} // Namespace