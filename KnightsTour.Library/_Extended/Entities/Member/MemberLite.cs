// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 21, 2023 4:50:50 AM
// File             : MemberLite.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Represents a lite version of the <see cref="Member"/> object.
    /// Generated On: January 21, 2023 at 4:50:50 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Helpful for API's.
    /// You can Extended the lite object as you require.
    /// </remarks>
    public class MemberLite : MemberLiteBase, KnightsTour.CoreLibrary.IEntityLite<int?>
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLite"/> class.
        /// Initializes a new instance of the <see cref="MemberLite"/> class.
        /// </summary>
        /// <example>
        /// <code>
        /// MemberLite memberLite = new MemberLite();
        /// </code>
        /// </example>
        public MemberLite() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLite"/> class.
        /// Initializes a new instance of the <see cref="MemberLite"/> class from its full class representation.
        /// </summary>
        /// <param name="member">The <see cref="Member"/>.</param>
        /// <example>
        /// <code>
        /// MemberLite memberLite = new MemberLite(new MemberLogic.GetByPK(1));
        /// if (memberLite != null)
        /// {
        ///     Console.WriteLine(memberLite.ToString());
        /// }
        /// </code>
        /// </example>
        public MemberLite(Member member) : base(member)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLite"/> class.
        /// Initializes a new instance of the <see cref="MemberLite"/> class from its base class representation.
        /// </summary>
        /// <param name="memberBase">The <see cref="MemberBase"/>.</param>
        public MemberLite(MemberBase memberBase) : base(memberBase)
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