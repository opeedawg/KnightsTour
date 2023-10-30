/**
 * File:     BoardBase.store.ts
 * Location: src\entities\Board\stores\
 * The base store to implement any common Board api calls.  It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Board.store.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { Board } from '../models/Board';
import { BoardService } from '../services/Board.service';
import { BoardStore } from 'src/entities/Board/stores/Board.store';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';

/**
* Class: BoardBaseStore
*
* Class to implement any common decoration on data returned from the base api service endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see BoardStore.
*
* @implements {board} Returns the related @see Board entity related to the @see Board.
* @implements {boardBySourceBoardId} Returns all the related @see Board entities related to the @see Board.
* @implements {boards} Returns all the related @see Boards entities related to the @see Board.
* @implements {constructor} The constructor for the @see BoardBaseStore class
* @implements {delete} Deletes the @see Board.
* @implements {deleteCascade} Deletes the @see Board in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see Boards.
* @implements {get} Gets an object of type @see Board by its primary key.
* @implements {getAll} Gets all of the @see Board.
* @implements {getAllFiltered} Gets all the @see Board with the filter applied.
* @implements {getByIds} Gets all of the @see Board given the set of primary keys.
* @implements {getCount} Gets the total number of the @see Board given the filter.
* @implements {hydrateBoardBySourceBoardId} Hydrates the boardBySourceBoardId property with the complete @see Board object.
* @implements {insert} Inserts the @see Board.
* @implements {insertCascade} Inserts the @see Board in a cascading fashion.
* @implements {puzzle} Returns the related @see Puzzle entity related to the @see Board.
* @implements {puzzles} Returns all the related @see Puzzles entities related to the @see Board.
* @implements {update} Updates the @see Board.
*/
export class BoardBaseStore {
  // *** Declarations ***
  /** A reference to the related service. */
  service: BoardService;

  /**
  * Function [constructor]: 
  * The constructor for the @see BoardBaseStore class
  */
  constructor() {
    this.service = new BoardService();
  } // constructor


  /**
  * Function [board]: 
  * Returns the related @see Board entity related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the related @see Board.
  * @returns {Promise<Board>} The promise of an object of type @see Board.
  */
  async board(id: number): Promise<Board> {
      const result = await this.service.board(id);
      return result.data;
  } // board


  /**
  * Function [boardBySourceBoardId]: 
  * Returns all the related @see Board entities related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the Boards.
  * @param {number} childId: The primary key of the @see Board of which to retrieve related to the Boards.
  * @returns {Promise<Board>} The promise of an object of type @see Board.
  */
  async boardBySourceBoardId(id: number, childId: number): Promise<Board> {
      const result = await this.service.boardBySourceBoardId(id, childId);
      return result.data;
  } // boardBySourceBoardId


  /**
  * Function [boards]: 
  * Returns all the related @see Boards entities related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the Boards.
  * @returns {Promise<Board[]>} The promise of a collection of type @see Board
  */
  async boards(id: number): Promise<Board[]> {
      const result = await this.service.boards(id);
      return result.data;
  } // boards


  /**
  * Function [delete]: 
  * Deletes the @see Board.
  * @param {number} id: The primary key of the @see Board for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async delete(id: number): Promise<DXResponse> {
      const result = await this.service.delete(id);
      return result.data;
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see Board in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Board for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async deleteCascade(id: number): Promise<DXResponse> {
      const result = await this.service.deleteCascade(id);
      return result.data;
  } // deleteCascade


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see Boards.
  * @param {string} operation: The operation name to execute.
  * @param {Board[]} selected: The collection of @see Board of which to operate on.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async doCustomOperation(operation: string, selected: Board[]): Promise<DXResponse> {
      const result = await this.service.doCustomOperation(operation, selected);
      return result.data;
  } // doCustomOperation


  /**
  * Function [get]: 
  * Gets an object of type @see Board by its primary key.
  * @param {number} id: The primary key of the @see Board
  * @param {(element: Board) => void} formatterFunction?: An optional formatter function.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async get(id: number, formatterFunction?: (element: Board) => void): Promise<DXResponse> {
      const result = await this.service.get(id);

      if (formatterFunction) {
        formatterFunction(result.data.dataObject);
      }

      return result.data;
  } // get


  /**
  * Function [getAll]: 
  * Gets all of the @see Board.
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
  * Gets all the @see Board with the filter applied.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Board collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getAllFiltered(filter);
      return result.data;
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Gets all of the @see Board given the set of primary keys.
  * @param {string[]} ids: An array of primary key ids to return.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getByIds(ids: string[]): Promise<DXResponse> {
      const result = await this.service.getByIds(ids);
      return result.data;
  } // getByIds


  /**
  * Function [getCount]: 
  * Gets the total number of the @see Board given the filter.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see Board collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getCount(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getCount(filter);
      return result.data;
  } // getCount


  /**
  * Function [hydrateBoardBySourceBoardId]: 
  * Hydrates the boardBySourceBoardId property with the complete @see Board object.
  * @param {Board[]} entities: The @see Board collection to retrieve hydrate (by reference).
  * @returns {Promise<Board[] | undefined>} The promise of an object of type @see Board[] | undefined.
  */
  async hydrateBoardBySourceBoardId(entities: Board[]): Promise<Board[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: Board) => {
      if (value.sourceBoardId && ids.indexOf(value.sourceBoardId.toString()) < 0) {
        ids.push(value.sourceBoardId.toString());
      }
    });

    // Now create a reference to the Board store to grab the minimal set of objects for hydration.
    const boardStore = new BoardStore();
    if (ids.length > 0) {
      const result = await boardStore
        .getByIds(ids)
        .then((response) => {
          if (response.isValid && response.dataObject.length > 0) {
            entities.forEach((value: Board) => {
              if (value.sourceBoardId) {
                const foundFK = response.dataObject.find(
                  (x: Board) => x.boardId == value.sourceBoardId
                );
                if (foundFK != null) {
                  value.boardBySourceBoardId = foundFK;
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
  } // hydrateBoardBySourceBoardId


  /**
  * Function [insert]: 
  * Inserts the @see Board.
  * @param {Board} data: The @see Board to insert.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insert(data: Board): Promise<DXResponse> {
      const result = await this.service.insert(data);
      return result.data;
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the @see Board in a cascading fashion.
  * @param {Board} data: The @see Board to insert with child objects (optional).
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insertCascade(data: Board): Promise<DXResponse> {
      const result = await this.service.insertCascade(data);
      return result.data;
  } // insertCascade


  /**
  * Function [puzzle]: 
  * Returns the related @see Puzzle entity related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the Puzzles.
  * @param {number} childId: The primary key of the @see Puzzle of which to retrieve related to the Puzzles.
  * @returns {Promise<Puzzle>} The promise of an object of type @see Puzzle.
  */
  async puzzle(id: number, childId: number): Promise<Puzzle> {
      const result = await this.service.puzzle(id, childId);
      return result.data;
  } // puzzle


  /**
  * Function [puzzles]: 
  * Returns all the related @see Puzzles entities related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the Puzzles.
  * @returns {Promise<Puzzle[]>} The promise of a collection of type @see Puzzle
  */
  async puzzles(id: number): Promise<Puzzle[]> {
      const result = await this.service.puzzles(id);
      return result.data;
  } // puzzles


  /**
  * Function [update]: 
  * Updates the @see Board.
  * @param {Board} data: The @see Board to update.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async update(data: Board): Promise<DXResponse> {
      const result = await this.service.update(data);
      return result.data;
  } // update

}
