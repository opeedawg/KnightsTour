/**
 * File:     IMemberBase.ts
 * Location: src\entities\Member\models\base\
 * Interface to represent the base properties and functions of the @see Member. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file IMember.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: IMemberBase
* @extends {IBaseEntity}
*
* Interface to define the Member model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see IMember.
*
* @implements {constructor} The constructor for the @see IMemberBase class
*/
export interface IMemberBase extends IBaseEntity {
  // *** Declarations ***
  /** The Code field. [dbo.Member.Code] */
  code: string;
  /** The Confirmation date field. [dbo.Member.ConfirmationDate] */
  confirmationDate: Date;
  /** The Confirmation date date formatted as per configuration for display. [Computed] */
  confirmationDateFormatted: string;
  /** The Create date field. [dbo.Member.CreateDate] */
  createDate: Date;
  /** The Create date date formatted as per configuration for display. [Computed] */
  createDateFormatted: string;
  /** The Display name field. [dbo.Member.DisplayName] */
  displayName: string;
  /** The Email address field. [dbo.Member.EmailAddress] */
  emailAddress: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Is administrator field. [dbo.Member.IsAdministrator] */
  isAdministrator: boolean;
  /** The Member id field. [dbo.Member.MemberId] */
  memberId: number;
  /** The Password field. [dbo.Member.Password] */
  password: string;
  /** The User initials field. [dbo.Member.UserInitials] */
  userInitials: string;
}
