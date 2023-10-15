/**
 * File:     Board.ts
 * Location: src\entities\Board\models\
 * The extended class for the @see Board entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  BoardBase,
  BoardPropertyNames,
} from './base/BoardBase';

/**
* Class: Board
* @extends {BoardBase}
*
* Class to define the Board model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Board
* @implements {constructor} The constructor for the @see Board class
*/
export class Board extends BoardBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see Board class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Board
  * @returns {Board} A new clone of @see Board
  */
  clone(): Board {
    const clonedEntity = new Board();
    const self = this;
    Object.values(BoardPropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
