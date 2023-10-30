/**
 * File:     PuzzleBase.service.ts
 * Location: src\entities\Puzzle\services\
 * Service to access all model (common) Puzzle api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Puzzle.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { Board } from 'src/entities/Board/models/Board';
import { DifficultyLevel } from 'src/entities/DifficultyLevel/models/DifficultyLevel';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Puzzle } from '../models/Puzzle';
import { Solution } from 'src/entities/Solution/models/Solution';

/**
* Class: PuzzleBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see PuzzleService.
*
* @implements {board} Returns the related @see Board entity related to the @see Puzzle.
* @implements {constructor} The constructor for the @see PuzzleBaseService class
* @implements {delete} Deletes a @see Puzzle.
* @implements {deleteCascade} Deletes the @see Puzzle in a cascading fashion (including all its related child objects).
* @implements {difficultyLevel} Returns the related @see DifficultyLevel entity related to the @see Puzzle.
* @implements {doCustomOperation} Performs the custom operation on one or many @see Puzzles.
* @implements {get} Retrives a @see Puzzle.
* @implements {getAll} Retrives all the available @see Puzzle.
* @implements {getAllFiltered} Retrives all the available @see Puzzles.
* @implements {getByIds} Retrives all the available @see Puzzles.
* @implements {getCount} Retrives the count of @see Puzzles.
* @implements {getIds} Gets an array of primary key values from the @see Puzzles collection passed.
* @implements {insert} Inserts the new @see Puzzle.
* @implements {insertCascade} Inserts the new @see Puzzle in a cascading fashion.
* @implements {solution} Returns the related @see Solution entity related to the @see Puzzle.
* @implements {solutions} Returns all the related @see Solution entities related to the @see Puzzle.
* @implements {update} Updates the existing @see Puzzle.
*/
export class PuzzleBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see PuzzleBaseService class
  */
  constructor() {
      super('puzzles');
  } // constructor


  /**
  * Function [board]: 
  * Returns the related @see Board entity related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the related @see Board.
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
  * Function [delete]: 
  * Deletes a @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to delete.
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
  * Deletes the @see Puzzle in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Puzzle of which to delete.
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
  * Function [difficultyLevel]: 
  * Returns the related @see DifficultyLevel entity related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the related @see DifficultyLevel.
  * @returns {Promise<AxiosResponse<DifficultyLevel>>} A promise of an object of type @see DifficultyLevel
  */
  async difficultyLevel(id: number): Promise<AxiosResponse<DifficultyLevel>> {
      try {
        return api.get(this.restPath + + '/' + id + '/difficultyLevel', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // difficultyLevel


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see Puzzles.
  * @param {string} operation: The operation name to execute.
  * @param {Puzzle[]} selected: The collection of @see Puzzle of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: Puzzle[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [get]: 
  * Retrives a @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve.
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
  * Retrives all the available @see Puzzle.
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
  * Retrives all the available @see Puzzles.
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
  * Retrives all the available @see Puzzles.
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
  * Retrives the count of @see Puzzles.
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
  * Gets an array of primary key values from the @see Puzzles collection passed.
  * @param {Puzzle[]} entities: The collection of @see Puzzle of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: Puzzle[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: Puzzle) {
        ids.push(entity.puzzleId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see Puzzle.
  * @param {Puzzle} data: The @see Puzzle to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: Puzzle): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see Puzzle in a cascading fashion.
  * @param {Puzzle} data: The @see Puzzle to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: Puzzle): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [solution]: 
  * Returns the related @see Solution entity related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the @see Solution.
  * @param {number} childId: The primary key of the @see Solution of which to retrieve related to the @see Solution entities.
  * @returns {Promise<AxiosResponse<Solution>>} A promise of an object of type @see Puzzle
  */
  async solution(id: number, childId: number): Promise<AxiosResponse<Solution>> {
      try {
        return api.get(this.restPath + '/' + id + '/solutions/' + childId, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // solution


  /**
  * Function [solutions]: 
  * Returns all the related @see Solution entities related to the @see Puzzle.
  * @param {number} id: The primary key of the @see Puzzle of which to retrieve the @see Solution entities.
  * @returns {Promise<AxiosResponse<Solution[]>>} A promise of an array of @see Puzzle
  */
  async solutions(id: number): Promise<AxiosResponse<Solution[]>> {
      try {
        return api.get(this.restPath + '/' + id + '/solutions', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // solutions


  /**
  * Function [update]: 
  * Updates the existing @see Puzzle.
  * @param {Puzzle} data: The @see Puzzle to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: Puzzle): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
