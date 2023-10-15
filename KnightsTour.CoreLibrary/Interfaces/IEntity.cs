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
// File             : IEntity.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Defines what an Entity must conform to.
    /// </summary>
    public interface IEntity<TPk>: IEntityLite<TPk>
    {
        #region Properties
        /// <summary>
        /// Header for SQL Insert statements.
        /// </summary>
        string SQLInsertBulkHeader { get; }
        /// <summary>
        /// Defines what an individual insert row looks like for bulk inserts.
        /// </summary>
        string SQLInsertBulkRow { get; }
        /// <summary>
        /// Gets the related name of the actual database table for this entity.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        string TableName { get; }
        /// <summary>
        /// The executing user id field, used for concurreny management.
        /// </summary>
        int? ExecutingUserId { get; set; }
        /// <summary>
        /// Gets the related name of the actual database schmea for this entity.
        /// </summary>
        /// <value>
        /// The schema name for the table.
        /// </value>
        string TableSchema { get; }
        /// <summary>
        /// The SQL insert statment for SQL storage mechanisms.
        /// </summary>
        IStorageStatement SQLInsertStatement { get; }
        /// <summary>
        /// The SQL update statment for SQL storage mechanisms.
        /// </summary>
        IStorageStatement SQLUpdateStatement { get; }
        /// <summary>
        /// Determines whether this instance is new.
        /// </summary>
        /// <returns><c>true</c> if this instance is new; otherwise, <c>false</c>.</returns>
        bool IsNew { get; }
        /// <summary>Gets or sets the pk insert configuration.</summary>
        /// <value>The pk insert configuration.</value>
        KnightsTour.CoreLibrary.Enumerations.InsertPKRule PKInsertConfiguration { get; set; }
        /// <summary>Gets or sets the pk default value.</summary>
        /// <value>The pk default value.</value>
        string PKDefaultValue { get; }
        /// <summary>
        /// The configured label or label collection configured, or the PK number or (new) if a new record.
        /// </summary>
        string InstanceLabel { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a serialized differential from the original object properties.
        /// </summary>
        /// <returns>System.String.</returns>
        string SerializeDifferential();
        /// <summary>
        /// Serializes the object according to the context.
        /// </summary>
        /// <returns>System.String.</returns>
        string SerializeObject();
        /// <summary>
        /// Cpmverts the object to a dynamic object based on the strategy defined.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns>dynamic.</returns>
        dynamic ToDynamic(Enumerations.DynamicObjectStrategy strategy = Enumerations.DynamicObjectStrategy.AllProperties);
        /// <summary>
        /// Determines whether this instance is modified.
        /// </summary>
        /// <returns><c>true</c> if this instance is modified; otherwise, <c>false</c>.</returns>
        bool IsModified();
        /// <summary>
        /// Sets the primary key for this particular object.
        /// </summary>
        /// <param name="id"></param>
        void SetPrimaryKey(TPk id);
        /// <summary>
        /// Sets the original propertes, used for checking on verification statuses.
        /// </summary>
        void SetOriginalProperties();
        /// <summary>
        /// Returns the name of the stored procedure specific to this entity.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetStoredProcedureName(Enumerations.StoredProcedureType type);
        #endregion
    }
}