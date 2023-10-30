/**
 * File:     DboVPuzzleOfTheDaySolutionBase.ts
 * Location: src\views\models\base\
 * The class that represents the view model for DB view dbo.V_PuzzleOfTheDaySolution.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import moment from 'moment';

/**
* Abstract Class: DboVPuzzleOfTheDaySolutionBase
*
* Base class to define the @see DboVPuzzleOfTheDaySolutionBase model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVPuzzleOfTheDaySolutionBase.
*
* @implements {constructor} The constructor for the @see DboVPuzzleOfTheDaySolutionBase class
*/
export abstract class DboVPuzzleOfTheDaySolutionBase {
  // *** Declarations ***
  /** The dbo.V_PuzzleOfTheDaySolution Cols field. */
  cols: number;
  /** The dbo.V_PuzzleOfTheDaySolution Difficulty field. */
  difficulty: string;
  /** The dbo.V_PuzzleOfTheDaySolution MemberId field. */
  memberId: number;
  /** The dbo.V_PuzzleOfTheDaySolution MemberPath field. */
  memberPath: string;
  /** The dbo.V_PuzzleOfTheDaySolution Note field. */
  note: string;
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
  /** The dbo.V_PuzzleOfTheDaySolution SolutionId field. */
  solutionId: number;
  /** The dbo.V_PuzzleOfTheDaySolution SolutionStartDate field. */
  solutionStartDate: Date;

  /**
  * Function [constructor]: 
  * The constructor for the @see DboVPuzzleOfTheDaySolutionBase class
  */
  constructor() {
      this.cols = 0;
      this.difficulty = '';
      this.memberId = 0;
      this.memberPath = '';
      this.note = '';
      this.puzzleId = 0;
      this.puzzleOfTheDayDate = new Date();
      this.puzzlePath = '';
      this.rows = 0;
      this.solutionDuration = 0;
      this.solutionId = 0;
      this.solutionStartDate = new Date();
  } // constructor

}
