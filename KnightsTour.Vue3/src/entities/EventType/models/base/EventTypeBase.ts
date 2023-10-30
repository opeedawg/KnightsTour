/**
 * File:     EventTypeBase.ts
 * Location: src\entities\EventType\models\base\
 * The base class for the @see EventType entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventType.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { IEventTypeBase } from './IEventTypeBase';

/** An enumeration of all @see EventType property names (includes computed fields). */
export enum EventTypePropertyNames {
  /** number(PRIMARY KEY mandatory) */
  eventTypeId = 'eventTypeId',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** string(mandatory) */
  name = 'name',
}

/**
* Abstract Class: EventTypeBase
* @implements {IEventTypeBase}
*
* Base class to define the @see EventType model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see EventType.
*
* @implements {constructor} The constructor for the @see EventTypeBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class EventTypeBase implements IEventTypeBase {
  // *** Declarations ***
  /** The entity type. [Computed] */
  entityType: string;
  /** The Event type id field PRIMARY KEY. [dbo.EventType.EventTypeId] */
  eventTypeId: number;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Name field. [dbo.EventType.Name] */
  name: string;

  /**
  * Function [constructor]: 
  * The constructor for the @see EventTypeBase class
  * @param {EventTypeBase} initialEventType?: An optional initial object to seed this class.
  */
  constructor(initialEventType?: EventTypeBase) {
    if (initialEventType) {
      this.entityType = initialEventType.entityType;
      this.eventTypeId = initialEventType.eventTypeId;
      this.instanceLabel = initialEventType.instanceLabel;
      this.name = initialEventType.name;
    } else {
      this.entityType = 'EventTypeBase';
      this.eventTypeId = 0;
      this.instanceLabel = '';
      this.name = '';
    }
  } // constructor


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see EventTypePropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see EventTypePropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
