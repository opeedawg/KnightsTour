// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : PuzzleInputType.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    /// <summary>
    /// Graph QL input model mapping for puzzle.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    public class PuzzleInputType : InputObjectGraphType<KnightsTour.PuzzleLite>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleInputType"/> class.
        /// Type configuration for access to the Puzzle entity.
        /// </summary>
        /// <param name="data">The data model assiciated with the GraphQL Schema.</param>
        public PuzzleInputType(KnightsTourData data)
        {
            Name = "PuzzleInput";

            // Puzzle property mapping.
            Field(x => x.Id, nullable: true).Description("The unique primary key accessor of the puzzle.");
            Field(x => x.PuzzleId, nullable: true).Description("The primary key of the puzzle.");
            Field(x => x.PuzzleCode, type: typeof(IdGraphType)).Description("The puzzle code of the puzzle.");
            Field(x => x.BoardId, nullable: true).Description("The associated board id to the puzzle.");
            Field(x => x.DifficultyLevelId, nullable: true).Description("The associated difficulty level id to the puzzle.");
            Field(x => x.Path).Description("The path of the puzzle.");
            Field(x => x.PuzzleOfTheDayDate, nullable: true).Description("The puzzle of the day date of the puzzle.");
        }
        #endregion Constructor(s)

    } // Class
} // Namespace