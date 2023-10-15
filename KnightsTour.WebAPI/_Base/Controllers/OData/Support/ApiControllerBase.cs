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
// File             : ApiControllerBase.cs
// ************************************************************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Configuration;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.ODataControllers
{
    public class ApiControllerBase: ODataController
    {
        #region Declarations
        int? defaultPageSize = null;
        int? defaultTimeoutSeconds = null;
        #endregion

        #region Properties
        /// <summary>Gets the default size of the page.</summary>
        /// <value>The default size of the page.</value>
        public int DefaultPageSize
        {
            get
            {
                int defaultDefaultPageSize = 25; //lol
                if (!defaultPageSize.HasValue)
                {
                    object o = ConfigurationManager.AppSettings["DefaultPageSize"];
                    if (o != null)
                    { 
                        if (int.TryParse(o.ToString(), out int result))
                            defaultPageSize = result;
                        else
                            defaultPageSize = defaultDefaultPageSize;
                    }
                    else
                        defaultPageSize = defaultDefaultPageSize;
                }
                return defaultPageSize.Value;
            }
        }
        /// <summary>
        /// Default timeout of the page load in seconds.
        /// </summary>
        public int DefaultTimeoutSeconds
        {
            get
            {
                int defaultDefaultTimeoutSeconds = 10;
                if (!defaultTimeoutSeconds.HasValue)
                {
                    object o = ConfigurationManager.AppSettings["DefaultTimeoutSeconds"];
                    if (o != null)
                    {
                        if (int.TryParse(o.ToString(), out int result))
                            defaultTimeoutSeconds = result;
                        else
                            defaultTimeoutSeconds = defaultDefaultTimeoutSeconds;
                    }
                    else
                        defaultTimeoutSeconds = defaultDefaultTimeoutSeconds;
                }
                return defaultTimeoutSeconds.Value;
            }
        }
        /// <summary>
        /// Returns the identity of the contextual user, otherwise Unknown.
        /// </summary>
        public string UserName
        {
            get
            {
                Claim identityClaim = Request.HttpContext.User.FindFirst(ClaimTypes.Name);
                if (identityClaim != null)
                    return identityClaim.Value;
                else
                    return "Unknown (OData)";
            }
        }
        #endregion

        #region Methods
        /// <summary>Executes the common method.</summary>
        /// <param name="functionHandler">The function handler.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        protected IActionResult ExecuteCommon(Func<dynamic[], IActionResult> functionHandler, dynamic[] arguments = null)
        {
            try
            {
                IActionResult result = StatusCode((int)HttpStatusCode.Accepted, $"Execution started at {DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()} UTC.");
                bool Completed = ExecuteWithTimeLimit(TimeSpan.FromSeconds(DefaultTimeoutSeconds), () =>
                {
                    result = functionHandler(arguments);
                });

                if (Completed)
                    return result;
                else
                    return StatusCode((int)HttpStatusCode.RequestTimeout, $"The requested call timed out.  Timeout configured to {DefaultTimeoutSeconds} seconds.");
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }
        bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                Task task = Task.Factory.StartNew(() => codeBlock());
                task.Wait(timeSpan);
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }
        #endregion
    }
}