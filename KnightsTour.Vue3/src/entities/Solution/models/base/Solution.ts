/**
 * File:     SolutionBase.ts
 * Location: src\entities\Solution\models\base\
 * The base class for the @see Solution entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Solution.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:16 AM
 */

// Imports
import { ISolutionBase } from './ISolutionBase';
import { Member } from 'src/entities/Member/models/Member';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';
import moment from 'moment';

/** An enumeration of all @see Solution property names (includes computed fields). */
export enum SolutionPropertyNames {
  /** string(mandatory) */
  code = 'code',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** number(optional) */
  memberId = 'memberId',
  /** string(optional) */
  nonMemberName = 'nonMemberName',
  /** string(optional) */
  note = 'note',
  /** string(optional) */
  path = 'path',
  /** number(mandatory) */
  puzzleId = 'puzzleId',
  /** number(optional) */
  solutionDuration = 'solutionDuration',
  /** number(PRIMARY KEY mandatory) */
  solutionId = 'solutionId',
  /** Date(mandatory) */
  solutionStartDate = 'solutionStartDate',
  /** Computed: string (optional) */
  solutionStartDateFormatted = 'solutionStartDateFormatted',
}

/**
* Abstract Class: SolutionBase
* @implements {ISolutionBase}
*
* Base class to define the @see Solution model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see Solution.
*
* @implements {constructor} The constructor for the @see SolutionBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class SolutionBase implements ISolutionBase {
  // *** Declarations ***
  /** The Code field. [dbo.Solution.Code] */
  code: string;
  /** The entity type. [Computed] */
  entityType: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  memberByMemberId: Member | null;
  /** The Member id field. [dbo.Solution.MemberId] */
  memberId: number;
  /** The Non member name field. [dbo.Solution.NonMemberName] */
  nonMemberName: string;
  /** The Note field. [dbo.Solution.Note] */
  note: string;
  /** The Path field. [dbo.Solution.Path] */
  path: string;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  puzzleByPuzzleId: Puzzle | null;
  /** The Puzzle id field. [dbo.Solution.PuzzleId] */
  puzzleId: number;
  /** The Solution duration field. [dbo.Solution.SolutionDuration] */
  solutionDuration: number;
  /** The Solution id field PRIMARY KEY. [dbo.Solution.SolutionId] */
  solutionId: number;
  /** The Solution start date field. [dbo.Solution.SolutionStartDate] */
  solutionStartDate: Date;
  /** The Solution start date date formatted as per configuration for display. [Computed] */
  solutionStartDateFormatted: string;

  /**
  * Function [constructor]: 
  * The constructor for the @see SolutionBase class
  * @param {SolutionBase} initialSolution?: An optional initial object to seed this class.
  */
  constructor(initialSolution?: SolutionBase) {
    if (initialSolution) {
      this.code = initialSolution.code;
      this.entityType = initialSolution.entityType;
      this.instanceLabel = initialSolution.instanceLabel;
      this.memberByMemberId = initialSolution.memberByMemberId;
      this.memberId = initialSolution.memberId;
      this.nonMemberName = initialSolution.nonMemberName;
      this.note = initialSolution.note;
      this.path = initialSolution.path;
      this.puzzleByPuzzleId = initialSolution.puzzleByPuzzleId;
      this.puzzleId = initialSolution.puzzleId;
      this.solutionDuration = initialSolution.solutionDuration;
      this.solutionId = initialSolution.solutionId;
      this.solutionStartDate = initialSolution.solutionStartDate;
      this.solutionStartDateFormatted = initialSolution.solutionStartDateFormatted;
    } else {
      this.code = '';
      this.entityType = 'SolutionBase';
      this.instanceLabel = '';
      this.memberByMemberId = null;
      this.memberId = 0;
      this.nonMemberName = '';
      this.note = '';
      this.path = '';
      this.puzzleByPuzzleId = null;
      this.puzzleId = 0;
      this.solutionDuration = 0;
      this.solutionId = 0;
      this.solutionStartDate = new Date();
      this.solutionStartDateFormatted = moment(this.solutionStartDate).format('YYYY-MM-DD');
    }
  } // constructor


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see SolutionPropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see SolutionPropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
