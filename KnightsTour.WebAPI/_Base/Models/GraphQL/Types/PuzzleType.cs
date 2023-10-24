// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : PuzzleType.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    /// <summary>
    /// Graph QL model mapping for puzzle.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    public class PuzzleType : ObjectGraphType<KnightsTour.Puzzle>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleType"/> class.
        /// Type configuration for access to the Puzzle entity.
        /// </summary>
        /// <param name="data">The data model associated with the GraphQL Schema.</param>
        public PuzzleType(KnightsTourData data)
        {
            Name = "Puzzle";
            Description = "The GraphQL class that maps and exposes properties and references from the KnightsTour.Puzzle entity.";

            // Puzzle property mapping.
            Field(x => x.Id, nullable: true).Description("The unique primary key accessor of the puzzle.");
            Field(x => x.PuzzleId, nullable: true).Description("The primary key of the puzzle.");
            Field(x => x.PuzzleCode, type: typeof(IdGraphType)).Description("The puzzle code of the puzzle.");
            Field(x => x.BoardId, nullable: true).Description("The associated board id to the puzzle.");
            Field(x => x.DifficultyLevelId, nullable: true).Description("The associated difficulty level id to the puzzle.");
            Field(x => x.Path).Description("The path of the puzzle.");
            Field(x => x.PuzzleOfTheDayDate, nullable: true).Description("The puzzle of the day date of the puzzle.");
            Field(x => x.PuzzleOfTheDayDateFormatted).Description("The puzzle formatted as a date using the defined custom or default date format.");

            // Foreign key reference mapping.
            Field<BoardType>("board", "The associated board reference (if it exists otherwise null) to this puzzle.", resolve: context => data.GetBoardByIdAsync(context.Source.BoardId));
            Field<DifficultyLevelType>("difficultyLevel", "The associated difficulty level reference (if it exists otherwise null) to this puzzle.", resolve: context => data.GetDifficultyLevelByIdAsync(context.Source.DifficultyLevelId));

            // Child relationship reference mapping.
            Field<ListGraphType<SolutionType>>("solutions", "A collection of child solutions that reference this puzzle.", resolve: context => context.Source.Solutions);
        }
        #endregion Constructor(s)

    } // Class
} // Namespace