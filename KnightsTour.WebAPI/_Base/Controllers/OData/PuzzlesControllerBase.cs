// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 21, 2023 9:45:26 AM
// File             : PuzzlesControllerBase.cs
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
    /// The base Rest based puzzle endpoints.
    /// Generated On: October 21, 2023 at 9:45:26 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <seealso cref="Web.ODataControllers.ApiControllerBase" />
    /// <remarks>
    /// This class is overwritten every time the entity or generator version is modified to stay in sync with your model.
    /// </remarks>
    public class PuzzlesControllerBase : ApiControllerBase
    {
        #region Public endpoints Methods

        /// <summary>
        /// Returns a page limited list of all Puzzle entities.
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
        /// Returns a single Puzzle entity.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Puzzle" /> of which to retrieve.</param>
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
        /// Insert a lite <seealso cref="KnightsTour.Puzzle" /> entity.
        /// </summary>
        /// <param name="puzzleLite">The new <seealso cref="KnightsTour.PuzzleLite" /> to insert.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Post([FromBody] KnightsTour.PuzzleLite puzzleLite)
        {
            return ExecuteCommon(_Post, new dynamic[] { puzzleLite });
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.Puzzle" /> entity.
        /// </summary>
        /// <param name="puzzleLite">The <seealso cref="KnightsTour.PuzzleLite" /> to update.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Put([FromBody] KnightsTour.PuzzleLite puzzleLite)
        {
            return ExecuteCommon(_Put, new dynamic[] { puzzleLite });
        }

        /// <summary>
        /// Deletes a single Puzzle entity.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Puzzle" /> of which to delete.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult Delete([FromODataUri] int key)
        {
            return ExecuteCommon(_Delete, new dynamic[] { key });
        }

        /// <summary>
        /// Returns all the related Solutions entities related to the Puzzle.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Puzzle" /> of which to retrieve the related <seealso cref="KnightsTour.Solution" /> entities.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [EnableQuery]
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult GetSolutions([FromODataUri] int key)
        {
            return ExecuteCommon(_GetSolutions, new dynamic[] { key });
        }

        /// <summary>
        /// Returns the related Board entity related to the Puzzle.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Puzzle" /> of which to retrieve the related <seealso cref="KnightsTour.Board" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult GetBoard([FromODataUri] int key)
        {
            return ExecuteCommon(_GetBoard, new dynamic[] { key });
        }

        /// <summary>
        /// Returns the related DifficultyLevel entity related to the Puzzle.
        /// </summary>
        /// <param name="key">The id of the <seealso cref="KnightsTour.Puzzle" /> of which to retrieve the related <seealso cref="KnightsTour.DifficultyLevel" /> entity.</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        [HttpGet]
        #if !DEBUG
        [Authorize]
        #endif
        public IActionResult GetDifficultyLevel([FromODataUri] int key)
        {
            return ExecuteCommon(_GetDifficultyLevel, new dynamic[] { key });
        }
        #endregion Public endpoints Methods

        #region CRUD Methods

        /// <summary>
        /// Returns a page limited list of all Puzzle entities.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Get(dynamic[] arguments)
        {
            KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);
            if (arguments == null)
            {
                IEnumerable<KnightsTour.Puzzle> puzzles = logic.GetAll().AsQueryable();
                return Ok(puzzles);
            }
            else
            {
                KnightsTour.Puzzle puzzle = logic.GetById(arguments[0]);
                if (puzzle == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    SingleResult<KnightsTour.Puzzle> creationResult = SingleResult.Create(new[] { puzzle }.AsQueryable());
                    return Ok(creationResult);
                }
            }
        }

        /// <summary>
        /// Insert a lite <seealso cref="KnightsTour.Puzzle" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Post(dynamic[] arguments)
        {
            KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);

            KnightsTour.Puzzle newPuzzle = new KnightsTour.Puzzle(arguments[0]);
            IActionResponse response = logic.Insert(newPuzzle);

            if (response.IsValid)
            {
                return Created(newPuzzle);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, response);
            }
        }

        /// <summary>
        /// Updated the passed<seealso cref="KnightsTour.Puzzle" /> entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Put(dynamic[] arguments)
        {
            KnightsTour.PuzzleLite puzzleLite = arguments[0];
            if (puzzleLite.Id.HasValue)
            {
                KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);

                KnightsTour.Puzzle existingPuzzle = logic.GetById(puzzleLite.PuzzleId.Value);
                if (existingPuzzle != null)
                {
                    existingPuzzle.UpdateFromLite(puzzleLite);
                    if (existingPuzzle.IsModified())
                    {
                        IActionResponse response = logic.Update(existingPuzzle);

                        if (response.IsValid)
                        {
                            return Updated(existingPuzzle);
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
                return StatusCode((int)HttpStatusCode.BadRequest, "When updating a puzzle via a HttpPut verb, PuzzleId must be set.");
            }
        }

        /// <summary>
        /// Deletes a single Puzzle entity.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _Delete(dynamic[] arguments)
        {
            KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);
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
        /// Returns all the related Solutions entities related to the Puzzle.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetSolutions(dynamic[] arguments)
        {
            KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);
            KnightsTour.Puzzle puzzle = logic.GetById(arguments[0]);
            if (puzzle == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(puzzle.Solutions.AsQueryable());
            }
        }
        #endregion Child CRUD access Methods

        #region Foreign key CRUD access Methods

        /// <summary>
        /// Returns the related Board entity related to the Puzzle.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetBoard(dynamic[] arguments)
        {
            KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);
            KnightsTour.Puzzle puzzle = logic.GetById(arguments[0]);
            if (puzzle == null || (!puzzle.BoardId.HasValue))
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(puzzle.Board);
            }
        }

        /// <summary>
        /// Returns the related DifficultyLevel entity related to the Puzzle.
        /// </summary>
        /// <param name="arguments">A dynamic list of arguments (required by the wrapping method call 'ExecuteCommon()').</param>
        /// <returns>A <seealso cref="System.Web.Http.IActionResult" /> result.</returns>
        private IActionResult _GetDifficultyLevel(dynamic[] arguments)
        {
            KnightsTour.PuzzleLogic logic = new KnightsTour.PuzzleLogic(UserName);
            KnightsTour.Puzzle puzzle = logic.GetById(arguments[0]);
            if (puzzle == null || (!puzzle.DifficultyLevelId.HasValue))
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(puzzle.DifficultyLevel);
            }
        }
        #endregion Foreign key CRUD access Methods

    } // Class
} // Namespace