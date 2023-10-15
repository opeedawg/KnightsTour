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
// Created          : January 13, 2023 7:25:01 AM
// File             : Context.cs
// ************************************************************************

using System;
using System.Globalization;

namespace KnightsTour
{
    /// <summary>
    /// Class Context. This class cannot be inherited.
    /// </summary>
    public sealed class Context
    {
        #region Public lazy loaded handlers
        /// <summary>
        /// Defined when generated, determines if the system should attempt to integrated with default auto-generated stored procedures or not.
        /// This can be overridden if desired.
        /// </summary>
        public static bool UseStoredProcedureIntegration = KnightsTour.Schema.Model.UseStoredProcedure;
        /// <summary>
        /// Gets the localization handler.
        /// </summary>
        /// <value>The localization handler.</value>
        public static KnightsTour.CoreLibrary.ILocalizationHandler LocalizationHandler { get { return lazyLocalization.Value; } }
        /// <summary>
        /// Gets the message handler.
        /// </summary>
        /// <value>The message handler.</value>
        public static KnightsTour.CoreLibrary.IMessageHandler MessageHandler { get { return lazyMessage.Value; } }
        /// <summary>
        /// Gets the log handler.
        /// </summary>
        /// <value>The log handler.</value>
        public static KnightsTour.CoreLibrary.ILogHandler LogHandler { get { return lazyLog.Value; } }
        /// <summary>
        /// Gets the exception handler.
        /// </summary>
        /// <value>The exception handler.</value>
        public static KnightsTour.CoreLibrary.IExceptionHandler ExceptionHandler { get { return lazyException.Value; } }
        /// <summary>
        /// Gets the data handler.
        /// </summary>
        /// <value>The data handler.</value>
        /// <summary>
        /// Gets the audit handler.
        /// </summary>
        /// <value>The audit handler.</value>
        public static KnightsTour.CoreLibrary.IAuditHandler AuditHandler { get { return lazyAudit.Value; } }
        /// <summary>
        /// Gets the validation handler.
        /// </summary>
        /// <value>The validation handler.</value>
        public static KnightsTour.CoreLibrary.IValidationHandler ValidationHandler { get { return lazyValidation.Value; } }
        /// <summary>
        /// Gets the cryptography handler.
        /// </summary>
        /// <value>The cryptography handler.</value>
        public static KnightsTour.CoreLibrary.ICryptographyHandler CryptographyHandler { get { return lazyCryptography.Value; } }
        /// <summary>
        /// Gets the email handler.
        /// </summary>
        /// <value>The email handler.</value>
        public static KnightsTour.CoreLibrary.IEmailHandler EmailHandler { get { return lazyEmail.Value; } }
        #endregion

        #region Handler definitions
        //Fee free to define your own handlers here - or use the built in one from 27 Software
        /// <summary>
        /// The lazy localization
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.ILocalizationHandler> lazyLocalization = new Lazy<KnightsTour.CoreLibrary.ILocalizationHandler>(() => new LocalizationHandler(new CultureInfo("en-US")), true);
        /// <summary>
        /// The lazy message
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.IMessageHandler> lazyMessage = new Lazy<KnightsTour.CoreLibrary.IMessageHandler>(() => new EnglishMessageHandler(), true);
        /// <summary>
        /// The lazy log
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.ILogHandler> lazyLog = new Lazy<KnightsTour.CoreLibrary.ILogHandler>(() => new LogHandler(), true);
        /// <summary>
        /// The lazy exception
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.IExceptionHandler> lazyException = new Lazy<KnightsTour.CoreLibrary.IExceptionHandler>(() => new ExceptionHandler(), true);
        /// <summary>
        /// The lazy audit
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.IAuditHandler> lazyAudit = new Lazy<KnightsTour.CoreLibrary.IAuditHandler>(() => new AuditHandler(KnightsTour.CoreLibrary.Enumerations.SerializationStrategy.JSON), true);
        /// <summary>
        /// The lazy validation
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.IValidationHandler> lazyValidation = new Lazy<KnightsTour.CoreLibrary.IValidationHandler>(() => new ValidationHandler(), true);
        /// <summary>
        /// The lazy cryptography
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.ICryptographyHandler> lazyCryptography = new Lazy<KnightsTour.CoreLibrary.ICryptographyHandler>(() => new AESCryptographyHandler("6C7E39E5DA3E52396457546C81898"), true);
        /// <summary>
        /// The lazy email
        /// </summary>
        private static readonly Lazy<KnightsTour.CoreLibrary.IEmailHandler> lazyEmail = new Lazy<KnightsTour.CoreLibrary.IEmailHandler>(() => new SendGridEmailHandler(), true);
        #endregion
    }
}
