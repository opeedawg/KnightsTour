/**
 * File:     DifficultyLevelBase.service.ts
 * Location: src\entities\DifficultyLevel\services\
 * Service to access all model (common) Difficulty level api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file DifficultyLevel.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { DifficultyLevel } from '../models/DifficultyLevel';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';

/**
* Class: DifficultyLevelBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DifficultyLevelService.
*
* @implements {constructor} The constructor for the @see DifficultyLevelBaseService class
* @implements {delete} Deletes a @see DifficultyLevel.
* @implements {deleteCascade} Deletes the @see DifficultyLevel in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see DifficultyLevels.
* @implements {get} Retrives a @see DifficultyLevel.
* @implements {getAll} Retrives all the available @see DifficultyLevel.
* @implements {getAllFiltered} Retrives all the available @see DifficultyLevels.
* @implements {getByIds} Retrives all the available @see DifficultyLevels.
* @implements {getCount} Retrives the count of @see DifficultyLevels.
* @implements {getIds} Gets an array of primary key values from the @see DifficultyLevels collection passed.
* @implements {insert} Inserts the new @see DifficultyLevel.
* @implements {insertCascade} Inserts the new @see DifficultyLevel in a cascading fashion.
* @implements {puzzle} Returns the related @see Puzzle entity related to the @see DifficultyLevel.
* @implements {puzzles} Returns all the related @see Puzzle entities related to the @see DifficultyLevel.
* @implements {update} Updates the existing @see DifficultyLevel.
*/
export class DifficultyLevelBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see DifficultyLevelBaseService class
  */
  constructor() {
      super('difficultylevels');
  } // constructor


  /**
  * Function [delete]: 
  * Deletes a @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel of which to delete.
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
  * Deletes the @see DifficultyLevel in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see DifficultyLevel of which to delete.
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
  * Performs the custom operation on one or many @see DifficultyLevels.
  * @param {string} operation: The operation name to execute.
  * @param {DifficultyLevel[]} selected: The collection of @see DifficultyLevel of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: DifficultyLevel[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [get]: 
  * Retrives a @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel of which to retrieve.
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
  * Retrives all the available @see DifficultyLevel.
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
  * Retrives all the available @see DifficultyLevels.
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
  * Retrives all the available @see DifficultyLevels.
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
  * Retrives the count of @see DifficultyLevels.
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
  * Gets an array of primary key values from the @see DifficultyLevels collection passed.
  * @param {DifficultyLevel[]} entities: The collection of @see DifficultyLevel of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: DifficultyLevel[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: DifficultyLevel) {
        ids.push(entity.difficultyLevelId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see DifficultyLevel.
  * @param {DifficultyLevel} data: The @see DifficultyLevel to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: DifficultyLevel): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see DifficultyLevel in a cascading fashion.
  * @param {DifficultyLevel} data: The @see DifficultyLevel to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: DifficultyLevel): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [puzzle]: 
  * Returns the related @see Puzzle entity related to the @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel of which to retrieve the @see Puzzle.
  * @param {number} childId: The primary key of the @see Puzzle of which to retrieve related to the @see Puzzle entities.
  * @returns {Promise<AxiosResponse<Puzzle>>} A promise of an object of type @see DifficultyLevel
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
  * Returns all the related @see Puzzle entities related to the @see DifficultyLevel.
  * @param {number} id: The primary key of the @see DifficultyLevel of which to retrieve the @see Puzzle entities.
  * @returns {Promise<AxiosResponse<Puzzle[]>>} A promise of an array of @see DifficultyLevel
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
  * Updates the existing @see DifficultyLevel.
  * @param {DifficultyLevel} data: The @see DifficultyLevel to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: DifficultyLevel): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
