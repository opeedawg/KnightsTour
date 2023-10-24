// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:55:34 AM
// File             : EventHistoryLiteBase.cs
// ************************************************************************

using System;
using System.Xml;

namespace KnightsTour
{
    /// <summary>
    /// The EventHistoryLiteBase class which is the single place which defines the properties.  Inherits <seealso cref="KnightsTour.CoreLibrary.EntityBase{T}" />
    /// Generated On: October 21, 2023 at 9:55:34 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended class <seealso cref="EventHistoryLite" />.
    /// </remarks>
    public abstract class EventHistoryLiteBase : KnightsTour.CoreLibrary.EntityBase<int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHistoryLiteBase"/> class.
        /// Initializes a new instance of the <see cref="EventHistoryLiteBase"/> class.
        /// </summary>
        public EventHistoryLiteBase()
        {
            OnIdSet += EventHistoryLiteBase_OnIdSet;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHistoryLiteBase"/> class.
        /// Initializes a new instance of the <see cref="EventHistoryLite"/> class from its full class representation.
        /// </summary>
        /// <param name="eventHistoryBase">The <see cref="EventHistoryBase"/>.</param>
        public EventHistoryLiteBase(EventHistoryBase eventHistoryBase)
        {
            // Only do this if the object exists.
            if (eventHistoryBase != null)
            {
                OnIdSet += EventHistoryLiteBase_OnIdSet;
                EventHistoryId = eventHistoryBase.EventHistoryId;
                EventTypeId = eventHistoryBase.EventTypeId;
                EventDate = eventHistoryBase.EventDate;
                SourceInternetAddress = eventHistoryBase.SourceInternetAddress;
                Country = eventHistoryBase.Country;
                Region = eventHistoryBase.Region;
                City = eventHistoryBase.City;
                ZipPostal = eventHistoryBase.ZipPostal;
                Context = eventHistoryBase.Context;
                MemberId = eventHistoryBase.MemberId;

                // Also set the Id field.
                Id = this.EventHistoryId;
            }
        }
        #endregion Constructor(s)

        #region Declarations
        KnightsTour.EventTypeLite _eventTypeLite = null; // Private EventType (by EventTypeId) reference used for lite graph hydraion.  NOT lazy loaded.
        KnightsTour.MemberLite _memberLite = null; // Private Member (by MemberId) reference used for lite graph hydraion.  NOT lazy loaded.
        #endregion Declarations

        #region Properties

        /// <summary>
        /// Gets or sets the related EventTypeLite (by EventTypeId) entity reference.  Never lazy loaded.
        /// </summary>
        /// <value>
        /// The event type.
        /// </value>
        public KnightsTour.EventTypeLite EventType
        {
            get
            {
                return _eventTypeLite;
            }
            set
            {
                _eventTypeLite = value;
            }
        }

        /// <summary>
        /// Gets or sets the related MemberLite (by MemberId) entity reference.  Never lazy loaded.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public KnightsTour.MemberLite Member
        {
            get
            {
                return _memberLite;
            }
            set
            {
                _memberLite = value;
            }
        }

        /// <summary>
        /// Gets or sets the primary key field event history id.
        /// </summary>
        /// <value>
        /// The event history id.
        /// </value>
        public int? EventHistoryId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event type id.
        /// </summary>
        /// <value>
        /// The event type id.
        /// </value>
        public int? EventTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public DateTime EventDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source internet address.
        /// </summary>
        /// <value>
        /// The source internet address.
        /// </value>
        public string SourceInternetAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public string Region
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the zip postal.
        /// </summary>
        /// <value>
        /// The zip postal.
        /// </value>
        public string ZipPostal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public string Context
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the member id.
        /// </summary>
        /// <value>
        /// The member id.
        /// </value>
        public int? MemberId
        {
            get;
            set;
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Invoked when the generic Id field of this class is modified (set).
        /// </summary>
        private void EventHistoryLiteBase_OnIdSet()
        {
            EventHistoryId = Id;
        }
        #endregion Methods

    } // Class
} // Namespace