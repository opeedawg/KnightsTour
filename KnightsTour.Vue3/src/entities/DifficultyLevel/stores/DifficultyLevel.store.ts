/**
 * File:     DifficultyLevel.store.ts
 * Location: src\entities\DifficultyLevel\stores\
 * Store to implement any custom Difficulty level api calls.  Mainly used to decorate service return calls.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { DifficultyLevel } from '../models/DifficultyLevel';
import { DifficultyLevelBaseStore } from './DifficultyLevelBase.store';

/**
* Class: DifficultyLevelStore
* @extends {DifficultyLevelBaseStore}
*
* Class to implement any decoration on data returned from the api service endpoints.
*
* @implements {constructor} The constructor for the @see DifficultyLevelStore class
* @implements {getAll} Performs any filtering, ordering or decoration of @see DifficultyLevels.
* @implements {getAllFilter} Filter results.  Complete parameters include (element, index, array) if you require them.  @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/filter.
* @implements {getAllFormatter} Format results.  Complete parameters include (element, index, array) if you require them.  @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach.
* @implements {getAllOrdering} Orders results.  Complete parameters include (a, b)  - the elements to compare.  @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/sort.
*/
export class DifficultyLevelStore extends DifficultyLevelBaseStore {

  /**
  * Function [constructor]: 
  * The constructor for the @see DifficultyLevelStore class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [getAll]: 
  * Performs any filtering, ordering or decoration of @see DifficultyLevels.
  * @returns {Promise<DifficultyLevel[]>} A promise of an array of @see DifficultyLevel
  */
  async getAll(): Promise<DifficultyLevel[]> {
      // Invoke the base class for standard data call.
      const result = await super.getAll(
        this.getAllFilter,
        this.getAllFormatter,
        this.getAllOrdering
      );
      // Return the result.
      return result;
  } // getAll


  /**
  * Function [getAllFilter]: 
  * Filter results.  Complete parameters include (element, index, array) if you require them.  @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/filter.
  * @returns {boolean} A boolean indicating if the element should be included or not.
  */
  getAllFilter(): boolean {
      return true;
  } // getAllFilter


  /**
  * Function [getAllFormatter]: 
  * Format results.  Complete parameters include (element, index, array) if you require them.  @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach.
  * @returns {void} No return, consider the entity as a by reference object.
  */
  getAllFormatter(): void {
      // Format each entity as required here.
  } // getAllFormatter


  /**
  * Function [getAllOrdering]: 
  * Orders results.  Complete parameters include (a, b)  - the elements to compare.  @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/sort.
  * @returns {number} An integer, > 0 if a > b, < 0 if a < b and 0 if equal.
  */
  getAllOrdering(): number {
      return 0;
  } // getAllOrdering

}
