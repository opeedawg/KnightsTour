/**
 * File:     EventHistoryBase.service.ts
 * Location: src\entities\EventHistory\services\
 * Service to access all model (common) Event history api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventHistory.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { EventHistory } from '../models/EventHistory';
import { EventType } from 'src/entities/EventType/models/EventType';
import { Member } from 'src/entities/Member/models/Member';

/**
* Class: EventHistoryBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see EventHistoryService.
*
* @implements {constructor} The constructor for the @see EventHistoryBaseService class
* @implements {delete} Deletes a @see EventHistory.
* @implements {deleteCascade} Deletes the @see EventHistory in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see EventHistories.
* @implements {eventType} Returns the related @see EventType entity related to the @see EventHistory.
* @implements {get} Retrives a @see EventHistory.
* @implements {getAll} Retrives all the available @see EventHistory.
* @implements {getAllFiltered} Retrives all the available @see EventHistories.
* @implements {getByIds} Retrives all the available @see EventHistories.
* @implements {getCount} Retrives the count of @see EventHistories.
* @implements {getIds} Gets an array of primary key values from the @see EventHistories collection passed.
* @implements {insert} Inserts the new @see EventHistory.
* @implements {insertCascade} Inserts the new @see EventHistory in a cascading fashion.
* @implements {member} Returns the related @see Member entity related to the @see EventHistory.
* @implements {update} Updates the existing @see EventHistory.
*/
export class EventHistoryBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see EventHistoryBaseService class
  */
  constructor() {
      super('eventhistories');
  } // constructor


  /**
  * Function [delete]: 
  * Deletes a @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory of which to delete.
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
  * Deletes the @see EventHistory in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see EventHistory of which to delete.
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
  * Performs the custom operation on one or many @see EventHistories.
  * @param {string} operation: The operation name to execute.
  * @param {EventHistory[]} selected: The collection of @see EventHistory of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: EventHistory[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [eventType]: 
  * Returns the related @see EventType entity related to the @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory of which to retrieve the related @see EventType.
  * @returns {Promise<AxiosResponse<EventType>>} A promise of an object of type @see EventType
  */
  async eventType(id: number): Promise<AxiosResponse<EventType>> {
      try {
        return api.get(this.restPath + + '/' + id + '/eventType', this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // eventType


  /**
  * Function [get]: 
  * Retrives a @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory of which to retrieve.
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
  * Retrives all the available @see EventHistory.
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
  * Retrives all the available @see EventHistories.
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
  * Retrives all the available @see EventHistories.
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
  * Retrives the count of @see EventHistories.
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
  * Gets an array of primary key values from the @see EventHistories collection passed.
  * @param {EventHistory[]} entities: The collection of @see EventHistory of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: EventHistory[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: EventHistory) {
        ids.push(entity.eventHistoryId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see EventHistory.
  * @param {EventHistory} data: The @see EventHistory to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: EventHistory): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see EventHistory in a cascading fashion.
  * @param {EventHistory} data: The @see EventHistory to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: EventHistory): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [member]: 
  * Returns the related @see Member entity related to the @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory of which to retrieve the related @see Member.
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
  * Function [update]: 
  * Updates the existing @see EventHistory.
  * @param {EventHistory} data: The @see EventHistory to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: EventHistory): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
