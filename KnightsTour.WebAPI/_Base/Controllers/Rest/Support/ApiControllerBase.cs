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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KnightsTour.WebAPI;
using KnightsTour.CoreLibrary;
using System.Text.Json;
using Newtonsoft.Json;

namespace WebAPI.RestControllers
{
    public class ApiControllerBase : ControllerBase
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
                    return "Unknown (Classic)";
            }
        }
        #endregion

        #region Methods
        [ApiExplorerSettings(IgnoreApi = true)]
        /// <summary>Applies the collection filter to a generic enumerable list.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public IEnumerable<T> ApplyCollectionFilter<T>(HttpRequest request, IEnumerable<T> collection)
        {
            CollectionFilter filter = new CollectionFilter(request, DefaultPageSize);

            if (!string.IsNullOrEmpty(filter.OrderBy))
                collection = collection.AsQueryable().OrderBy(filter.OrderBy);

            return collection.Skip(filter.Skip).Take(filter.PageSize);
        }

        /// <summary>Executes the common method.</summary>
        /// <param name="functionHandler">The function handler.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        protected IActionResult ExecuteCommon(Func<dynamic[], IActionResult> functionHandler, dynamic[] arguments = null, [CallerMemberName] string caller = null)
        {
            try
            {
                // Initialize the api call log object.
                WriteErrorLog($"  ExecuteCommon: {caller}");
                WebApiCallLog callLog = new WebApiCallLog($"{NameOfCallingClass()}.{caller}", HttpContext, arguments);

                IActionResult result = Content($"Execution started at {DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()} UTC.");
                bool Completed = ExecuteWithTimeLimit(TimeSpan.FromSeconds(DefaultTimeoutSeconds), () =>
                {
                    callLog.Start();
                    result = functionHandler(new dynamic[1] { callLog });
                });

                if (Completed)
                {
                    callLog.End();
                    return result;
                }
                else
                {
                    callLog.Timeout();
                    return StatusCode((int)HttpStatusCode.RequestTimeout, $"The requested call timed out.  Timeout configured to {DefaultTimeoutSeconds} seconds.");
                }
            }
            catch (Exception exception)
            {
                WriteErrorLog($"  ExecuteCommon: Exception {exception}");
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }

        /// <summary>
        /// Executes a function as an asynchronous call and returns an IActionResult.
        /// </summary>
        /// <param name="functionHandler"></param>
        /// <param name="arguments"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        protected async Task<IActionResult> ExecuteCommonAsync(Func<dynamic[], IActionResult> functionHandler, dynamic[] arguments = null, [CallerMemberName] string caller = null)
        {
            try
            {
                // Initialize the api call log object.
                WebApiCallLog callLog = new WebApiCallLog($"{NameOfCallingClass()}.{caller}", HttpContext, arguments);

                try
                {
                    IActionResult result = Content($"Execution started at {DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()} UTC.");
                    bool Completed = await Task.Run(() => ExecuteWithTimeLimit(TimeSpan.FromSeconds(DefaultTimeoutSeconds), () =>
                    {
                        callLog.Start();
                        result = functionHandler(new dynamic[1] { callLog });
                    }));

                    if (Completed)
                    {
                        callLog.End();
                        return result;
                    }
                    else
                    {
                        callLog.Timeout();
                        return StatusCode((int)HttpStatusCode.RequestTimeout, $"The requested call timed out.  Timeout configured to {DefaultTimeoutSeconds} seconds.");
                    }
                }
                catch (Exception exception)
                {
                    WriteErrorLog($"  ExecuteCommonAsync: Exception {exception}");
                    callLog.Error(exception);
                    return StatusCode((int)HttpStatusCode.InternalServerError, exception);
                }
            }
            catch (Exception exception)
            {
                WriteErrorLog($"  ExecuteCommonAsync: Exception {exception}");
                return StatusCode((int)HttpStatusCode.InternalServerError, exception);
            }
        }

        /// <summary>
        /// Executes a web api call with an established time limit.
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="codeBlock"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the name of the calling class, 2 stack frames up using reflection.
        /// </summary>
        /// <returns></returns>
        string NameOfCallingClass()
        {
            try
            {
                string fullName;
                Type declaringType;
                int skipFrames = 2;
                do
                {
                    MethodBase method = new StackFrame(skipFrames, false).GetMethod();
                    declaringType = method.DeclaringType;
                    if (declaringType == null)
                    {
                        return method.Name;
                    }
                    skipFrames++;
                    fullName = declaringType.FullName;
                }
                while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));

                return fullName;
            }
            catch (Exception exception)
            {
                WriteErrorLog($"    NameOfCallingClass: Exception: {exception.Message}");
            }

            return string.Empty;
        }
        /// <summary>
        /// Handles generic errors or non-authorized exceptions.
        /// </summary>
        /// <param name="callLog"></param>
        /// <returns></returns>
        protected IActionResult ProcessExceptions(WebApiCallLog callLog)
        {
            if (callLog.HttpStatus == HttpStatusCode.Unauthorized)
            {
                return Unauthorized(callLog.ErrorDetails.Message);
            }
            else
            {
                return BadRequest(callLog.ErrorDetails.Message);
            }
        }
        /// <summary>
        /// Splits a string list of numeric ids into a strong list type.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected List<int?> SplitNumericIds(string input)
        {
            List<int?> ids = new List<int?>();
            foreach (string id in input.Split(','))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int newId = 0;
                    if (int.TryParse(id, out newId))
                    {
                        ids.Add(newId);
                    }
                }
            }
            return ids;
        }
        /// <summary>
        /// Splits a string list of non-numeric ids into a strong list type.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected List<string> SplitTextIds(string input)
        {
            List<string> ids = new List<string>();
            foreach (string id in input.Split(','))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ids.Add($"'{id.Replace("'", "")}'");
                }
            }
            return ids;
        }
        /// <summary>
        /// Valdiates the response prior to seding it back to make sure any attacched data object can be serialized as JSON.
        /// Typical errors are circular references, etc.
        /// 2 types of serialization are performed.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected IActionResult ValidateResponseObject(IActionResponse response)
        {
            if (response.DataObject != null)
            {
                // Validate that it can be serialized as JSON
                try
                {
                    // DO it two different ways to be really sure!
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(response.DataObject);
                    jsonString = JsonConvert.SerializeObject(response.DataObject);
                }
                catch (Exception exception)
                {
                    response.Append(new Exception($"Serialization failure in {response.Context}: {exception.Message}"));
                    WriteErrorLog($"Serialization failure in {response.Context}: {exception.Message}");
                    response.DataObject = null;
                }
            }

            return Ok(response);
        }
        /// <summary>
        /// Writes an error log, this path can and should be configured to your liking.
        /// </summary>
        /// <param name="message"></param>
        void WriteErrorLog(string message)
        {
            System.IO.File.AppendAllLines($"E:\\Development\\KnightsTour\\Logs\\KT_APIErrorLog_{DateTime.Now.ToString("yyyy-MM-dd")}.txt", new List<string>() { $"{DateTime.Now.ToLongDateString()}: {message}" });
        }
        protected IActionResponse FormatException(Exception exception)
        {
            IActionResponse response = new ActionResponse();

            if(exception.InnerException != null)
            {
                response.Append(FormatException(exception.InnerException));
            }
            else
            {
                response.Append(exception);
            }

            return response;
        }
        #endregion
    }
}