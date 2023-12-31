// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 26, 2023 9:31:46 AM
// File             : MemberLogicBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Transactions;

namespace KnightsTour
{
    /// <summary>
    /// Base member logic support methods.  Implements both <seealso cref="KnightsTour.CoreLibrary.IRepository{T,TLite, TPk}" /> and <seealso cref="KnightsTour.CoreLibrary.IEntityLogic{T,TLite, TPk}" />
    /// Generated On: October 26, 2023 at 9:31:46 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class supports basic and extended CRUD access - agnostic to supporting both cache and direct database access.
    /// This class is abstract and is meant to only be inherited and accessed via <seealso cref="MemberLogic" /> class.
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    public abstract class MemberLogicBase : LogicBase<KnightsTour.Member, KnightsTour.MemberLite, int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the configured repository.
        /// </summary>
        /// <param name="userName">The user using this class.</param>
        /// <example>
        /// <code>
        /// MemberLogicBase MemberLogic = new MemberLogic(userName);
        /// </code>
        /// </example>
        public MemberLogicBase(string userName) : base(Enumerations.EntityName.Member, userName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the passed handler.
        /// </summary>
        /// <param name="handler">A storage handler.</param>
        /// <param name="userName">The user using this class.</param>
        public MemberLogicBase(KnightsTour.CoreLibrary.IStorageHandler handler, string userName) : base(Enumerations.EntityName.Member, handler, userName)
        {
        }
        #endregion Constructor(s)

        #region Methods

        /// <summary>
        /// Inserts the Member and also checks to insert all the FK objects as well.
        /// </summary>
        /// <param name="member">The <see cref="Member"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public KnightsTour.CoreLibrary.IActionResponse InsertCascade(Member member)
        {
            KnightsTour.CoreLibrary.IActionResponse response = new KnightsTour.CoreLibrary.ActionResponse("Flat member insert");

            using (var transactionScope = new TransactionScope())
            {

                // Insert the hydrated object.
                response.Append(new MemberLogic(UserName).Insert(member));

                // Complete the transaction if everything worked as expected with no errors.
                if (response.IsValid)
                {
                    transactionScope.Complete();
                }

            }

            // Return the response.
            return response;
        }

        /// <summary>
        /// Inserts the Member.
        /// </summary>
        /// <param name="member">The <see cref="Member"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public new KnightsTour.CoreLibrary.IActionResponse Insert(Member member)
        {
            // Configured insert defaults.
            member.CreateDate = DateTime.Now;
            member.IsAdministrator = false;

            // Encryption requested on these field(s).
            member.Password = Context.CryptographyHandler.Encrypt(member.Password);

            // Call the base method.
            return base.Insert(member);
        }

        /// <summary>
        /// Update the Member.
        /// </summary>
        /// <param name="member">The <see cref="Member"/> to update.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public new KnightsTour.CoreLibrary.IActionResponse Update(Member member)
        {
            // Configured update defaults.

            // Encryption requested on these field(s).
            member.Password = Context.CryptographyHandler.Encrypt(member.Password);

            // Call the base method.
            return base.Update(member);
        }
        #endregion Methods

    } // Class
} // Namespace