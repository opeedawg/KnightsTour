/**
 * File:     Board.ts
 * Location: models\base\
 * The base class for the @see Board entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

// Imports
import moment from 'moment';

/**
 * Class: Board
 *
 * Base class to define the @see Board model.
 *
 * @implements {constructor} The constructor for the @see Board class
 */
export class Board {
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
   * The constructor for the @see Board class
   * @param {Board} initialBoard?: An optional initial object to seed this class.
   */
  constructor(initialBoard?: Board) {
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
      this.boardCode = '';
      this.boardId = 0;
      this.colDimension = 0;
      this.discoveryDate = new Date();
      this.discoveryDateFormatted = moment(this.discoveryDate).format(
        'YYYY-MM-DD'
      );
      this.discoveryIterationCount = 0;
      this.discoveryRandomness = 0;
      this.entityType = 'Board';
      this.instanceLabel = '';
      this.path = '';
      this.rowDimension = 0;
      this.sourceBoardId = 0;
    }
  } // constructor
}
