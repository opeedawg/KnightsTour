// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 13, 2023 7:25:01 AM
// File             : SolutionLogic.cs
// ************************************************************************

using KnightsTour.CoreLibrary;
using KnightsTour.Enumerations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace KnightsTour
{
    /// <summary>
    /// Auto generated from DB table Solution
    /// Generated On: January 13, 2023 at 7:25:01 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <remarks>
    /// Use this class to manage and extend the generated logic related to the <see cref="Solution"/> class.
    /// This class is only regenerated if it is detected that it has never been modified.
    /// </remarks>
    public class SolutionLogic : SolutionLogicBase
    {
        #region Extended Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionLogic"/> class.
        /// Instantiates a new generic LogicBase class using the configured repository.
        /// </summary>
        /// <param name="userName">The user using this class.</param>
        /// <example>
        /// <code>
        /// SolutionLogicBase SolutionLogic = new SolutionLogic(userName);
        /// </code>
        /// </example>
        public SolutionLogic(string userName) : base(userName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionLogic"/> class.
        /// Instantiates a new generic LogicBase class using the passed handler.
        /// </summary>
        /// <param name="handler">A storage handler.</param>
        /// <param name="userName">The user using this class.</param>
        public SolutionLogic(KnightsTour.CoreLibrary.IStorageHandler handler, string userName) : base(handler, userName)
        {
        }
        #endregion Extended Constructor(s)

        #region Extended Declarations
        #endregion Extended Declarations

        #region Extended Properties
        #endregion Extended Properties

        #region Extended Methods

        /// <summary>
        /// Executes a custom action against the Solution given the passed ids.
        /// </summary>
        /// <param name="actionName">The name of the custom operation to execute.</param>
        /// <param name="ids">The comma delimited list of id(s) of the objects on which to execute the custom operation.</param>
        /// <returns><see cref="KnightsTour.CoreLibrary.IActionResponse"/>: A populated rich response object.</returns>
        public KnightsTour.CoreLibrary.IActionResponse DoCustomAction(string actionName, string ids)
        {
            KnightsTour.CoreLibrary.IActionResponse response = new KnightsTour.CoreLibrary.ActionResponse($"Do custom action: '{actionName}'");

            // Some parameter validations.
            if (string.IsNullOrEmpty(actionName))
            {
                response.Append(new Exception("Missing mandatory parameter 'actionName' in SolutionLogic.DoCustomAction"));
            }
            if (string.IsNullOrEmpty(ids))
            {
                response.Append(new Exception("Missing mandatory parameter 'ids' in SolutionLogic.DoCustomAction"));
            }

            if (response.IsValid)
            {
                // Get a distinct list of non-empty ids.
                List<string> idList = ids.Split(',').ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                if (idList.Count > 0)
                {
                    // Validate that this action exists.
                    switch (actionName)
                    {
                        // As this is extended code, as you configure new custom actions or remove them, you will need to maintain the case statement manually.

                        default:
                            response.Append(new Exception($"Unknown or unhandled action type '{actionName}'"));
                            break;

                    }
                }
            }

            // Return the response.
            return response;
        }
        public DboVPuzzleOfTheDaySolution GetByMemberAndPuzzle(int memberId, int puzzleId)
        {
            var result = StorageHandler.GetRecord(new StorageStatement()
            {
                Statement = "SELECT * FROM [V_PuzzleOfTheDaySolution] WHERE MemberId = @memberId and PuzzleId = @puzzleId",
                Parameters = new List<IParameter>() {
                    new GenericParameter("@memberId", memberId),
                    new GenericParameter("@puzzleId", puzzleId)
                }
            });

            DboVPuzzleOfTheDaySolution memberSolution = null;
            if (result != null)
                memberSolution = new DboVPuzzleOfTheDaySolution(result);

            return memberSolution;
        }
        public IActionResponse StartPuzzle(int puzzleId, int memberId, HttpRequest request)
        {
            IActionResponse response = new ActionResponse("StartPuzzle");
            try
            {
                Puzzle puzzle = new PuzzleLogic(UserName).GetById(puzzleId);
                if (puzzle != null)
                {
                    Solution newSolution = new Solution()
                    {
                        PuzzleId = puzzleId,
                        MemberId = memberId,
                        SolutionStartDate = DateTime.Now,
                        SolutionDuration = null,
                        Path = puzzle.Path
                    };

                    response.Append(Insert(newSolution));
                    if (response.IsValid)
                        response.DataObject = newSolution.ToLite();
                }
                else
                    response.Append(new Exception("Invalid puzzle id"));
            }
            catch (Exception exception)
            {
                response.Append(exception);
                EventHistoryLogic.Add(Enumerations.EventType.Exception, $"{{function: \"SolutionLogic.StartPuzzle\", exception: \"{GetCompleteExceptionMessage(exception)}\"}}", request);
            }

            return response;
        }
        public IActionResponse UpdateSolution(int solutionId, string path, string notes, HttpRequest request)
        {
            IActionResponse response = new ActionResponse("UpdateSolutionPath");
            try
            {
                Solution solution = GetById(solutionId);
                if (solution != null)
                {
                    solution.Path = path;
                    solution.Note = notes;

                    response.Append(Update(solution));
                    response.DataObject = null;
                }
                else
                    response.Append(new Exception("Invalid solution"));
            }
            catch (Exception exception)
            {
                response.Append(exception);
                EventHistoryLogic.Add(Enumerations.EventType.Exception, $"{{function: \"SolutionLogic.UpdateSolutionPath\", exception: \"{GetCompleteExceptionMessage(exception)}\"}}", request);
            }

            return response;
        }
        public IActionResponse CompleteSolution(int solutionId, HttpRequest request)
        {
            IActionResponse response = new ActionResponse("UpdateSolutionPath");
            string solutionCode = string.Empty;
            try
            {
                Solution solution = GetById(solutionId);
                if (solution != null)
                {
                    solutionCode = Guid.NewGuid().ToString();
                    solution.Code = solutionCode;
                    decimal solutionDuration = decimal.Parse(Math.Round(DateTime.Now.Subtract(solution.SolutionStartDate).TotalSeconds, 2).ToString());

                    solution.SolutionDuration = solutionDuration;
                    response.Append(Update(solution));
                    if (response.IsValid)
                    {
                        response.Messages.Clear();
                        response.Append(new Message($"You won!  You completed the puzzle in {solutionDuration} seconds. Well done!"));
                    }

                    response.DataObject = null;
                }
                else
                    response.Append(new Exception("Opps, something went wrong.  This seems to not be a valid solution."));
            }
            catch (Exception exception)
            {
                response.Append(exception);
                EventHistoryLogic.Add(Enumerations.EventType.Exception, $"{{function: \"SolutionLogic.UpdateSolutionPath\", exception: \"{GetCompleteExceptionMessage(exception)}\"}}", request);
            }

            response.DataObject = null;
            if (response.IsValid)
                response.DataObject = solutionCode;

            return response;
        }
        public IActionResponse InsertNonMemberSolution(SolutionLite solution, HttpRequest request)
        {
            IActionResponse response = new ActionResponse("InsertNonMemberSolution");
            try
            {
                if (string.IsNullOrEmpty(solution.NonMemberName))
                    response.Append(new Exception("For non-member solutions, a temporary display name is required."));

                if (response.IsValid)
                {
                    // Test if an existing solution record exists for this IP and member name.
                    Solution existingSolution = GetExistingNonMemberSolution(solution, request);

                    if (existingSolution != null)
                    {
                        response.Append(new Message($"You won again!  You have previously completed this particular knight`s tour puzzle so your best time remains {existingSolution.SolutionDuration} seconds.", CoreLibrary.Enumerations.MessageType.Warning));
                        solution = existingSolution.ToLite();
                    }
                    else
                    {
                        solution.Code = Guid.NewGuid().ToString();
                        solution.MemberId = null;
                        solution.NonMemberIp = GetIpAddress(request);
                        response.Append(Insert(solution.ToFull()));
                        response.Append(new Message($"You won!  You completed the puzzle in {solution.SolutionDuration} seconds. Well done!"));
                    }
                }
            }
            catch (Exception exception)
            {
                response.Append(exception);
                EventHistoryLogic.Add(Enumerations.EventType.Exception, $"{{function: \"SolutionLogic.InsertNonMemberSolution\", exception: \"{GetCompleteExceptionMessage(exception)}\"}}", request);
            }

            response.DataObject = null;
            if(response.IsValid)
                response.DataObject = solution.Code;

            return response;
        }
        Solution GetExistingNonMemberSolution(SolutionLite solution, HttpRequest request)
        {
            var result = StorageHandler.GetRecord(new StorageStatement()
            {
                Statement = "SELECT * FROM [Solution] WHERE NonMemberName = @nonMemberName AND NonMemberIP = @nonMemberIp AND PuzzleId = @puzzleId;",
                Parameters = new List<IParameter>() {
                    new GenericParameter("@nonMemberName", solution.NonMemberName),
                    new GenericParameter("@nonMemberIp", GetIpAddress(request)),
                    new GenericParameter("@puzzleId", solution.PuzzleId.Value)
                }
            });

            if (result == null)
                return null;

            return new Solution(result);
        }
        public IActionResponse GetSolutionByCode(string code, HttpRequest request)
        {
            IActionResponse response = new ActionResponse($"GetSolutionByCode ({code})");
            try
            {
                var result = StorageHandler.GetRecord(new StorageStatement()
                {
                    Statement = "SELECT * FROM [Solution] WHERE Code = @code;",
                    Parameters = new List<IParameter>() {
                        new GenericParameter("@code", code),
                    }
                });

                if (result != null)
                {
                    response.DataObject = new Solution(result).ToLite();
                }
            }
            catch (Exception exception)
            {
                response.Append(exception);
                EventHistoryLogic.Add(Enumerations.EventType.Exception, $"{{function: \"SolutionLogic.GetSolutionByCode({code})\", exception: \"{GetCompleteExceptionMessage(exception)}\"}}", request);
            }


            return response;
        }
        static string GetIpAddress(HttpRequest request)
        {
            return request.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        #endregion Extended Methods

    } // Class
} // Namespace