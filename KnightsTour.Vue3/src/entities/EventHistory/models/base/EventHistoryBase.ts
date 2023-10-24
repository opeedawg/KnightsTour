/**
 * File:     EventHistoryBase.ts
 * Location: src\entities\EventHistory\models\base\
 * The base class for the @see EventHistory entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventHistory.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { EventType } from 'src/entities/EventType/models/EventType';
import { IEventHistoryBase } from './IEventHistoryBase';
import { Member } from 'src/entities/Member/models/Member';
import moment from 'moment';

/** An enumeration of all @see EventHistory property names (includes computed fields). */
export enum EventHistoryPropertyNames {
  /** string(optional) */
  city = 'city',
  /** string(mandatory) */
  context = 'context',
  /** string(optional) */
  country = 'country',
  /** Date(mandatory) */
  eventDate = 'eventDate',
  /** Computed: string (optional) */
  eventDateFormatted = 'eventDateFormatted',
  /** number(PRIMARY KEY mandatory) */
  eventHistoryId = 'eventHistoryId',
  /** number(mandatory) */
  eventTypeId = 'eventTypeId',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** number(optional) */
  memberId = 'memberId',
  /** string(optional) */
  region = 'region',
  /** string(mandatory) */
  sourceInternetAddress = 'sourceInternetAddress',
  /** string(optional) */
  zipPostal = 'zipPostal',
}

/**
* Abstract Class: EventHistoryBase
* @implements {IEventHistoryBase}
*
* Base class to define the @see EventHistory model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see EventHistory.
*
* @implements {constructor} The constructor for the @see EventHistoryBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class EventHistoryBase implements IEventHistoryBase {
  // *** Declarations ***
  /** The City field. [dbo.EventHistory.City] */
  city: string;
  /** The Context field. [dbo.EventHistory.Context] */
  context: string;
  /** The Country field. [dbo.EventHistory.Country] */
  country: string;
  /** The entity type. [Computed] */
  entityType: string;
  /** The Event date field. [dbo.EventHistory.EventDate] */
  eventDate: Date;
  /** The Event date date formatted as per configuration for display. [Computed] */
  eventDateFormatted: string;
  /** The Event history id field PRIMARY KEY. [dbo.EventHistory.EventHistoryId] */
  eventHistoryId: number;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  eventTypeByEventTypeId: EventType | null;
  /** The Event type id field. [dbo.EventHistory.EventTypeId] */
  eventTypeId: number;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** A reference to the FK object.  Initially null, it can be efficiently hydrated by authored method in the entity store. */
  memberByMemberId: Member | null;
  /** The Member id field. [dbo.EventHistory.MemberId] */
  memberId: number;
  /** The Region field. [dbo.EventHistory.Region] */
  region: string;
  /** The Source internet address field. [dbo.EventHistory.SourceInternetAddress] */
  sourceInternetAddress: string;
  /** The Zip postal field. [dbo.EventHistory.ZipPostal] */
  zipPostal: string;

  /**
  * Function [constructor]: 
  * The constructor for the @see EventHistoryBase class
  * @param {EventHistoryBase} initialEventHistory?: An optional initial object to seed this class.
  */
  constructor(initialEventHistory?: EventHistoryBase) {
    if (initialEventHistory) {
      this.city = initialEventHistory.city;
      this.context = initialEventHistory.context;
      this.country = initialEventHistory.country;
      this.entityType = initialEventHistory.entityType;
      this.eventDate = initialEventHistory.eventDate;
      this.eventDateFormatted = initialEventHistory.eventDateFormatted;
      this.eventHistoryId = initialEventHistory.eventHistoryId;
      this.eventTypeByEventTypeId = initialEventHistory.eventTypeByEventTypeId;
      this.eventTypeId = initialEventHistory.eventTypeId;
      this.instanceLabel = initialEventHistory.instanceLabel;
      this.memberByMemberId = initialEventHistory.memberByMemberId;
      this.memberId = initialEventHistory.memberId;
      this.region = initialEventHistory.region;
      this.sourceInternetAddress = initialEventHistory.sourceInternetAddress;
      this.zipPostal = initialEventHistory.zipPostal;
    } else {
      this.city = '';
      this.context = '';
      this.country = '';
      this.entityType = 'EventHistoryBase';
      this.eventDate = new Date();
      this.eventDateFormatted = moment(this.eventDate).format('YYYY-MM-DD');
      this.eventHistoryId = 0;
      this.eventTypeByEventTypeId = null;
      this.eventTypeId = 0;
      this.instanceLabel = '';
      this.memberByMemberId = null;
      this.memberId = 0;
      this.region = '';
      this.sourceInternetAddress = '';
      this.zipPostal = '';
    }
  } // constructor


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see EventHistoryPropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see EventHistoryPropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
