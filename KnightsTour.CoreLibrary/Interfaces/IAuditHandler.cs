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
// File             : IAuditHandler.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The IAuditHandler interface.
    /// </summary>
    public interface IAuditHandler
    {
        #region Properties
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        Dictionary<string, Dictionary<Enumerations.CrudAction, bool>> Configuration { get; set; }
        /// <summary>
        /// Gets or sets the serialization strategy.
        /// </summary>
        /// <value>The serialization strategy.</value>
        Enumerations.SerializationStrategy SerializationStrategy { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the specified table is enabled.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        /// <returns><c>true</c> if the specified table is enabled; otherwise, <c>false</c>.</returns>
        bool IsEnabled(string table, Enumerations.CrudAction action);
        /// <summary>
        /// Enables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        void Enable(string table, Enumerations.CrudAction action);
        /// <summary>
        /// Disables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        void Disable(string table, Enumerations.CrudAction action);
        /// <summary>
        /// Enables the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        void Enable(Enumerations.CrudAction action);
        /// <summary>
        /// Disables the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        void Disable(Enumerations.CrudAction action);
        /// <summary>
        /// Enables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        void Enable(string table);
        /// <summary>
        /// Disables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        void Disable(string table);
        /// <summary>
        /// Enables this instance.
        /// </summary>
        void Enable();
        /// <summary>
        /// Disables this instance.
        /// </summary>
        void Disable();
        /// TODO: Here the documentation could be improved.
        /// <summary>
        /// Pres the insert.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        Guid PreInsert(string table, string serializedData, string userName);
        /// <summary>
        /// Posts the insert.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="response">The response.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if any records are modified, <c>false</c> otherwise.</returns>
        bool PostInsert(string table, Guid preGuid, ActionResponse response, string userName);
        /// <summary>
        /// Pres the update.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        Guid PreUpdate(string table, string serializedData, string userName);
        /// <summary>
        /// Posts the update.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="response">The response.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if any records are modified, <c>false</c> otherwise.</returns>
        bool PostUpdate(string table, Guid preGuid, ActionResponse response, string userName);
        /// <summary>
        /// Pres the delete.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        Guid PreDelete(string table, string serializedData, string userName);
        /// <summary>
        /// Posts the delete.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="response">The response.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if any records are modified, <c>false</c> otherwise.</returns>
        bool PostDelete(string table, Guid preGuid, ActionResponse response, string userName);
        /// <summary>
        /// Pres the fetch.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        Guid PreFetch(string table, string userName);
        /// <summary>
        /// Posts the fetch.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="records">The records.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if any records are returned, <c>false</c> otherwise.</returns>
        bool PostFetch(string table, Guid preGuid, int records, string userName);
        #endregion
    }
}