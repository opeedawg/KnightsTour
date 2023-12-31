/**
 * File:     Solution.ts
 * Location: src\entities\Solution\models\
 * The extended class for the @see Solution entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  SolutionBase,
  SolutionPropertyNames,
} from './base/SolutionBase';

/**
* Class: Solution
* @extends {SolutionBase}
*
* Class to define the Solution model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Solution
* @implements {constructor} The constructor for the @see Solution class
*/
export class Solution extends SolutionBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see Solution class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Solution
  * @returns {Solution} A new clone of @see Solution
  */
  clone(): Solution {
    const clonedEntity = new Solution();
    const self = this;
    Object.values(SolutionPropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
