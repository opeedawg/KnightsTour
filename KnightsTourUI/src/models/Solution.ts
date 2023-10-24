/**
 * File:     Solution.ts
 * Location: src\models\
 * The base class for the @see Solution entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

import moment from 'moment';
import { Member } from './Member';
import { Puzzle } from './Puzzle';

// Imports

/**
 * Class: Solution
 * @implements {ISolution}
 *
 * Base class to define the @see Solution model.
 *
 * @implements {constructor} The constructor for the @see Solution class
 */
export class Solution {
  // *** Declarations ***
  /** The Code field. [dbo.Solution.Code] */
  code: string;
  /** The entity type. [Computed] */
  entityType: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  memberByMemberId: Member | null;
  /** The Non member IP field. [dbo.Solution.NonMemberIP] */
  nonMemberIp: string;
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
   * The constructor for the @see Solution class
   * @param {Solution} initialSolution?: An optional initial object to seed this class.
   */
  constructor(initialSolution?: Solution) {
    if (initialSolution) {
      this.code = initialSolution.code;
      this.entityType = initialSolution.entityType;
      this.instanceLabel = initialSolution.instanceLabel;
      this.memberByMemberId = initialSolution.memberByMemberId;
      this.memberId = initialSolution.memberId;
      this.nonMemberIp = initialSolution.nonMemberIp;
      this.nonMemberName = initialSolution.nonMemberName;
      this.note = initialSolution.note;
      this.path = initialSolution.path;
      this.puzzleByPuzzleId = initialSolution.puzzleByPuzzleId;
      this.puzzleId = initialSolution.puzzleId;
      this.solutionDuration = initialSolution.solutionDuration;
      this.solutionId = initialSolution.solutionId;
      this.solutionStartDate = initialSolution.solutionStartDate;
      this.solutionStartDateFormatted =
        initialSolution.solutionStartDateFormatted;
    } else {
      this.code = '';
      this.entityType = 'SolutionBase';
      this.instanceLabel = '';
      this.memberByMemberId = null;
      this.memberId = 0;
      this.nonMemberIp = '';
      this.nonMemberName = '';
      this.note = '';
      this.path = '';
      this.puzzleByPuzzleId = null;
      this.puzzleId = 0;
      this.solutionDuration = 0;
      this.solutionId = 0;
      this.solutionStartDate = new Date();
      this.solutionStartDateFormatted = moment(this.solutionStartDate).format(
        'YYYY-MM-DD'
      );
    }
  } // constructor
}
