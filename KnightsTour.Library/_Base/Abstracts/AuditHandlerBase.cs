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
// File             : AuditHandlerBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// Class AuditHandlerBase.
    /// </summary>
    /// <seealso cref="KnightsTour.MethodWrappers" />
    public abstract class AuditHandlerBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditHandlerBase"/> class.
        /// </summary>
        /// <param name="serializationStrategy">The serialization strategy.</param>
        public AuditHandlerBase(KnightsTour.CoreLibrary.Enumerations.SerializationStrategy serializationStrategy)
        {
            try
            {
                Configuration = new Dictionary<string, Dictionary<KnightsTour.CoreLibrary.Enumerations.CrudAction, bool>>();
                foreach (Enumerations.EntityName table in Enum.GetValues(typeof(Enumerations.EntityName)))
                {
                    Configuration.Add(table.ToString().ToUpper(), DefaultActions);
                }
                SerializationStrategy = serializationStrategy;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Properties
        Dictionary<KnightsTour.CoreLibrary.Enumerations.CrudAction, bool> DefaultActions
        {
            get
            {
                Dictionary<KnightsTour.CoreLibrary.Enumerations.CrudAction, bool> actions = new Dictionary<KnightsTour.CoreLibrary.Enumerations.CrudAction, bool>();
                foreach (KnightsTour.CoreLibrary.Enumerations.CrudAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.CrudAction)))
                {
                    actions.Add(action, false);
                }
                return actions;
            }
        }
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Dictionary<string, Dictionary<KnightsTour.CoreLibrary.Enumerations.CrudAction, bool>> Configuration { get; set; }
        /// <summary>
        /// Gets or sets the serialization strategy.
        /// </summary>
        /// <value>The serialization strategy.</value>
        public KnightsTour.CoreLibrary.Enumerations.SerializationStrategy SerializationStrategy { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Enables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        public void Enable(KnightsTour.Enumerations.EntityName table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            Enable(table.ToString(), action);
        }
        /// <summary>
        /// Enables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        public void Enable(string table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            try
            {
                if (Configuration.ContainsKey(table.ToUpper()))
                    Configuration[table.ToUpper()][action] = true;
                else
                {
                    Dictionary<KnightsTour.CoreLibrary.Enumerations.CrudAction, bool> actions = DefaultActions;
                    actions[action] = true;
                    Configuration.Add(table.ToUpper(), actions);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Enables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void Enable(Enumerations.EntityName table)
        {
            Enable(table.ToString());
        }
        /// <summary>
        /// Enables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void Enable(string table)
        {
            try
            {
                if (Configuration.ContainsKey(table.ToUpper()))
                {
                    foreach (KnightsTour.CoreLibrary.Enumerations.CrudAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.CrudAction)))
                    {
                        Configuration[table.ToUpper()][action] = true;
                    }
                }
                else
                {
                    Configuration.Add(table.ToUpper(), DefaultActions);
                    Enable(table);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Enables the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Enable(KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            try
            {
                foreach(string key in Configuration.Keys)
                {
                    Configuration[key][action] = true;
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Enables this instance.
        /// </summary>
        public void Enable()
        {
            try
            {
                foreach (string key in Configuration.Keys)
                {
                    foreach (KnightsTour.CoreLibrary.Enumerations.CrudAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.CrudAction)))
                    {
                        Configuration[key][action] = true;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Disables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        public void Disable(Enumerations.EntityName table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            Disable(table.ToString(), action);
        }
        /// <summary>
        /// Disables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        public void Disable(string table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            try
            {
                if (Configuration.ContainsKey(table.ToUpper()))
                    Configuration[table.ToUpper()][action] = false;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Disables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void Disable(Enumerations.EntityName table)
        {
            Disable(table.ToString());
        }
        /// <summary>
        /// Disables the specified table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void Disable(string table)
        {
            try
            {
                if (Configuration.ContainsKey(table.ToUpper()))
                {
                    foreach (KnightsTour.CoreLibrary.Enumerations.CrudAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.CrudAction)))
                    {
                        Configuration[table.ToUpper()][action] = false;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Disables the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Disable(KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            try
            {
                foreach (string key in Configuration.Keys)
                {
                    Configuration[key][action] = false;
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Disables this instance.
        /// </summary>
        public void Disable()
        {
            try
            {
                foreach (string key in Configuration.Keys)
                {
                    foreach (KnightsTour.CoreLibrary.Enumerations.CrudAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.CrudAction)))
                    {
                        Configuration[key][action] = false;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Determines whether the specified table is enabled.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        /// <returns><c>true</c> if the specified table is enabled; otherwise, <c>false</c>.</returns>
        public bool IsEnabled(Enumerations.EntityName table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            return IsEnabled(table.ToString(), action);
        }
        /// <summary>
        /// Determines whether the specified table is enabled.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        /// <returns><c>true</c> if the specified table is enabled; otherwise, <c>false</c>.</returns>
        public bool IsEnabled(string table, KnightsTour.CoreLibrary.Enumerations.CrudAction action)
        {
            if(Configuration.ContainsKey(table.ToUpper()))
                return Configuration[table.ToUpper()][action];
            return false;
        }
        #endregion
    }
}