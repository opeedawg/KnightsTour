// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 26, 2023 9:31:46 AM
// File             : EventHistoryExtensionsBase.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// The EventHistoryLiteExtensionsBase class where common and useful extensions are placed.
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
        /// Converts a <seealso cref="EventHistory" /> to its <seealso cref="EventHistoryLite" /> representation.
        /// </summary>
        /// <param name="eventHistory">The event history to convert.</param>
        /// <returns>A lite representation of the EventHistory entity.</returns>
        public static EventHistoryLite ToLite(this EventHistory eventHistory)
        {
            if (eventHistory != null)
            {
                return new EventHistoryLite(eventHistory);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="EventHistory" /> to their <seealso cref="EventHistoryLite" /> representations.
        /// </summary>
        /// <param name="eventHistories">The event history collection to convert.</param>
        /// <returns>A collection of lite representations of the EventHistory entity collection.</returns>
        public static IEnumerable<EventHistoryLite> ToLite(this IEnumerable<EventHistory> eventHistories)
        {
            if (eventHistories != null)
            {
                List<EventHistoryLite> liteEventHistories = new List<EventHistoryLite>();
                foreach (EventHistory eventHistory in eventHistories)
                {
                    liteEventHistories.Add(eventHistory.ToLite());
                }
                return liteEventHistories;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a <seealso cref="EventHistoryLite" /> to its <seealso cref="EventHistory" /> representation.
        /// </summary>
        /// <param name="eventHistoryLite">The event history lite entity to convert.</param>
        /// <returns>A full representation of the EventHistoryLite entity.</returns>
        public static EventHistory ToFull(this EventHistoryLite eventHistoryLite)
        {
            if (eventHistoryLite != null)
            {
                return new EventHistory(eventHistoryLite);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extensions"/> class.
        /// Converts a collection of <seealso cref="EventHistoryLite" /> to their <seealso cref="EventHistory" /> representations.
        /// </summary>
        /// <param name="eventHistoryLites">The lite event history collection to convert.</param>
        /// <returns>A collection of full representations of the EventHistoryLite entity collection.</returns>
        public static IEnumerable<EventHistory> ToFull(this IEnumerable<EventHistoryLite> eventHistoryLites)
        {
            if (eventHistoryLites != null)
            {
                List<EventHistory> eventHistories = new List<EventHistory>();
                foreach (EventHistoryLite eventHistoryLite in eventHistoryLites)
                {
                    eventHistories.Add(eventHistoryLite.ToFull());
                }
                return eventHistories;
            }
            else
            {
                return null;
            }
        }
        #endregion Constructor(s)

    } // Class
} // Namespace