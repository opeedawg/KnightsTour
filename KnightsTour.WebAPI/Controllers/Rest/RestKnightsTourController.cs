// © 2023 27 Software
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 13, 2023 7:25:01 AM
// File             : RestBoardsController.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KnightsTour;
using KnightsTour.CoreLibrary;
using KnightsTour.WebAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.RestControllers
{
    /// <summary>
    /// The extended REST board endpoints.
    /// Generated On: January 13, 2023 at 7:25:01 AM by DXterity Solutions.
    /// Generated By: DXterity8 Version 8.6.0 (see https://dxteritysolutions.com/).
    /// </summary>
    /// <seealso cref="WebAPI.RestControllers" />
    /// <remarks>
    /// As this class is just one of 3 available API techniques, it is prefixed with "Rest" as namespace differentations are not respected in the APIController protocol.
    /// This class is never overwritten once initialized - feel free to extend it as required with your custom endpoints.
    /// </remarks>
    [EnableCors("*")]
    [Route("rest/knightsTour")]
    public class RestKnightsTourController : ApiControllerBase
    {
        #region Extended Constructor(s)

        #endregion Extended Constructor(s)

        #region Extended Declarations
        #endregion Extended Declarations

        #region Extended Properties
        #endregion Extended Properties

        #region Member related
        [Route("signUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] MemberLite member)
        {
            return await ExecuteCommonAsync(_SignUp, new dynamic[] { member });
        }
        private IActionResult _SignUp(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("SignUp");
                try
                {
                    MemberLite member = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).SignUp(member.EmailAddress, member.DisplayName, member.UserInitials, member.Password, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] MemberLite member)
        {
            return await ExecuteCommonAsync(_SignIn, new dynamic[] { member });
        }
        private IActionResult _SignIn(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("SignIn");
                try
                {
                    MemberLite member = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).SignIn(member.EmailAddress, member.Password, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("changePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChange passwordChange)
        {
            return await ExecuteCommonAsync(_ChangePassword, new dynamic[] { passwordChange });
        }
        private IActionResult _ChangePassword(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("ChangePassword");
                try
                {
                    PasswordChange passwordChange = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).ChangePassword(passwordChange.MemberId, passwordChange.OldPassword, passwordChange.NewPassword1, passwordChange.NewPassword2, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("recoverPassword")]
        [HttpPost]
        public async Task<IActionResult> RecoverPassword([FromBody] string emailAddress)
        {
            return await ExecuteCommonAsync(_RecoverPassword, new dynamic[] { emailAddress });
        }
        private IActionResult _RecoverPassword(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("RecoverPassword");
                try
                {
                    string emailAddress = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).RecoverPassword(emailAddress, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("confirmEmail")]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string code)
        {
            return await ExecuteCommonAsync(_ConfirmEmail, new dynamic[] { code });
        }
        private IActionResult _ConfirmEmail(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("RecoverPassword");
                try
                {
                    string code = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).ConfirmEmail(code, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("startPuzzle")]
        [HttpPost]
        public async Task<IActionResult> StartPuzzle([FromBody] SolutionLite solution)
        {
            return await ExecuteCommonAsync(_StartPuzzle, new dynamic[] { solution });
        }
        private IActionResult _StartPuzzle(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("StartPuzzle");
                try
                {
                    SolutionLite solution = callLog.Arguments[0];

                    response.Append(new SolutionLogic(callLog.UserName).StartPuzzle(solution.PuzzleId.Value, solution.MemberId.Value, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("updateSolution")]
        [HttpPost]
        public async Task<IActionResult> UpdateSolution([FromBody] SolutionLite solution)
        {
            return await ExecuteCommonAsync(_UpdateSolution, new dynamic[] { solution });
        }
        private IActionResult _UpdateSolution(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("StartPuzzle");
                try
                {
                    SolutionLite solution = callLog.Arguments[0];

                    response.Append(new SolutionLogic(callLog.UserName).UpdateSolution(solution.SolutionId.Value, solution.Path, solution.Note, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("completeSolution")]
        [HttpPost]
        public async Task<IActionResult> CompleteSolution([FromBody] SolutionLite solution)
        {
            return await ExecuteCommonAsync(_CompleteSolution, new dynamic[] { solution });
        }
        private IActionResult _CompleteSolution(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("StartPuzzle");
                try
                {
                    SolutionLite solution = callLog.Arguments[0];

                    response.Append(new SolutionLogic(callLog.UserName).CompleteSolution(solution.SolutionId.Value, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }


        [Route("insertNonMemberSolution")]
        [HttpPost]
        public async Task<IActionResult> InsertNonMemberSolution([FromBody] SolutionLite solution)
        {
            return await ExecuteCommonAsync(_InsertNonMemberSolution, new dynamic[] { solution });
        }
        private IActionResult _InsertNonMemberSolution(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("StartPuzzle");
                try
                {
                    SolutionLite solution = callLog.Arguments[0];

                    response.Append(new SolutionLogic(callLog.UserName).InsertNonMemberSolution(solution, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }


        [Route("getMemberStatistics/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMemberStatistics(int id)
        {
            return await ExecuteCommonAsync(_GetMemberStatistics, new dynamic[] { id });
        }
        private IActionResult _GetMemberStatistics(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("GetMemberStatistics");
                try
                {
                    int id = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).GetStatistics(id, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("communicationSubmit")]
        [HttpPost]
        public async Task<IActionResult> CommunicationSubmit([FromBody] MemberCommunication communication)
        {
            return await ExecuteCommonAsync(_CommunicationSubmit, new dynamic[] { communication });
        }
        private IActionResult _CommunicationSubmit(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("StartPuzzle");
                try
                {
                    MemberCommunication communication = callLog.Arguments[0];

                    response.Append(new MemberLogic(callLog.UserName).Communicate(communication, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }
        #endregion

        #region Level related
        [Route("getLevels")]
        [HttpGet]
        public async Task<IActionResult> GetLevels()
        {
            return await ExecuteCommonAsync(_GetLevels, new dynamic[] { });
        }
        private IActionResult _GetLevels(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("GetLevels");
                try
                {
                    List<DifficultyLevelLite> levels = new DifficultyLevelLogic(callLog.UserName).GetAll().OrderByDescending(l => l.PercentVisibility).ToLite().ToList();

                    response.Append(new Message($"{levels.Count} difficuly levels retrieved."));
                    response.DataObject = levels;
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }
        #endregion

        #region Puzzle related
        [Route("getDailyPuzzle/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDailyPuzzle(int id)
        {
            return await ExecuteCommonAsync(_GetDailyPuzzle, new dynamic[] { id });
        }
        private IActionResult _GetDailyPuzzle(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("GetDailyPuzzle");
                try
                {
                    int memberId = callLog.Arguments[0];
                    response.Append(new PuzzleLogic(callLog.UserName).GetDailyPuzzle(memberId, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("getPuzzleRankings")]
        [HttpPost]
        public async Task<IActionResult> GetPuzzleRankings([FromBody] PuzzleRankingQuery solution)
        {
            return await ExecuteCommonAsync(_GetPuzzleRankings, new dynamic[] { solution });
        }
        private IActionResult _GetPuzzleRankings(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("GetDailyPuzzle");
                try
                {
                    PuzzleRankingQuery solution = callLog.Arguments[0];
                    response.Append(new PuzzleLogic(callLog.UserName).GetRankings(solution.PuzzleId, solution.MemberId, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        [Route("getDistinctBoardSizes")]
        [HttpGet]
        public async Task<IActionResult> GetDistinctBoardSizes()
        {
            return await ExecuteCommonAsync(_GetDistinctBoardSizes, new dynamic[] { });
        }
        private IActionResult _GetDistinctBoardSizes(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("GetDistinctBoardSizes");
                try
                {
                    response.Append(new BoardLogic(callLog.UserName).GetBoardSizes());
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }


        [Route("getRandomPuzzle")]
        [HttpPost]
        public async Task<IActionResult> GetRandomPuzzle([FromBody] PuzzleSearch solution)
        {
            return await ExecuteCommonAsync(_GetRandomPuzzle, new dynamic[] { solution });
        }
        private IActionResult _GetRandomPuzzle(dynamic[] arguments)
        {
            WebApiCallLog callLog = (WebApiCallLog)arguments[0];

            if (callLog.IsAuthorized())
            {
                IActionResponse response = new ActionResponse("GetDailyPuzzle");
                try
                {
                    PuzzleSearch search = callLog.Arguments[0];
                    response.Append(new PuzzleLogic(callLog.UserName).GetRandomPuzzle(search, this.Request));
                }
                catch (Exception exception)
                {
                    response.Append(exception);
                }

                return ValidateResponseObject(response);
            }
            else
            {
                return ProcessExceptions(callLog);
            }
        }

        #endregion

        #region Support Classes
        public class PasswordChange
        {
            public int MemberId { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword1 { get; set; }
            public string NewPassword2 { get; set; }
        }
        public class PuzzleRankingQuery
        {
            public int PuzzleId { get; set; }
            public int MemberId { get; set; }
        }

        #endregion

    } // Class
} // Namespace