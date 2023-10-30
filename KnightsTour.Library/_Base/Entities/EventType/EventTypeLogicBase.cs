// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 26, 2023 9:31:46 AM
// File             : EventTypeLogicBase.cs
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
    /// Base eventType logic support methods.  Implements both <seealso cref="KnightsTour.CoreLibrary.IRepository{T,TLite, TPk}" /> and <seealso cref="KnightsTour.CoreLibrary.IEntityLogic{T,TLite, TPk}" />
    /// Generated On: October 26, 2023 at 9:31:46 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class supports basic and extended CRUD access - agnostic to supporting both cache and direct database access.
    /// This class is abstract and is meant to only be inherited and accessed via <seealso cref="EventTypeLogic" /> class.
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    public abstract class EventTypeLogicBase : LogicBase<KnightsTour.EventType, KnightsTour.EventTypeLite, int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the configured repository.
        /// </summary>
        /// <param name="userName">The user using this class.</param>
        /// <example>
        /// <code>
        /// EventTypeLogicBase EventTypeLogic = new EventTypeLogic(userName);
        /// </code>
        /// </example>
        public EventTypeLogicBase(string userName) : base(Enumerations.EntityName.EventType, userName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeLogicBase"/> class.
        /// Instantiates a new generic LogicBase class using the passed handler.
        /// </summary>
        /// <param name="handler">A storage handler.</param>
        /// <param name="userName">The user using this class.</param>
        public EventTypeLogicBase(KnightsTour.CoreLibrary.IStorageHandler handler, string userName) : base(Enumerations.EntityName.EventType, handler, userName)
        {
        }
        #endregion Constructor(s)

        #region Methods

        /// <summary>
        /// Inserts the EventType and also checks to insert all the FK objects as well.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/> to insert.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public KnightsTour.CoreLibrary.IActionResponse InsertCascade(EventType eventType)
        {
            KnightsTour.CoreLibrary.IActionResponse response = new KnightsTour.CoreLibrary.ActionResponse("Flat event type insert");

            using (var transactionScope = new TransactionScope())
            {

                // Insert the hydrated object.
                response.Append(new EventTypeLogic(UserName).Insert(eventType));

                // Complete the transaction if everything worked as expected with no errors.
                if (response.IsValid)
                {
                    transactionScope.Complete();
                }

            }

            // Return the response.
            return response;
        }
        #endregion Methods

    } // Class
} // Namespace