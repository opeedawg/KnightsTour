/**
 * File:     DboVDistinctBoardSizeBase.ts
 * Location: src\views\models\base\
 * The class that represents the view model for DB view dbo.V_DistinctBoardSizes.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */


/**
* Abstract Class: DboVDistinctBoardSizeBase
*
* Base class to define the @see DboVDistinctBoardSizeBase model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVDistinctBoardSizeBase.
*
* @implements {constructor} The constructor for the @see DboVDistinctBoardSizeBase class
*/
export abstract class DboVDistinctBoardSizeBase {
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
  * The constructor for the @see DboVDistinctBoardSizeBase class
  */
  constructor() {
      this.colDimension = 0;
      this.puzzleCount = 0;
      this.rowDimension = 0;
      this.value = '';
  } // constructor

}
