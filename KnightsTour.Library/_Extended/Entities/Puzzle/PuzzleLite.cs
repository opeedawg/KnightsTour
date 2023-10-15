// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 13, 2023 7:25:01 AM
// File             : PuzzleLite.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Represents a lite version of the <see cref="Puzzle"/> object.
    /// Generated On: January 13, 2023 at 7:25:01 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Helpful for API's.
    /// You can Extended the lite object as you require.
    /// </remarks>
    public class PuzzleLite : PuzzleLiteBase, KnightsTour.CoreLibrary.IEntityLite<int?>
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleLite"/> class.
        /// Initializes a new instance of the <see cref="PuzzleLite"/> class.
        /// </summary>
        /// <example>
        /// <code>
        /// PuzzleLite puzzleLite = new PuzzleLite();
        /// </code>
        /// </example>
        public PuzzleLite() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleLite"/> class.
        /// Initializes a new instance of the <see cref="PuzzleLite"/> class from its full class representation.
        /// </summary>
        /// <param name="puzzle">The <see cref="Puzzle"/>.</param>
        /// <example>
        /// <code>
        /// PuzzleLite puzzleLite = new PuzzleLite(new PuzzleLogic.GetByPK(1));
        /// if (puzzleLite != null)
        /// {
        ///     Console.WriteLine(puzzleLite.ToString());
        /// }
        /// </code>
        /// </example>
        public PuzzleLite(Puzzle puzzle) : base(puzzle)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleLite"/> class.
        /// Initializes a new instance of the <see cref="PuzzleLite"/> class from its base class representation.
        /// </summary>
        /// <param name="puzzleBase">The <see cref="PuzzleBase"/>.</param>
        public PuzzleLite(PuzzleBase puzzleBase) : base(puzzleBase)
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