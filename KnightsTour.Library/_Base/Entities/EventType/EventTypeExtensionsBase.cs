// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 26, 2023 9:31:46 AM
// File             : EventTypeExtensionsBase.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// The EventTypeLiteExtensionsBase class where common and useful extensions are placed.
    /// Generated On: October 26, 2023 at 9:31:46 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended extensions class provided.
    /// </remarks>
    public static partial class Extensions
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a <seealso cref="EventType" /> to its <seealso cref="EventTypeLite" /> representation.
        /// </summary>
        /// <param name="eventType">The event type to convert.</param>
        /// <returns>A lite representation of the EventType entity.</returns>
        public static EventTypeLite ToLite(this EventType eventType)
        {
            if (eventType != null)
            {
                return new EventTypeLite(eventType);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="EventType" /> to their <seealso cref="EventTypeLite" /> representations.
        /// </summary>
        /// <param name="eventTypes">The event type collection to convert.</param>
        /// <returns>A collection of lite representations of the EventType entity collection.</returns>
        public static IEnumerable<EventTypeLite> ToLite(this IEnumerable<EventType> eventTypes)
        {
            if (eventTypes != null)
            {
                List<EventTypeLite> liteEventTypes = new List<EventTypeLite>();
                foreach (EventType eventType in eventTypes)
                {
                    liteEventTypes.Add(eventType.ToLite());
                }
                return liteEventTypes;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a <seealso cref="EventTypeLite" /> to its <seealso cref="EventType" /> representation.
        /// </summary>
        /// <param name="eventTypeLite">The event type lite entity to convert.</param>
        /// <returns>A full representation of the EventTypeLite entity.</returns>
        public static EventType ToFull(this EventTypeLite eventTypeLite)
        {
            if (eventTypeLite != null)
            {
                return new EventType(eventTypeLite);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="EventTypeLite" /> to their <seealso cref="EventType" /> representations.
        /// </summary>
        /// <param name="eventTypeLites">The lite event type collection to convert.</param>
        /// <returns>A collection of full representations of the EventTypeLite entity collection.</returns>
        public static IEnumerable<EventType> ToFull(this IEnumerable<EventTypeLite> eventTypeLites)
        {
            if (eventTypeLites != null)
            {
                List<EventType> eventTypes = new List<EventType>();
                foreach (EventTypeLite eventTypeLite in eventTypeLites)
                {
                    eventTypes.Add(eventTypeLite.ToFull());
                }
                return eventTypes;
            }
            else
            {
                return null;
            }
        }
        #endregion Constructor(s)

    } // Class
} // Namespace