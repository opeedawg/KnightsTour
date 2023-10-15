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
// File             : ExceptionHandler.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace KnightsTour
{
    /// <summary>
    /// Class ExceptionHandler.
    /// </summary>
    /// <seealso cref="KnightsTour.ExceptionHandlerBase" />
    /// <seealso cref="KnightsTour.CoreLibrary.IExceptionHandler" />
    public class ExceptionHandler: ExceptionHandlerBase, KnightsTour.CoreLibrary.IExceptionHandler
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
        /// </summary>
        public ExceptionHandler(): base()
        {
            AddHandler_New(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Cache, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_New(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_New(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_New(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Api, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.Raise);
            AddHandler_New(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.UI, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.Cancel);

            AddHandler_Known(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Cache, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_Known(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_Known(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_Known(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Api, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise);
            AddHandler_Known(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.UI, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.Cancel);
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Handles the log exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleLogException(Exception exception)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.LogException extendedException = new KnightsTour.CoreLibrary.LogException(customException);
                throw extendedException;
            }
        }
        /// <summary>
        /// Handles the data exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="statement">The statement.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleDataException(Exception exception, KnightsTour.CoreLibrary.IStorageStatement statement = null)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.DataException extendedException = new KnightsTour.CoreLibrary.DataException(customException);
                extendedException.Statement = statement;
                throw extendedException;
            }
        }
        /// <summary>
        /// Handles the audit exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleAuditException(Exception exception, string table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.AuditException extendedException = new KnightsTour.CoreLibrary.AuditException(customException);
                extendedException.Table = table;
                extendedException.Action = action;
                throw extendedException;
            }
        }
        /// <summary>
        /// Handles the business exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleBusinessException(Exception exception)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.LogicException extendedException = new KnightsTour.CoreLibrary.LogicException(customException);
                throw extendedException;
            }
        }
        /// <summary>
        /// Handles the cache exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="cacheKey">The cache key.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleCacheException(Exception exception, string cacheKey = null)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Cache, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.CacheException extendedException = new KnightsTour.CoreLibrary.CacheException(customException);
                extendedException.CacheKey = cacheKey;
                throw extendedException;
            }
        }
        /// <summary>
        /// Handles the rest exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="jsonData">The json data.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleRestException(Exception exception, string endpoint, string jsonData = null)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Api, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.RestException extendedException = new KnightsTour.CoreLibrary.RestException(customException);
                extendedException.Endpoint = endpoint;
                extendedException.JSONData = jsonData;
                throw extendedException;
            }
        }
        /// <summary>
        /// Handles the UI exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public void HandleUIException(Exception exception)
        {
            KnightsTour.CoreLibrary.CustomException customException = GetException(exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier.UI, new StackTrace());
            if (customException != null)
            {
                KnightsTour.CoreLibrary.UIException extendedException = new KnightsTour.CoreLibrary.UIException(customException);
                throw extendedException;
            }
        }
        #endregion

        #region Private support methods
        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="tier">The tier.</param>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>CustomException.</returns>
        KnightsTour.CoreLibrary.CustomException GetException(Exception exception, KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, StackTrace stackTrace)
        {
            // Get calling class and method name for context
            KnightsTour.CoreLibrary.MethodAttributeAssistant attributes = KnightsTour.CoreLibrary.ReflectionAssistant.GetMethodAttributes(stackTrace);
            string nameSpace = attributes.NameSpace;
            string className = attributes.Class;
            string methodName = attributes.Method;

            //Log Exception if required
            Context.LogHandler.Log(tier, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Exception, exception.Message, exception);

            //Determine if this is a known exception type or not and set the correct option list
            Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction> options = HandlingOptions_New;
            if (IsKnown(exception))
            {
                options = HandlingOptions_Known;
            }

            //Is there a configuration defined for this tier?
            if (options.ContainsKey(tier))
            {
                //Switch on the configuration
                switch (options[tier])
                {
                    case KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.Raise:
                        throw exception;
                    case KnightsTour.CoreLibrary.Enumerations.ExceptionHandlingAction.WrapAndRaise:
                        KnightsTour.CoreLibrary.CustomException baseCustomException = null;
                        if (exception is InvalidCastException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Invalid Cast Exception", exception);
                        else if (exception is SqlException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Sql Exception", exception);
                        else if (exception is IOException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("IO Exception", exception);
                        else if (exception is ObjectDisposedException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Object Disposed Exception", exception);
                        else if (exception is InvalidOperationException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Invalid Operation Exception", exception);
                        else if (exception is KnightsTour.CoreLibrary.DataException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Data Exception", exception);
                        else if (exception is KnightsTour.CoreLibrary.CacheException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Cache Exception", exception);
                        else if (exception is KnightsTour.CoreLibrary.RestException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Rest Exception", exception);
                        else if (exception is KnightsTour.CoreLibrary.UIException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("UI Exception", exception);
                        else if (exception is KnightsTour.CoreLibrary.LogicException)
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("Logic Exception", exception);
                        else
                            baseCustomException = new KnightsTour.CoreLibrary.CustomException("General Exception", exception);

                        baseCustomException.Tier = tier;
                        baseCustomException.Context = $"{nameSpace}.{className}.{methodName}()";
                        return baseCustomException;
                }
            }
            else
            {
                throw exception;
            }
            return null;
        }
        /// <summary>
        /// Determines whether the specified exception is known.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if the specified exception is known; otherwise, <c>false</c>.</returns>
        bool IsKnown(Exception exception)
        {
            return
                exception is KnightsTour.CoreLibrary.DataException ||
                exception is KnightsTour.CoreLibrary.CacheException ||
                exception is KnightsTour.CoreLibrary.LogicException ||
                exception is KnightsTour.CoreLibrary.RestException ||
                exception is KnightsTour.CoreLibrary.UIException;
        }
        #endregion
    }
}