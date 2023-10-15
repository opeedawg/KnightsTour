/**
 * File:     IBoardBase.ts
 * Location: src\entities\Board\models\base\
 * Interface to represent the base properties and functions of the @see Board. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file IBoard.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:15 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: IBoardBase
* @extends {IBaseEntity}
*
* Interface to define the Board model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see IBoard.
*
* @implements {constructor} The constructor for the @see IBoardBase class
*/
export interface IBoardBase extends IBaseEntity {
  // *** Declarations ***
  /** The Author field. [dbo.Board.Author] */
  author: string;
  /** The Board code field. [dbo.Board.BoardCode] */
  boardCode: string;
  /** The Board id field. [dbo.Board.BoardId] */
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
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Path field. [dbo.Board.Path] */
  path: string;
  /** The Row dimension field. [dbo.Board.RowDimension] */
  rowDimension: number;
  /** The Source board id field. [dbo.Board.SourceBoardId] */
  sourceBoardId: number;
}
