/**
 * File:     EventTypeBase.service.ts
 * Location: src\entities\EventType\services\
 * Service to access all model (common) Event type api calls including foreign key and child relationships. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventType.service.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { BaseService } from 'src/common/services/base.service';
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { EventHistory } from 'src/entities/EventHistory/models/EventHistory';
import { EventType } from '../models/EventType';

/**
* Class: EventTypeBaseService
* @extends {BaseService}
*
* Class to implement any custom api calls that go beyond the base api endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see EventTypeService.
*
* @implements {constructor} The constructor for the @see EventTypeBaseService class
* @implements {delete} Deletes a @see EventType.
* @implements {deleteCascade} Deletes the @see EventType in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see EventTypes.
* @implements {eventHistories} Returns all the related @see EventHistory entities related to the @see EventType.
* @implements {eventHistory} Returns the related @see EventHistory entity related to the @see EventType.
* @implements {get} Retrives a @see EventType.
* @implements {getAll} Retrives all the available @see EventType.
* @implements {getAllFiltered} Retrives all the available @see EventTypes.
* @implements {getByIds} Retrives all the available @see EventTypes.
* @implements {getCount} Retrives the count of @see EventTypes.
* @implements {getIds} Gets an array of primary key values from the @see EventTypes collection passed.
* @implements {insert} Inserts the new @see EventType.
* @implements {insertCascade} Inserts the new @see EventType in a cascading fashion.
* @implements {update} Updates the existing @see EventType.
*/
export class EventTypeBaseService extends BaseService {

  /**
  * Function [constructor]: 
  * The constructor for the @see EventTypeBaseService class
  */
  constructor() {
      super('eventtypes');
  } // constructor


  /**
  * Function [delete]: 
  * Deletes a @see EventType.
  * @param {number} id: The primary key of the @see EventType of which to delete.
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
  * Deletes the @see EventType in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see EventType of which to delete.
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
  * Performs the custom operation on one or many @see EventTypes.
  * @param {string} operation: The operation name to execute.
  * @param {EventType[]} selected: The collection of @see EventType of which to operate on.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async doCustomOperation(operation: string, selected: EventType[]): Promise<AxiosResponse<DXResponse>> {
      try {
        return api.get(this.restPath + '/doCustomAction/' + operation + '/' + this.getIds(selected), this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // doCustomOperation


  /**
  * Function [eventHistories]: 
  * Returns all the related @see EventHistory entities related to the @see EventType.
  * @param {number} id: The primary key of the @see EventType of which to retrieve the @see EventHistory entities.
  * @returns {Promise<AxiosResponse<EventHistory[]>>} A promise of an array of @see EventType
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
  * Returns the related @see EventHistory entity related to the @see EventType.
  * @param {number} id: The primary key of the @see EventType of which to retrieve the @see EventHistory.
  * @param {number} childId: The primary key of the @see EventHistory of which to retrieve related to the @see EventHistory entities.
  * @returns {Promise<AxiosResponse<EventHistory>>} A promise of an object of type @see EventType
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
  * Retrives a @see EventType.
  * @param {number} id: The primary key of the @see EventType of which to retrieve.
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
  * Retrives all the available @see EventType.
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
  * Retrives all the available @see EventTypes.
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
  * Retrives all the available @see EventTypes.
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
  * Retrives the count of @see EventTypes.
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
  * Gets an array of primary key values from the @see EventTypes collection passed.
  * @param {EventType[]} entities: The collection of @see EventType of which to gather the primary key values.
  * @returns {string[]} An array of primary keys as string (regardless of the type).
  */
  getIds(entities: EventType[]): string[] {
      const ids: string[] = [];
      entities.forEach(function (entity: EventType) {
        ids.push(entity.eventTypeId.toString());
      });

      return ids;
  } // getIds


  /**
  * Function [insert]: 
  * Inserts the new @see EventType.
  * @param {EventType} data: The @see EventType to insert.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insert(data: EventType): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the new @see EventType in a cascading fashion.
  * @param {EventType} data: The @see EventType to insert, with optionally populated child objects.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async insertCascade(data: EventType): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.post(this.restPath + '/cascade', data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // insertCascade


  /**
  * Function [update]: 
  * Updates the existing @see EventType.
  * @param {EventType} data: The @see EventType to update.
  * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
  */
  async update(data: EventType): Promise<AxiosResponse<DXResponse>> {
      try {
        return await api.put(this.restPath, data, this.config);
      } catch (error) {
        super.ProcessServiceError(error as AxiosError);
        return Promise.reject(error);
      }
  } // update

}
