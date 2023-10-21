/**
 * File:     DboVPuzzleOfTheDaySolution.ts
 * Location: src\view\
 * The class that represents the view model for DB view dbo.V_PuzzleOfTheDaySolution.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 13, 2023 at 6:44:33 PM
 */

/**
 * Abstract Class: DboVPuzzleOfTheDaySolution
 *
 * Base class to define the @see DboVPuzzleOfTheDaySolution model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVPuzzleOfTheDaySolution.
 *
 * @implements {constructor} The constructor for the @see DboVPuzzleOfTheDaySolution class
 */
export class DboVPuzzleOfTheDaySolution {
  // *** Declarations ***
  /** The dbo.V_PuzzleOfTheDaySolution Cols field. */
  cols: number;
  /** The dbo.V_PuzzleOfTheDaySolution Difficulty field. */
  difficulty: string;
  /** The dbo.V_PuzzleOfTheDaySolution MemberId field. */
  memberId: number;
  /** The dbo.V_PuzzleOfTheDaySolution PuzzleId field. */
  puzzleId: number;
  /** The dbo.V_PuzzleOfTheDaySolution PuzzleOfTheDayDate field. */
  puzzleOfTheDayDate: Date;
  /** The dbo.V_PuzzleOfTheDaySolution PuzzlePath field. */
  puzzlePath: string;
  /** The dbo.V_PuzzleOfTheDaySolution Rows field. */
  rows: number;
  /** The dbo.V_PuzzleOfTheDaySolution SolutionDuration field. */
  solutionDuration: number;
  /** The dbo.V_PuzzleOfTheDaySolution SolutionPath field. */
  memberSolution: string;
  /** The dbo.V_PuzzleOfTheDaySolution SolutionStartDate field. */
  solutionStartDate: Date;
  solutionId: number;
  note: string;

  solutionStartDateFormatted: string;
  solutionDurationFormatted: string;
  memberCells: number[][];

  /**
   * Function [constructor]:
   * The constructor for the @see DboVPuzzleOfTheDaySolution class
   */
  constructor() {
    this.cols = 0;
    this.difficulty = '';
    this.memberId = 0;
    this.puzzleId = 0;
    this.solutionId = 0;
    this.puzzleOfTheDayDate = new Date();
    this.puzzlePath = '';
    this.rows = 0;
    this.solutionDuration = 0;
    this.memberSolution = '';
    this.solutionStartDate = new Date();
    this.note = '';

    this.solutionStartDateFormatted = '';
    this.solutionDurationFormatted = '';
    this.memberCells = [];
  } // constructor
}
