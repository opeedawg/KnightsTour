/**
 * File:     DifficultyLevelBase.store.ts
 * Location: src\entities\DifficultyLevel\stores\
 * The base store to implement any common Difficulty level api calls.  It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file DifficultyLevel.store.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { DifficultyLevel } from '../models/DifficultyLevel';
import { DifficultyLevelService } from '../services/DifficultyLevel.service';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';

/**
* Class: DifficultyLevelBaseStore
*
* Class to implement any common decoration on data returned from the base api service endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DifficultyLevelStore.
*
* @implements {constructor} The constructor for the @see DifficultyLevelBaseStore class
* @implements {delete} Deletes the @see DifficultyLevel.
* @implements {deleteCascade} Deletes the @see DifficultyLevel in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see DifficultyLevels.
* @implements {get} Gets an object of type @see DifficultyLevel by its primary key.
* @implements {getAll} Gets all of the @see DifficultyLevel.
* @implements {getAllFiltered} Gets all the @see DifficultyLevel with the filter applied.
* @implements {getByIds} Gets all of the @see DifficultyLevel given the set of primary keys.
* @implements {getCount} Gets the total number of the @see DifficultyLevel given the filter.
* @implements {insert} Inserts the @see DifficultyLevel.
* @implements {insertCascade} Inserts the @see DifficultyLevel in a cascading fashion.
* @implements {puzzle} Returns the related @see Puzzle entity related to the @see DifficultyLevel.
* @implements {puzzles} Returns all the related @see Puzzles entities related to the @see DifficultyLevel.
* @implements {update} Updates the @see DifficultyLevel.
*/
export class DifficultyLevelBaseStore {
  // *** Declarations ***
  /** A reference to the related service. */
  service: DifficultyLevelService;

  /**
  * Function [constructor]: 
  * The constructor for the @see DifficultyLevelBaseStore class
  */
  constructor() {
    this.service = new DifficultyLevelService();
  } // constructor


  /**
  * Function [delete]: 
  * Deletes the @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async delete(id: number): Promise<DXResponse> {
      const result = await this.service.delete(id);
      return result.data;
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see DifficultyLevel in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see DifficultyLevel for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async deleteCascade(id: number): Promise<DXResponse> {
      const result = await this.service.deleteCascade(id);
      return result.data;
  } // deleteCascade


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see DifficultyLevels.
  * @param {string} operation: The operation name to execute.
  * @param {DifficultyLevel[]} selected: The collection of @see DifficultyLevel of which to operate on.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async doCustomOperation(operation: string, selected: DifficultyLevel[]): Promise<DXResponse> {
      const result = await this.service.doCustomOperation(operation, selected);
      return result.data;
  } // doCustomOperation


  /**
  * Function [get]: 
  * Gets an object of type @see DifficultyLevel by its primary key.
  * @param {number} id: The primary key of the @see DifficultyLevel
  * @param {(element: DifficultyLevel) => void} formatterFunction?: An optional formatter function.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async get(id: number, formatterFunction?: (element: DifficultyLevel) => void): Promise<DXResponse> {
      const result = await this.service.get(id);

      if (formatterFunction) {
        formatterFunction(result.data.dataObject);
      }

      return result.data;
  } // get


  /**
  * Function [getAll]: 
  * Gets all of the @see DifficultyLevel.
  * @param {() => boolean} filterFunction?: A reference to a function that performs a filter on the list.  Passed from the extended class.
  * @param {() => void} formatterFunction?: A reference to a function that performs any formatting on the list.  Passed from the extended class.
  * @param {() => number} sortFunction?: A reference to a function that performs any sorting on the list.  Passed from the extended class.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAll(filterFunction?: () => boolean, formatterFunction?: () => void, sortFunction?: () => number): Promise<DXResponse> {
      const result = await this.service.getAll();

      if (result.data.isValid) {
        let filteredResults = result.data.dataObject;

        // Apply a filter.
        if (filterFunction) {
          filteredResults = result.data.dataObject.filter(filterFunction);
        }

        // Perform any required formatting.
        if (formatterFunction) {
          filteredResults.forEach(formatterFunction);
        }

        // Apply any required sorting.
        if (sortFunction) {
          filteredResults.sort(sortFunction);
        }

        // Set the modified result set to the data portion of the result object as the UI expects.
        result.data.dataObject = filteredResults;
      }

      return result.data;
  } // getAll


  /**
  * Function [getAllFiltered]: 
  * Gets all the @see DifficultyLevel with the filter applied.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see DifficultyLevel collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getAllFiltered(filter);
      return result.data;
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Gets all of the @see DifficultyLevel given the set of primary keys.
  * @param {string[]} ids: An array of primary key ids to return.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getByIds(ids: string[]): Promise<DXResponse> {
      const result = await this.service.getByIds(ids);
      return result.data;
  } // getByIds


  /**
  * Function [getCount]: 
  * Gets the total number of the @see DifficultyLevel given the filter.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see DifficultyLevel collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getCount(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getCount(filter);
      return result.data;
  } // getCount


  /**
  * Function [insert]: 
  * Inserts the @see DifficultyLevel.
  * @param {DifficultyLevel} data: The @see DifficultyLevel to insert.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insert(data: DifficultyLevel): Promise<DXResponse> {
      const result = await this.service.insert(data);
      return result.data;
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the @see DifficultyLevel in a cascading fashion.
  * @param {DifficultyLevel} data: The @see DifficultyLevel to insert with child objects (optional).
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insertCascade(data: DifficultyLevel): Promise<DXResponse> {
      const result = await this.service.insertCascade(data);
      return result.data;
  } // insertCascade


  /**
  * Function [puzzle]: 
  * Returns the related @see Puzzle entity related to the @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel of which to retrieve the Puzzles.
  * @param {number} childId: The primary key of the @see Puzzle of which to retrieve related to the Puzzles.
  * @returns {Promise<Puzzle>} The promise of an object of type @see Puzzle.
  */
  async puzzle(id: number, childId: number): Promise<Puzzle> {
      const result = await this.service.puzzle(id, childId);
      return result.data;
  } // puzzle


  /**
  * Function [puzzles]: 
  * Returns all the related @see Puzzles entities related to the @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel of which to retrieve the Puzzles.
  * @returns {Promise<Puzzle[]>} The promise of a collection of type @see Puzzle
  */
  async puzzles(id: number): Promise<Puzzle[]> {
      const result = await this.service.puzzles(id);
      return result.data;
  } // puzzles


  /**
  * Function [update]: 
  * Updates the @see DifficultyLevel.
  * @param {DifficultyLevel} data: The @see DifficultyLevel to update.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async update(data: DifficultyLevel): Promise<DXResponse> {
      const result = await this.service.update(data);
      return result.data;
  } // update

}
