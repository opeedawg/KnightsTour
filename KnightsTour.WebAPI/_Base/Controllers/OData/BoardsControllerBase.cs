// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : BoardsControllerBase.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using KnightsTour.CoreLibrary;
using KnightsTour.WebAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace Web.ODataControllers
{
    /// <summary>
    /// The base Rest based board endpoints.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <seealso cref="Web.ODataControllers.ApiControllerBase" />
    /// <remarks>
    /// This class is overwritten every time the entity or generator version is modified to stay in sync with your model.
    /// </remarks>
    public class BoardsControllerBase : ApiControllerBase
    {
        #region Public endpoints Methods

        /// <summary>
        /// Returns a page limited list of all Board entities.
        /// </summary>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [EnableQuery]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Get()
        {
            return ExecuteCommon(_Get);
        }

        /// <summary>
        /// Returns a single Board entity.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [EnableQuery]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Get(int key)
        {
            return ExecuteCommon(_Get, new dynamic[] { key });
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.Board" /> entity.
        /// </summary>
        /// <param name="boardLite">The new <seealso cref="KnightsTour.BoardLite" /> to insert.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Post([FromBody] KnightsTour.BoardLite boardLite)
        {
            return ExecuteCommon(_Post, new dynamic[] { boardLite });
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.Board" /> entity.
        /// </summary>
        /// <param name="boardLite">The <seealso cref="KnightsTour.BoardLite" /> to update.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Put([FromBody] KnightsTour.BoardLite boardLite)
        {
            return ExecuteCommon(_Put, new dynamic[] { boardLite });
        }

        /// <summary>
        /// Deletes a single Board entity.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Board" /> of which to delete.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Delete([FromODataUri] int key)
        {
            return ExecuteCommon(_Delete, new dynamic[] { key });
        }

        /// <summary>
        /// Returns all the related Boards entities related to the Board.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Board" /> entities.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [EnableQuery]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult GetBoards([FromODataUri] int key)
        {
            return ExecuteCommon(_GetBoards, new dynamic[] { key });
        }

        /// <summary>
        /// Returns all the related Puzzles entities related to the Board.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Puzzle" /> entities.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [EnableQuery]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult GetPuzzles([FromODataUri] int key)
        {
            return ExecuteCommon(_GetPuzzles, new dynamic[] { key });
        }

        /// <summary>
        /// Returns the related Board entity related to the Board.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Board" /> of which to retrieve the related <seealso cref="KnightsTour.Board" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult GetBoard([FromODataUri] int key)
        {
            return ExecuteCommon(_GetBoard, new dynamic[] { key });
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
            KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);
            if (arguments == null)
            {
                IEnumerable<KnightsTour.Board> boards = logic.GetAll().AsQueryable();
                return Ok(boards);
            }
            else
            {
                KnightsTour.Board board = logic.GetById(arguments[0]);
                if (board == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    SingleResult<KnightsTour.Board> creationResult = SingleResult.Create(new[] { board }.AsQueryable());
                    return Ok(creationResult);
                }
            }
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.Board" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Post(dynamic[] arguments)
        {
            KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);

            KnightsTour.Board newBoard = new KnightsTour.Board(arguments[0]);
            IActionResponse response = logic.Insert(newBoard);

            if (response.IsValid)
            {
                return Created(newBoard);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.Board" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Put(dynamic[] arguments)
        {
            KnightsTour.BoardLite boardLite = arguments[0];
            if (boardLite.Id.HasValue)
            {
                KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);

                KnightsTour.Board existingBoard = logic.GetById(boardLite.BoardId.Value);
                if (existingBoard != null)
                {
                    existingBoard.UpdateFromLite(boardLite);
                    if (existingBoard.IsModified())
                    {
                        IActionResponse response = logic.Update(existingBoard);

                        if (response.IsValid)
                        {
                            return Updated(existingBoard);
                        }
                        else
                        {
                            return StatusCode((int)HttpStatusCode.BadRequest, response);
                        }
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.NoContent, "No update required.");
                    }
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "When updating a board via a HttpPut verb, BoardId must be set.");
            }
        }

        /// <summary>
        /// Deletes a single Board entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Delete(dynamic[] arguments)
        {
            KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);
            IActionResponse response = logic.Delete(arguments[0]);

            if (response.IsValid)
            {
                return StatusCode((int)HttpStatusCode.NoContent, response);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
        }
        #endregion CRUD Methods

        #region Child CRUD access Methods

        /// <summary>
        /// Returns all the related Boards entities related to the Board.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetBoards(dynamic[] arguments)
        {
            KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);
            KnightsTour.Board board = logic.GetById(arguments[0]);
            if (board == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(board.Boards.AsQueryable());
            }
        }

        /// <summary>
        /// Returns all the related Puzzles entities related to the Board.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetPuzzles(dynamic[] arguments)
        {
            KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);
            KnightsTour.Board board = logic.GetById(arguments[0]);
            if (board == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(board.Puzzles.AsQueryable());
            }
        }
        #endregion Child CRUD access Methods

        #region Foreign key CRUD access Methods

        /// <summary>
        /// Returns the related Board entity related to the Board.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetBoard(dynamic[] arguments)
        {
            KnightsTour.BoardLogic logic = new KnightsTour.BoardLogic(UserName);
            KnightsTour.Board board = logic.GetById(arguments[0]);
            if (board == null || (!board.SourceBoardId.HasValue))
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(board.Board);
            }
        }
        #endregion Foreign key CRUD access Methods

    } // Class
} // Namespace