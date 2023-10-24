/**
 * File:     MemberBase.ts
 * Location: src\entities\Member\models\base\
 * The base class for the @see Member entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file Member.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { IMemberBase } from './IMemberBase';
import moment from 'moment';

/** An enumeration of all @see Member property names (includes computed fields). */
export enum MemberPropertyNames {
  /** string(mandatory) */
  code = 'code',
  /** Date(optional) */
  confirmationDate = 'confirmationDate',
  /** Computed: string (optional) */
  confirmationDateFormatted = 'confirmationDateFormatted',
  /** Date(mandatory) */
  createDate = 'createDate',
  /** Computed: string (optional) */
  createDateFormatted = 'createDateFormatted',
  /** string(mandatory) */
  displayName = 'displayName',
  /** string(mandatory) */
  emailAddress = 'emailAddress',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** boolean(mandatory) */
  isAdministrator = 'isAdministrator',
  /** number(PRIMARY KEY mandatory) */
  memberId = 'memberId',
  /** string(mandatory) */
  password = 'password',
  /** string(mandatory) */
  userInitials = 'userInitials',
}

/**
* Abstract Class: MemberBase
* @implements {IMemberBase}
*
* Base class to define the @see Member model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see Member.
*
* @implements {constructor} The constructor for the @see MemberBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class MemberBase implements IMemberBase {
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
  * The constructor for the @see MemberBase class
  * @param {MemberBase} initialMember?: An optional initial object to seed this class.
  */
  constructor(initialMember?: MemberBase) {
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
      this.confirmationDateFormatted = moment(this.confirmationDate).format('YYYY-MM-DD');
      this.createDate = new Date();
      this.createDateFormatted = moment(this.createDate).format('YYYY-MM-DD');
      this.displayName = '';
      this.emailAddress = '';
      this.entityType = 'MemberBase';
      this.instanceLabel = '';
      this.isAdministrator = false;
      this.memberId = 0;
      this.password = '';
      this.userInitials = '';
    }
  } // constructor


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see MemberPropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see MemberPropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
