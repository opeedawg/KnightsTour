/**
 * File:     DboVPuzzleOfTheDay.ts
 * Location: src\view\
 * The class that represents the view model for DB view dbo.V_PuzzleOfTheDay.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 19, 2023 at 7:56:06 AM
 */

// Imports
import { v4 as guid } from 'uuid';
import moment from 'moment';

/**
* Abstract Class: DboVPuzzleOfTheDay
*
* Base class to define the @see DboVPuzzleOfTheDay model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVPuzzleOfTheDay.
*
* @implements {constructor} The constructor for the @see DboVPuzzleOfTheDay class
*/
export abstract class DboVPuzzleOfTheDay {
  // *** Declarations ***
  /** The dbo.V_PuzzleOfTheDay Author field. */
  author: string;
  /** The dbo.V_PuzzleOfTheDay BoardPath field. */
  boardPath: string;
  /** The dbo.V_PuzzleOfTheDay Cols field. */
  cols: number;
  /** The dbo.V_PuzzleOfTheDay DifficultyLevel field. */
  difficultyLevel: string;
  /** The dbo.V_PuzzleOfTheDay DiscoveryDate field. */
  discoveryDate: string;
  /** The dbo.V_PuzzleOfTheDay DiscoveryIterationCount field. */
  discoveryIterationCount: string;
  /** The dbo.V_PuzzleOfTheDay PuzzleId field. */
  puzzleId: number;
  /** The dbo.V_PuzzleOfTheDay PuzzleOfTheDayDate field. */
  puzzleOfTheDayDate: Date;
  /** The dbo.V_PuzzleOfTheDay PuzzlePath field. */
  puzzlePath: string;
  /** The dbo.V_PuzzleOfTheDay Rows field. */
  rows: number;

  /**
  * Function [constructor]: 
  * The constructor for the @see DboVPuzzleOfTheDay class
  */
  constructor() {
      this.author = '';
      this.boardPath = '';
      this.cols = 0;
      this.difficultyLevel = '';
      this.discoveryDate = '';
      this.discoveryIterationCount = '';
      this.puzzleId = 0;
      this.puzzleOfTheDayDate = new Date();
      this.puzzlePath = '';
      this.rows = 0;
  } // constructor

}
