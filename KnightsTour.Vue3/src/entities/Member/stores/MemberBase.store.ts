/**
 * File:     MemberBase.store.ts
 * Location: src\entities\Member\stores\
 * The base store to implement any common Member api calls.  It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Member.store.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:15 AM
 */

// Imports
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { EventHistory } from 'src/entities/EventHistory/models/EventHistory';
import { Member } from '../models/Member';
import { MemberService } from '../services/Member.service';
import { Solution } from 'src/entities/Solution/models/Solution';

/**
* Class: MemberBaseStore
*
* Class to implement any common decoration on data returned from the base api service endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see MemberStore.
*
* @implements {constructor} The constructor for the @see MemberBaseStore class
* @implements {delete} Deletes the @see Member.
* @implements {deleteCascade} Deletes the @see Member in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see Members.
* @implements {eventHistories} Returns all the related @see EventHistories entities related to the @see Member.
* @implements {eventHistory} Returns the related @see EventHistory entity related to the @see Member.
* @implements {get} Gets an object of type @see Member by its primary key.
* @implements {getAll} Gets all of the @see Member.
* @implements {getAllFiltered} Gets all the @see Member with the filter applied.
* @implements {getByIds} Gets all of the @see Member given the set of primary keys.
* @implements {getCount} Gets the total number of the @see Member given the filter.
* @implements {insert} Inserts the @see Member.
* @implements {insertCascade} Inserts the @see Member in a cascading fashion.
* @implements {solution} Returns the related @see Solution entity related to the @see Member.
* @implements {solutions} Returns all the related @see Solutions entities related to the @see Member.
* @implements {update} Updates the @see Member.
*/
export class MemberBaseStore {
  // *** Declarations ***
  /** A reference to the related service. */
  service: MemberService;

  /**
  * Function [constructor]: 
  * The constructor for the @see MemberBaseStore class
  */
  constructor() {
    this.service = new MemberService();
  } // constructor


  /**
  * Function [delete]: 
  * Deletes the @see Member.
  * @param {number} id: The primary key of the @see Member for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async delete(id: number): Promise<DXResponse> {
      const result = await this.service.delete(id);
      return result.data;
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see Member in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Member for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async deleteCascade(id: number): Promise<DXResponse> {
      const result = await this.service.deleteCascade(id);
      return result.data;
  } // deleteCascade


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see Members.
  * @param {string} operation: The operation name to execute.
  * @param {Member[]} selected: The collection of @see Member of which to operate on.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async doCustomOperation(operation: string, selected: Member[]): Promise<DXResponse> {
      const result = await this.service.doCustomOperation(operation, selected);
      return result.data;
  } // doCustomOperation


  /**
  * Function [eventHistories]: 
  * Returns all the related @see EventHistories entities related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the EventHistories.
  * @returns {Promise<EventHistory[]>} The promise of a collection of type @see EventHistory
  */
  async eventHistories(id: number): Promise<EventHistory[]> {
      const result = await this.service.eventHistories(id);
      return result.data;
  } // eventHistories


  /**
  * Function [eventHistory]: 
  * Returns the related @see EventHistory entity related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the EventHistories.
  * @param {number} childId: The primary key of the @see EventHistory of which to retrieve related to the EventHistories.
  * @returns {Promise<EventHistory>} The promise of an object of type @see EventHistory.
  */
  async eventHistory(id: number, childId: number): Promise<EventHistory> {
      const result = await this.service.eventHistory(id, childId);
      return result.data;
  } // eventHistory


  /**
  * Function [get]: 
  * Gets an object of type @see Member by its primary key.
  * @param {number} id: The primary key of the @see Member
  * @param {(element: Member) => void} formatterFunction?: An optional formatter function.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async get(id: number, formatterFunction?: (element: Member) => void): Promise<DXResponse> {
      const result = await this.service.get(id);

      if (formatterFunction) {
        formatterFunction(result.data.dataObject);
      }

      return result.data;
  } // get


  /**
  * Function [getAll]: 
  * Gets all of the @see Member.
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
  * Gets all the @see Member with the filter applied.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Member collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getAllFiltered(filter);
      return result.data;
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Gets all of the @see Member given the set of primary keys.
  * @param {string[]} ids: An array of primary key ids to return.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getByIds(ids: string[]): Promise<DXResponse> {
      const result = await this.service.getByIds(ids);
      return result.data;
  } // getByIds


  /**
  * Function [getCount]: 
  * Gets the total number of the @see Member given the filter.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Member collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getCount(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getCount(filter);
      return result.data;
  } // getCount


  /**
  * Function [insert]: 
  * Inserts the @see Member.
  * @param {Member} data: The @see Member to insert.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insert(data: Member): Promise<DXResponse> {
      const result = await this.service.insert(data);
      return result.data;
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the @see Member in a cascading fashion.
  * @param {Member} data: The @see Member to insert with child objects (optional).
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insertCascade(data: Member): Promise<DXResponse> {
      const result = await this.service.insertCascade(data);
      return result.data;
  } // insertCascade


  /**
  * Function [solution]: 
  * Returns the related @see Solution entity related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the Solutions.
  * @param {number} childId: The primary key of the @see Solution of which to retrieve related to the Solutions.
  * @returns {Promise<Solution>} The promise of an object of type @see Solution.
  */
  async solution(id: number, childId: number): Promise<Solution> {
      const result = await this.service.solution(id, childId);
      return result.data;
  } // solution


  /**
  * Function [solutions]: 
  * Returns all the related @see Solutions entities related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the Solutions.
  * @returns {Promise<Solution[]>} The promise of a collection of type @see Solution
  */
  async solutions(id: number): Promise<Solution[]> {
      const result = await this.service.solutions(id);
      return result.data;
  } // solutions


  /**
  * Function [update]: 
  * Updates the @see Member.
  * @param {Member} data: The @see Member to update.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async update(data: Member): Promise<DXResponse> {
      const result = await this.service.update(data);
      return result.data;
  } // update

}
