/**
 * File:     Member.ts
 * Location: src\entities\Member\models\
 * The extended class for the @see Member entity.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { 
  MemberBase,
  MemberPropertyNames,
} from './base/MemberBase';

/**
* Class: Member
* @extends {MemberBase}
*
* Class to define the Member model.  Add any extended properties or functions here.
*
* @implements {clone} Creates a clone of the current Member
* @implements {constructor} The constructor for the @see Member class
*/
export class Member extends MemberBase {

  /**
  * Function [constructor]: 
  * The constructor for the @see Member class
  */
  constructor() {
      super();
  } // constructor


  /**
  * Function [clone]: 
  * Creates a clone of the current Member
  * @returns {Member} A new clone of @see Member
  */
  clone(): Member {
    const clonedEntity = new Member();
    const self = this;
    Object.values(MemberPropertyNames).forEach(function (val: string) {
      clonedEntity.set(val, self.get(val));
    });

    return clonedEntity;
  } // clone

}
