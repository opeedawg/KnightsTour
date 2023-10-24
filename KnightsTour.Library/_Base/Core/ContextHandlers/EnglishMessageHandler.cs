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
// Created          : October 21, 2023 9:55:34 AM
// File             : EnglishMessageHandler.cs
// ************************************************************************

namespace KnightsTour
{
    /// <summary>
    /// Class EnglishMessageHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.CoreLibrary.MessageHandlerBase" />
    /// <seealso cref="KnightsTour.CoreLibrary.IMessageHandler" />
    public class EnglishMessageHandler : KnightsTour.CoreLibrary.MessageHandlerBase, KnightsTour.CoreLibrary.IMessageHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EnglishMessageHandler"/> class.
        /// </summary>
        public EnglishMessageHandler(): base()
        {
            //Cache messages
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Cache_Fresh, "Cache results enabled.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Cache_Off, "Cache not enabled for '{0}'.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Cache_On, "Cache configuration discovered and enabled for '{0}'.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Cache_Stale, "Cache is not set or stale for '{0}'.  Refreshing from data source.");

            //Data messages
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_NoOperation, "No operations were performed by design.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnInsert, "{0} record inserted with primary key {1}.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnInsertFailure, "{0} insert failure.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnInsertTotal, "{0}/{1} {2} record(s) inserted.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdate, "{0} {1} records updated.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdateFailure, "{0} update failure.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnUpdateTotal, "{0}/{1} {2} record(s) updated.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDelete, "{0} {1} records deleted.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDeleteFailure, "{0} delete failure.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_OnDeleteTotal, "{0}/{1} {2} record(s) deleted.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_InsertSkipped_NotNew, "{0} insert skipped.  The record is not new.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_UpdateSkipped_New, "{0} update skipped.  The record is new.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Data_UpdateSkipped_NotModified, "{0} update skipped.  The record has not been modified.");

            //Event messages
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start, "Initialized.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End, "Terminated.");

            //Validation messages
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_Between, "'{0}' must be between {1} and {2}.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_GreaterThan, "'{0}' must be greater than {1}");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_GreaterThanOrEqual, "'{0}' must be greater than or equal to {1}");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_LessThan, "'{0}' must be less than {1}");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_LessThanOrEqual, "'{0}' must be less than or equal to {1}");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_MissingMandatoryField, "Please enter a value for '{0}'.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_MissingMandatoryRelationship, "Please select a value for '{0}'.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_TooLong, "'{0}' must have a length no longer than {1}.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_TooShort, "'{0}' must have a length longer than or equal to {1}.");
            Set(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Validation_InvalidFormat, "'{0}' does not meet the required format '{1}'.");
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion
    }
}