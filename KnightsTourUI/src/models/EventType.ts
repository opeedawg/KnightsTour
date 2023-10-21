/**
 * File:     EventType.ts
 * Location: src\models\
 * The base class for the @see EventType entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

// Imports

/**
 * Class: EventType
 *
 * Base class to define the @see EventType model.
 *
 * @implements {constructor} The constructor for the @see EventType class
 */
export class EventType {
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
   * The constructor for the @see EventType class
   * @param {EventType} initialEventType?: An optional initial object to seed this class.
   */
  constructor(initialEventType?: EventType) {
    if (initialEventType) {
      this.entityType = initialEventType.entityType;
      this.eventTypeId = initialEventType.eventTypeId;
      this.instanceLabel = initialEventType.instanceLabel;
      this.name = initialEventType.name;
    } else {
      this.entityType = 'EventType';
      this.eventTypeId = 0;
      this.instanceLabel = '';
      this.name = '';
    }
  } // constructor
}
