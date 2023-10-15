// © 2023 DXterity Solutions
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : DummyClass.cs
// ************************************************************************

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;
using System.Xml.Serialization;
using KnightsTour;

namespace KnightsTourUnitTests
{
    public class DummyClass : DummyClassBase
    {
        #region Constructors
        /// <summary>
        /// Creates a new blank Dummy entity.
        /// </summary>
        public DummyClass() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dummy"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DummyClass(int id) : base(id)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dummy" /> class.
        /// </summary>
        /// <param name="record">The <see cref="IDataRecord" />.</param>
        /// <param name="columnsToInclude">A list of <see cref="DummyProperties"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public DummyClass(IDataRecord record, List<DummyClassProperties> columnsToInclude = null) : base(record, columnsToInclude)
        {
        }
        /// <summary>
        /// Creates an Dummy from a IDataRecord
        /// </summary>
        /// <param name="record"></param>
        public DummyClass(IDataRecord record) : base(record, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dummy"/> class.
        /// </summary>
        /// <param name="record">The <see cref="DataRow" />.</param>
        public DummyClass(DataRow record) : base(record, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dummy"/> class.
        /// </summary>
        /// <param name="record">The <see cref="DataRow" />.</param>
        /// <param name="columnsToInclude">A list of <see cref="DummyProperties"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public DummyClass(DataRow record, List<DummyClassProperties> columnsToInclude = null) : base(record, columnsToInclude)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Dummy"/> class.
        /// </summary>
        /// <param name="lite">The <see cref="DummyLite" />.</param>
        public DummyClass(DummyClassLite lite) : base(lite)
        {
        }
        #endregion
    }
    public class DummyClassLite : KnightsTour.CoreLibrary.EntityBase<int?>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClassLite"/> class.
        /// </summary>
        public DummyClassLite()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClassLite"/> class.
        /// </summary>
        /// <param name="baseClass">The <see cref="DummyClassBase"/>.</param>
        public DummyClassLite(DummyClassBase baseClass)
        {
            //Only do this if the object exists
            if (baseClass != null)
            {
                PK = baseClass.PK;
                Description = baseClass.Description;
                FK1 = baseClass.FK1;
                FK2 = baseClass.FK2;
                CreateDate = baseClass.CreateDate;
                Description = baseClass.Description;
                NullableDateTime = baseClass.NullableDateTime;
                SomeFlag = baseClass.SomeFlag;
                Amount = baseClass.Amount;
            }
        }
        #endregion

        #region Properties
        public int? PK { get; set; }
        public string Description { get; set; }
        public int? FK1 { get; set; }
        public int? FK2 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? NullableDateTime { get; set; }
        public decimal Amount { get; set; }
        public bool SomeFlag { get; set; }
        #endregion
    }
    public class DummyClassBase : DummyClassLite, KnightsTour.CoreLibrary.IEntity<int?>
    {
        #region Constructors
        /// <summary>
        /// Creates a blank DummyClass object initialized with default properties.
        /// </summary>
        public DummyClassBase() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClass"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DummyClassBase(int id)
        {
            Initialize();
            SetPrimaryKey(id);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClass" /> class.
        /// </summary>
        /// <param name="record">The <see cref="IDataRecord" />.</param>
        /// <param name="columnsToInclude">A list of <see cref="DummyClassProperties"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public DummyClassBase(IDataRecord record, List<DummyClassProperties> columnsToInclude = null)
        {
            Initialize();

            if (columnsToInclude == null)
                columnsToInclude = new List<DummyClassProperties>() { DummyClassProperties.All };

            //Primary key must always be passed.
            PK = record.ValueAs<int?>("PK");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.Amount))
                Amount = record.ValueAs<decimal>("Amount");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.CreateDate))
                CreateDate = record.ValueAs<DateTime>("CreateDate");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.Description))
                Description = record.ValueAs<string>("Description");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.FK1))
                FK1 = record.ValueAs<int>("FK1");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.FK2))
                FK2 = record.ValueAs<int>("FK2");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.NullableDateTime))
                NullableDateTime = record.ValueAs<DateTime?>("NullableDateTime");
            if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.SomeFlag))
                SomeFlag = record.ValueAs<bool>("SomeFlag");

            SetPrimaryKey(PK.Value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClass"/> class.
        /// </summary>
        /// <param name="record">The <see cref="DataRow" />.</param>
        /// <param name="columnsToInclude">A list of <see cref="DummyClassProperties"/> if you want a sub set of properties populated.  Defaulted to null which will be translated to mean no filter and return all properties.</param>
        public DummyClassBase(DataRow record, List<DummyClassProperties> columnsToInclude = null)
        {
            if (record != null)
            {
                Initialize();

                if (columnsToInclude == null)
                    columnsToInclude = new List<DummyClassProperties>() { DummyClassProperties.All };

                //Primary key must always be passed.
                PK = record.ValueAs<int?>("PK");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.Amount))
                    Amount = record.ValueAs<decimal>("Amount");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.CreateDate))
                    CreateDate = record.ValueAs<DateTime>("CreateDate");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.Description))
                    Description = record.ValueAs<string>("Description");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.FK1))
                    FK1 = record.ValueAs<int>("FK1");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.FK2))
                    FK2 = record.ValueAs<int>("FK2");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.NullableDateTime))
                    NullableDateTime = record.ValueAs<DateTime?>("NullableDateTime");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.SomeFlag))
                    SomeFlag = record.ValueAs<bool>("SomeFlag");

                SetPrimaryKey(PK.Value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClass"/> class.
        /// </summary>
        /// <param name="lite">The <see cref="DummyClassLite" />.</param>
        public DummyClassBase(DummyClassLite lite)
        {
            if (lite != null)
            {
                Initialize();

                PK = lite.PK;
                Amount = lite.Amount;
                CreateDate = lite.CreateDate;
                Description = lite.Description;
                FK1 = lite.FK1;
                FK2 = lite.FK2;
                NullableDateTime = lite.NullableDateTime;
                SomeFlag = lite.SomeFlag;

                SetPrimaryKey(PK.Value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClass"/> class.
        /// </summary>
        /// <param name="record">A dynamic Expando Object</param>
        /// <param name="columnsToInclude">Optional columns to include, by default all.</param>
        public DummyClassBase(ExpandoObject record, List<DummyClassProperties> columnsToInclude = null)
        {
            if (record != null)
            {
                IDictionary<string, object> recordAsDictionary = (IDictionary<string, object>)record;

                Initialize();

                if (columnsToInclude == null)
                    columnsToInclude = new List<DummyClassProperties>() { DummyClassProperties.All };

                //Primary key must always be passed.
                PK = recordAsDictionary.ValueAs<int?>("PK");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.Amount))
                    Amount = recordAsDictionary.ValueAs<decimal>("Amount");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.CreateDate))
                    CreateDate = recordAsDictionary.ValueAs<DateTime>("CreateDate");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.Description))
                    Description = recordAsDictionary.ValueAs<string>("Description");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.FK1))
                    FK1 = recordAsDictionary.ValueAs<int>("FK1");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.FK2))
                    FK2 = recordAsDictionary.ValueAs<int>("FK2");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.NullableDateTime))
                    NullableDateTime = recordAsDictionary.ValueAs<DateTime?>("NullableDateTime");
                if (columnsToInclude.Contains(DummyClassProperties.All) || columnsToInclude.Contains(DummyClassProperties.SomeFlag))
                    SomeFlag = recordAsDictionary.ValueAs<bool>("SomeFlag");

                SetPrimaryKey(PK.Value);
            }
        }
        #endregion

        #region Properties
        public string PKDefaultValue { get { return ""; } }
        /// <summary>
        /// The primary key column for this entity.
        /// </summary>
        public DummyClassProperties PrimaryKey { get; set; }
        /// <summary>
        /// Gets or sets the field validations.
        /// </summary>
        /// <value>The field validations.</value>
        [JsonIgnore]
        [XmlIgnore]
        public List<FieldValidator > FieldValidations { get; set; }
        /// <summary>
        /// The insert header for bulk SQL operations.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public string SQLInsertBulkHeader
        {
            get
            {
                return $"INSERT INTO {StorageProvider.GetTableSQL(EntityName, TableSchema)} (FK1, FK2, Description, CreateDate, Amount, NullableDateTime, SomeFlag)";
            }
        }
        /// <summary>
        /// The insert row for bulk SQL operations.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public string SQLInsertBulkRow
        {
            get
            {
                return $"({FK1.SafeSQL()}, {FK2.SafeSQL()}, '{Description.SafeSQL()}', {CreateDate.SafeSQL()}, {Amount.SafeSQL()}, '{NullableDateTime.SafeSQL()}', {SomeFlag.SafeSQL()})";
            }
        }
        /// <summary>
        /// The insert SQL statement for single records.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IStorageStatement SQLInsertStatement
        {
            get
            {
                KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement();
                StringBuilder sql = new StringBuilder(SQLInsertBulkHeader);

                sql.Append(" VALUES(");
                sql.Append($"@{DummyClassProperties.FK1.ToString()}, ");
                sql.Append($"@{DummyClassProperties.FK2.ToString()}, ");
                sql.Append($"@{DummyClassProperties.Description.ToString()}, ");
                sql.Append($"@{DummyClassProperties.CreateDate.ToString()}, ");
                sql.Append($"@{DummyClassProperties.Amount.ToString()}, ");
                sql.Append($"@{DummyClassProperties.NullableDateTime.ToString()}, ");
                sql.Append($"@{DummyClassProperties.SomeFlag.ToString()}");
                sql.Append($")");

                //Add the parameters
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.FK1.ToString()}", FK1));
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.FK2.ToString()}", FK2));
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.Description.ToString()}", Description));
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.CreateDate.ToString()}", CreateDate));
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.Amount.ToString()}", Amount));
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.NullableDateTime.ToString()}", NullableDateTime));
                statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter($"@{DummyClassProperties.SomeFlag.ToString()}", SomeFlag));

                statement.Statement = sql.ToString();
                return statement;
            }
        }
        /// <summary>
        /// The update SQL statement for single records.
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IStorageStatement SQLUpdateStatement
        {
            get
            {
                KnightsTour.CoreLibrary.StorageStatement statement = new KnightsTour.CoreLibrary.StorageStatement();
                StringBuilder sql = new StringBuilder($"UPDATE {StorageProvider.GetTableSQL(EntityName, TableSchema)} SET ");

                foreach (DummyClassProperties property in Enum.GetValues(typeof(DummyClassProperties)))
                {
                    if (property != DummyClassProperties.All)
                    {
                        if (IsModified(property))
                        {
                            sql.Append($"{property.ToString()} = @{property.ToString()}, ");
                            statement.Parameters.Add(new KnightsTour.CoreLibrary.GenericParameter("@" + property.ToString(), GetDBValue(property)));
                        }
                    }
                }

                sql = sql.Remove(sql.Length - 2, 2); //Remove the trailing comma and space
                sql.Append($" WHERE {StorageProvider.GetColumnSQL(PrimaryKeyField)} = {Id}");
                statement.Statement = sql.ToString();
                return statement;
            }
        }
        public string TableSchema { get { return "dbo"; } }
        #endregion

        #region Original Properties
        /// <summary>
        /// Gets or sets the initial state.
        /// </summary>
        /// <value>The initial state.</value>
        [JsonIgnore]
        [XmlIgnore]
        public DummyClassLite InitialState { get; set; }
        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        [XmlIgnore]
        public bool IsNew
        {
            get
            {
                return !PK.HasValue;
            }
        }
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get { return EntityName; } }
        public string InstanceLabel { get { return PKDefaultValue; } }
        #endregion

        #region Methods
        /// <summary>
        /// Validates the object using the defined field validators.
        /// </summary>
        KnightsTour.CoreLibrary.ActionResponse Validate()
        {
            return KnightsTour.Context.ValidationHandler.ValidateEntity<int?>(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), TableSchema, this, IsNew);
        }
        /// <summary>
        /// Sets the original properties.
        /// </summary>
        public void SetOriginalProperties()
        {
            InitialState = new DummyClassLite(this);
        }
        /// <summary>
        /// Serializes the object.
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
        /// Serializes the differential.
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
        /// To the dynamic.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns>dynamic.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public dynamic ToDynamic(KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy strategy = KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.AllProperties)
        {
            dynamic dnamicDummyClass = new JObject();
            switch (strategy)
            {
                case KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.AllProperties:
                    dnamicDummyClass.PK = PK;
                    dnamicDummyClass.Description = Description;
                    dnamicDummyClass.CreateDate = CreateDate;
                    dnamicDummyClass.Amount = Amount;
                    dnamicDummyClass.FK1 = FK1;
                    dnamicDummyClass.FK2 = FK2;
                    dnamicDummyClass.NullableDateTime = NullableDateTime;
                    dnamicDummyClass.SomeFlag = SomeFlag;
                    break;
                case KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.AllPropertiesWithOriginals:
                    dnamicDummyClass.PK = PK;
                    dnamicDummyClass.Description = Description;
                    dnamicDummyClass.CreateDate = CreateDate;
                    dnamicDummyClass.Amount = Amount;
                    dnamicDummyClass.FK1 = FK1;
                    dnamicDummyClass.FK2 = FK2;
                    dnamicDummyClass.NullableDateTime = NullableDateTime;
                    dnamicDummyClass.SomeFlag = SomeFlag;

                    dnamicDummyClass.PK_Original = InitialState.PK;
                    dnamicDummyClass.Description_Original = InitialState.Description;
                    dnamicDummyClass.CreateDate_Original = InitialState.CreateDate;
                    dnamicDummyClass.Amount_Original = InitialState.Amount;
                    dnamicDummyClass.FK1_Original = InitialState.FK1;
                    dnamicDummyClass.FK2_Original = InitialState.FK2;
                    dnamicDummyClass.NullableDateTime_Original = InitialState.NullableDateTime;
                    dnamicDummyClass.SomeFlag_Original = InitialState.SomeFlag;

                    break;
                case KnightsTour.CoreLibrary.Enumerations.DynamicObjectStrategy.ModifiedPropertiesOnly:
                    if (IsModified(DummyClassProperties.PK))
                    {
                        dnamicDummyClass.PK = PK;
                        dnamicDummyClass.PK_Original = InitialState.PK;
                    }
                    if (IsModified(DummyClassProperties.Amount))
                    {
                        dnamicDummyClass.Amount = Amount;
                        dnamicDummyClass.Amount_Original = InitialState.Amount;
                    }
                    if (IsModified(DummyClassProperties.FK1))
                    {
                        dnamicDummyClass.FK1 = FK1;
                        dnamicDummyClass.FK1_Original = InitialState.FK1;
                    }
                    if (IsModified(DummyClassProperties.FK2))
                    {
                        dnamicDummyClass.FK2 = FK2;
                        dnamicDummyClass.FK2_Original = InitialState.FK2;
                    }
                    if (IsModified(DummyClassProperties.Description))
                    {
                        dnamicDummyClass.Description = Description;
                        dnamicDummyClass.Description_Original = InitialState.Description;
                    }
                    if (IsModified(DummyClassProperties.CreateDate))
                    {
                        dnamicDummyClass.CreateDate = CreateDate;
                        dnamicDummyClass.CreateDate_Original = InitialState.CreateDate;
                    }
                    if (IsModified(DummyClassProperties.NullableDateTime))
                    {
                        dnamicDummyClass.NullableDateTime = NullableDateTime;
                        dnamicDummyClass.NullableDateTime_Original = InitialState.NullableDateTime;
                    }
                    if (IsModified(DummyClassProperties.SomeFlag))
                    {
                        dnamicDummyClass.SomeFlag = SomeFlag;
                        dnamicDummyClass.SomeFlag_Original = InitialState.SomeFlag;
                    }
                    break;
                default:
                    throw new NotImplementedException($"{strategy.ToString()} strategy not implemented.");
            }
            return dnamicDummyClass;
        }
        /// <summary>
        /// Determines whether this instance is modified.
        /// </summary>
        /// <returns><c>true</c> if this instance is modified; otherwise, <c>false</c>.</returns>
        public bool IsModified()
        {
            foreach (DummyClassProperties property in Enum.GetValues(typeof(DummyClassProperties)))
            {
                if (property != DummyClassProperties.All)
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
        /// <param name="property">The property.</param>
        /// <returns><c>true</c> if the specified property is modified; otherwise, <c>false</c>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsModified(DummyClassProperties property)
        {
            switch (property)
            {
                case DummyClassProperties.PK:
                    return PK != InitialState.PK;
                case DummyClassProperties.Amount:
                    return Amount != InitialState.Amount;
                case DummyClassProperties.Description:
                    return Description != InitialState.Description;
                case DummyClassProperties.CreateDate:
                    return CreateDate != InitialState.CreateDate;
                case DummyClassProperties.FK1:
                    return FK1 != InitialState.FK1;
                case DummyClassProperties.FK2:
                    return FK2 != InitialState.FK2;
                case DummyClassProperties.NullableDateTime:
                    return NullableDateTime != InitialState.NullableDateTime;
                case DummyClassProperties.SomeFlag:
                    return SomeFlag != InitialState.SomeFlag;
                case DummyClassProperties.All:
                    return
                        IsModified(DummyClassProperties.PK) ||
                        IsModified(DummyClassProperties.Amount) ||
                        IsModified(DummyClassProperties.Description) ||
                        IsModified(DummyClassProperties.CreateDate) ||
                        IsModified(DummyClassProperties.FK1) ||
                        IsModified(DummyClassProperties.FK2) ||
                        IsModified(DummyClassProperties.NullableDateTime) ||
                        IsModified(DummyClassProperties.SomeFlag);
                default:
                    throw new NotImplementedException($"{property.ToString()} property not implemented.");
            }
        }
        /// <summary>
        /// Initializes this class.
        /// </summary>
        public void Initialize()
        {
            MethodWrappers.CommonWrapper(baseInitialize, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new object[] { });
        }
        void baseInitialize(object[] arguments)
        {
            InitialState = new DummyClassLite();

            // Base Entity properties
            EntityName = "DummyClass";
            PrimaryKey = DummyClassProperties.PK;
            PrimaryKeyField = "PK";

            // Table properties
            PK = null;
            FK1 = null;
            FK2 = null;
            Description = string.Empty;
            CreateDate = DateTime.Now;
            Amount = 0.0M;
            NullableDateTime = null;
            SomeFlag = false;
        }
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Account.</returns>
        public DummyClass Clone()
        {
            DummyClass dummyClass = new DummyClass(Id.Value);

            dummyClass.PK = PK;
            dummyClass.FK1 = FK1;
            dummyClass.FK2 = FK2;
            dummyClass.Description = Description;
            dummyClass.CreateDate = CreateDate;
            dummyClass.Amount = Amount;
            dummyClass.NullableDateTime = NullableDateTime;
            dummyClass.SomeFlag = SomeFlag;

            return dummyClass;
        }
        /// <summary>
        /// To the string base.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string ToString()
        {
            return SerializeObject();
        }
        /// <summary>
        /// Gets the database value.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException"></exception>
        dynamic GetDBValue(DummyClassProperties property)
        {
            switch (property)
            {
                case DummyClassProperties.PK:
                    return PK;
                case DummyClassProperties.Amount:
                    return Amount;
                case DummyClassProperties.FK1:
                    return FK1;
                case DummyClassProperties.FK2:
                    return FK2;
                case DummyClassProperties.Description:
                    return Description;
                case DummyClassProperties.CreateDate:
                    return CreateDate;
                case DummyClassProperties.NullableDateTime:
                    return NullableDateTime;
                case DummyClassProperties.SomeFlag:
                    return SomeFlag;
                default:
                    throw new ArgumentException($"Property {property.ToString()} unhandled.");
            }
        }
        /// <summary>
        /// Sets the primary key.
        /// </summary>
        /// <param name="id"></param>
        public void SetPrimaryKey(int? id)
        {
            PK = id;
            SetOriginalProperties();
        }
        /// <summary>
        /// Returns the stored procedure name (of a given type) or this class.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetStoredProcedureName(KnightsTour.CoreLibrary.Enumerations.StoredProcedureType type)
        {
            string storedProcedureName = string.Empty;

            // The Stored procedure prefix (as defined on the model) is optional, deal with that first.
            if (!string.IsNullOrEmpty(Schema.Model.StoredProcedurePrefix))
            {
                storedProcedureName += $"{Schema.Model.StoredProcedurePrefix}_";
            }

            // Model prefix (optional), Entity name then finally the type.
            return $"{storedProcedureName}{EntityName}_{type}";
        }
        #endregion
    }
    public enum DummyClassProperties
    {
        All,
        PK,
        Description,
        FK1,
        FK2,
        CreateDate,
        NullableDateTime,
        Amount,
        SomeFlag
    }
}