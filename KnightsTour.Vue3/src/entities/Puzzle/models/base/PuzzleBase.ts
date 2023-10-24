/**
 * File:     PuzzleBase.ts
 * Location: src\entities\Puzzle\models\base\
 * The base class for the @see Puzzle entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Puzzle.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { Board } from 'src/entities/Board/models/Board';
import { DifficultyLevel } from 'src/entities/DifficultyLevel/models/DifficultyLevel';
import { IPuzzleBase } from './IPuzzleBase';
import { v4 as guid } from 'uuid';
import moment from 'moment';

/** An enumeration of all @see Puzzle property names (includes computed fields). */
export enum PuzzlePropertyNames {
  /** number(mandatory) */
  boardId = 'boardId',
  /** number(mandatory) */
  difficultyLevelId = 'difficultyLevelId',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** string(mandatory) */
  path = 'path',
  /** string(mandatory) */
  puzzleCode = 'puzzleCode',
  /** number(PRIMARY KEY mandatory) */
  puzzleId = 'puzzleId',
  /** Date(optional) */
  puzzleOfTheDayDate = 'puzzleOfTheDayDate',
  /** Computed: string (optional) */
  puzzleOfTheDayDateFormatted = 'puzzleOfTheDayDateFormatted',
}

/**
* Abstract Class: PuzzleBase
* @implements {IPuzzleBase}
*
* Base class to define the @see Puzzle model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see Puzzle.
*
* @implements {constructor} The constructor for the @see PuzzleBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class PuzzleBase implements IPuzzleBase {
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
  * The constructor for the @see PuzzleBase class
  * @param {PuzzleBase} initialPuzzle?: An optional initial object to seed this class.
  */
  constructor(initialPuzzle?: PuzzleBase) {
    if (initialPuzzle) {
      this.boardByBoardId = initialPuzzle.boardByBoardId;
      this.boardId = initialPuzzle.boardId;
      this.difficultyLevelByDifficultyLevelId = initialPuzzle.difficultyLevelByDifficultyLevelId;
      this.difficultyLevelId = initialPuzzle.difficultyLevelId;
      this.entityType = initialPuzzle.entityType;
      this.instanceLabel = initialPuzzle.instanceLabel;
      this.path = initialPuzzle.path;
      this.puzzleCode = initialPuzzle.puzzleCode;
      this.puzzleId = initialPuzzle.puzzleId;
      this.puzzleOfTheDayDate = initialPuzzle.puzzleOfTheDayDate;
      this.puzzleOfTheDayDateFormatted = initialPuzzle.puzzleOfTheDayDateFormatted;
    } else {
      this.boardByBoardId = null;
      this.boardId = 0;
      this.difficultyLevelByDifficultyLevelId = null;
      this.difficultyLevelId = 0;
      this.entityType = 'PuzzleBase';
      this.instanceLabel = '';
      this.path = '';
      this.puzzleCode = guid();
      this.puzzleId = 0;
      this.puzzleOfTheDayDate = new Date();
      this.puzzleOfTheDayDateFormatted = moment(this.puzzleOfTheDayDate).format('YYYY-MM-DD');
    }
  } // constructor


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see PuzzlePropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see PuzzlePropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
