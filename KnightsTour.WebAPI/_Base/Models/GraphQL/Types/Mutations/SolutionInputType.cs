// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : SolutionInputType.cs
// ************************************************************************

using GraphQL.Types;

namespace WebAPI.GraphQL.Types
{
    /// <summary>
    /// Graph QL input model mapping for solution.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    public class SolutionInputType : InputObjectGraphType<KnightsTour.SolutionLite>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionInputType"/> class.
        /// Type configuration for access to the Solution entity.
        /// </summary>
        /// <param name="data">The data model assiciated with the GraphQL Schema.</param>
        public SolutionInputType(KnightsTourData data)
        {
            Name = "SolutionInput";

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
        }
        #endregion Constructor(s)

    } // Class
} // Namespace