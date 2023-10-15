/**
 * File:     ISolutionBase.ts
 * Location: src\entities\Solution\models\base\
 * Interface to represent the base properties and functions of the @see Solution. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file ISolution.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:16 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: ISolutionBase
* @extends {IBaseEntity}
*
* Interface to define the Solution model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see ISolution.
*
* @implements {constructor} The constructor for the @see ISolutionBase class
*/
export interface ISolutionBase extends IBaseEntity {
  // *** Declarations ***
  /** The Code field. [dbo.Solution.Code] */
  code: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Member id field. [dbo.Solution.MemberId] */
  memberId: number;
  /** The Non member name field. [dbo.Solution.NonMemberName] */
  nonMemberName: string;
  /** The Note field. [dbo.Solution.Note] */
  note: string;
  /** The Path field. [dbo.Solution.Path] */
  path: string;
  /** The Puzzle id field. [dbo.Solution.PuzzleId] */
  puzzleId: number;
  /** The Solution duration field. [dbo.Solution.SolutionDuration] */
  solutionDuration: number;
  /** The Solution id field. [dbo.Solution.SolutionId] */
  solutionId: number;
  /** The Solution start date field. [dbo.Solution.SolutionStartDate] */
  solutionStartDate: Date;
  /** The Solution start date date formatted as per configuration for display. [Computed] */
  solutionStartDateFormatted: string;
}
