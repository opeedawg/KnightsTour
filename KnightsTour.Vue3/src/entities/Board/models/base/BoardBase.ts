/**
 * File:     BoardBase.ts
 * Location: src\entities\Board\models\base\
 * The base class for the @see Board entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Board.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { Board } from 'src/entities/Board/models/Board';
import { IBoardBase } from './IBoardBase';
import { v4 as guid } from 'uuid';
import moment from 'moment';

/** An enumeration of all @see Board property names (includes computed fields). */
export enum BoardPropertyNames {
  /** string(mandatory) */
  author = 'author',
  /** string(mandatory) */
  boardCode = 'boardCode',
  /** number(PRIMARY KEY mandatory) */
  boardId = 'boardId',
  /** number(mandatory) */
  colDimension = 'colDimension',
  /** Date(mandatory) */
  discoveryDate = 'discoveryDate',
  /** Computed: string (optional) */
  discoveryDateFormatted = 'discoveryDateFormatted',
  /** number(mandatory) */
  discoveryIterationCount = 'discoveryIterationCount',
  /** number(mandatory) */
  discoveryRandomness = 'discoveryRandomness',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** string(mandatory) */
  path = 'path',
  /** number(mandatory) */
  rowDimension = 'rowDimension',
  /** number(optional) */
  sourceBoardId = 'sourceBoardId',
}

/**
* Abstract Class: BoardBase
* @implements {IBoardBase}
*
* Base class to define the @see Board model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see Board.
*
* @implements {constructor} The constructor for the @see BoardBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class BoardBase implements IBoardBase {
  // *** Declarations ***
  /** The Author field. [dbo.Board.Author] */
  author: string;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  boardBySourceBoardId: Board | null;
  /** The Board code field. [dbo.Board.BoardCode] */
  boardCode: string;
  /** The Board id field PRIMARY KEY. [dbo.Board.BoardId] */
  boardId: number;
  /** The Col dimension field. [dbo.Board.ColDimension] */
  colDimension: number;
  /** The Discovery date field. [dbo.Board.DiscoveryDate] */
  discoveryDate: Date;
  /** The Discovery date date formatted as per configuration for display. [Computed] */
  discoveryDateFormatted: string;
  /** The Discovery iteration count field. [dbo.Board.DiscoveryIterationCount] */
  discoveryIterationCount: number;
  /** The Discovery randomness field. [dbo.Board.DiscoveryRandomness] */
  discoveryRandomness: number;
  /** The entity type. [Computed] */
  entityType: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Path field. [dbo.Board.Path] */
  path: string;
  /** The Row dimension field. [dbo.Board.RowDimension] */
  rowDimension: number;
  /** The Source board id field. [dbo.Board.SourceBoardId] */
  sourceBoardId: number;

  /**
  * Function [constructor]: 
  * The constructor for the @see BoardBase class
  * @param {BoardBase} initialBoard?: An optional initial object to seed this class.
  */
  constructor(initialBoard?: BoardBase) {
    if (initialBoard) {
      this.author = initialBoard.author;
      this.boardBySourceBoardId = initialBoard.boardBySourceBoardId;
      this.boardCode = initialBoard.boardCode;
      this.boardId = initialBoard.boardId;
      this.colDimension = initialBoard.colDimension;
      this.discoveryDate = initialBoard.discoveryDate;
      this.discoveryDateFormatted = initialBoard.discoveryDateFormatted;
      this.discoveryIterationCount = initialBoard.discoveryIterationCount;
      this.discoveryRandomness = initialBoard.discoveryRandomness;
      this.entityType = initialBoard.entityType;
      this.instanceLabel = initialBoard.instanceLabel;
      this.path = initialBoard.path;
      this.rowDimension = initialBoard.rowDimension;
      this.sourceBoardId = initialBoard.sourceBoardId;
    } else {
      this.author = '';
      this.boardBySourceBoardId = null;
      this.boardCode = guid();
      this.boardId = 0;
      this.colDimension = 0;
      this.discoveryDate = new Date();
      this.discoveryDateFormatted = moment(this.discoveryDate).format('YYYY-MM-DD');
      this.discoveryIterationCount = 0;
      this.discoveryRandomness = 0;
      this.entityType = 'BoardBase';
      this.instanceLabel = '';
      this.path = '';
      this.rowDimension = 0;
      this.sourceBoardId = 0;
    }
  } // constructor


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see BoardPropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see BoardPropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
