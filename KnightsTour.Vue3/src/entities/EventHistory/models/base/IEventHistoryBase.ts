/**
 * File:     IEventHistoryBase.ts
 * Location: src\entities\EventHistory\models\base\
 * Interface to represent the base properties and functions of the @see EventHistory. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file IEventHistory.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: IEventHistoryBase
* @extends {IBaseEntity}
*
* Interface to define the EventHistory model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see IEventHistory.
*
* @implements {constructor} The constructor for the @see IEventHistoryBase class
*/
export interface IEventHistoryBase extends IBaseEntity {
  // *** Declarations ***
  /** The City field. [dbo.EventHistory.City] */
  city: string;
  /** The Context field. [dbo.EventHistory.Context] */
  context: string;
  /** The Country field. [dbo.EventHistory.Country] */
  country: string;
  /** The Event date field. [dbo.EventHistory.EventDate] */
  eventDate: Date;
  /** The Event date date formatted as per configuration for display. [Computed] */
  eventDateFormatted: string;
  /** The Event history id field. [dbo.EventHistory.EventHistoryId] */
  eventHistoryId: number;
  /** The Event type id field. [dbo.EventHistory.EventTypeId] */
  eventTypeId: number;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Member id field. [dbo.EventHistory.MemberId] */
  memberId: number;
  /** The Region field. [dbo.EventHistory.Region] */
  region: string;
  /** The Source internet address field. [dbo.EventHistory.SourceInternetAddress] */
  sourceInternetAddress: string;
  /** The Zip postal field. [dbo.EventHistory.ZipPostal] */
  zipPostal: string;
}
