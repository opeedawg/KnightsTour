/**
 * File:     SolutionBase.service.ts
 * Location: src\entities\Solution\services\
 * Service to access all model (common) Solution api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Solution.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { Member } from 'src/entities/Member/models/Member';
import { Puzzle } from 'src/entities/Puzzle/models/Puzzle';
import { Solution } from '../models/Solution';

/**
* Class: SolutionBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see SolutionService.
*
* @implements {constructor} The constructor for the @see SolutionBaseService class
* @implements {delete} Deletes a @see Solution.
* @implements {deleteCascade} Deletes the @see Solution in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see Solutions.
* @implements {get} Retrives a @see Solution.
* @implements {getAll} Retrives all the available @see Solution.
* @implements {getAllFiltered} Retrives all the available @see Solutions.
* @implements {getByIds} Retrives all the available @see Solutions.
* @implements {getCount} Retrives the count of @see Solutions.
* @implements {getIds} Gets an array of primary key values from the @see Solutions collection passed.
* @implements {insert} Inserts the new @see Solution.
* @implements {insertCascade} Inserts the new @see Solution in a cascading fashion.
* @implements {member} Returns the related @see Member entity related to the @see Solution.
* @implements {puzzle} Returns the related @see Puzzle entity related to the @see Solution.
* @implements {update} Updates the existing @see Solution.
*/
export class SolutionBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see SolutionBaseService class
  */
  constructor() {
      super('solutions');
  } // constructor


  /**
  * Function [delete]: 
  * Deletes a @see Solution.
  * @param {number} id: The primary key of the @see Solution of which to delete.
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
  * Deletes the @see Solution in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Solution of which to delete.
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
  * Performs the custom operation on one or many @see Solutions.
  * @param {string} operation: The operation name to execute.
  * @param {Solution[]} selected: The collection of @see Solution of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: Solution[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [get]: 
  * Retrives a @see Solution.
  * @param {number} id: The primary key of the @see Solution of which to retrieve.
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
  * Retrives all the available @see Solution.
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
  * Retrives all the available @see Solutions.
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
  * Retrives all the available @see Solutions.
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
  * Retrives the count of @see Solutions.
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
  * Gets an array of primary key values from the @see Solutions collection passed.
  * @param {Solution[]} entities: The collection of @see Solution of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: Solution[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: Solution) {
        ids.push(entity.solutionId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see Solution.
  * @param {Solution} data: The @see Solution to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: Solution): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see Solution in a cascading fashion.
  * @param {Solution} data: The @see Solution to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: Solution): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [member]: 
  * Returns the related @see Member entity related to the @see Solution.
  * @param {number} id: The primary key of the @see Solution of which to retrieve the related @see Member.
  * @returns {Promise<AxiosResponse<Member>>} A promise of an object of type @see Member
  */
  async member(id: number): Promise<AxiosResponse<Member>> {
      try {
        return api.get(this.restPath + + '/' + id + '/member', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // member


  /**
  * Function [puzzle]: 
  * Returns the related @see Puzzle entity related to the @see Solution.
  * @param {number} id: The primary key of the @see Solution of which to retrieve the related @see Puzzle.
  * @returns {Promise<AxiosResponse<Puzzle>>} A promise of an object of type @see Puzzle
  */
  async puzzle(id: number): Promise<AxiosResponse<Puzzle>> {
      try {
        return api.get(this.restPath + + '/' + id + '/puzzle', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // puzzle


  /**
  * Function [update]: 
  * Updates the existing @see Solution.
  * @param {Solution} data: The @see Solution to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: Solution): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
