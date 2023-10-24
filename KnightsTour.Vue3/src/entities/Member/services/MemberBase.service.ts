/**
 * File:     MemberBase.service.ts
 * Location: src\entities\Member\services\
 * Service to access all model (common) Member api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Member.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { EventHistory } from 'src/entities/EventHistory/models/EventHistory';
import { Member } from '../models/Member';
import { Solution } from 'src/entities/Solution/models/Solution';

/**
* Class: MemberBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see MemberService.
*
* @implements {constructor} The constructor for the @see MemberBaseService class
* @implements {delete} Deletes a @see Member.
* @implements {deleteCascade} Deletes the @see Member in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see Members.
* @implements {eventHistories} Returns all the related @see EventHistory entities related to the @see Member.
* @implements {eventHistory} Returns the related @see EventHistory entity related to the @see Member.
* @implements {get} Retrives a @see Member.
* @implements {getAll} Retrives all the available @see Member.
* @implements {getAllFiltered} Retrives all the available @see Members.
* @implements {getByIds} Retrives all the available @see Members.
* @implements {getCount} Retrives the count of @see Members.
* @implements {getIds} Gets an array of primary key values from the @see Members collection passed.
* @implements {insert} Inserts the new @see Member.
* @implements {insertCascade} Inserts the new @see Member in a cascading fashion.
* @implements {solution} Returns the related @see Solution entity related to the @see Member.
* @implements {solutions} Returns all the related @see Solution entities related to the @see Member.
* @implements {update} Updates the existing @see Member.
*/
export class MemberBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see MemberBaseService class
  */
  constructor() {
      super('members');
  } // constructor


  /**
  * Function [delete]: 
  * Deletes a @see Member.
  * @param {number} id: The primary key of the @see Member of which to delete.
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
  * Deletes the @see Member in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see Member of which to delete.
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
  * Performs the custom operation on one or many @see Members.
  * @param {string} operation: The operation name to execute.
  * @param {Member[]} selected: The collection of @see Member of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: Member[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [eventHistories]: 
  * Returns all the related @see EventHistory entities related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the @see EventHistory entities.
  * @returns {Promise<AxiosResponse<EventHistory[]>>} A promise of an array of @see Member
  */
  async eventHistories(id: number): Promise<AxiosResponse<EventHistory[]>> {
      try {
        return api.get(this.restPath + '/' + id + '/eventHistories', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // eventHistories


  /**
  * Function [eventHistory]: 
  * Returns the related @see EventHistory entity related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the @see EventHistory.
  * @param {number} childId: The primary key of the @see EventHistory of which to retrieve related to the @see EventHistory entities.
  * @returns {Promise<AxiosResponse<EventHistory>>} A promise of an object of type @see Member
  */
  async eventHistory(id: number, childId: number): Promise<AxiosResponse<EventHistory>> {
      try {
        return api.get(this.restPath + '/' + id + '/eventHistories/' + childId, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // eventHistory


  /**
  * Function [get]: 
  * Retrives a @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve.
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
  * Retrives all the available @see Member.
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
  * Retrives all the available @see Members.
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
  * Retrives all the available @see Members.
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
  * Retrives the count of @see Members.
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
  * Gets an array of primary key values from the @see Members collection passed.
  * @param {Member[]} entities: The collection of @see Member of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: Member[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: Member) {
        ids.push(entity.memberId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see Member.
  * @param {Member} data: The @see Member to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: Member): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see Member in a cascading fashion.
  * @param {Member} data: The @see Member to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: Member): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [solution]: 
  * Returns the related @see Solution entity related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the @see Solution.
  * @param {number} childId: The primary key of the @see Solution of which to retrieve related to the @see Solution entities.
  * @returns {Promise<AxiosResponse<Solution>>} A promise of an object of type @see Member
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
  * Returns all the related @see Solution entities related to the @see Member.
  * @param {number} id: The primary key of the @see Member of which to retrieve the @see Solution entities.
  * @returns {Promise<AxiosResponse<Solution[]>>} A promise of an array of @see Member
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
  * Updates the existing @see Member.
  * @param {Member} data: The @see Member to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: Member): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
