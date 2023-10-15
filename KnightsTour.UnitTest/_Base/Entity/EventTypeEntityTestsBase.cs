// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : EventTypeEntityTestsBase.cs
// ************************************************************************

using System;

using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnightsTourUnitTests.Entity
{
    /// <summary>
    /// Tests against the EventType Entity.  Inherits <seealso cref="BaseDataTest" />
    /// Generated On: March 19, 2023 at 7:56:06 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// </remarks>
    [TestClass]
    public class EventTypeEntityTestsBase : DataTestBase<int?>
    {
        #region EventType entity tests Methods

        /// <summary>
        /// Description for Event Type_ Constructor.
        /// </summary>
        [TestMethod]
        public void EventType_Constructor()
        {
            Entity_Constructor<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Constructor_ Id.
        /// </summary>
        [TestMethod]
        public void EventType_Constructor_Id()
        {
            Entity_Constructor_Id<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Constructor_ I Data Record.
        /// </summary>
        [TestMethod]
        public void EventType_Constructor_IDataRecord()
        {
            Entity_Constructor_IDataRecord<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Constructor_ Data Row.
        /// </summary>
        [TestMethod]
        public void EventType_Constructor_DataRow()
        {
            Entity_Constructor_DataRow<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Constructor_ Lite.
        /// </summary>
        [TestMethod]
        public void EventType_Constructor_Lite()
        {
            Entity_Constructor_Lite<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Constructor_ Dynamic.
        /// </summary>
        [TestMethod]
        public void EventType_Constructor_Dynamic()
        {
            Entity_Constructor_Dynamic<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Clone.
        /// </summary>
        [TestMethod]
        public void EventType_Clone()
        {
            Entity_Clone<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ To String.
        /// </summary>
        [TestMethod]
        public void EventType_ToString()
        {
            Entity_ToString<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Is Modified.
        /// </summary>
        [TestMethod]
        public void EventType_IsModified()
        {
            Entity_IsModified<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Lite_ Constructor.
        /// </summary>
        [TestMethod]
        public void EventType_Lite_Constructor()
        {
            Entity_Lite_Constructor<KnightsTour.EventType, KnightsTour.EventTypeLite>();
        }

        /// <summary>
        /// Description for Event Type_ Is Modified Property.
        /// </summary>
        [TestMethod]
        public void EventType_IsModifiedProperty()
        {
            // Parameter 1: The related Properties.
            // Parameter 2: an object[] of 2 KnightsTour.EventTypeProperties.
            // The first MUST BE the primary key field property.
            // The second can be anything BUT the primary key field property.
            Entity_IsModifiedProperty<KnightsTour.EventType, KnightsTour.EventTypeLite>(
                typeof(KnightsTour.Enumerations.EventTypeProperty),
                new object[] { KnightsTour.Enumerations.EventTypeProperty.EventTypeId, KnightsTour.Enumerations.EventTypeProperty.Name }
            );
        }
        #endregion EventType entity tests Methods

    } // Class
} // Namespace