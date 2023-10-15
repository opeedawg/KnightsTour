// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:18:11 AM
// File             : EventTypeBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using KnightsTour.CoreLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KnightsTour
{
    /// <summary>
    /// The EventTypeBase class which tightly binds the model to the object.  Inherits <seealso cref="EventTypeLiteBase" /> and implements <seealso cref="KnightsTour.CoreLibrary.IEntity{T}" />
    /// Generated On: October 14, 2023 at 11:18:11 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// This class will be regenerated when requested to stay in sync with your model.
    /// This class should NOT be modified - any extensions or overrides should be completed in the extended class <seealso cref="EventType" />.
    /// </remarks>
    public abstract class EventTypeBase : EventTypeLiteBase, KnightsTour.CoreLibrary.IEntity<int?>
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class.
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class initialized with default properties.
        /// </summary>
        public EventTypeBase() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class.
        /// Initializes a new empty instance of the EventTypeBase class with the given primary key.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        public EventTypeBase(int? id)
        {
            Initialize();
            SetPrimaryKey(id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class.
        /// Initializes a new empty instance of the EventTypeBase class from the record in a data reader populating only the EventType columns specified.
        /// </summary>
        /// <param name="record">A record returned from a database reader.</param>
        /// <param name="columnsToInclude">A list of <see cref="Enumerations.EventTypeProperty"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public EventTypeBase(IDataRecord record, List<Enumerations.EventTypeProperty> columnsToInclude = null)
        {
            Initialize();

            // If not specified, default to all columns.
            if (columnsToInclude == null)
            {
                columnsToInclude = new List<Enumerations.EventTypeProperty>() { Enumerations.EventTypeProperty.All };
            }

            // Primary key must always be passed.
            EventTypeId = record.ValueAs<int?>("EventTypeId");
            if (columnsToInclude.Contains(Enumerations.EventTypeProperty.All) || columnsToInclude.Contains(Enumerations.EventTypeProperty.Name))
            {
                Name = record.ValueAs<string>("Name");
            }

            // Link the primary key to the base Id field.
            SetPrimaryKey(EventTypeId.Value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class.
        /// Initializes a new empty instance of the EventTypeBase class from a DataRow with the EventType columns specified.
        /// </summary>
        /// <param name="record">A <see cref="DataRow"/>.</param>
        /// <param name="columnsToInclude">A list of <see cref="Enumerations.EventTypeProperty"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public EventTypeBase(DataRow record, List<Enumerations.EventTypeProperty> columnsToInclude = null)
        {
            if (record != null)
            {
                Initialize();

                // If not specified, default to all columns.
                if (columnsToInclude == null)
                {
                    columnsToInclude = new List<Enumerations.EventTypeProperty>() { Enumerations.EventTypeProperty.All };
                }

                // Primary key must always be passed.
                EventTypeId = record.ValueAs<int?>("EventTypeId");
                if (columnsToInclude.Contains(Enumerations.EventTypeProperty.All) || columnsToInclude.Contains(Enumerations.EventTypeProperty.Name))
                {
                    Name = record.ValueAs<string>("Name");
                }

                // Link the primary key to the base Id field.
                SetPrimaryKey(EventTypeId.Value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class.
        /// Initializes a new empty instance of the EventTypeBase class from a DataRow with the EventType columns specified.
        /// </summary>
        /// <param name="eventTypeLite">A <see cref="EventTypeLite"/>.</param>
        public EventTypeBase(EventTypeLite eventTypeLite)
        {
            if (eventTypeLite != null)
            {
                Initialize();

                // Base properties.
                EventTypeId = eventTypeLite.EventTypeId.HasValue && eventTypeLite.EventTypeId.Value <= 0 ? null : eventTypeLite.EventTypeId;
                Name = eventTypeLite.Name;

                // Link the primary key to the base Id field.
                SetPrimaryKey(EventTypeId);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeBase"/> class.
        /// Initializes a new empty instance of the EventTypeBase class from a DataRow with the EventType columns specified.
        /// </summary>
        /// <param name="record">A dynamic Expando Object.</param>
        /// <param name="columnsToInclude">A list of <see cref="Enumerations.EventTypeProperty"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public EventTypeBase(ExpandoObject record, List<Enumerations.EventTypeProperty> columnsToInclude = null)
        {
            if (record != null)
            {
                IDictionary<string, object> recordAsDictionary = (IDictionary<string, object>)record;

                Initialize();

                // If not specified, default to all columns.
                if (columnsToInclude == null)
                {
                    columnsToInclude = new List<Enumerations.EventTypeProperty>() { Enumerations.EventTypeProperty.All };
                }
                else if (!columnsToInclude.Contains(Enumerations.EventTypeProperty.All))
                {
                    // Primary key must always be passed.
                    EventTypeId = recordAsDictionary.ValueAs<int?>("EventTypeId");
                }

                if (columnsToInclude.Contains(Enumerations.EventTypeProperty.All) || columnsToInclude.Contains(Enumerations.EventTypeProperty.Name))
                {
                    Name = recordAsDictionary.ValueAs<string>("Name");
                }

                // Link the primary key to the base Id field.
                SetPrimaryKey(EventTypeId.Value);
            }
        }
        #endregion Constructor(s)

        #region Declarations
        KnightsTour.CoreLibrary.IStorageHandler storageHandler = null; // Storage handler reference used for lazy loading.
        IEnumerable<KnightsTour.EventHistory> _eventHistories = null; // Private collection of child eventHistories references (by EventTypeId) used for graph hydration.  Lazy loaded if not initialized explicitly.
        #endregion Declarations

        #region Properties

        /// <summary>
        /// The override implementation of the base Id interface property.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public new int? Id
        {
            get
            {
                return EventTypeId;
            }
            set
            {
                EventTypeId = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of child eventHistories references (by EventTypeId) used for graph hydration.  Lazy loaded if not initialized explicitly.
        /// </summary>
        /// <value>
        /// The event histories.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public IEnumerable<KnightsTour.EventHistory> EventHistories
        {
            get
            {
                if (_eventHistories == null)
                {
                    _eventHistories = new List<EventHistory>();
                    if (!IsNew)
                    {
                        _eventHistories = new EventHistoryLogic(StorageHandler, UserName).GetByFK<int?>(EntityMapper.GetPropertyName(Enumerations.EventHistoryProperty.EventTypeId).ToString(), EventTypeId);
                    }
                }
                return _eventHistories;
            }
            set
            {
                _eventHistories = value;
            }
        }

        /// <summary>
        /// The primary key column for this entity.
        /// </summary>
        /// <value>
        /// The primary key.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public Enumerations.EventTypeProperty PrimaryKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the field validations.
        /// </summary>
        /// <value>
        /// The field validations.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public List<FieldValidator> FieldValidations
        {
            get;
            set;
        }

        /// <summary>
        /// The insert header for bulk SQL operations.
        /// </summary>
        /// <value>
        /// The s q l insert bulk header.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public string SQLInsertBulkHeader
        {
            get
            {
                if (PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.AutoIncrement)
                {
                    return $"INSERT INTO {StorageProvider.GetTableSQL(EntityMapper.EntityNameTransformation[EntityName], TableSchema)} ({StorageProvider.GetColumnSQL("Name")})";
                }
                else
                {
                    return $"INSERT INTO {StorageProvider.GetTableSQL(EntityMapper.EntityNameTransformation[EntityName], TableSchema)} ({StorageProvider.GetColumnSQL("EventTypeId")}, {StorageProvider.GetColumnSQL("Name")})";
                }
            }
        }

        /// <summary>
        /// The SQL safe insert row for bulk SQL operations.
        /// </summary>
        /// <value>
        /// The s q l insert bulk row.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public string SQLInsertBulkRow
        {
            get
            {
                if (PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.AutoIncrement)
                {
                    return $"({Name.SafeSQL()})";
                }
                else if (PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual)
                {
                    return $"({EventTypeId.SafeSQL()}, {Name.SafeSQL()})";
                }
                else if (PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Sequence)
                {
                    return $"({StorageProvider.GetTableSQL(EntityMapper.SequenceMapper[EntityName], TableSchema)}.NEXTVAL, {Name.SafeSQL()})";
                }
                else
                {
                    throw new Exception($"Unhandled PK Insert Configuration: {StorageHandler.PKInsertConfiguration.ToString()}");
                }
            }
        }

        /// <summary>
        /// The insert SQL statement for single records.
        /// </summary>
        /// <value>
        /// The s q l insert statement.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IStorageStatement SQLInsertStatement
        {
            get
            {
                KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement();

                if (KnightsTour.Context.UseStoredProcedureIntegration)
                {
                    statement.CommandType = System.Data.CommandType.StoredProcedure;
                    statement.Statement = GetStoredProcedureName(KnightsTour.CoreLibrary.Enumerations.StoredProcedureType.Insert);
                    statement.Parameters = new List<KnightsTour.CoreLibrary.IParameter>
                    {
                        new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}EventTypeId", GetDBValue(KnightsTour.Enumerations.EventTypeProperty.EventTypeId)),
                        new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}Name", GetDBValue(KnightsTour.Enumerations.EventTypeProperty.Name)),
                    };
                }
                else
                {
                    StringBuilder sql = new StringBuilder(SQLInsertBulkHeader);

                    sql.Append(" VALUES(");
                    foreach (Enumerations.EventTypePropertyNotComputed property in Enum.GetValues(typeof(Enumerations.EventTypePropertyNotComputed)))
                    {
                        if (property != Enumerations.EventTypePropertyNotComputed.All)
                        {
                            if (ConvertProperty(property) != PrimaryKey)
                            {
                                sql.Append($"{StorageProvider.GetParameterPrefix()}{property.ToString()}, ");
                                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter(StorageProvider.GetParameterPrefix() + property.ToString(), GetDBValue(property), GetDataType(property)));
                            }
                            else if (PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Sequence)
                            {
                                sql.Append($"{EntityMapper.GetSequenceName(EntityName)}.NEXTVAL, ");
                            }
                            else if (PKInsertConfiguration == KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual)
                            {
                                sql.Append($"{StorageProvider.GetParameterPrefix()}{property.ToString()}, ");
                                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter(StorageProvider.GetParameterPrefix() + property.ToString(), GetDBValue(property), GetDataType(property)));
                            }
                        }
                    }

                    // Remove the trailing comma and space.
                    sql = sql.Remove(sql.Length - 2, 2);
                    sql.Append(")");

                    statement.Statement = sql.ToString();
                }

                return statement;
            }
        }

        /// <summary>
        /// The update SQL statement for single records.
        /// </summary>
        /// <value>
        /// The s q l update statement.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IStorageStatement SQLUpdateStatement
        {
            get
            {
                KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement();

                if (KnightsTour.Context.UseStoredProcedureIntegration)
                {
                    statement.CommandType = System.Data.CommandType.StoredProcedure;
                    statement.Statement = GetStoredProcedureName(KnightsTour.CoreLibrary.Enumerations.StoredProcedureType.Update);
                    statement.Parameters = new List<KnightsTour.CoreLibrary.IParameter>
                    {
                        new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}EventTypeId", GetDBValue(KnightsTour.Enumerations.EventTypeProperty.EventTypeId)),
                        new KnightsTour.CoreLibrary.GenericParameter($"{StorageProvider.GetParameterPrefix()}Name", GetDBValue(KnightsTour.Enumerations.EventTypeProperty.Name)),
                    };
                }
                else
                {
                    StringBuilder sql = new StringBuilder($"UPDATE {StorageProvider.GetTableSQL(EntityMapper.EntityNameTransformation[EntityName], TableSchema)} SET ");

                    foreach (Enumerations.EventTypePropertyNotComputed property in Enum.GetValues(typeof(Enumerations.EventTypePropertyNotComputed)))
                    {
                        if (property != Enumerations.EventTypePropertyNotComputed.All)
                        {
                            if (IsModified(ConvertProperty(property)))
                            {
                                sql.Append($"{StorageProvider.GetColumnSQL(EntityMapper.GetPropertyName(ConvertProperty(property)))} = {StorageProvider.GetParameterPrefix()}{property.ToString()}, ");
                                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter(StorageProvider.GetParameterPrefix() + property.ToString(), GetDBValue(property), GetDataType(property)));
                            }
                        }
                    }

                    sql = sql.Remove(sql.Length - 2, 2); //Remove the trailing comma and space
                    sql.Append($" WHERE {StorageProvider.GetColumnSQL(PrimaryKeyField)} = {EventTypeId.SafeSQL()}");

                    statement.Statement = sql.ToString();
                }

                return statement;
            }
        }

        /// <summary>
        /// Gets or sets the initial state for this entity.
        /// </summary>
        /// <value>
        /// The initial state.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public EventTypeLiteBase InitialState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this EventType instance is new or not.
        /// </summary>
        /// <value>
        /// The is new.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public bool IsNew
        {
            get
            {
                return !EventTypeId.HasValue;
            }
        }

        /// <summary>
        /// Gets the related name of the actual database table.
        /// </summary>
        /// <value>
        /// The table name.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public string TableName
        {
            get
            {
                return EntityMapper.GetDbEntityName(EntityName);
            }
        }

        /// <summary>
        /// Gets the related name of the actual database schema.
        /// </summary>
        /// <value>
        /// The table schema.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public string TableSchema
        {
            get
            {
                return "dbo";
            }
        }

        /// <summary>
        /// Gets the primary key default value.
        /// </summary>
        /// <value>
        /// The p k default value.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public string PKDefaultValue
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Gets or sets the storage handler from the default configured source unless otherwise set.
        /// </summary>
        /// <value>
        /// The storage handler.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IStorageHandler StorageHandler
        {
            get
            {
                if (storageHandler == null)
                {
                    storageHandler = StorageProvider.GetHandler();
                }
                return storageHandler;
            }
            set
            {
                storageHandler = value;
            }
        }

        /// <summary>
        /// The configured label or label collection configured, or the PK number or (new) if a new record.
        /// </summary>
        /// <value>
        /// The instance label.
        /// </value>
        public string InstanceLabel
        {
            get
            {
                if (IsNew)
                {
                    return "(New)";
                }
                else
                {
                    return EventTypeId.Value.ToString();
                }
            }
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the object using the defined field validators.
        /// </summary>
        public KnightsTour.CoreLibrary.IActionResponse Validate()
        {
            return KnightsTour.Context.ValidationHandler.ValidateEntity<int?>(Enumerations.EntityName.EventType.ToString(), TableSchema, this, IsNew);
        }

        /// <summary>
        /// Sets the original properties (required for object state checking).
        /// </summary>
        public void SetOriginalProperties()
        {
            InitialState = new EventTypeLite(this);
        }

        /// <summary>
        /// Serializes the object based on the defined serialization strategy defined in the <seealso cref="AuditHandler" />.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string SerializeObject()
        {
            string objectSerialization = string.Empty;
            switch (KnightsTour.Context.AuditHandler.SerializationStrategy)
            {
                case KnightsTour.CoreLibrary.Enumerations.SerializationStrategy.XML:
                    objectSerialization = KnightsTour.CoreLibrary.XMLAssistant.Serialize(ToDynamic());
                    break;
                case KnightsTour.CoreLibrary.Enumerations.SerializationStrategy.JSON:
                    objectSerialization = ToDynamic().ToString();
                    break;
                default:
                    throw new NotImplementedException($"{KnightsTour.Context.AuditHandler.SerializationStrategy.ToString()} serialization strategy not implemented.");
            }
            return objectSerialization;
        }

        /// <summary>
        /// Serializes the object differential based on the defined serialization strategy defined in the <seealso cref="AuditHandler" />.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string SerializeDifferential()
        {
            string objectSerialization = string.Empty;
            switch (KnightsTour.Context.AuditHandler.SerializationStrategy)
            {
                case KnightsTour.CoreLibrary.Enumerations.SerializationStrategy.XML:
                    objectSerialization = KnightsTour.CoreLibrary.XMLAssistant.Serialize(ToDynamic(KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.ModifiedPropertiesOnly));
                    break;
                case KnightsTour.CoreLibrary.Enumerations.SerializationStrategy.JSON:
                    objectSerialization = ToDynamic(KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.ModifiedPropertiesOnly).ToString();
                    break;
                default:
                    throw new NotImplementedException($"{KnightsTour.Context.AuditHandler.SerializationStrategy.ToString()} serialization strategy not implemented.");
            }
            return objectSerialization;
        }

        /// <summary>
        /// Creates a dynamic object based on the passed <seealso cref="KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy" />.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns>dynamic.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public dynamic ToDynamic(KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy strategy = KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.AllProperties)
        {
            dynamic dynamicEventType = new JObject();
            switch (strategy)
            {
                case KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.AllProperties:
                    dynamicEventType.EventTypeId = EventTypeId;
                    dynamicEventType.Name = Name;
                    break;
                case KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.AllPropertiesWithOriginals:
                    dynamicEventType.EventTypeId = EventTypeId;
                    dynamicEventType.EventTypeId_Original = InitialState.EventTypeId;
                    dynamicEventType.Name = Name;
                    dynamicEventType.Name_Original = InitialState.Name;
                    break;
                case KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.ModifiedPropertiesOnly:
                    if (IsModified(Enumerations.EventTypeProperty.EventTypeId))
                    {
                        dynamicEventType.EventTypeId = EventTypeId;
                        dynamicEventType.EventTypeId_Original = InitialState.EventTypeId;
                    }
                    if (IsModified(Enumerations.EventTypeProperty.Name))
                    {
                        dynamicEventType.Name = Name;
                        dynamicEventType.Name_Original = InitialState.Name;
                    }
                    break;
                default:
                    throw new NotImplementedException($"{strategy.ToString()} strategy not implemented.");
            }
            return dynamicEventType;
        }

        /// <summary>
        /// Determines whether this instance is modified.
        /// </summary>
        /// <returns><c>true</c> if this instance is modified; otherwise, <c>false</c>.</returns>
        public bool IsModified()
        {
            foreach (Enumerations.EventTypeProperty property in Enum.GetValues(typeof(Enumerations.EventTypeProperty)))
            {
                if (property != Enumerations.EventTypeProperty.All)
                {
                    if (IsModified(property))
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified property is modified.
        /// </summary>
        /// <param name="property">The EventType property to test.</param>
        /// <returns><c>true</c> if the specified property is modified; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsModified(Enumerations.EventTypeProperty property)
        {
            switch (property)
            {
                case Enumerations.EventTypeProperty.EventTypeId:
                    return EventTypeId != InitialState.EventTypeId;
                case Enumerations.EventTypeProperty.Name:
                    return Name != InitialState.Name;
                case Enumerations.EventTypeProperty.All:
                    return IsModified();
                default:
                    throw new NotImplementedException($"{property.ToString()} property not implemented.");
            }
        }

        /// <summary>
        /// Initializes the properties of this class.
        /// </summary>
        public void Initialize()
        {
            MethodWrappers.CommonWrapper(baseInitialize, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { });
        }

        /// <summary>
        /// The privately wrapped implementation of the Initialize method.
        /// </summary>
        /// <param name="arguments">The generic arguments sent to this method from the public wrapped call.</param>
        private void baseInitialize(object[] arguments)
        {
            InitialState = new EventTypeLite();

            // Base Entity properties.
            EntityName = Enumerations.EntityName.EventType.ToString();
            PrimaryKey = Enumerations.EventTypeProperty.EventTypeId;
            PrimaryKeyField = EntityMapper.GetPropertyName(PrimaryKey);
            PrimaryKeyFieldFormatted = "EventTypeId";
            PKInsertConfiguration = KnightsTour.CoreLibrary.Enumerations.InsertPKRule.Manual;

            // Table properties.
            EventTypeId = null;
            Name = string.Empty;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A cloned EventType.</returns>
        public EventType Clone()
        {
            EventType eventType = new EventType();

            eventType.EventTypeId = EventTypeId;
            eventType.Name = Name;

            return eventType;
        }

        /// <summary>
        /// Returns a readable summary of this object.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string ToString()
        {
            return SerializeObject();
        }

        /// <summary>
        /// Converts a non computed property to a regular property.
        /// </summary>
        /// <param name="property">The non computed EventType property to convert.</param>
        /// <returns>The regular related property value.</returns>
        /// <exception cref="ArgumentException"></exception>
        private Enumerations.EventTypeProperty ConvertProperty(Enumerations.EventTypePropertyNotComputed property)
        {
            foreach (Enumerations.EventTypeProperty regularProperty in Enum.GetValues(typeof(Enumerations.EventTypeProperty)))
            {
                if (regularProperty.ToString() == property.ToString())
                {
                    return regularProperty;
                }
            }

            throw new Exception($"Unable to convert non computed property '{property.ToString()}' of type 'EventTypePropertyNotComputed' to a 'EventTypeProperty'.");
        }

        /// <summary>
        /// Returns the underlying object value.
        /// </summary>
        /// <param name="property">The not computed EventType property to test.</param>
        /// <returns>The dynamic underlying property value.</returns>
        /// <exception cref="ArgumentException"></exception>
        public dynamic GetDBValue(Enumerations.EventTypePropertyNotComputed property)
        {
            return GetDBValue(ConvertProperty(property));
        }

        /// <summary>
        /// Returns the underlying object data type for this language.
        /// </summary>
        /// <param name="property">The non computed EventType property to test.</param>
        /// <returns>The data type for this property.</returns>
        /// <exception cref="ArgumentException"></exception>
        private string GetDataType(Enumerations.EventTypePropertyNotComputed property)
        {
            return GetDataType(ConvertProperty(property));
        }

        /// <summary>
        /// Returns the underlying object value.
        /// </summary>
        /// <param name="property">The EventType property to test.</param>
        /// <returns>The dynamic underlying property value.</returns>
        /// <exception cref="ArgumentException"></exception>
        public dynamic GetDBValue(Enumerations.EventTypeProperty property)
        {
            switch (property)
            {
                case Enumerations.EventTypeProperty.EventTypeId:
                    if (EventTypeId == null) return DBNull.Value;
                    return EventTypeId;
                case Enumerations.EventTypeProperty.Name:
                    if (Name == null) return DBNull.Value;
                    return Name;
                default:
                    throw new ArgumentException($"Property {property.ToString()} unhandled.");
            }
        }

        /// <summary>
        /// Returns the underlying object data type for this language.
        /// </summary>
        /// <param name="property">The EventType property to test.</param>
        /// <returns>The data type for this property.</returns>
        /// <exception cref="ArgumentException"></exception>
        private string GetDataType(Enumerations.EventTypeProperty property)
        {
            switch (property)
            {
                case Enumerations.EventTypeProperty.EventTypeId:
                    return "int?";
                case Enumerations.EventTypeProperty.Name:
                    return "string";
                default:
                    throw new ArgumentException($"Property {property.ToString()} unhandled.");
            }
        }

        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="id">The EventTypes primary key value.</param>
        public void SetPrimaryKey(int? id)
        {
            EventTypeId = id;
            Id = id;
            SetOriginalProperties();
        }

        /// <summary>
        /// Updates the individual properties from the lite object.
        /// </summary>
        /// <param name="eventTypeLite">The EventTypeLite source object.</param>
        public void UpdateFromLite(EventTypeLite eventTypeLite)
        {
            // Do this first just to make sure.
            SetOriginalProperties();

            EventTypeId = eventTypeLite.EventTypeId;
            Name = eventTypeLite.Name;
        }

        /// <summary>
        /// Returns the stored procedure name (of a given type) or this class.
        /// </summary>
        /// <param name="type">The stored procedure type.</param>
        public string GetStoredProcedureName(KnightsTour.CoreLibrary.Enumerations.StoredProcedureType type)
        {
            string storedProcedureName = string.Empty;

            // The Stored procedure prefix (as defined on the model) is optional, deal with that first.
            if (!string.IsNullOrEmpty(Schema.Model.StoredProcedurePrefix))
            {
                storedProcedureName += $"{Schema.Model.StoredProcedurePrefix}_";
            }

            // Model prefix (optional), entity name then finally the type.
            if (string.IsNullOrEmpty(TableSchema))
            {
                return $"{storedProcedureName}{TextAssistant.PascalCase(OnlyAlpha(TableName, true))}_{type}";
            }
            else
            {
                return $"{TableSchema}.{storedProcedureName}{TextAssistant.PascalCase(OnlyAlpha(TableName, true))}_{type}";
            }
        }
        #endregion Methods

    } // Class
} // Namespace