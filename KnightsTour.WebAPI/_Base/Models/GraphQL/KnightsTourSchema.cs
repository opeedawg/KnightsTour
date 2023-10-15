// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 10:21:15 AM
// File             : KnightsTourSchema.cs
// ************************************************************************

using GraphQL;
using GraphQL.Types;
using WebAPI.GraphQL;

namespace WebAPI.GraphQL
{
    /// <summary>
    /// GraphQL query model.
    /// Generated On: October 14, 2023 at 10:21:15 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    public class KnightsTourSchema : Schema
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="KnightsTourSchema"/> class.
        /// Schema configuration for KnightsTour.
        /// </summary>
        /// <param name="resolver">The resolver assiciated with the GraphQL dependency injection.</param>
        public KnightsTourSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<KnightsTourQuery>();
            Mutation = resolver.Resolve<KnightsTourMutation>();
        }
        #endregion Constructor(s)

    } // Class
} // Namespace