/**
 * File:     BoardBase.service.ts
 * Location: src\entities\Board\services\
 * Service to access all model (common) Board api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Board.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:15 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { Board } from '../models/Board';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';

/**
* Class: BoardBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see BoardService.
*
* @implements {board} Returns the related @see Board entity related to the @see Board.
* @implements {boardBySourceBoardId} Returns the related @see Board entity related to the @see Board.
* @implements {boards} Returns all the related @see Board entities related to the @see Board.
* @implements {constructor} The constructor for the @see BoardBaseService class
* @implements {delete} Deletes a @see Board.
* @implements {deleteCascade} Deletes the @see Board in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see Boards.
* @implements {get} Retrives a @see Board.
* @implements {getAll} Retrives all the available @see Board.
* @implements {getAllFiltered} Retrives all the available @see Boards.
* @implements {getByIds} Retrives all the available @see Boards.
* @implements {getCount} Retrives the count of @see Boards.
* @implements {getIds} Gets an array of primary key values from the @see Boards collection passed.
* @implements {insert} Inserts the new @see Board.
* @implements {insertCascade} Inserts the new @see Board in a cascading fashion.
* @implements {puzzle} Returns the related @see Puzzle entity related to the @see Board.
* @implements {puzzles} Returns all the related @see Puzzle entities related to the @see Board.
* @implements {update} Updates the existing @see Board.
*/
export class BoardBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see BoardBaseService class
  */
  constructor() {
      super('boards');
  } // constructor


  /**
  * Function [board]: 
  * Returns the related @see Board entity related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the related @see Board.
  * @returns {Promise<AxiosResponse<Board>>} A promise of an object of type @see Board
  */
  async board(id: number): Promise<AxiosResponse<Board>> {
      try {
        return api.get(this.restPath + + '/' + id + '/board', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // board


  /**
  * Function [boardBySourceBoardId]: 
  * Returns the related @see Board entity related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the @see Board.
  * @param {number} childId: The primary key of the @see Board of which to retrieve related to the @see Board entities.
  * @returns {Promise<AxiosResponse<Board>>} A promise of an object of type @see Board
  */
  async boardBySourceBoardId(id: number, childId: number): Promise<AxiosResponse<Board>> {
      try {
        return api.get(this.restPath + '/' + id + '/boards/' + childId, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // boardBySourceBoardId


  /**
  * Function [boards]: 
  * Returns all the related @see Board entities related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the @see Board entities.
  * @returns {Promise<AxiosResponse<Board[]>>} A promise of an array of @see Board
  */
  async boards(id: number): Promise<AxiosResponse<Board[]>> {
      try {
        return api.get(this.restPath + '/' + id + '/boards', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // boards


  /**
  * Function [delete]: 
  * Deletes a @see Board.
  * @param {number} id: The primary key of the @see Board of which to delete.
  * @returns {Promise<AxiosResponse<DXResponse>>} A promise of an object of type @see DXResponse containing detailed feedback.
  */
  async delete(id: number): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.delete(this.restPath + '/' + id, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see Board in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Board of which to delete.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async deleteCascade(id: number): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.delete(this.restPath + '/' + id + '/cascade', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // deleteCascade


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see Boards.
  * @param {string} operation: The operation name to execute.
  * @param {Board[]} selected: The collection of @see Board of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: Board[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [get]: 
  * Retrives a @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async get(id: number): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/' + id, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // get


  /**
  * Function [getAll]: 
  * Retrives all the available @see Board.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async getAll(): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.get(this.restPath, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // getAll


  /**
  * Function [getAllFiltered]: 
  * Retrives all the available @see Boards.
  * @param {DXEntityFilter} filter: A filter for the entities to retrieve.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/extended', filter, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Retrives all the available @see Boards.
  * @param {string[]} ids: An array of primary key values.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async getByIds(ids: string[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.get(this.restPath + '/ids/' + ids, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // getByIds


  /**
  * Function [getCount]: 
  * Retrives the count of @see Boards.
  * @param {DXEntityFilter} filter: A filter for the entities to retrieve the count for.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async getCount(filter: DXEntityFilter): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/count', filter, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // getCount


  /**
  * Function [getIds]: 
  * Gets an array of primary key values from the @see Boards collection passed.
  * @param {Board[]} entities: The collection of @see Board of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: Board[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: Board) {
        ids.push(entity.boardId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see Board.
  * @param {Board} data: The @see Board to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: Board): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see Board in a cascading fashion.
  * @param {Board} data: The @see Board to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: Board): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [puzzle]: 
  * Returns the related @see Puzzle entity related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the @see Puzzle.
  * @param {number} childId: The primary key of the @see Puzzle of which to retrieve related to the @see Puzzle entities.
  * @returns {Promise<AxiosResponse<Puzzle>>} A promise of an object of type @see Board
  */
  async puzzle(id: number, childId: number): Promise<AxiosResponse<Puzzle>> {
      try {
        return api.get(this.restPath + '/' + id + '/puzzles/' + childId, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // puzzle


  /**
  * Function [puzzles]: 
  * Returns all the related @see Puzzle entities related to the @see Board.
  * @param {number} id: The primary key of the @see Board of which to retrieve the @see Puzzle entities.
  * @returns {Promise<AxiosResponse<Puzzle[]>>} A promise of an array of @see Board
  */
  async puzzles(id: number): Promise<AxiosResponse<Puzzle[]>> {
      try {
        return api.get(this.restPath + '/' + id + '/puzzles', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // puzzles


  /**
  * Function [update]: 
  * Updates the existing @see Board.
  * @param {Board} data: The @see Board to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: Board): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
