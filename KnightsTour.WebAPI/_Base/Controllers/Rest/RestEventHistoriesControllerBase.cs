// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : RestEventHistoriesControllerBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

using KnightsTour;
using KnightsTour.CoreLibrary;
using KnightsTour.WebAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.RestControllers
{
    /// <summary>
    /// The base Rest based event history endpoints.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    /// <remarks>
    /// As this class is just one of 3 available API techniques, it is prefixed with "Rest" as namespace differentations are not respected in the APIController protocol.
    /// This class is overwritten every time the entity or generator version is modified to stay in sync with your model.
    /// </remarks>
    public class RestEventHistoriesControllerBase : ApiControllerBase
    {
        #region Public endpoints Methods

        /// <summary>
        /// Offers a simple ping test to see if the controller is responding at all.
        /// </summary>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("ping")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Ping()
        {
            return Ok("Rest EventHistories controller is responding.");
        }

        /// <summary>
        /// Returns a page limited list of all EventHistory entities.
        /// </summary>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Get()
        {
            return await ExecuteCommonAsync(_Get);
        }

        /// <summary>
        /// Returns a single EventHistory entity.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.EventHistory" /> of which to retrieve.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Get(int? id)
        {
            return await ExecuteCommonAsync(_Get, new dynamic[] { id });
        }

        /// <summary>
        /// Returns a list of entities based on the ids requested.  Supports object hydration.
        /// </summary>
        /// <param name="ids">The ids of the <seealso cref="KnightsTour.EventHistory" /> of which to retrieve.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("ids/{ids}")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> GetByIds(string ids)
        {
            return await ExecuteCommonAsync(_GetByIds, new dynamic[] { ids });
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.EventHistory" /> entity.
        /// </summary>
        /// <param name="eventHistoryLite">The new <seealso cref="KnightsTour.EventHistoryLite" /> to insert.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("")]
        [HttpPost]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Post([FromBody] KnightsTour.EventHistoryLite eventHistoryLite)
        {
            return await ExecuteCommonAsync(_Post, new dynamic[] { eventHistoryLite });
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.EventHistory" /> entity in a cascading manner.
        /// </summary>
        /// <param name="eventHistoryLite">The new <seealso cref="KnightsTour.EventHistory" /> to insert.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("cascade")]
        [HttpPost]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> PostCascade([FromBody] KnightsTour.EventHistoryLite eventHistoryLite)
        {
            return await ExecuteCommonAsync(_PostCascade, new dynamic[] { eventHistoryLite });
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.EventHistory" /> entity.
        /// </summary>
        /// <param name="eventHistoryLite">The <seealso cref="KnightsTour.EventHistoryLite" /> to update.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("")]
        [HttpPut]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Put([FromBody] KnightsTour.EventHistoryLite eventHistoryLite)
        {
            return await ExecuteCommonAsync(_Put, new dynamic[] { eventHistoryLite });
        }

        /// <summary>
        /// Deletes a single EventHistory entity.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.EventHistory" /> of which to delete.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}")]
        [HttpDelete]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Delete(int? id)
        {
            return await ExecuteCommonAsync(_Delete, new dynamic[] { id });
        }

        /// <summary>
        /// Deletes a single EventHistory entity and all its dependencies.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.EventHistory" /> of which to delete.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/cascade")]
        [HttpDelete]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> DeleteCascade(int? id)
        {
            return await ExecuteCommonAsync(_DeleteCascade, new dynamic[] { id });
        }

        /// <summary>
        /// Deletes a single EventHistory entity.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.EventHistory" /> of which to delete.</param>
        /// <param name="fkName">The foerign key column name for which to use as a basis for this deletion.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/byFK/{fkName}")]
        [HttpDelete]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> DeleteByFK(int? id, string fkName)
        {
            return await ExecuteCommonAsync(_DeleteByFK, new dynamic[] { fkName, id });
        }

        /// <summary>
        /// Performs a defined custom action against the passed ids.
        /// </summary>
        /// <param name="actionName">The name of the defined/configured custom action.</param>
        /// <param name="ids">The list of pks in which to exiecute this action.  Can be a single one.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("doCustomAction/{actionName}/{ids}")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> DoCustomAction(string actionName, string ids)
        {
            return await ExecuteCommonAsync(_DoCustomAction, new dynamic[] { actionName, ids });
        }

        /// <summary>
        /// Returns a single EventHistory entity.
        /// </summary>
        /// <param name="filter">The filter to apply to the <seealso cref="KnightsTour.EventHistory" /> of which to retrieve.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("extended")]
        [HttpPost]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> GetAllExtended([FromBody] KnightsTour.CoreLibrary.EntityFilter filter)
        {
            return await ExecuteCommonAsync(_GetAllExtended, new dynamic[] { filter });
        }

        /// <summary>
        /// Returns the number of EventHistory records fiven the filter.
        /// </summary>
        /// <param name="filter">The filter to apply to the <seealso cref="KnightsTour.EventHistory" /> of which to retrieve.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("count")]
        [HttpPost]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> GetCount([FromBody] KnightsTour.CoreLibrary.EntityFilter filter)
        {
            return await ExecuteCommonAsync(_GetCount, new dynamic[] { filter });
        }

        /// <summary>
        /// Returns the related EventType entity related to the EventHistory.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.EventHistory" /> of which to retrieve the related <seealso cref="KnightsTour.EventType" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/eventType")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> EventType(int? id)
        {
            return await ExecuteCommonAsync(_EventType, new dynamic[] { id });
        }

        /// <summary>
        /// Returns the related Member entity related to the EventHistory.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.EventHistory" /> of which to retrieve the related <seealso cref="KnightsTour.Member" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/member")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Member(int? id)
        {
            return await ExecuteCommonAsync(_Member, new dynamic[] { id });
        }
        #endregion Public endpoints Methods

        #region CRUD Methods

        /// <summary>
        /// Returns a page limited list of all EventHistory entities.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Get(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                ActionResponse response = new ActionResponse();
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                    if (callLog.Arguments == null)
                    {
                        IEnumerable<KnightsTour.EventHistory> eventHistories = ApplyCollectionFilter<KnightsTour.EventHistory>(Request, logic.GetAll());
                        response.DataObject = eventHistories.ToLite();
                    }
                    else
                    {
                        KnightsTour.EventHistory eventHistory = logic.GetById(callLog.Arguments[0]);
                        if (eventHistory == null)
                        {
                            return new NotFoundResult();
                        }
                        else
                        {
                            response.DataObject = eventHistory.ToLite();
                        }
                    }
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Returns a list of EventHistory entities based on the ids passed.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetByIds(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                if (callLog.Arguments == null)
                {
                    return NoContent();
                }
                else
                {
                    ActionResponse response = new ActionResponse();
                    try
                    {
                        KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                        // The list of ids is always passed as a string, parse it out now.
                        string ids = callLog.Arguments[0];
                        IEnumerable<KnightsTour.EventHistory> eventHistories = ApplyCollectionFilter<KnightsTour.EventHistory>(Request, logic.GetByIds(SplitNumericIds(ids)));
                        response.Append(new Message($"{eventHistories.Count()} records returned."));
                        response.DataObject = eventHistories.ToLite();
                    }
                    catch (Exception exception)
                    {
                        response.Append(FormatException(exception));
                    }

                    return ValidateResponseObject(response);
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.EventHistory" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Post(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("API _Post");
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);

                    KnightsTour.EventHistory newEventHistory = new KnightsTour.EventHistory();
                    if (callLog.Arguments[0] != null)
                    {
                        newEventHistory = new KnightsTour.EventHistory(callLog.Arguments[0]);
                        response = logic.Insert(newEventHistory);
                    }
                    else
                    {
                        // Most likely a serialization issue on the object.
                        response.Append(new Exception("A technical problem occurred: No event history passed to insert."));
                    }

                    if (response.IsValid)
                    {
                        response.DataObject = logic.GetById(newEventHistory.EventHistoryId.Value).ToLite();
                    }
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.EventHistory" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _PostCascade(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("API _PostCascade");
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);

                    KnightsTour.EventHistoryLite liteEntity = callLog.Arguments[0];
                    if (liteEntity != null)
                    {
                        KnightsTour.EventHistory newEventHistory = new KnightsTour.EventHistory(liteEntity);
                        response = logic.InsertCascade(newEventHistory);

                        if (response.IsValid)
                        {
                            response.DataObject = logic.GetById(newEventHistory.EventHistoryId.Value).ToLite();
                        }
                    }
                    else
                    {
                        response.Append(new Exception("No data passed."));
                    }
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.EventHistory" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Put(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("API _Put");
                try
                {
                    KnightsTour.EventHistoryLite eventHistoryLite = callLog.Arguments[0];
                    if (eventHistoryLite != null && eventHistoryLite.EventHistoryId.HasValue)
                    {
                        KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);

                        KnightsTour.EventHistory existingEventHistory = logic.GetById(eventHistoryLite.EventHistoryId.Value);
                        if (existingEventHistory != null)
                        {
                            existingEventHistory.UpdateFromLite(eventHistoryLite);
                            if (existingEventHistory.IsModified())
                            {
                                response = logic.Update(existingEventHistory, callLog.ExecutingUserId);

                                if (response.IsValid)
                                {
                                    response.DataObject = existingEventHistory.ToLite();
                                }
                            }
                            else
                            {
                                response.Append(new Message("No update required.", KnightsTour.CoreLibrary.Enumerations.MessageType.Warning));
                            }
                        }
                        else
                        {
                            response.Append(new Exception("No EventHistory found with primary key " + eventHistoryLite.EventHistoryId.Value));
                        }
                    }
                    else
                    {
                        // Most likely a serialization issue on the object.
                        response.Append(new Exception("A technical problem occurred: No event history passed to update."));
                    }
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Deletes a single EventHistory entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Delete(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("API _Delete");
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                    response = logic.Delete(callLog.Arguments[0]);
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Deletes a single EventHistory entity and all its dependencies.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _DeleteCascade(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("API _DeleteCascade");
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                    response = logic.DeleteCascade(callLog.Arguments[0]);
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Deletes a collection of EventHistory entities by a foreign key.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _DeleteByFK(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("API _DeleteByFK");
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                    response = logic.DeleteByFK(callLog.Arguments[0], callLog.Arguments[1]);
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Performs a defined custom action against the passed ids.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _DoCustomAction(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                ActionResponse response = new ActionResponse();
                try
                {
                    KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                    response = logic.DoCustomAction(callLog.Arguments[0], callLog.Arguments[1]);
                }
                catch (Exception exception)
                {
                    response.Append(FormatException(exception));
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Returns a list of EventHistory entities based on the filter.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetAllExtended(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                if (callLog.Arguments == null)
                {
                    return NoContent();
                }
                else
                {
                    ActionResponse response = new ActionResponse();
                    try
                    {
                        KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                        EntityFilter filter = callLog.Arguments[0];
                        IEnumerable<KnightsTour.EventHistory> eventHistories = logic.GetAllExtended(filter);
                        response.Append(new Message($"{eventHistories.Count()} records returned."));
                        response.DataObject = eventHistories.ToLite();
                    }
                    catch (Exception exception)
                    {
                        response.Append(FormatException(exception));
                    }

                    return ValidateResponseObject(response);
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Returns the total number of EventHistory entities based on the filter.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetCount(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                if (callLog.Arguments == null)
                {
                    return NoContent();
                }
                else
                {
                    ActionResponse response = new ActionResponse();
                    try
                    {
                        KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                        EntityFilter filter = callLog.Arguments[0];
                        int recordCount = logic.GetCount(filter);
                        response.Append(new Message($"{recordCount} records returned."));
                        response.DataObject = recordCount;
                    }
                    catch (Exception exception)
                    {
                        response.Append(FormatException(exception));
                    }

                    return ValidateResponseObject(response);
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }
        #endregion CRUD Methods

        #region Foreign key CRUD access Methods

        /// <summary>
        /// Returns the related EventType entity related to the EventHistory.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _EventType(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                KnightsTour.EventHistory eventHistory = logic.GetById(callLog.Arguments[0]);
                if (eventHistory == null || (!eventHistory.EventTypeId.HasValue))
                {
                    return new NotFoundResult();
                }
                else
                {
                    return Ok(eventHistory.EventType);
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Returns the related Member entity related to the EventHistory.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Member(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                KnightsTour.EventHistoryLogic logic = new KnightsTour.EventHistoryLogic(callLog.UserName);
                KnightsTour.EventHistory eventHistory = logic.GetById(callLog.Arguments[0]);
                if (eventHistory == null || (!eventHistory.MemberId.HasValue))
                {
                    return new NotFoundResult();
                }
                else
                {
                    return Ok(eventHistory.Member);
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }
        #endregion Foreign key CRUD access Methods

    } // Class
} // Namespace