// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:55:34 AM
// File             : PuzzleExtensionsBase.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// The PuzzleLiteExtensionsBase class where common and useful extensions are placed.
    /// Generated On: October 21, 2023 at 9:55:34 AM by DXterity Solutions.
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
        /// Converts a <seealso cref="Puzzle" /> to its <seealso cref="PuzzleLite" /> representation.
        /// </summary>
        /// <param name="puzzle">The puzzle to convert.</param>
        /// <returns>A lite representation of the Puzzle entity.</returns>
        public static PuzzleLite ToLite(this Puzzle puzzle)
        {
            if (puzzle != null)
            {
                return new PuzzleLite(puzzle);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="Puzzle" /> to their <seealso cref="PuzzleLite" /> representations.
        /// </summary>
        /// <param name="puzzles">The puzzle collection to convert.</param>
        /// <returns>A collection of lite representations of the Puzzle entity collection.</returns>
        public static IEnumerable<PuzzleLite> ToLite(this IEnumerable<Puzzle> puzzles)
        {
            if (puzzles != null)
            {
                List<PuzzleLite> litePuzzles = new List<PuzzleLite>();
                foreach (Puzzle puzzle in puzzles)
                {
                    litePuzzles.Add(puzzle.ToLite());
                }
                return litePuzzles;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a <seealso cref="PuzzleLite" /> to its <seealso cref="Puzzle" /> representation.
        /// </summary>
        /// <param name="puzzleLite">The puzzle lite entity to convert.</param>
        /// <returns>A full representation of the PuzzleLite entity.</returns>
        public static Puzzle ToFull(this PuzzleLite puzzleLite)
        {
            if (puzzleLite != null)
            {
                return new Puzzle(puzzleLite);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="PuzzleLite" /> to their <seealso cref="Puzzle" /> representations.
        /// </summary>
        /// <param name="puzzleLites">The lite puzzle collection to convert.</param>
        /// <returns>A collection of full representations of the PuzzleLite entity collection.</returns>
        public static IEnumerable<Puzzle> ToFull(this IEnumerable<PuzzleLite> puzzleLites)
        {
            if (puzzleLites != null)
            {
                List<Puzzle> puzzles = new List<Puzzle>();
                foreach (PuzzleLite puzzleLite in puzzleLites)
                {
                    puzzles.Add(puzzleLite.ToFull());
                }
                return puzzles;
            }
            else
            {
                return null;
            }
        }
        #endregion Constructor(s)

    } // Class
} // Namespace