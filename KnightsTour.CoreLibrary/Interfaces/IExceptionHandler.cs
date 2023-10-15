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
// File             : IExceptionHandler.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The IExceptionHandler interface.
    /// </summary>
    public interface IExceptionHandler
    {
        #region Properties
        /// <summary>
        /// Gets or sets the new handling options.
        /// </summary>
        /// <value>The handling options new.</value>
        Dictionary<Enumerations.ApplicationTier, Enumerations.ExceptionHandlingAction> HandlingOptions_New { get; set; }
        /// <summary>
        /// Gets or sets the known handling options.
        /// </summary>
        /// <value>The handling options known.</value>
        Dictionary<Enumerations.ApplicationTier, Enumerations.ExceptionHandlingAction> HandlingOptions_Known { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Adds new handler.
        /// </summary>
        /// <param name="tier">The application tier.</param>
        /// <param name="option">The option.</param>
        /// <returns><c>true</c> if adding the new handler succeeded, <c>false</c> otherwise.</returns>
        bool AddHandler_New(Enumerations.ApplicationTier tier, Enumerations.ExceptionHandlingAction option);
        /// <summary>
        /// Adds known handler.
        /// </summary>
        /// <param name="tier">The application tier.</param>
        /// <param name="option">The option.</param>
        /// <returns><c>true</c> if adding the known handler succeeded, <c>false</c> otherwise.</returns>
        bool AddHandler_Known(Enumerations.ApplicationTier tier, Enumerations.ExceptionHandlingAction option);
        /// <summary>
        /// Handles log exceptions.
        /// </summary>
        /// <param name="exception">The log exception.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleLogException(Exception exception);
        /// <summary>
        /// Handles data exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="statement">The statement.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleDataException(Exception exception, IStorageStatement statement = null);
        /// <summary>
        /// Handles business exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleBusinessException(Exception exception);
        /// <summary>
        /// Handles cache exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="cacheKey">The cache key.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleCacheException(Exception exception, string cacheKey = null);
        /// <summary>
        /// Handles rest exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="jsonData">The json data.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleRestException(Exception exception, string endpoint, string jsonData = null);
        /// <summary>
        /// Handles audit exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleAuditException(Exception exception, string table, Enumerations.CrudAction action);
        /// <summary>
        /// Handles UI exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        void HandleUIException(Exception exception);
        #endregion
    }
}