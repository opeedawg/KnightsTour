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
// File             : LogHandlerBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;

namespace KnightsTour
{
    /// <summary>
    /// Class LogHandlerBase.
    /// </summary>
    public abstract class LogHandlerBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LogHandlerBase"/> class.
        /// </summary>
        public LogHandlerBase()
        {
            try
            {
                Configuration = new Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, Dictionary<KnightsTour.CoreLibrary.Enumerations.LoggingAction, bool>>();
                foreach (KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.ApplicationTier)))
                {
                    Dictionary<KnightsTour.CoreLibrary.Enumerations.LoggingAction, bool> actions = new Dictionary<KnightsTour.CoreLibrary.Enumerations.LoggingAction, bool>();
                    foreach (KnightsTour.CoreLibrary.Enumerations.LoggingAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.LoggingAction)))
                    {
                        actions.Add(action, false);
                    }
                    Configuration.Add(tier, actions);
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Dictionary<KnightsTour.CoreLibrary.Enumerations.ApplicationTier, Dictionary<KnightsTour.CoreLibrary.Enumerations.LoggingAction, bool>> Configuration { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Enables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        public void Enable(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.LoggingAction action)
        {
            try
            {
                Configuration[tier][action] = true;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Enables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        public void Enable(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier)
        {
            try
            {
                foreach (KnightsTour.CoreLibrary.Enumerations.LoggingAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.LoggingAction)))
                {
                    Configuration[tier][action] = true;
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
        public void Enable(KnightsTour.CoreLibrary.Enumerations.LoggingAction action)
        {
            try
            {
                foreach (KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.ApplicationTier)))
                {
                    Configuration[tier][action] = true;
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
                foreach (KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.ApplicationTier)))
                {
                    foreach (KnightsTour.CoreLibrary.Enumerations.LoggingAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.LoggingAction)))
                    {
                        Configuration[tier][action] = true;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Disables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        public void Disable(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.LoggingAction action)
        {
            try
            {
                Configuration[tier][action] = false;
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        /// <summary>
        /// Disables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        public void Disable(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier)
        {
            try
            {
                foreach (KnightsTour.CoreLibrary.Enumerations.LoggingAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.LoggingAction)))
                {
                    Configuration[tier][action] = false;
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
        public void Disable(KnightsTour.CoreLibrary.Enumerations.LoggingAction action)
        {
            try
            {
                foreach (KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.ApplicationTier)))
                {
                    Configuration[tier][action] = false;
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
                foreach (KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.ApplicationTier)))
                {
                    foreach (KnightsTour.CoreLibrary.Enumerations.LoggingAction action in Enum.GetValues(typeof(KnightsTour.CoreLibrary.Enumerations.LoggingAction)))
                    {
                        Configuration[tier][action] = false;
                    }
                }
            }
            catch (Exception exception)
            {
                Context.ExceptionHandler.HandleLogException(exception);
            }
        }
        #endregion

        #region Private support methods
        /// <summary>
        /// Determines whether the specified tier is enabled.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        /// <returns><c>true</c> if the specified tier is enabled; otherwise, <c>false</c>.</returns>
        public bool IsEnabled(KnightsTour.CoreLibrary.Enumerations.ApplicationTier tier, KnightsTour.CoreLibrary.Enumerations.LoggingAction action)
        {
            return Configuration[tier][action];
        }
        #endregion
    }
}