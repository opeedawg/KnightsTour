// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 10:21:15 AM
// File             : DifficultyLevelInputType.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    /// <summary>
    /// Graph QL input model mapping for difficulty level.
    /// Generated On: October 14, 2023 at 10:21:15 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    public class DifficultyLevelInputType : InputObjectGraphType<KnightsTour.DifficultyLevelLite>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="DifficultyLevelInputType"/> class.
        /// Type configuration for access to the DifficultyLevel entity.
        /// </summary>
        /// <param name="data">The data model assiciated with the GraphQL Schema.</param>
        public DifficultyLevelInputType(KnightsTourData data)
        {
            Name = "DifficultyLevelInput";

            // DifficultyLevel property mapping.
            Field(x => x.Id, nullable: true).Description("The unique primary key accessor of the difficulty level.");
            Field(x => x.DifficultyLevelId, nullable: true).Description("The primary key of the difficulty level.");
            Field(x => x.Name).Description("The name of the difficulty level.");
            Field(x => x.Description).Description("The description of the difficulty level.");
            Field(x => x.MaximumGap).Description("The maximum gap of the difficulty level.");
            Field(x => x.PercentVisibility).Description("The percent visibility of the difficulty level.");
            Field(x => x.HighlightClosestEnabled).Description("The highlight closest enabled of the difficulty level.");
            Field(x => x.DuplicateCheckingEnabled).Description("The duplicate checking enabled of the difficulty level.");
            Field(x => x.GuessFilterEnabled).Description("The guess filter enabled of the difficulty level.");
            Field(x => x.BadLinkEnabled).Description("The bad link enabled of the difficulty level.");
            Field(x => x.MaximumDimension).Description("The maximum dimension of the difficulty level.");
            Field(x => x.MinimumDimension).Description("The minimum dimension of the difficulty level.");
        }
        #endregion Constructor(s)

    } // Class
} // Namespace