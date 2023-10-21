/**
 * File:     Puzzle.ts
 * Location: src\models\
 * The base class for the @see Puzzle entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

// Imports
import moment from 'moment';
import { Board } from './Board';
import { DifficultyLevel } from './DifficultyLevel';

/**
 * Class: Puzzle
 * @implements {IPuzzle}
 *
 * Base class to define the @see Puzzle model.
 *
 * @implements {constructor} The constructor for the @see Puzzle class
 */
export class Puzzle {
  // *** Declarations ***
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  boardByBoardId: Board | null;
  /** The Board id field. [dbo.Puzzle.BoardId] */
  boardId: number;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  difficultyLevelByDifficultyLevelId: DifficultyLevel | null;
  /** The Difficulty level id field. [dbo.Puzzle.DifficultyLevelId] */
  difficultyLevelId: number;
  /** The entity type. [Computed] */
  entityType: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Path field. [dbo.Puzzle.Path] */
  path: string;
  /** The Puzzle code field. [dbo.Puzzle.PuzzleCode] */
  puzzleCode: string;
  /** The Puzzle id field PRIMARY KEY. [dbo.Puzzle.PuzzleId] */
  puzzleId: number;
  /** The Puzzle of the day date field. [dbo.Puzzle.PuzzleOfTheDayDate] */
  puzzleOfTheDayDate: Date;
  /** The Puzzle of the day date date formatted as per configuration for display. [Computed] */
  puzzleOfTheDayDateFormatted: string;

  /**
   * Function [constructor]:
   * The constructor for the @see Puzzle class
   * @param {Puzzle} initialPuzzle?: An optional initial object to seed this class.
   */
  constructor(initialPuzzle?: Puzzle) {
    if (initialPuzzle) {
      this.boardByBoardId = initialPuzzle.boardByBoardId;
      this.boardId = initialPuzzle.boardId;
      this.difficultyLevelByDifficultyLevelId =
        initialPuzzle.difficultyLevelByDifficultyLevelId;
      this.difficultyLevelId = initialPuzzle.difficultyLevelId;
      this.entityType = initialPuzzle.entityType;
      this.instanceLabel = initialPuzzle.instanceLabel;
      this.path = initialPuzzle.path;
      this.puzzleCode = initialPuzzle.puzzleCode;
      this.puzzleId = initialPuzzle.puzzleId;
      this.puzzleOfTheDayDate = initialPuzzle.puzzleOfTheDayDate;
      this.puzzleOfTheDayDateFormatted =
        initialPuzzle.puzzleOfTheDayDateFormatted;
    } else {
      this.boardByBoardId = null;
      this.boardId = 0;
      this.difficultyLevelByDifficultyLevelId = null;
      this.difficultyLevelId = 0;
      this.entityType = 'Puzzle';
      this.instanceLabel = '';
      this.path = '';
      this.puzzleCode = '';
      this.puzzleId = 0;
      this.puzzleOfTheDayDate = new Date();
      this.puzzleOfTheDayDateFormatted = moment(this.puzzleOfTheDayDate).format(
        'YYYY-MM-DD'
      );
    }
  } // constructor
}
