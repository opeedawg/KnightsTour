/**
 * File:     DboVMemberSolution.ts
 * Location: src\view\
 * The class that represents the view model for DB view dbo.V_MemberSolution.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 19, 2023 at 7:56:06 AM
 */

// Imports
import { v4 as guid } from 'uuid';
import moment from 'moment';

/**
* Abstract Class: DboVMemberSolution
*
* Base class to define the @see DboVMemberSolution model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVMemberSolution.
*
* @implements {constructor} The constructor for the @see DboVMemberSolution class
*/
export abstract class DboVMemberSolution {
  // *** Declarations ***
  /** The dbo.V_MemberSolution Cols field. */
  cols: number;
  /** The dbo.V_MemberSolution Difficulty field. */
  difficulty: string;
  /** The dbo.V_MemberSolution MemberId field. */
  memberId: number;
  /** The dbo.V_MemberSolution PuzzleId field. */
  puzzleId: number;
  /** The dbo.V_MemberSolution PuzzleOfTheDayDate field. */
  puzzleOfTheDayDate: Date;
  /** The dbo.V_MemberSolution Rows field. */
  rows: number;
  /** The dbo.V_MemberSolution SolutionDuration field. */
  solutionDuration: number;
  /** The dbo.V_MemberSolution SolutionId field. */
  solutionId: number;
  /** The dbo.V_MemberSolution SolutionStartDate field. */
  solutionStartDate: Date;

  /**
  * Function [constructor]: 
  * The constructor for the @see DboVMemberSolution class
  */
  constructor() {
      this.cols = 0;
      this.difficulty = '';
      this.memberId = 0;
      this.puzzleId = 0;
      this.puzzleOfTheDayDate = new Date();
      this.rows = 0;
      this.solutionDuration = 0;
      this.solutionId = 0;
      this.solutionStartDate = new Date();
  } // constructor

}
