/**
 * File:     IPuzzleBase.ts
 * Location: src\entities\Puzzle\models\base\
 * Interface to represent the base properties and functions of the @see Puzzle. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file IPuzzle.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: IPuzzleBase
* @extends {IBaseEntity}
*
* Interface to define the Puzzle model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see IPuzzle.
*
* @implements {constructor} The constructor for the @see IPuzzleBase class
*/
export interface IPuzzleBase extends IBaseEntity {
  // *** Declarations ***
  /** The Board id field. [dbo.Puzzle.BoardId] */
  boardId: number;
  /** The Difficulty level id field. [dbo.Puzzle.DifficultyLevelId] */
  difficultyLevelId: number;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Path field. [dbo.Puzzle.Path] */
  path: string;
  /** The Puzzle code field. [dbo.Puzzle.PuzzleCode] */
  puzzleCode: string;
  /** The Puzzle id field. [dbo.Puzzle.PuzzleId] */
  puzzleId: number;
  /** The Puzzle of the day date field. [dbo.Puzzle.PuzzleOfTheDayDate] */
  puzzleOfTheDayDate: Date;
  /** The Puzzle of the day date date formatted as per configuration for display. [Computed] */
  puzzleOfTheDayDateFormatted: string;
}
