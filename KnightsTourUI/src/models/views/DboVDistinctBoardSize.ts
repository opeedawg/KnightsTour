/**
 * File:     DboVDistinctBoardSize.ts
 * Location: src\view\
 * The class that represents the view model for DB view dbo.V_DistinctBoardSizes.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 18, 2023 at 9:22:45 AM
 */

/**
 * Abstract Class: DboVDistinctBoardSize
 *
 * Base class to define the @see DboVDistinctBoardSize model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVDistinctBoardSize.
 *
 * @implements {constructor} The constructor for the @see DboVDistinctBoardSize class
 */
export class DboVDistinctBoardSize {
  // *** Declarations ***
  /** The dbo.V_DistinctBoardSizes ColDimension field. */
  colDimension: number;
  /** The dbo.V_DistinctBoardSizes PuzzleCount field. */
  puzzleCount: number;
  /** The dbo.V_DistinctBoardSizes RowDimension field. */
  rowDimension: number;
  /** The dbo.V_DistinctBoardSizes Value field. */
  value: string;

  /**
   * Function [constructor]:
   * The constructor for the @see DboVDistinctBoardSize class
   */
  constructor() {
    this.colDimension = 0;
    this.puzzleCount = 0;
    this.rowDimension = 0;
    this.value = '';
  } // constructor
}
