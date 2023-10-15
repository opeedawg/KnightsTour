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
// Created          : March 14, 2023 6:19:34 AM
// File             : RestLookupController.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using KnightsTour;
using KnightsTour.CoreLibrary;
using KnightsTour.WebAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.RestControllers
{
    /// <summary>
    /// The extended REST email tracker endpoints.
    /// Created On: January 3, 2023
    /// Created By: Chris Chartrand (DXterity solutions)
    /// </summary>
    /// <seealso cref="WebAPI.RestControllers" />
    /// <remarks>
    /// As this class is just one of 3 available API techniques, it is prefixed with "Rest" as namespace differentations are not respected in the APIController protocol.
    /// This class is never overwritten once initialized - feel free to extend it as required with your custom endpoints.
    /// </remarks>
    [EnableCors("*")]
    [Route("rest/lookup")]
    public class RestLookupController : ApiControllerBase
    {
        #region Extended Methods
        [HttpPost]
        public IActionResult GetSelectValues([FromBody] dynamic parameters)
        {
            return ExecuteCommon(_GetSelectValues, new dynamic[] { parameters.selectionFilter });
        }
        /// <summary>
        /// Returns the total number of ContractTree entities based on the filter.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetSelectValues(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                ActionResponse response = new ActionResponse();
                try
                {
                    if (callLog.Arguments == null || string.IsNullOrEmpty(callLog.Arguments[0].ToString()))
                    {
                        response.Append(new Exception("Missing mandatory 'selection' parameter."));
                    }
                    else
                    {
                        string filter = callLog.Arguments[0];
                        response = LookupLogic.GetSelectOptions(filter);
                    }
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return Ok(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }
        [Route("single")]
        [HttpPost]
        public IActionResult GetSelectValue([FromBody] dynamic parameters)
        {
            return ExecuteCommon(_GetSelectValue, new dynamic[] { parameters.selectionFilter, parameters.value });
        }
        /// <summary>
        /// Returns the total number of ContractTree entities based on the filter.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetSelectValue(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                ActionResponse response = new ActionResponse();
                try
                {
                    if (callLog.Arguments == null || string.IsNullOrEmpty(callLog.Arguments[0].ToString()))
                    {
                        response.Append(new Exception("Missing mandatory 'selectionFilter' or 'value' parameter."));
                    }
                    else
                    {
                        string filter = callLog.Arguments[0];
                        string value = callLog.Arguments[1];
                        response = LookupLogic.GetSelectOption(filter, value);
                    }
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return Ok(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        #endregion Extended Methods

    } // Class
} // Namespace