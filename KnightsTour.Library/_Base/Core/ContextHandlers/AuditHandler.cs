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
// Created          : October 14, 2023 11:18:11 AM
// File             : AuditHandler.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Class AuditHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.AuditHandlerBase" />
    /// <seealso cref="KnightsTour.CoreLibrary.IAuditHandler" />
    public class AuditHandler : AuditHandlerBase, KnightsTour.CoreLibrary.IAuditHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditHandler"/> class.
        /// </summary>
        /// <param name="serializationStrategy">The serialization strategy.</param>
        public AuditHandler(KnightsTour.CoreLibrary.Enumerations.SerializationStrategy serializationStrategy): base(serializationStrategy)
        {
            //Enable everything
            Enable();
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>Pres the insert.</summary>
        /// <param name="table">The table.</param>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        public Guid PreInsert(string table, string serializedData, string userName)
        {
            return MethodWrappers.CommonWrapper<Guid>(preAudit, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Insert, serializedData });
        }
        /// <summary>
        /// Pres the update.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        public Guid PreUpdate(string table, string serializedData, string userName)
        {
            return MethodWrappers.CommonWrapper<Guid>(preAudit, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Update, serializedData });
        }
        /// <summary>
        /// Pres the delete.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        public Guid PreDelete(string table, string serializedData, string userName)
        {
            return MethodWrappers.CommonWrapper<Guid>(preAudit, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Delete, serializedData });
        }
        /// <summary>
        /// Pres the fetch.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns>Guid.</returns>
        public Guid PreFetch(string table, string userName)
        {
            return MethodWrappers.CommonWrapper<Guid>(preAudit, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Fetch });
        }
        /// <summary>
        /// Posts the delete.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="response">The response.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if the response is valid, <c>false</c> otherwise.</returns>
        public bool PostDelete(string table, Guid preGuid, KnightsTour.CoreLibrary.ActionResponse response, string userName)
        {
            return MethodWrappers.CommonWrapper<bool>(postAuditResponse, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Delete, preGuid, response });
        }
        /// <summary>
        /// Posts the insert.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="response">The response.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if the response is valid, <c>false</c> otherwise.</returns>
        public bool PostInsert(string table, Guid preGuid, KnightsTour.CoreLibrary.ActionResponse response, string userName)
        {
            return MethodWrappers.CommonWrapper<bool>(postAuditResponse, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Insert, preGuid, response });
        }
        /// <summary>
        /// Posts the update.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="response">The response.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if the response is valid, <c>false</c> otherwise.</returns>
        public bool PostUpdate(string table, Guid preGuid, KnightsTour.CoreLibrary.ActionResponse response, string userName)
        {
            return MethodWrappers.CommonWrapper<bool>(postAuditResponse, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Update, preGuid, response });
        }
        /// <summary>
        /// Posts the fetch.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="preGuid">The pre unique identifier.</param>
        /// <param name="records">The records.</param>
        /// <param name="userName">The user performing the operation.</param>
        /// <returns><c>true</c> if at least 1 record was modified, <c>false</c> otherwise.</returns>
        public bool PostFetch(string table, Guid preGuid, int records, string userName)
        {
            return MethodWrappers.CommonWrapper<bool>(postAuditFetch, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new object[] { table, KnightsTour.CoreLibrary.Enumerations.CrudAction.Fetch, preGuid, records });
        }
        #endregion

        #region Private support methods
        /// <summary>
        /// Handles the pre audit code
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Guid.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Guid preAudit(object[] arguments)
        {
            Enumerations.EntityName table = EntityMapper.GetEntity((string)arguments[0]);
            KnightsTour.CoreLibrary.Enumerations.CrudAction action = (KnightsTour.CoreLibrary.Enumerations.CrudAction)arguments[1];

            string serializedData = string.Empty;
            switch (action)
            {
                case KnightsTour.CoreLibrary.Enumerations.CrudAction.Insert:
                    serializedData = (string)arguments[2];
                    Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Audit, $"Auditing table {table.ToString()} on pre {action.ToString()}.", serializedData);
                    break;
                case KnightsTour.CoreLibrary.Enumerations.CrudAction.Fetch:
                    Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Audit, $"Auditing table {table.ToString()} on pre {action.ToString()}.");
                    break;
                case KnightsTour.CoreLibrary.Enumerations.CrudAction.Update:
                    serializedData = (string)arguments[2];
                    Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Audit, $"Auditing table {table.ToString()} on pre {action.ToString()}.", serializedData);
                    break;
                case KnightsTour.CoreLibrary.Enumerations.CrudAction.Delete:
                    serializedData = (string)arguments[2];
                    Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Audit, $"Auditing table {table.ToString()} on pre {action.ToString()}.", serializedData);
                    break;
                default:
                    throw new NotImplementedException($"{action.ToString()} not implemented.");
            }

            return Guid.NewGuid();
        }
        /// <summary>
        /// Handles the post audit code having a response
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns><c>true</c> if the response is valid, <c>false</c> otherwise.</returns>
        bool postAuditResponse(object[] arguments)
        {
            Enumerations.EntityName table = EntityMapper.GetEntity((string)arguments[0]);
            KnightsTour.CoreLibrary.Enumerations.CrudAction action = (KnightsTour.CoreLibrary.Enumerations.CrudAction)arguments[1];
            Guid preGuid = (Guid)arguments[2];
            KnightsTour.CoreLibrary.ActionResponse response = (KnightsTour.CoreLibrary.ActionResponse)arguments[3];

            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Audit, $"Auditing table {table.ToString()} on post action {action.ToString()} (Pre action guid {preGuid.ToString()}).  Valid response: {response.IsValid.ToString()}");

            return response.IsValid;
        }
        /// <summary>
        /// Handles the post audit code having a fetch
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns><c>true</c> if at least 1 record was modified, <c>false</c> otherwise.</returns>
        bool postAuditFetch(object[] arguments)
        {
            Enumerations.EntityName table = EntityMapper.GetEntity((string)arguments[0]);
            KnightsTour.CoreLibrary.Enumerations.CrudAction action = (KnightsTour.CoreLibrary.Enumerations.CrudAction)arguments[1];
            Guid preGuid = (Guid)arguments[2];
            int totalRecords = (int)arguments[3];

            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Audit, $"Auditing table {table.ToString()} on post action {action.ToString()} (Pre action guid {preGuid.ToString()}).  Total records returned: {totalRecords}");

            return totalRecords > 0;
        }
        #endregion
    }
}