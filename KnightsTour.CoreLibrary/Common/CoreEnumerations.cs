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
// Created          : October 14, 2023 11:07:03 AM
// File             : CoreEnumerations.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary.Enumerations
{
    /// <summary>
    /// Types of auto generated stored procedures.
    /// </summary>
    public enum StoredProcedureType
    {
        Insert,
        Update,
        GetAll,
        GetById,
        GetByIds,
        GetAllExtended,
        GetCount,
        Delete,
    }
    /// <summary>
    /// Triger operations when setting deafult values.
    /// </summary>
    public enum DefaultTriggerOperation
    {
        /// <summary>On Insert.</summary>
        INSERT,
        /// <summary>On Update.</summary>
        UPDATE
    }
    /// <summary>
    /// Default value types
    /// </summary>
    public enum DefaultType
    {
        /// <summary>A relative date and time.</summary>
        DATETIME,
        /// <summary>A guaranteed unique identifier.</summary>
        GUID,
        /// <summary>A random token of defined length (default 7).</summary>
        RANDOMTOKEN,
        /// <summary>A custom value.</summary>
        VALUE,
    }
    /// <summary>
    /// Data type of Primary Key for the entity.
    /// </summary>
    public enum PKType
    {
        /// <summary>Not set or undefined.</summary>
        UNDEFINED,
        /// <summary>A 32 bit number.</summary>
        Integer,
        /// <summary>A universally unique identifier.</summary>
        UUID,
        /// <summary>A date/time.</summary>
        Date,
        /// <summary>A string.</summary>
        String,
        /// <summary>A 64 bit number.</summary>
        Long,
        /// <summary>A 16 bit number.</summary>
        Tiny
    }
    /// <summary>The various types of possible insert PK rules.</summary>
    public enum InsertPKRule
    {
        /// <summary>The PK is automatic incremented.</summary>
        AutoIncrement = 0,
        /// <summary>A sequence technology is used via SEQ.nextval</summary>
        Sequence = 1,
        /// <summary>PK is manually passed and handled by the end user.</summary>
        Manual = 2,
    }
    /// <summary>
    /// The list of possible web UI configuration types.
    /// </summary>
    public enum WebUIConfigurationType
    {
        Authorization,
        Entity,
        Navigation,
        Route,
        Setting
    }    
    /// <summary>
    /// The available entity relationship types.
    /// </summary>
    public enum RelationshipType
        {
        /// <summary>One to one</summary>
        OneToOne,
        /// <summary>One to many</summary>
        OneToMany,
        /// <summary>Many to many</summary>
        ManyToMany
    };
    /// <summary>
    /// The available properties on the entity attribute class.
    /// </summary>
    public enum EntityProperty
    {
        /// <summary>Record Count</summary>
        RecordCount,
        /// <summary>First Id</summary>
        FirstId,
        /// <summary>Last Id</summary>
        LastId,
        /// <summary>Has String Field</summary>
        HasStringField,
        /// <summary>String Field</summary>
        StringField,
        /// <summary>Has Int Field</summary>
        HasIntField,
        /// <summary>Int Field</summary>
        IntField,
    }
    /// <summary>
    /// The SystemMessages enumeration.
    /// </summary>
    public enum SystemMessage
    {
        /// <summary>
        /// The cache on item.
        /// </summary>
        Cache_On,
        /// <summary>
        /// The cache stale item.
        /// </summary>
        Cache_Stale,
        /// <summary>
        /// The cache fresh item.
        /// </summary>
        Cache_Fresh,
        /// <summary>
        /// The cache off item.
        /// </summary>
        Cache_Off,
        /// <summary>
        /// Message regarding no operations were performed by design.
        /// </summary>
        Data_NoOperation,
        /// <summary>
        /// The data on insert item.
        /// </summary>
        Data_OnInsert,
        /// <summary>
        /// The data on insert failure item.
        /// </summary>
        Data_OnInsertFailure,
        /// <summary>
        /// The data on insert total item.
        /// </summary>
        Data_OnInsertTotal,
        /// <summary>
        /// The data on update item.
        /// </summary>
        Data_OnUpdate,
        /// <summary>
        /// The data on update failure item.
        /// </summary>
        Data_OnUpdateFailure,
        /// <summary>
        /// The data on update total item.
        /// </summary>
        Data_OnUpdateTotal,
        /// <summary>
        /// The data on delete item.
        /// </summary>
        Data_OnDelete,
        /// <summary>
        /// The data on delete failure item.
        /// </summary>
        Data_OnDeleteFailure,
        /// <summary>
        /// The data on delete total item.
        /// </summary>
        Data_OnDeleteTotal,
        /// <summary>
        /// The data insert skipped not new item.
        /// </summary>
        Data_InsertSkipped_NotNew,
        /// <summary>
        /// The data update skipped new item.
        /// </summary>
        Data_UpdateSkipped_New,
        /// <summary>
        /// The data update skipped not modified item.
        /// </summary>
        Data_UpdateSkipped_NotModified,
        /// <summary>
        /// The method start item.
        /// </summary>
        Method_Start,
        /// <summary>
        /// The method end item.
        /// </summary>
        Method_End,
        /// <summary>
        /// The validation missing mandatory field item.
        /// </summary>
        Validation_MissingMandatoryField,
        /// <summary>
        /// The validation missing mandatory relationship item.
        /// </summary>
        Validation_MissingMandatoryRelationship,
        /// <summary>
        /// The validation greater than item.
        /// </summary>
        Validation_GreaterThan,
        /// <summary>
        /// The validation less than item.
        /// </summary>
        Validation_LessThan,
        /// <summary>
        /// The validation greater than or equal item.
        /// </summary>
        Validation_GreaterThanOrEqual,
        /// <summary>
        /// The validation less than or equal item.
        /// </summary>
        Validation_LessThanOrEqual,
        /// <summary>
        /// The validation between item.
        /// </summary>
        Validation_Between,
        /// <summary>
        /// The validation too long item.
        /// </summary>
        Validation_TooLong,
        /// <summary>
        /// The validation too short item.
        /// </summary>
        Validation_TooShort,
        /// <summary>
        /// The validation invalid format item.
        /// </summary>
        Validation_InvalidFormat,
    }
    /// <summary>
    /// The LoggingActions enumeration.
    /// </summary>
    public enum LoggingAction
    {
        /// <summary>
        /// The debugging action.
        /// </summary>
        Debugging,
        /// <summary>
        /// The information action.
        /// </summary>
        Information,
        /// <summary>
        /// The exception action.
        /// </summary>
        Exception,
        /// <summary>
        /// The event action.
        /// </summary>
        Event,
        /// <summary>
        /// The SQL action.
        /// </summary>
        SQL,
        /// <summary>
        /// The audit action.
        /// </summary>
        Audit
    }
    /// <summary>
    /// The ExceptionHandlingActions enumeration.
    /// </summary>
    public enum ExceptionHandlingAction
    {
        /// <summary>
        /// The wrap and raise exception handling action.
        /// </summary>
        WrapAndRaise,
        /// <summary>
        /// The raise exception handling action.
        /// </summary>
        Raise,
        /// <summary>
        /// The cancel exception handling action.
        /// </summary>
        Cancel
    }
    /// <summary>
    /// The ApplicationTiers enumeration.
    /// </summary>
    public enum ApplicationTier
    {
        /// <summary>
        /// The audit application tier.
        /// </summary>
        Audit,
        /// <summary>
        /// The cache application tier.
        /// </summary>
        Cache,
        /// <summary>
        /// The data application tier.
        /// </summary>
        Data,
        /// <summary>
        /// The business application tier.
        /// </summary>
        Business,
        /// <summary>
        /// The rest application tier.
        /// </summary>
        Api,
        /// <summary>
        /// The UI application tier.
        /// </summary>
        UI,
        /// <summary>
        /// The logging application tier.
        /// </summary>
        Logging
    }
    /// <summary>
    /// Enumeration of Create, Retrieve, Update and Delete actions.
    /// </summary>
    public enum CrudAction
    {
        /// <summary>
        /// The insert action.
        /// </summary>
        Insert,
        /// <summary>
        /// The fetch action.
        /// </summary>
        Fetch,
        /// <summary>
        /// The update action.
        /// </summary>
        Update,
        /// <summary>
        /// The delete action.
        /// </summary>
        Delete,
    }
    /// <summary>
    /// Log Format Options
    /// </summary>
    public enum LogFormatOption
    {
        /// <summary>
        /// The pipe delimited
        /// </summary>
        PipeDelimited,
        /// <summary>
        /// The tab delimited
        /// </summary>
        TabDelimited,
        /// <summary>
        /// The json
        /// </summary>
        JSON
    }
    /// <summary>
    /// Storage handler types
    /// </summary>
    public enum StorageHandlerType
    {
        /// <summary>SQLServer</summary>
        MySQL = 6,
        /// <summary>SQLServer</summary>
        SQLServer = 3,
        /// <summary>Oracle</summary>
        Oracle = 7,
        /// <summary>PostgreSQL</summary>
        PostgreSQL = 8,
    }
    /// <summary>
    /// The available cloud storage providers.
    /// </summary>
    public enum CloudStorageProvider
    {
        /// <summary>Drop Box</summary>
        DropBox = 1,
    }
    /// <summary>
    /// Available message types.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The positive
        /// </summary>
        Positive = 1,
        /// <summary>
        /// The negative
        /// </summary>
        Negative = 4,
        /// <summary>
        /// The information
        /// </summary>
        Information = 2,
        /// <summary>
        /// A warning
        /// </summary>
        Warning = 3,
    }
    /// <summary>
    /// Available serialization strategies.
    /// </summary>
    public enum SerializationStrategy
    {
        /// <summary>
        /// The XML
        /// </summary>
        XML,
        /// <summary>
        /// The json
        /// </summary>
        JSON,
    }
    /// <summary>
    /// Available dynamic object strategies.
    /// </summary>
    public enum DynamicObjectStrategy
    {
        /// <summary>All properties</summary>
        AllProperties,
        /// <summary>All properties with originals</summary>
        AllPropertiesWithOriginals,
        /// <summary>The modified properties only</summary>
        ModifiedPropertiesOnly,
    }
    /// <summary>
    /// The possible where conditions for non-sql comparisons.
    /// </summary>
    public enum WhereCondition
    {
        /// <summary>Equals</summary>
        Equals,
        /// <summary>Not Equal</summary>
        NotEqual,
        /// <summary>Greater Than</summary>
        GreaterThan,
        /// <summary>Greater Than Or Equal</summary>
        GreaterThanOrEqual,
        /// <summary>Less Than</summary>
        LessThan,
        /// <summary>Less Than Or Equal</summary>
        LessThanOrEqual,
        /// <summary>In</summary>
        In,
        /// <summary>Not In</summary>
        NotIn,
        /// <summary>Is Null</summary>
        IsNull,
        /// <summary>Is Not Null</summary>
        IsNotNull,
        /// <summary>Starts With</summary>
        StartsWith,
        /// <summary>Ends With</summary>
        EndsWith,
        /// <summary>Like</summary>
        Like
    }
    /// <summary>
    /// Where operators.
    /// </summary>
    public enum WhereOperator
    {
        /// <summary>And</summary>
        And,
        /// <summary>Or</summary>
        Or
    }
    /// <summary>
    /// Order by options.
    /// </summary>
    public enum OrderByDirection
    {
        /// <summary>Ascending</summary>
        Ascending,
        /// <summary>Descending</summary>
        Descending
    }
    /// <summary>
    /// The execute action options for non-sql storage statements.
    /// </summary>
    public enum NonSQLExecuteActionType
    {
        /// <summary>Undefined</summary>
        None,
        /// <summary>Update</summary>
        Update,
        /// <summary>Delete</summary>
        Delete
    }
    /// <summary>
    /// Options in how messages may be formatted.
    /// </summary>
    public enum MessageFormat
    {
        /// <summary>The new line</summary>
        NewLine,
        /// <summary>The HTML enumerated list</summary>
        HtmlEnumeratedList,
        /// <summary>The HTML list</summary>
        HtmlList,
    }
}