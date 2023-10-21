/**
 * File:     DboVSolutionRanking.ts
 * Location: src\view\
 * The class that represents the view model for DB view dbo.V_SolutionRanking.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 15, 2023 at 12:08:41 PM
 */

/**
 * Abstract Class: DboVSolutionRanking
 *
 * Base class to define the @see DboVSolutionRanking model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVSolutionRanking.
 *
 * @implements {constructor} The constructor for the @see DboVSolutionRanking class
 */
export class DboVSolutionRanking {
  // *** Declarations ***
  /** The dbo.V_SolutionRanking MemberId field. */
  memberId: number;
  /** The dbo.V_SolutionRanking PuzzleId field. */
  puzzleId: number;
  /** The dbo.V_SolutionRanking SolutionDuration field. */
  solutionDuration: number;
  /** The dbo.V_SolutionRanking UserInitials field. */
  userInitials: string;

  rank: number;
  durationFormatted: string;

  /**
   * Function [constructor]:
   * The constructor for the @see DboVSolutionRanking class
   */
  constructor() {
    this.memberId = 0;
    this.puzzleId = 0;
    this.solutionDuration = 0;
    this.userInitials = '';
    this.rank = 0;
    this.durationFormatted = '';
  } // constructor
}
