/**
 * File:     Member.ts
 * Location: src\entities\Member\models\base\
 * The base class for the @see Member entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

// Imports
import moment from 'moment';

/**
 * Class: Member
 * @implements {IMember}
 *
 * Base class to define the @see Member model.
 *
 * @implements {constructor} The constructor for the @see Member class
 */
export class Member {
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
  /** The entity type. [Computed] */
  entityType: string;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Is administrator field. [dbo.Member.IsAdministrator] */
  isAdministrator: boolean;
  /** The Member id field PRIMARY KEY. [dbo.Member.MemberId] */
  memberId: number;
  /** The Password field. [dbo.Member.Password] */
  password: string;
  /** The User initials field. [dbo.Member.UserInitials] */
  userInitials: string;

  /**
   * Function [constructor]:
   * The constructor for the @see Member class
   * @param {Member} initialMember?: An optional initial object to seed this class.
   */
  constructor(initialMember?: Member) {
    if (initialMember) {
      this.code = initialMember.code;
      this.confirmationDate = initialMember.confirmationDate;
      this.confirmationDateFormatted = initialMember.confirmationDateFormatted;
      this.createDate = initialMember.createDate;
      this.createDateFormatted = initialMember.createDateFormatted;
      this.displayName = initialMember.displayName;
      this.emailAddress = initialMember.emailAddress;
      this.entityType = initialMember.entityType;
      this.instanceLabel = initialMember.instanceLabel;
      this.isAdministrator = initialMember.isAdministrator;
      this.memberId = initialMember.memberId;
      this.password = initialMember.password;
      this.userInitials = initialMember.userInitials;
    } else {
      this.code = '';
      this.confirmationDate = new Date();
      this.confirmationDateFormatted = moment(this.confirmationDate).format(
        'YYYY-MM-DD'
      );
      this.createDate = new Date();
      this.createDateFormatted = moment(this.createDate).format('YYYY-MM-DD');
      this.displayName = '';
      this.emailAddress = '';
      this.entityType = 'Member';
      this.instanceLabel = '';
      this.isAdministrator = false;
      this.memberId = 0;
      this.password = '';
      this.userInitials = '';
    }
  } // constructor
}
