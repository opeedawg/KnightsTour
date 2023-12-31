// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 26, 2023 9:31:46 AM
// File             : BoardExtensionsBase.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// The BoardLiteExtensionsBase class where common and useful extensions are placed.
    /// Generated On: October 26, 2023 at 9:31:46 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended extensions class provided.
    /// </remarks>
    public static partial class Extensions
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a <seealso cref="Board" /> to its <seealso cref="BoardLite" /> representation.
        /// </summary>
        /// <param name="board">The board to convert.</param>
        /// <returns>A lite representation of the Board entity.</returns>
        public static BoardLite ToLite(this Board board)
        {
            if (board != null)
            {
                return new BoardLite(board);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="Board" /> to their <seealso cref="BoardLite" /> representations.
        /// </summary>
        /// <param name="boards">The board collection to convert.</param>
        /// <returns>A collection of lite representations of the Board entity collection.</returns>
        public static IEnumerable<BoardLite> ToLite(this IEnumerable<Board> boards)
        {
            if (boards != null)
            {
                List<BoardLite> liteBoards = new List<BoardLite>();
                foreach (Board board in boards)
                {
                    liteBoards.Add(board.ToLite());
                }
                return liteBoards;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a <seealso cref="BoardLite" /> to its <seealso cref="Board" /> representation.
        /// </summary>
        /// <param name="boardLite">The board lite entity to convert.</param>
        /// <returns>A full representation of the BoardLite entity.</returns>
        public static Board ToFull(this BoardLite boardLite)
        {
            if (boardLite != null)
            {
                return new Board(boardLite);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="BoardLite" /> to their <seealso cref="Board" /> representations.
        /// </summary>
        /// <param name="boardLites">The lite board collection to convert.</param>
        /// <returns>A collection of full representations of the BoardLite entity collection.</returns>
        public static IEnumerable<Board> ToFull(this IEnumerable<BoardLite> boardLites)
        {
            if (boardLites != null)
            {
                List<Board> boards = new List<Board>();
                foreach (BoardLite boardLite in boardLites)
                {
                    boards.Add(boardLite.ToFull());
                }
                return boards;
            }
            else
            {
                return null;
            }
        }
        #endregion Constructor(s)

    } // Class
} // Namespace