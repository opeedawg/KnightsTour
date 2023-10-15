/**
 * File:     EventType.ts
 * Location: src\entities\EventType\models\
 * The extended class for the @see EventType entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  EventTypeBase,
  EventTypePropertyNames,
} from './base/EventTypeBase';

/**
* Class: EventType
* @extends {EventTypeBase}
*
* Class to define the EventType model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Event type
* @implements {constructor} The constructor for the @see EventType class
*/
export class EventType extends EventTypeBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see EventType class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Event type
  * @returns {EventType} A new clone of @see EventType
  */
  clone(): EventType {
    const clonedEntity = new EventType();
    const self = this;
    Object.values(EventTypePropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
