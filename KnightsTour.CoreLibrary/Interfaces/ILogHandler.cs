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
// File             : ILogHandler.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// The ILogHandler interface.
    /// </summary>
    public interface ILogHandler
    {
        #region Methods
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        Dictionary<Enumerations.ApplicationTier, Dictionary<Enumerations.LoggingAction, bool>> Configuration { get; set; }
        /// <summary>
        /// Enables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        void Enable(Enumerations.ApplicationTier tier, Enumerations.LoggingAction action);
        /// <summary>
        /// Disables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        void Disable(Enumerations.ApplicationTier tier, Enumerations.LoggingAction action);
        /// <summary>
        /// Enables the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        void Enable(Enumerations.LoggingAction action);
        /// <summary>
        /// Disables the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        void Disable(Enumerations.LoggingAction action);
        /// <summary>
        /// Enables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        void Enable(Enumerations.ApplicationTier tier);
        /// <summary>
        /// Disables the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        void Disable(Enumerations.ApplicationTier tier);
        /// <summary>
        /// Enables this instance.
        /// </summary>
        void Enable();
        /// <summary>
        /// Disables this instance.
        /// </summary>
        void Disable();
        /// <summary>
        /// Flushes this instance.
        /// </summary>
        void Flush();
        /// <summary>
        /// Logs the specified tier.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        /// <param name="data">The data.</param>
        /// <param name="extendedDetails">The extended details.</param>
        void Log(Enumerations.ApplicationTier tier, Enumerations.LoggingAction action, string data, object extendedDetails = null);
        /// <summary>
        /// Determines whether the specified tier is enabled.
        /// </summary>
        /// <param name="tier">The tier.</param>
        /// <param name="action">The action.</param>
        /// <returns><c>true</c> if the specified tier is enabled; otherwise, <c>false</c>.</returns>
        bool IsEnabled(Enumerations.ApplicationTier tier, Enumerations.LoggingAction action);
        #endregion
    }
}