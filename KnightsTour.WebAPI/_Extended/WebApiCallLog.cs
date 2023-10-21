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
// Created          : January 13, 2023 7:25:02 AM
// File             : WebApiCallLog.cs
// ************************************************************************

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using KnightsTour.CoreLibrary;
using KnightsTour.CoreLibrary.Enumerations;

namespace KnightsTour.WebAPI
{
    /// <summary>
    /// A base class to provide common API end point utility, can be extended as required.
    /// </summary>
    /// <seealso cref="KnightsTour.WebAPI.WebApiCallLogBase" />
    public class WebApiCallLog : WebApiCallLogBase
    {
        #region Extended Constructors
        /// <summary>
        /// Instatiates a new api call log.
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="context"></param>
        public WebApiCallLog(string endPoint, HttpContext context, dynamic[] arguments) : base(endPoint, context, arguments)
        {
          #if DEBUG
            // In debug mode, open up everything.
            if (!AuthorizationRequirements.ContainsKey(endPoint))
              AuthorizationRequirements.Add(endPoint, new List<string>() { });
          #endif        
        }
        #endregion

        #region Extended Declarations
        public int? executingUserId = null;
        #endregion

        #region Extended Properties
        public string UserName { get; set; }
        public int ExecutingUserId 
        {
            get
            {
                if (!executingUserId.HasValue)
                {
                    executingUserId = 0;
                }

                return executingUserId.Value;
            }
        }
        #endregion

        #region Method Overrides
        /// <summary>
        /// Typically called just prior to the api invocation.
        /// </summary>
        public new void Start()
        {
            base.Start();

            Authenticate();
        }

        /// <summary>
        /// Typically called after the natural api termination.
        /// </summary>
        public new void End()
        {
            base.End();
        }

        /// <summary>
        /// Typically called after an exception in the api.
        /// </summary>
        public new void Error(string errorDetails)
        {
            base.Error(errorDetails);
        }

        /// <summary>
        /// Typically called after an exception in the api.
        /// </summary>
        public new void Error(Exception exception)
        {
            base.Error(exception);
        }

        /// <summary>
        /// Typically called after an api timeout.
        /// </summary>
        public new void Timeout()
        {
            base.Timeout();
        }

        /// <summary>
        /// Custom authentication implementation.
        /// </summary>
        private void Authenticate()
        {
            // TODO: Do your custom authentication here.
            IActionResponse authenticationResponse = new ActionResponse("API Authentication");
            // authenticationResponse.Append(new Exception("Not implemented"));

            Authenticated = authenticationResponse.IsValid;

            if (!Authenticated)
            {
                Error(authenticationResponse.Messages.FirstOrDefault(m => m.Type == MessageType.Negative).Content);
                HttpStatus = HttpStatusCode.Unauthorized;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized()
        {
            if (Authenticated)
            {
                if (AuthorizationRequirements.ContainsKey(EndPoint))
                {
                    // TODO: Invoke your custom authorization implemention here.
                    if (true)
                    {
                        return true;
                    }
                    else
                    {
                        Error("Insufficient privelages");
                        HttpStatus = HttpStatusCode.Unauthorized;
                    }
                }
                else
                {
                    return true; // No authorization configured.
                }
            }
            else
            {
                Error("Not authenticated.");
                HttpStatus = HttpStatusCode.Unauthorized;
            }

            return false; // Secure by default.
        }
        #endregion

        #region Extended Methods
        #endregion
    }
}