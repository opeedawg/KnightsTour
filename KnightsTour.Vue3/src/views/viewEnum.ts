/** The available server side views, values automatically synced with the logic layer. */
export enum ViewEnum {
  /** DB view: 'dbo.V_DistinctBoardSizes' */
  DboVDistinctBoardSizes = 0,
  /** DB view: 'dbo.V_MemberSolution' */
  DboVMemberSolution = 1,
  /** DB view: 'dbo.V_MemberStatistics' */
  DboVMemberStatistics = 2,
  /** DB view: 'dbo.V_PuzzleOfTheDay' */
  DboVPuzzleOfTheDay = 3,
  /** DB view: 'dbo.V_PuzzleOfTheDaySolution' */
  DboVPuzzleOfTheDaySolution = 4,
  /** DB view: 'dbo.V_ShareSolution' */
  DboVShareSolution = 5,
  /** DB view: 'dbo.V_SolutionRanking' */
  DboVSolutionRanking = 6,
}