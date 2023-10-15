// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 13, 2023 7:25:01 AM
// File             : BoardLite.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Represents a lite version of the <see cref="Board"/> object.
    /// Generated On: January 13, 2023 at 7:25:01 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Helpful for API's.
    /// You can Extended the lite object as you require.
    /// </remarks>
    public class BoardLite : BoardLiteBase, KnightsTour.CoreLibrary.IEntityLite<int?>
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardLite"/> class.
        /// Initializes a new instance of the <see cref="BoardLite"/> class.
        /// </summary>
        /// <example>
        /// <code>
        /// BoardLite boardLite = new BoardLite();
        /// </code>
        /// </example>
        public BoardLite() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardLite"/> class.
        /// Initializes a new instance of the <see cref="BoardLite"/> class from its full class representation.
        /// </summary>
        /// <param name="board">The <see cref="Board"/>.</param>
        /// <example>
        /// <code>
        /// BoardLite boardLite = new BoardLite(new BoardLogic.GetByPK(1));
        /// if (boardLite != null)
        /// {
        ///     Console.WriteLine(boardLite.ToString());
        /// }
        /// </code>
        /// </example>
        public BoardLite(Board board) : base(board)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardLite"/> class.
        /// Initializes a new instance of the <see cref="BoardLite"/> class from its base class representation.
        /// </summary>
        /// <param name="boardBase">The <see cref="BoardBase"/>.</param>
        public BoardLite(BoardBase boardBase) : base(boardBase)
        {
        }
        #endregion Extended Constructor(s)

        #region Extended Declarations
        #endregion Extended Declarations

        #region Extended Properties
        #endregion Extended Properties

        #region Extended Methods
        #endregion Extended Methods

    } // Class
} // Namespace