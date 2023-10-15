// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 21, 2023 4:50:50 AM
// File             : EventTypeLite.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Represents a lite version of the <see cref="EventType"/> object.
    /// Generated On: January 21, 2023 at 4:50:50 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Helpful for API's.
    /// You can Extended the lite object as you require.
    /// </remarks>
    public class EventTypeLite : EventTypeLiteBase, KnightsTour.CoreLibrary.IEntityLite<int?>
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeLite"/> class.
        /// Initializes a new instance of the <see cref="EventTypeLite"/> class.
        /// </summary>
        /// <example>
        /// <code>
        /// EventTypeLite eventTypeLite = new EventTypeLite();
        /// </code>
        /// </example>
        public EventTypeLite() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeLite"/> class.
        /// Initializes a new instance of the <see cref="EventTypeLite"/> class from its full class representation.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <example>
        /// <code>
        /// EventTypeLite eventTypeLite = new EventTypeLite(new EventTypeLogic.GetByPK(1));
        /// if (eventTypeLite != null)
        /// {
        ///     Console.WriteLine(eventTypeLite.ToString());
        /// }
        /// </code>
        /// </example>
        public EventTypeLite(EventType eventType) : base(eventType)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeLite"/> class.
        /// Initializes a new instance of the <see cref="EventTypeLite"/> class from its base class representation.
        /// </summary>
        /// <param name="eventTypeBase">The <see cref="EventTypeBase"/>.</param>
        public EventTypeLite(EventTypeBase eventTypeBase) : base(eventTypeBase)
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