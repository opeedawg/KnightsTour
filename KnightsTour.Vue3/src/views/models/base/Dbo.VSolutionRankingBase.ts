/**
 * File:     Dbo.VSolutionRankingBase.ts
 * Location: src\views\models\base\
 * The class that represents the view model for DB view dbo.V_SolutionRanking.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:16 AM
 */


/**
* Abstract Class: Dbo.VSolutionRankingBase
*
* Base class to define the @see Dbo.VSolutionRankingBase model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see Dbo.VSolutionRankingBase.
*
* @implements {constructor} The constructor for the @see Dbo.VSolutionRankingBase class
*/
export abstract class Dbo.VSolutionRankingBase {
  // *** Declarations ***
  /** The dbo.V_SolutionRanking MemberId field. */
  memberId: number;
  /** The dbo.V_SolutionRanking PuzzleId field. */
  puzzleId: number;
  /** The dbo.V_SolutionRanking SolutionDuration field. */
  solutionDuration: number;
  /** The dbo.V_SolutionRanking UserInitials field. */
  userInitials: string;

  /**
  * Function [constructor]: 
  * The constructor for the @see Dbo.VSolutionRankingBase class
  */
  constructor() {
      this.memberId = 0;
      this.puzzleId = 0;
      this.solutionDuration = 0;
      this.userInitials = '';
  } // constructor

}
