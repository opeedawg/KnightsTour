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
// File             : MethodWrappers.cs
// ************************************************************************

using System;

namespace KnightsTour
{
    /// <summary>
    /// Class MethodWrappers.
    /// </summary>
    public static class MethodWrappers
    {
        /// <summary>
        /// Commons the wrapper.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="functionHandler">The function handler.</param>
        /// <param name="tier">The tier.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="argumentIndexToLog">The argument index to log.</param>
        /// <returns>T.</returns>
        public static T CommonWrapper<T>(Func<object[], T> functionHandler, KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, object[] arguments, int argumentIndexToLog)
        {
            return CommonWrapper<T>(functionHandler, tier, arguments, true, argumentIndexToLog);
        }
        /// <summary>
        /// Commons the wrapper.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="functionHandler">The function handler.</param>
        /// <param name="tier">The tier.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="withExceptionManagement">if set to <c>true</c> [with exception management].</param>
        /// <param name="argumentIndexToLog">The argument index to log.</param>
        /// <returns>T.</returns>
        public static T CommonWrapper<T>(Func<object[], T> functionHandler, KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, object[] arguments, bool withExceptionManagement = true, int? argumentIndexToLog = null)
        {
            switch (tier)
            {
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit:
                    #region Wrapper Code
                    string table = (string)arguments[0];
                    KnightsTour.CoreLibrary.Enumerations.CrudAction action = (KnightsTour.CoreLibrary.Enumerations.CrudAction)arguments[1];
                    if (withExceptionManagement)
                    {
                        try
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));
                            if (Context.AuditHandler.IsEnabled(table, action))
                            {
                                return functionHandler(arguments);
                            }
                        }
                        catch (Exception exception)
                        {
                            Context.ExceptionHandler.HandleAuditException(exception, table, action);
                        }
                        finally
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                        }
                    }
                    else
                    {
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));
                        T result = functionHandler(arguments);
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                        return result;
                    }
                    break;
                #endregion
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Cache:
                    break;
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data:
                    #region Wrapper Code
                    KnightsTour.CoreLibrary.StorageStatement statement = (KnightsTour.CoreLibrary.StorageStatement)arguments[0];
                    if (withExceptionManagement)
                    {
                        try
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), statement);
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.SQL, statement.Statement, statement);
                            return functionHandler(arguments);
                        }
                        catch (Exception exception)
                        {
                            Context.ExceptionHandler.HandleDataException(exception, statement);
                        }
                        finally
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End), statement);
                        }
                    }
                    else
                    {
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), statement);
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.SQL, statement.Statement, statement);
                        T result = functionHandler(arguments);
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));

                        return result;
                    }
                    break;
                #endregion
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business:
                    #region Wrapper Code
                    if (withExceptionManagement)
                    {
                        try
                        {
                            if (argumentIndexToLog.HasValue && arguments.Length > argumentIndexToLog)
                                Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), arguments[argumentIndexToLog.Value]);
                            else
                                Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));

                            return functionHandler(arguments);
                        }
                        catch (Exception exception)
                        {
                            Context.ExceptionHandler.HandleBusinessException(exception);
                        }
                        finally
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                        }
                    }
                    else
                    {
                        if (argumentIndexToLog.HasValue && arguments.Length > argumentIndexToLog)
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), arguments[argumentIndexToLog.Value]);
                        else
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));

                        T response = functionHandler(arguments);

                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));

                        return response;
                    }
                    break;
                #endregion
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Api:
                    break;
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.UI:
                    break;
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging:
                    break;
            }
            return default(T);
        }
        /// <summary>
        /// Commons the wrapper.
        /// </summary>
        /// <param name="actionHandler">The action handler.</param>
        /// <param name="tier">The tier.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="argumentIndexToLog">The argument index to log.</param>
        public static void CommonWrapper(Action<object[]> actionHandler, KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, object[] arguments, int argumentIndexToLog)
        {
            CommonWrapper(actionHandler, tier, arguments, true, argumentIndexToLog);
        }
        /// <summary>
        /// Commons the wrapper.
        /// </summary>
        /// <param name="actionHandler">The action handler.</param>
        /// <param name="tier">The tier.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="withExceptionManagement">if set to <c>true</c> [with exception management].</param>
        /// <param name="argumentIndexToLog">The argument index to log.</param>
        public static void CommonWrapper(Action<object[]> actionHandler, KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, object[] arguments, bool withExceptionManagement = true, int? argumentIndexToLog = null)
        {
            switch (tier)
            {
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit:
                    #region Wrapper Code
                    string table = (string)arguments[0];
                    KnightsTour.CoreLibrary.Enumerations.CrudAction action = (KnightsTour.CoreLibrary.Enumerations.CrudAction)arguments[1];
                    if (withExceptionManagement)
                    {
                        try
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));
                            if (Context.AuditHandler.IsEnabled(table, action))
                            {
                                actionHandler(arguments);
                            }
                        }
                        catch (Exception exception)
                        {
                            Context.ExceptionHandler.HandleAuditException(exception, table, action);
                        }
                        finally
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                        }
                    }
                    else
                    {
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));
                        actionHandler(arguments);
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Audit, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                    }
                    break;
                #endregion
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Cache:
                    break;
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data:
                    #region Wrapper Code
                    KnightsTour.CoreLibrary.StorageStatement statement = (KnightsTour.CoreLibrary.StorageStatement)arguments[0];
                    if (withExceptionManagement)
                    {
                        try
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), statement);
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.SQL, statement.Statement, statement);
                            actionHandler(arguments);
                        }
                        catch (Exception exception)
                        {
                            Context.ExceptionHandler.HandleDataException(exception, statement);
                        }
                        finally
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End), statement);
                        }
                    }
                    else
                    {
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), statement);
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.SQL, statement.Statement, statement);
                        actionHandler(arguments);
                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Data, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                    }
                    break;
                #endregion
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business:
                    #region Wrapper Code
                    if (withExceptionManagement)
                    {
                        try
                        {
                            if (argumentIndexToLog.HasValue && arguments.Length > argumentIndexToLog)
                                Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), arguments[argumentIndexToLog.Value]);
                            else
                                Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));

                            actionHandler(arguments);
                        }
                        catch (Exception exception)
                        {
                            Context.ExceptionHandler.HandleBusinessException(exception);
                        }
                        finally
                        {
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                        }
                    }
                    else
                    {
                        if (argumentIndexToLog.HasValue && arguments.Length > argumentIndexToLog)
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start), arguments[argumentIndexToLog.Value]);
                        else
                            Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_Start));

                        actionHandler(arguments);

                        Context.LogHandler.Log(KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Business, KnightsTour.CoreLibrary.Enumerations.LoggingAction.Event, Context.MessageHandler.Get(KnightsTour.CoreLibrary.Enumerations.SystemMessage.Method_End));
                    }
                    break;
                #endregion
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Api:
                    break;
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.UI:
                    break;
                case KnightsTour.CoreLibrary.Enumerations.ApplicationTier.Logging:
                    break;
            }
        }
    }
}


