// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : RestBoardsControllerBase.cs
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
    /// The base Rest based board endpoints.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    /// <remarks>
    /// As this class is just one of 3 available API techniques, it is prefixed with "Rest" as namespace differentations are not respected in the APIController protocol.
    /// This class is overwritten every time the entity or generator version is modified to stay in sync with your model.
    /// </remarks>
    public class RestBoardsControllerBase : ApiControllerBase
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
            return Ok("Rest Boards controller is responding.");
        }

        /// <summary>
        /// Returns a page limited list of all Board entities.
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
        /// Returns a single Board entity.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve.</param>
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
        /// <param name="ids">The ids of the <seealso cref="KnightsTour.Board" /> of which to retrieve.</param>
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
        /// Insert a lite <seealso cref="KnightsTour.Board" /> entity.
        /// </summary>
        /// <param name="boardLite">The new <seealso cref="KnightsTour.BoardLite" /> to insert.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("")]
        [HttpPost]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Post([FromBody] KnightsTour.BoardLite boardLite)
        {
            return await ExecuteCommonAsync(_Post, new dynamic[] { boardLite });
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.Board" /> entity in a cascading manner.
        /// </summary>
        /// <param name="boardLite">The new <seealso cref="KnightsTour.Board" /> to insert.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("cascade")]
        [HttpPost]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> PostCascade([FromBody] KnightsTour.BoardLite boardLite)
        {
            return await ExecuteCommonAsync(_PostCascade, new dynamic[] { boardLite });
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.Board" /> entity.
        /// </summary>
        /// <param name="boardLite">The <seealso cref="KnightsTour.BoardLite" /> to update.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("")]
        [HttpPut]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Put([FromBody] KnightsTour.BoardLite boardLite)
        {
            return await ExecuteCommonAsync(_Put, new dynamic[] { boardLite });
        }

        /// <summary>
        /// Deletes a single Board entity.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to delete.</param>
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
        /// Deletes a single Board entity and all its dependencies.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to delete.</param>
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
        /// Deletes a single Board entity.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to delete.</param>
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
        /// Returns a single Board entity.
        /// </summary>
        /// <param name="filter">The filter to apply to the <seealso cref="KnightsTour.Board" /> of which to retrieve.</param>
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
        /// Returns the number of Board records fiven the filter.
        /// </summary>
        /// <param name="filter">The filter to apply to the <seealso cref="KnightsTour.Board" /> of which to retrieve.</param>
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
        /// Returns all the related Boards entities related to the Board.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Board" /> entities.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/boards")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Boards(int? id)
        {
            return await ExecuteCommonAsync(_Boards, new dynamic[] { id });
        }

        /// <summary>
        /// Returns the related Boards entity related to the Board.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Board" /> entities.</param>
        /// <param name="childId">The child id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the specific <seealso cref="KnightsTour.Board" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/boards/{childId}")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Boards(int? id, int? childId)
        {
            return await ExecuteCommonAsync(_Boards, new dynamic[] { id, childId });
        }

        /// <summary>
        /// Returns all the related Puzzles entities related to the Board.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Puzzle" /> entities.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/puzzles")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Puzzles(int? id)
        {
            return await ExecuteCommonAsync(_Puzzles, new dynamic[] { id });
        }

        /// <summary>
        /// Returns the related Puzzles entity related to the Board.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Puzzle" /> entities.</param>
        /// <param name="childId">The child id of the <seealso cref="KnightsTour.Puzzle" /> of which to retrieve the specific <seealso cref="KnightsTour.Puzzle" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/puzzles/{childId}")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Puzzles(int? id, int? childId)
        {
            return await ExecuteCommonAsync(_Puzzles, new dynamic[] { id, childId });
        }

        /// <summary>
        /// Returns the related Board entity related to the Board.
        /// </summary>
        /// <param name="id">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Board" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [Route("{id}/board")]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> Board(int? id)
        {
            return await ExecuteCommonAsync(_Board, new dynamic[] { id });
        }
        #endregion Public endpoints Methods

        #region CRUD Methods

        /// <summary>
        /// Returns a page limited list of all Board entities.
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
                    if (callLog.Arguments == null)
                    {
                        IEnumerable<KnightsTour.Board> boards = ApplyCollectionFilter<KnightsTour.Board>(Request, logic.GetAll());
                        response.DataObject = boards.ToLite();
                    }
                    else
                    {
                        KnightsTour.Board board = logic.GetById(callLog.Arguments[0]);
                        if (board == null)
                        {
                            return new NotFoundResult();
                        }
                        else
                        {
                            response.DataObject = board.ToLite();
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
        /// Returns a list of Board entities based on the ids passed.
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
                        KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
                        // The list of ids is always passed as a string, parse it out now.
                        string ids = callLog.Arguments[0];
                        IEnumerable<KnightsTour.Board> boards = ApplyCollectionFilter<KnightsTour.Board>(Request, logic.GetByIds(SplitNumericIds(ids)));
                        response.Append(new Message($"{boards.Count()} records returned."));
                        response.DataObject = boards.ToLite();
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
        /// Insert a lite <seealso cref="KnightsTour.Board" /> entity.
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);

                    KnightsTour.Board newBoard = new KnightsTour.Board();
                    if (callLog.Arguments[0] != null)
                    {
                        newBoard = new KnightsTour.Board(callLog.Arguments[0]);
                        response = logic.Insert(newBoard);
                    }
                    else
                    {
                        // Most likely a serialization issue on the object.
                        response.Append(new Exception("A technical problem occurred: No board passed to insert."));
                    }

                    if (response.IsValid)
                    {
                        response.DataObject = logic.GetById(newBoard.BoardId.Value).ToLite();
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
        /// Insert a lite <seealso cref="KnightsTour.Board" /> entity.
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);

                    KnightsTour.BoardLite liteEntity = callLog.Arguments[0];
                    if (liteEntity != null)
                    {
                        KnightsTour.Board newBoard = new KnightsTour.Board(liteEntity);
                        response = logic.InsertCascade(newBoard);

                        if (response.IsValid)
                        {
                            response.DataObject = logic.GetById(newBoard.BoardId.Value).ToLite();
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
        /// Updated the passed<seealso cref="KnightsTour.Board" /> entity.
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
                    KnightsTour.BoardLite boardLite = callLog.Arguments[0];
                    if (boardLite != null && boardLite.BoardId.HasValue)
                    {
                        KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);

                        KnightsTour.Board existingBoard = logic.GetById(boardLite.BoardId.Value);
                        if (existingBoard != null)
                        {
                            existingBoard.UpdateFromLite(boardLite);
                            if (existingBoard.IsModified())
                            {
                                response = logic.Update(existingBoard, callLog.ExecutingUserId);

                                if (response.IsValid)
                                {
                                    response.DataObject = existingBoard.ToLite();
                                }
                            }
                            else
                            {
                                response.Append(new Message("No update required.", KnightsTour.CoreLibrary.Enumerations.MessageType.Warning));
                            }
                        }
                        else
                        {
                            response.Append(new Exception("No Board found with primary key " + boardLite.BoardId.Value));
                        }
                    }
                    else
                    {
                        // Most likely a serialization issue on the object.
                        response.Append(new Exception("A technical problem occurred: No board passed to update."));
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
        /// Deletes a single Board entity.
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
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
        /// Deletes a single Board entity and all its dependencies.
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
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
        /// Deletes a collection of Board entities by a foreign key.
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
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
                    KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
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
        /// Returns a list of Board entities based on the filter.
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
                        KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
                        EntityFilter filter = callLog.Arguments[0];
                        IEnumerable<KnightsTour.Board> boards = logic.GetAllExtended(filter);
                        response.Append(new Message($"{boards.Count()} records returned."));
                        response.DataObject = boards.ToLite();
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
        /// Returns the total number of Board entities based on the filter.
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
                        KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
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

        #region Child CRUD access Methods

        /// <summary>
        /// Returns all the related Boards entities related to the Board.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Boards(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
                KnightsTour.Board board = logic.GetById(callLog.Arguments[0]);
                if (board == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    if (callLog.Arguments.Length == 1)
                    {
                        return Ok(ApplyCollectionFilter<KnightsTour.Board>(Request, board.Boards));
                    }
                    else //A request for a specific child object has been entered.
                    {
                        KnightsTour.Board childBoard = board.Boards.FirstOrDefault(p => p.Id == callLog.Arguments[1]);
                        if (childBoard != null)
                        {
                            return Ok(childBoard);
                        }
                        else
                        {
                            return new NotFoundResult();
                        }
                    }
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        /// <summary>
        /// Returns all the related Puzzles entities related to the Board.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Puzzles(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
                KnightsTour.Board board = logic.GetById(callLog.Arguments[0]);
                if (board == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    if (callLog.Arguments.Length == 1)
                    {
                        return Ok(ApplyCollectionFilter<KnightsTour.Puzzle>(Request, board.Puzzles));
                    }
                    else //A request for a specific child object has been entered.
                    {
                        KnightsTour.Puzzle childPuzzle = board.Puzzles.FirstOrDefault(p => p.Id == callLog.Arguments[1]);
                        if (childPuzzle != null)
                        {
                            return Ok(childPuzzle);
                        }
                        else
                        {
                            return new NotFoundResult();
                        }
                    }
                }
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }
        #endregion Child CRUD access Methods

        #region Foreign key CRUD access Methods

        /// <summary>
        /// Returns the related Board entity related to the Board.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Board(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(callLog.UserName);
                KnightsTour.Board board = logic.GetById(callLog.Arguments[0]);
                if (board == null || (!board.SourceBoardId.HasValue))
                {
                    return new NotFoundResult();
                }
                else
                {
                    return Ok(board.Board);
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