/**
 * File:     DboVShareSolutionBase.ts
 * Location: src\views\models\base\
 * The class that represents the view model for DB view dbo.V_ShareSolution.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import moment from 'moment';

/**
* Abstract Class: DboVShareSolutionBase
*
* Base class to define the @see DboVShareSolutionBase model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVShareSolutionBase.
*
* @implements {constructor} The constructor for the @see DboVShareSolutionBase class
*/
export abstract class DboVShareSolutionBase {
  // *** Declarations ***
  /** The dbo.V_ShareSolution Code field. */
  code: string;
  /** The dbo.V_ShareSolution MemberName field. */
  memberName: string;
  /** The dbo.V_ShareSolution SolutionDuration field. */
  solutionDuration: number;
  /** The dbo.V_ShareSolution SolutionId field. */
  solutionId: number;
  /** The dbo.V_ShareSolution SolutionStartDate field. */
  solutionStartDate: Date;

  /**
  * Function [constructor]: 
  * The constructor for the @see DboVShareSolutionBase class
  */
  constructor() {
      this.code = '';
      this.memberName = '';
      this.solutionDuration = 0;
      this.solutionId = 0;
      this.solutionStartDate = new Date();
  } // constructor

}
