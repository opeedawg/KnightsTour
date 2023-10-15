/**
 * File:     DifficultyLevel.ts
 * Location: src\entities\DifficultyLevel\models\
 * The extended class for the @see DifficultyLevel entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  DifficultyLevelBase,
  DifficultyLevelPropertyNames,
} from './base/DifficultyLevelBase';

/**
* Class: DifficultyLevel
* @extends {DifficultyLevelBase}
*
* Class to define the DifficultyLevel model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Difficulty level
* @implements {constructor} The constructor for the @see DifficultyLevel class
*/
export class DifficultyLevel extends DifficultyLevelBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see DifficultyLevel class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Difficulty level
  * @returns {DifficultyLevel} A new clone of @see DifficultyLevel
  */
  clone(): DifficultyLevel {
    const clonedEntity = new DifficultyLevel();
    const self = this;
    Object.values(DifficultyLevelPropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
