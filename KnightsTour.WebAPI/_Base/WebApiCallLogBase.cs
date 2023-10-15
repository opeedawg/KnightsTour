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
// File             : WebApiCallLogBase.cs
// ************************************************************************

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace KnightsTour.WebAPI
{
    /// <summary>
    /// The base (common) api call log functionality.  Can be extended in the provided WebApiCallLog class.
    /// </summary>
    /// <seealso cref="KnightsTour.WebAPI.WebApiCallLog" />
    public class WebApiCallLogBase
    {
        #region Constructors
        public WebApiCallLogBase(string endPoint, HttpContext context, dynamic[] arguments)
        {
            Authenticated = false;

            ExecutionId = Guid.NewGuid();
            EndPoint = endPoint;
            Context = context;
            Arguments = arguments;
            string jsonArguments = ArgumentsJSON; // Due to reflection and stack issues, this needs to be initialized here.
            AuthorizationRequirements = new Dictionary<string, List<string>>();
        }
        #endregion

        #region Declarations
        private string argumentsJson = null;
        #endregion

        #region Properties
        /// <summary>
        /// The Http Context for the invoking call.
        /// </summary>
        public HttpContext Context { get; set; }
        /// <summary>
        /// The namespace, class and method name being invoked.
        /// </summary>
        public string EndPoint { get; private set; }
        /// <summary>
        /// A unique identifier for call tracking.
        /// </summary>
        public Guid ExecutionId { get; private set; }
        /// <summary>
        /// The time the 'Start()' method was invoked just prior to end point invocation.
        /// </summary>
        public DateTime? StartTime { get; private set; }
        /// <summary>
        /// The time the 'End()' or 'Error()' or 'Timeout()' method was invoked just after to end point termination.
        /// </summary>
        public DateTime? EndTime { get; private set; }
        /// <summary>
        /// The total duration, set once the call has completed.
        /// </summary>
        public TimeSpan? Duration
        {
            get
            {
                if (StartTime.HasValue && EndTime.HasValue)
                {
                    return EndTime.Value.Subtract(StartTime.Value);
                }

                return null;
            }
        }
        /// <summary>
        /// Any exception details.
        /// </summary>
        public Exception ErrorDetails { get; set; }
        /// <summary>
        /// The arguments passed to this call.
        /// </summary>
        public dynamic[] Arguments { get; private set; }
        /// <summary>
        /// Returns a JSON formatted key value pair representation of the parameters.
        /// </summary>
        public string ArgumentsJSON
        {
            get
            {
                // Lazyload/singleton pattern for efficiency.
                if (argumentsJson == null)
                {
                    argumentsJson = GetParameters();
                }

                return argumentsJson;
            }
        }
        public HttpStatusCode HttpStatus { get; set; }
        /// <summary>
        /// Determines if the call is still valid (if there are no exceptions).
        /// </summary>
        public bool IsValid 
        {
            get 
            {
                return ErrorDetails == null;
            }
        }     
        /// <summary>
        /// A dictionary of endpoint paths and required authorization claims.
        /// </summary>
        public Dictionary<string, List<string>> AuthorizationRequirements { get; set; }
        /// <summary>
        /// Returns if this call has been authenticated or not.
        /// </summary>
        public bool Authenticated { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Typically called just prior to the api invocation.
        /// </summary>
        public void Start()
        {
            StartTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Typically called after the natural api termination.
        /// </summary>
        public void End()
        {
            HttpStatus = HttpStatusCode.OK;
            EndTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Typically called after an exception in the api.
        /// </summary>
        public void Error(string errorDetails)
        {
            Error(new Exception(errorDetails));
        }

        /// <summary>
        /// Typically called after an exception in the api.
        /// </summary>
        public void Error(Exception exception)
        {
            HttpStatus = HttpStatusCode.InternalServerError;
            ErrorDetails = exception;
            End();
        }

        /// <summary>
        /// Typically called after an api timeout.
        /// </summary>
        public void Timeout()
        {
            HttpStatus = HttpStatusCode.RequestTimeout;
            End();
        }

        /// <summary>
        /// Converts the dynamic argument values, along with some reflection to create a JSON represetnation of the method parameters.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        private string GetParameters()
        {
            try
            {
                // Going for {key1:val1, key2:val2}
                Dictionary<string, string> valueDictionary = new Dictionary<string, string>();
                if (Arguments != null && Arguments.Length > 0)
                {
                    MethodBase method = new StackFrame(5, false).GetMethod();
                    ParameterInfo[] param = method.GetParameters();
                    int paramIndex = 0;
                    foreach (ParameterInfo pi in param)
                    {
                        valueDictionary.Add(pi.Name, Newtonsoft.Json.JsonConvert.SerializeObject(Arguments[paramIndex]));
                        paramIndex++;
                    }
                }

                if (valueDictionary != null && valueDictionary.Count > 0)
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(valueDictionary);
                }
            }
            catch
            {
            }

            return "{}";
        }
        #endregion
    }
}