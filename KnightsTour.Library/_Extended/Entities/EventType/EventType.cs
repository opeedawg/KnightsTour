// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 21, 2023 4:50:50 AM
// File             : EventType.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;

namespace KnightsTour
{
    /// <summary>
    /// The extended EventType object.
    /// Generated On: January 21, 2023 at 4:50:50 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Feel free to add properties as you see fit here.
    /// In general operations against or for EventTypes should be placed in the EventTypeLogic class.
    /// The exception to this suggestion is overriding base methods (Initialize is a common example)
    /// e.g. public new void Initialize(){ base.Initialize(); }
    /// </remarks>
    public class EventType : EventTypeBase
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class.
        /// </summary>
        /// <example>
        /// <code>
        /// EventType eventType = new EventType();
        /// </code>
        /// </example>
        public EventType() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class with the given primary key.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        /// <example>
        /// <code>
        /// EventType eventType = new EventType(1);
        /// </code>
        /// </example>
        public EventType(int? id) : base(id)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class from the record in a data reader.
        /// </summary>
        /// <param name="record">A record returned from a database reader.</param>
        public EventType(IDataRecord record) : base(record, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class from the record in a data reader populating only the EventType columns specified.
        /// </summary>
        /// <param name="record">A record returned from a database reader.</param>
        /// <param name="columnsToInclude">A list of <see cref="Enumerations.EventTypeProperty"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public EventType(IDataRecord record, List<Enumerations.EventTypeProperty> columnsToInclude = null) : base(record, columnsToInclude)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class from a DataRow (via a <see cref="DataTable" /> usually part of a larger <see cref="DataSet" />).
        /// </summary>
        /// <param name="record">The <see cref="DataRow" />.</param>
        public EventType(DataRow record) : base(record, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class from a DataRow (via a <see cref="DataTable" /> usually part of a larger <see cref="DataSet" />) populating only the EventType columns specified.
        /// </summary>
        /// <param name="record">The <see cref="DataRow" />.</param>
        /// <param name="columnsToInclude">A list of <see cref="Enumerations.EventTypeProperty"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public EventType(DataRow record, List<Enumerations.EventTypeProperty> columnsToInclude = null) : base(record, columnsToInclude)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// Initializes a new empty instance of the EventType class from the lite version of the EventType entity.
        /// </summary>
        /// <param name="eventTypeLite">An object representing the lite version of the EventType.</param>
        public EventType(EventTypeLite eventTypeLite) : base(eventTypeLite)
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