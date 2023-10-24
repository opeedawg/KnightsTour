/**
 * File:     PuzzleBase.store.ts
 * Location: src\entities\Puzzle\stores\
 * The base store to implement any common Puzzle api calls.  It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Puzzle.store.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { Board } from 'src/entities/Board/models/Board';
import { BoardStore } from 'src/entities/Board/stores/Board.store';
import { DifficultyLevel } from 'src/entities/DifficultyLevel/models/DifficultyLevel';
import { DifficultyLevelStore } from 'src/entities/DifficultyLevel/stores/DifficultyLevel.store';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Puzzle } from '../models/Puzzle';
import { PuzzleService } from '../services/Puzzle.service';
import { Solution } from 'src/entities/Solution/models/Solution';

/**
* Class: PuzzleBaseStore
*
* Class to implement any common decoration on data returned from the base api service endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see PuzzleStore.
*
* @implements {board} Returns the related @see Board entity related to the @see Puzzle.
* @implements {constructor} The constructor for the @see PuzzleBaseStore class
* @implements {delete} Deletes the @see Puzzle.
* @implements {deleteCascade} Deletes the @see Puzzle in a cascading fashion (including all its related child objects).
* @implements {difficultyLevel} Returns the related @see DifficultyLevel entity related to the @see Puzzle.
* @implements {doCustomOperation} Performs the custom operation on one or many @see Puzzles.
* @implements {get} Gets an object of type @see Puzzle by its primary key.
* @implements {getAll} Gets all of the @see Puzzle.
* @implements {getAllFiltered} Gets all the @see Puzzle with the filter applied.
* @implements {getByIds} Gets all of the @see Puzzle given the set of primary keys.
* @implements {getCount} Gets the total number of the @see Puzzle given the filter.
* @implements {hydrateBoardByBoardId} Hydrates the boardByBoardId property with the complete @see Board object.
* @implements {hydrateDifficultyLevelByDifficultyLevelId} Hydrates the difficultyLevelByDifficultyLevelId property with the complete @see DifficultyLevel object.
* @implements {insert} Inserts the @see Puzzle.
* @implements {insertCascade} Inserts the @see Puzzle in a cascading fashion.
* @implements {solution} Returns the related @see Solution entity related to the @see Puzzle.
* @implements {solutions} Returns all the related @see Solutions entities related to the @see Puzzle.
* @implements {update} Updates the @see Puzzle.
*/
export class PuzzleBaseStore {
  // *** Declarations ***
  /** A reference to the related service. */
  service: PuzzleService;

  /**
  * Function [constructor]: 
  * The constructor for the @see PuzzleBaseStore class
  */
  constructor() {
    this.service = new PuzzleService();
  } // constructor


  /**
  * Function [board]: 
  * Returns the related @see Board entity related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the related @see Board.
  * @returns {Promise<Board>} The promise of an object of type @see Board.
  */
  async board(id: number): Promise<Board> {
      const result = await this.service.board(id);
      return result.data;
  } // board


  /**
  * Function [delete]: 
  * Deletes the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async delete(id: number): Promise<DXResponse> {
      const result = await this.service.delete(id);
      return result.data;
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see Puzzle in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Puzzle for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async deleteCascade(id: number): Promise<DXResponse> {
      const result = await this.service.deleteCascade(id);
      return result.data;
  } // deleteCascade


  /**
  * Function [difficultyLevel]: 
  * Returns the related @see DifficultyLevel entity related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the related @see DifficultyLevel.
  * @returns {Promise<DifficultyLevel>} The promise of an object of type @see DifficultyLevel.
  */
  async difficultyLevel(id: number): Promise<DifficultyLevel> {
      const result = await this.service.difficultyLevel(id);
      return result.data;
  } // difficultyLevel


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see Puzzles.
  * @param {string} operation: The operation name to execute.
  * @param {Puzzle[]} selected: The collection of @see Puzzle of which to operate on.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async doCustomOperation(operation: string, selected: Puzzle[]): Promise<DXResponse> {
      const result = await this.service.doCustomOperation(operation, selected);
      return result.data;
  } // doCustomOperation


  /**
  * Function [get]: 
  * Gets an object of type @see Puzzle by its primary key.
  * @param {number} id: The primary key of the @see Puzzle
  * @param {(element: Puzzle) => void} formatterFunction?: An optional formatter function.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async get(id: number, formatterFunction?: (element: Puzzle) => void): Promise<DXResponse> {
      const result = await this.service.get(id);

      if (formatterFunction) {
        formatterFunction(result.data.dataObject);
      }

      return result.data;
  } // get


  /**
  * Function [getAll]: 
  * Gets all of the @see Puzzle.
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
  * Gets all the @see Puzzle with the filter applied.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Puzzle collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getAllFiltered(filter);
      return result.data;
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Gets all of the @see Puzzle given the set of primary keys.
  * @param {string[]} ids: An array of primary key ids to return.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getByIds(ids: string[]): Promise<DXResponse> {
      const result = await this.service.getByIds(ids);
      return result.data;
  } // getByIds


  /**
  * Function [getCount]: 
  * Gets the total number of the @see Puzzle given the filter.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Puzzle collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getCount(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getCount(filter);
      return result.data;
  } // getCount


  /**
  * Function [hydrateBoardByBoardId]: 
  * Hydrates the boardByBoardId property with the complete @see Board object.
  * @param {Puzzle[]} entities: The @see Puzzle collection to retrieve hydrate (by reference).
  * @returns {Promise<Puzzle[] | undefined>} The promise of an object of type @see Puzzle[] | undefined.
  */
  async hydrateBoardByBoardId(entities: Puzzle[]): Promise<Puzzle[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: Puzzle) => {
      if (value.boardId && ids.indexOf(value.boardId.toString()) < 0) {
        ids.push(value.boardId.toString());
      }
    });

    // Now create a reference to the Board store to grab the minimal set of objects for hydration.
    const boardStore = new BoardStore();
    if (ids.length > 0) {
      const result = await boardStore
        .getByIds(ids)
        .then((response) => {
          if (response.isValid && response.dataObject.length > 0) {
            entities.forEach((value: Puzzle) => {
              if (value.boardId) {
                const foundFK = response.dataObject.find(
                  (x: Board) => x.boardId == value.boardId
                );
                if (foundFK != null) {
                  value.boardByBoardId = foundFK;
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
  } // hydrateBoardByBoardId


  /**
  * Function [hydrateDifficultyLevelByDifficultyLevelId]: 
  * Hydrates the difficultyLevelByDifficultyLevelId property with the complete @see DifficultyLevel object.
  * @param {Puzzle[]} entities: The @see Puzzle collection to retrieve hydrate (by reference).
  * @returns {Promise<Puzzle[] | undefined>} The promise of an object of type @see Puzzle[] | undefined.
  */
  async hydrateDifficultyLevelByDifficultyLevelId(entities: Puzzle[]): Promise<Puzzle[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: Puzzle) => {
      if (value.difficultyLevelId && ids.indexOf(value.difficultyLevelId.toString()) < 0) {
        ids.push(value.difficultyLevelId.toString());
      }
    });

    // Now create a reference to the DifficultyLevel store to grab the minimal set of objects for hydration.
    const difficultyLevelStore = new DifficultyLevelStore();
    if (ids.length > 0) {
      const result = await difficultyLevelStore
        .getByIds(ids)
        .then((response) => {
          if (response.isValid && response.dataObject.length > 0) {
            entities.forEach((value: Puzzle) => {
              if (value.difficultyLevelId) {
                const foundFK = response.dataObject.find(
                  (x: DifficultyLevel) => x.difficultyLevelId == value.difficultyLevelId
                );
                if (foundFK != null) {
                  value.difficultyLevelByDifficultyLevelId = foundFK;
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
  } // hydrateDifficultyLevelByDifficultyLevelId


  /**
  * Function [insert]: 
  * Inserts the @see Puzzle.
  * @param {Puzzle} data: The @see Puzzle to insert.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insert(data: Puzzle): Promise<DXResponse> {
      const result = await this.service.insert(data);
      return result.data;
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the @see Puzzle in a cascading fashion.
  * @param {Puzzle} data: The @see Puzzle to insert with child objects (optional).
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insertCascade(data: Puzzle): Promise<DXResponse> {
      const result = await this.service.insertCascade(data);
      return result.data;
  } // insertCascade


  /**
  * Function [solution]: 
  * Returns the related @see Solution entity related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the Solutions.
  * @param {number} childId: The primary key of the @see Solution of which to retrieve related to the Solutions.
  * @returns {Promise<Solution>} The promise of an object of type @see Solution.
  */
  async solution(id: number, childId: number): Promise<Solution> {
      const result = await this.service.solution(id, childId);
      return result.data;
  } // solution


  /**
  * Function [solutions]: 
  * Returns all the related @see Solutions entities related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the Solutions.
  * @returns {Promise<Solution[]>} The promise of a collection of type @see Solution
  */
  async solutions(id: number): Promise<Solution[]> {
      const result = await this.service.solutions(id);
      return result.data;
  } // solutions


  /**
  * Function [update]: 
  * Updates the @see Puzzle.
  * @param {Puzzle} data: The @see Puzzle to update.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async update(data: Puzzle): Promise<DXResponse> {
      const result = await this.service.update(data);
      return result.data;
  } // update

}
