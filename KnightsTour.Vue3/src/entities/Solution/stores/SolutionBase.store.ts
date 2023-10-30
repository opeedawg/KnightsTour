/**
 * File:     SolutionBase.store.ts
 * Location: src\entities\Solution\stores\
 * The base store to implement any common Solution api calls.  It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Solution.store.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Member } from 'src/entities/Member/models/Member';
import { MemberStore } from 'src/entities/Member/stores/Member.store';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';
import { PuzzleStore } from 'src/entities/Puzzle/stores/Puzzle.store';
import { Solution } from '../models/Solution';
import { SolutionService } from '../services/Solution.service';

/**
* Class: SolutionBaseStore
*
* Class to implement any common decoration on data returned from the base api service endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see SolutionStore.
*
* @implements {constructor} The constructor for the @see SolutionBaseStore class
* @implements {delete} Deletes the @see Solution.
* @implements {deleteCascade} Deletes the @see Solution in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see Solutions.
* @implements {get} Gets an object of type @see Solution by its primary key.
* @implements {getAll} Gets all of the @see Solution.
* @implements {getAllFiltered} Gets all the @see Solution with the filter applied.
* @implements {getByIds} Gets all of the @see Solution given the set of primary keys.
* @implements {getCount} Gets the total number of the @see Solution given the filter.
* @implements {hydrateMemberByMemberId} Hydrates the memberByMemberId property with the complete @see Member object.
* @implements {hydratePuzzleByPuzzleId} Hydrates the puzzleByPuzzleId property with the complete @see Puzzle object.
* @implements {insert} Inserts the @see Solution.
* @implements {insertCascade} Inserts the @see Solution in a cascading fashion.
* @implements {member} Returns the related @see Member entity related to the @see Solution.
* @implements {puzzle} Returns the related @see Puzzle entity related to the @see Solution.
* @implements {update} Updates the @see Solution.
*/
export class SolutionBaseStore {
  // *** Declarations ***
  /** A reference to the related service. */
  service: SolutionService;

  /**
  * Function [constructor]: 
  * The constructor for the @see SolutionBaseStore class
  */
  constructor() {
    this.service = new SolutionService();
  } // constructor


  /**
  * Function [delete]: 
  * Deletes the @see Solution.
  * @param {number} id: The primary key of the @see Solution for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async delete(id: number): Promise<DXResponse> {
      const result = await this.service.delete(id);
      return result.data;
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see Solution in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Solution for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async deleteCascade(id: number): Promise<DXResponse> {
      const result = await this.service.deleteCascade(id);
      return result.data;
  } // deleteCascade


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see Solutions.
  * @param {string} operation: The operation name to execute.
  * @param {Solution[]} selected: The collection of @see Solution of which to operate on.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async doCustomOperation(operation: string, selected: Solution[]): Promise<DXResponse> {
      const result = await this.service.doCustomOperation(operation, selected);
      return result.data;
  } // doCustomOperation


  /**
  * Function [get]: 
  * Gets an object of type @see Solution by its primary key.
  * @param {number} id: The primary key of the @see Solution
  * @param {(element: Solution) => void} formatterFunction?: An optional formatter function.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async get(id: number, formatterFunction?: (element: Solution) => void): Promise<DXResponse> {
      const result = await this.service.get(id);

      if (formatterFunction) {
        formatterFunction(result.data.dataObject);
      }

      return result.data;
  } // get


  /**
  * Function [getAll]: 
  * Gets all of the @see Solution.
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
  * Gets all the @see Solution with the filter applied.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Solution collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getAllFiltered(filter);
      return result.data;
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Gets all of the @see Solution given the set of primary keys.
  * @param {string[]} ids: An array of primary key ids to return.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getByIds(ids: string[]): Promise<DXResponse> {
      const result = await this.service.getByIds(ids);
      return result.data;
  } // getByIds


  /**
  * Function [getCount]: 
  * Gets the total number of the @see Solution given the filter.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Solution collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getCount(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getCount(filter);
      return result.data;
  } // getCount


  /**
  * Function [hydrateMemberByMemberId]: 
  * Hydrates the memberByMemberId property with the complete @see Member object.
  * @param {Solution[]} entities: The @see Solution collection to retrieve hydrate (by reference).
  * @returns {Promise<Solution[] | undefined>} The promise of an object of type @see Solution[] | undefined.
  */
  async hydrateMemberByMemberId(entities: Solution[]): Promise<Solution[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: Solution) => {
      if (value.memberId && ids.indexOf(value.memberId.toString()) < 0) {
        ids.push(value.memberId.toString());
      }
    });

    // Now create a reference to the Member store to grab the minimal set of objects for hydration.
    const memberStore = new MemberStore();
    if (ids.length > 0) {
      const result = await memberStore
        .getByIds(ids)
        .then((response) => {
          if (response.isValid && response.dataObject.length > 0) {
            entities.forEach((value: Solution) => {
              if (value.memberId) {
                const foundFK = response.dataObject.find(
                  (x: Member) => x.memberId == value.memberId
                );
                if (foundFK != null) {
                  value.memberByMemberId = foundFK;
                }
              }
            });

            return entities;
          }
        });

      return result;
    } else {
      return entities;
    }
  } // hydrateMemberByMemberId


  /**
  * Function [hydratePuzzleByPuzzleId]: 
  * Hydrates the puzzleByPuzzleId property with the complete @see Puzzle object.
  * @param {Solution[]} entities: The @see Solution collection to retrieve hydrate (by reference).
  * @returns {Promise<Solution[] | undefined>} The promise of an object of type @see Solution[] | undefined.
  */
  async hydratePuzzleByPuzzleId(entities: Solution[]): Promise<Solution[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: Solution) => {
      if (value.puzzleId && ids.indexOf(value.puzzleId.toString()) < 0) {
        ids.push(value.puzzleId.toString());
      }
    });

    // Now create a reference to the Puzzle store to grab the minimal set of objects for hydration.
    const puzzleStore = new PuzzleStore();
    if (ids.length > 0) {
      const result = await puzzleStore
        .getByIds(ids)
        .then((response) => {
          if (response.isValid && response.dataObject.length > 0) {
            entities.forEach((value: Solution) => {
              if (value.puzzleId) {
                const foundFK = response.dataObject.find(
                  (x: Puzzle) => x.puzzleId == value.puzzleId
                );
                if (foundFK != null) {
                  value.puzzleByPuzzleId = foundFK;
                }
              }
            });

            return entities;
          }
        });

      return result;
    } else {
      return entities;
    }
  } // hydratePuzzleByPuzzleId


  /**
  * Function [insert]: 
  * Inserts the @see Solution.
  * @param {Solution} data: The @see Solution to insert.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insert(data: Solution): Promise<DXResponse> {
      const result = await this.service.insert(data);
      return result.data;
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the @see Solution in a cascading fashion.
  * @param {Solution} data: The @see Solution to insert with child objects (optional).
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insertCascade(data: Solution): Promise<DXResponse> {
      const result = await this.service.insertCascade(data);
      return result.data;
  } // insertCascade


  /**
  * Function [member]: 
  * Returns the related @see Member entity related to the @see Solution.
  * @param {number} id: The primary key of the @see Solution of which to retrieve the related @see Member.
  * @returns {Promise<Member>} The promise of an object of type @see Member.
  */
  async member(id: number): Promise<Member> {
      const result = await this.service.member(id);
      return result.data;
  } // member


  /**
  * Function [puzzle]: 
  * Returns the related @see Puzzle entity related to the @see Solution.
  * @param {number} id: The primary key of the @see Solution of which to retrieve the related @see Puzzle.
  * @returns {Promise<Puzzle>} The promise of an object of type @see Puzzle.
  */
  async puzzle(id: number): Promise<Puzzle> {
      const result = await this.service.puzzle(id);
      return result.data;
  } // puzzle


  /**
  * Function [update]: 
  * Updates the @see Solution.
  * @param {Solution} data: The @see Solution to update.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async update(data: Solution): Promise<DXResponse> {
      const result = await this.service.update(data);
      return result.data;
  } // update

}
