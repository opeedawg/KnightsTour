/**
 * File:     EventHistory.ts
 * Location: src\entities\EventHistory\models\
 * The extended class for the @see EventHistory entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  EventHistoryBase,
  EventHistoryPropertyNames,
} from './base/EventHistoryBase';

/**
* Class: EventHistory
* @extends {EventHistoryBase}
*
* Class to define the EventHistory model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Event history
* @implements {constructor} The constructor for the @see EventHistory class
*/
export class EventHistory extends EventHistoryBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see EventHistory class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Event history
  * @returns {EventHistory} A new clone of @see EventHistory
  */
  clone(): EventHistory {
    const clonedEntity = new EventHistory();
    const self = this;
    Object.values(EventHistoryPropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
