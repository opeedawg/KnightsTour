/**
 * File:     EventHistory.ts
 * Location: src\entities\EventHistory\models\base\
 * The base class for the @see EventHistory entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

// Imports
import moment from 'moment';
import { EventType } from './EventType';
import { Member } from './Member';

/**
 * Class: EventHistory
 *
 * Base class to define the @see EventHistory model.
 *
 * @implements {constructor} The constructor for the @see EventHistory class
 * @implements {get} Retrieves a value off the entity based on the property name (as a string).
 * @implements {set} Sets a value on the entity based on the property name (as a string).
 */
export class EventHistory {
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
   * The constructor for the @see EventHistory class
   * @param {EventHistory} initialEventHistory?: An optional initial object to seed this class.
   */
  constructor(initialEventHistory?: EventHistory) {
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
      this.entityType = 'EventHistory';
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
}
