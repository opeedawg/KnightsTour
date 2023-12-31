/**
 * File:     Puzzle.ts
 * Location: src\entities\Puzzle\models\
 * The extended class for the @see Puzzle entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  PuzzleBase,
  PuzzlePropertyNames,
} from './base/PuzzleBase';

/**
* Class: Puzzle
* @extends {PuzzleBase}
*
* Class to define the Puzzle model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Puzzle
* @implements {constructor} The constructor for the @see Puzzle class
*/
export class Puzzle extends PuzzleBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see Puzzle class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Puzzle
  * @returns {Puzzle} A new clone of @see Puzzle
  */
  clone(): Puzzle {
    const clonedEntity = new Puzzle();
    const self = this;
    Object.values(PuzzlePropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
