/**
 * File:     EventHistoryBase.store.ts
 * Location: src\entities\EventHistory\stores\
 * The base store to implement any common Event history api calls.  It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventHistory.store.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:15 AM
 */

// Imports
import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
import { EventHistory } from '../models/EventHistory';
import { EventHistoryService } from '../services/EventHistory.service';
import { EventType } from 'src/entities/EventType/models/EventType';
import { EventTypeStore } from 'src/entities/EventType/stores/EventType.store';
import { Member } from 'src/entities/Member/models/Member';
import { MemberStore } from 'src/entities/Member/stores/Member.store';

/**
* Class: EventHistoryBaseStore
*
* Class to implement any common decoration on data returned from the base api service endpoints. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see EventHistoryStore.
*
* @implements {constructor} The constructor for the @see EventHistoryBaseStore class
* @implements {delete} Deletes the @see EventHistory.
* @implements {deleteCascade} Deletes the @see EventHistory in a cascading fashion (including all its related child objects).
* @implements {doCustomOperation} Performs the custom operation on one or many @see EventHistories.
* @implements {eventType} Returns the related @see EventType entity related to the @see EventHistory.
* @implements {get} Gets an object of type @see EventHistory by its primary key.
* @implements {getAll} Gets all of the @see EventHistory.
* @implements {getAllFiltered} Gets all the @see EventHistory with the filter applied.
* @implements {getByIds} Gets all of the @see EventHistory given the set of primary keys.
* @implements {getCount} Gets the total number of the @see EventHistory given the filter.
* @implements {hydrateEventTypeByEventTypeId} Hydrates the eventTypeByEventTypeId property with the complete @see EventType object.
* @implements {hydrateMemberByMemberId} Hydrates the memberByMemberId property with the complete @see Member object.
* @implements {insert} Inserts the @see EventHistory.
* @implements {insertCascade} Inserts the @see EventHistory in a cascading fashion.
* @implements {member} Returns the related @see Member entity related to the @see EventHistory.
* @implements {update} Updates the @see EventHistory.
*/
export class EventHistoryBaseStore {
  // *** Declarations ***
  /** A reference to the related service. */
  service: EventHistoryService;

  /**
  * Function [constructor]: 
  * The constructor for the @see EventHistoryBaseStore class
  */
  constructor() {
    this.service = new EventHistoryService();
  } // constructor


  /**
  * Function [delete]: 
  * Deletes the @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async delete(id: number): Promise<DXResponse> {
      const result = await this.service.delete(id);
      return result.data;
  } // delete


  /**
  * Function [deleteCascade]: 
  * Deletes the @see EventHistory in a cascading fashion (including all its related child objects).
  * @param {number} id: The primary key of the @see EventHistory for which to delete.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async deleteCascade(id: number): Promise<DXResponse> {
      const result = await this.service.deleteCascade(id);
      return result.data;
  } // deleteCascade


  /**
  * Function [doCustomOperation]: 
  * Performs the custom operation on one or many @see EventHistories.
  * @param {string} operation: The operation name to execute.
  * @param {EventHistory[]} selected: The collection of @see EventHistory of which to operate on.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async doCustomOperation(operation: string, selected: EventHistory[]): Promise<DXResponse> {
      const result = await this.service.doCustomOperation(operation, selected);
      return result.data;
  } // doCustomOperation


  /**
  * Function [eventType]: 
  * Returns the related @see EventType entity related to the @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory of which to retrieve the related @see EventType.
  * @returns {Promise<EventType>} The promise of an object of type @see EventType.
  */
  async eventType(id: number): Promise<EventType> {
      const result = await this.service.eventType(id);
      return result.data;
  } // eventType


  /**
  * Function [get]: 
  * Gets an object of type @see EventHistory by its primary key.
  * @param {number} id: The primary key of the @see EventHistory
  * @param {(element: EventHistory) => void} formatterFunction?: An optional formatter function.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async get(id: number, formatterFunction?: (element: EventHistory) => void): Promise<DXResponse> {
      const result = await this.service.get(id);

      if (formatterFunction) {
        formatterFunction(result.data.dataObject);
      }

      return result.data;
  } // get


  /**
  * Function [getAll]: 
  * Gets all of the @see EventHistory.
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
  * Gets all the @see EventHistory with the filter applied.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see EventHistory collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getAllFiltered(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getAllFiltered(filter);
      return result.data;
  } // getAllFiltered


  /**
  * Function [getByIds]: 
  * Gets all of the @see EventHistory given the set of primary keys.
  * @param {string[]} ids: An array of primary key ids to return.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getByIds(ids: string[]): Promise<DXResponse> {
      const result = await this.service.getByIds(ids);
      return result.data;
  } // getByIds


  /**
  * Function [getCount]: 
  * Gets the total number of the @see EventHistory given the filter.
  * @param {DXEntityFilter} filter: The filter to applly to the retrieval of the @see EventHistory collection.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async getCount(filter: DXEntityFilter): Promise<DXResponse> {
      const result = await this.service.getCount(filter);
      return result.data;
  } // getCount


  /**
  * Function [hydrateEventTypeByEventTypeId]: 
  * Hydrates the eventTypeByEventTypeId property with the complete @see EventType object.
  * @param {EventHistory[]} entities: The @see EventHistory collection to retrieve hydrate (by reference).
  * @returns {Promise<EventHistory[] | undefined>} The promise of an object of type @see EventHistory[] | undefined.
  */
  async hydrateEventTypeByEventTypeId(entities: EventHistory[]): Promise<EventHistory[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: EventHistory) => {
      if (value.eventTypeId && ids.indexOf(value.eventTypeId.toString()) < 0) {
        ids.push(value.eventTypeId.toString());
      }
    });

    // Now create a reference to the EventType store to grab the minimal set of objects for hydration.
    const eventTypeStore = new EventTypeStore();
    if (ids.length > 0) {
      const result = await eventTypeStore
        .getByIds(ids)
        .then((response) => {
          if (response.isValid && response.dataObject.length > 0) {
            entities.forEach((value: EventHistory) => {
              if (value.eventTypeId) {
                const foundFK = response.dataObject.find(
                  (x: EventType) => x.eventTypeId == value.eventTypeId
                );
                if (foundFK != null) {
                  value.eventTypeByEventTypeId = foundFK;
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
  } // hydrateEventTypeByEventTypeId


  /**
  * Function [hydrateMemberByMemberId]: 
  * Hydrates the memberByMemberId property with the complete @see Member object.
  * @param {EventHistory[]} entities: The @see EventHistory collection to retrieve hydrate (by reference).
  * @returns {Promise<EventHistory[] | undefined>} The promise of an object of type @see EventHistory[] | undefined.
  */
  async hydrateMemberByMemberId(entities: EventHistory[]): Promise<EventHistory[] | undefined> {
    // First collect a minimal and cleansed set of ids that need to be hydrated.
    const ids: string[] = [] as string[];
    entities.forEach((value: EventHistory) => {
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
            entities.forEach((value: EventHistory) => {
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
  * Function [insert]: 
  * Inserts the @see EventHistory.
  * @param {EventHistory} data: The @see EventHistory to insert.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insert(data: EventHistory): Promise<DXResponse> {
      const result = await this.service.insert(data);
      return result.data;
  } // insert


  /**
  * Function [insertCascade]: 
  * Inserts the @see EventHistory in a cascading fashion.
  * @param {EventHistory} data: The @see EventHistory to insert with child objects (optional).
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async insertCascade(data: EventHistory): Promise<DXResponse> {
      const result = await this.service.insertCascade(data);
      return result.data;
  } // insertCascade


  /**
  * Function [member]: 
  * Returns the related @see Member entity related to the @see EventHistory.
  * @param {number} id: The primary key of the @see EventHistory of which to retrieve the related @see Member.
  * @returns {Promise<Member>} The promise of an object of type @see Member.
  */
  async member(id: number): Promise<Member> {
      const result = await this.service.member(id);
      return result.data;
  } // member


  /**
  * Function [update]: 
  * Updates the @see EventHistory.
  * @param {EventHistory} data: The @see EventHistory to update.
  * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
  */
  async update(data: EventHistory): Promise<DXResponse> {
      const result = await this.service.update(data);
      return result.data;
  } // update

}
