// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : SolutionType.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    /// <summary>
    /// Graph QL model mapping for solution.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    public class SolutionType : ObjectGraphType<KnightsTour.Solution>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionType"/> class.
        /// Type configuration for access to the Solution entity.
        /// </summary>
        /// <param name="data">The data model associated with the GraphQL Schema.</param>
        public SolutionType(KnightsTourData data)
        {
            Name = "Solution";
            Description = "The GraphQL class that maps and exposes properties and references from the KnightsTour.Solution entity.";

            // Solution property mapping.
            Field(x => x.Id, nullable: true).Description("The unique primary key accessor of the solution.");
            Field(x => x.SolutionId, nullable: true).Description("The primary key of the solution.");
            Field(x => x.PuzzleId, nullable: true).Description("The associated puzzle id to the solution.");
            Field(x => x.MemberId, nullable: true).Description("The associated member id to the solution.");
            Field(x => x.SolutionStartDate).Description("The solution start date of the solution.");
            Field(x => x.SolutionDuration, nullable: true).Description("The solution duration of the solution.");
            Field(x => x.Path, nullable: true).Description("The path of the solution.");
            Field(x => x.Note, nullable: true).Description("The note of the solution.");
            Field(x => x.Code).Description("The code of the solution.");
            Field(x => x.NonMemberName, nullable: true).Description("The non member name of the solution.");
            Field(x => x.NonMemberIp, nullable: true).Description("The non member ip of the solution.");
            Field(x => x.SolutionStartDateFormatted).Description("The solution formatted as a date using the defined custom or default date format.");
            Field(x => x.SolutionDurationAsCurrency).Description("The solution formatted in a custom or default currency format.");

            // Foreign key reference mapping.
            Field<PuzzleType>("puzzle", "The associated puzzle reference (if it exists otherwise null) to this solution.", resolve: context => data.GetPuzzleByIdAsync(context.Source.PuzzleId));
            Field<MemberType>("member", "The associated member reference (if it exists otherwise null) to this solution.", resolve: context => data.GetMemberByIdAsync(context.Source.MemberId));
        }
        #endregion Constructor(s)

    } // Class
} // Namespace