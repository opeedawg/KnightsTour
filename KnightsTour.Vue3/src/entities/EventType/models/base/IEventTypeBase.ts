/**
 * File:     IEventTypeBase.ts
 * Location: src\entities\EventType\models\base\
 * Interface to represent the base properties and functions of the @see EventType. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file IEventType.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: IEventTypeBase
* @extends {IBaseEntity}
*
* Interface to define the EventType model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see IEventType.
*
* @implements {constructor} The constructor for the @see IEventTypeBase class
*/
export interface IEventTypeBase extends IBaseEntity {
  // *** Declarations ***
  /** The Event type id field. [dbo.EventType.EventTypeId] */
  eventTypeId: number;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Name field. [dbo.EventType.Name] */
  name: string;
}
