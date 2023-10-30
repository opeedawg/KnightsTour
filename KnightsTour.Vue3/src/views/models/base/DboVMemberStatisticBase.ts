/**
 * File:     DboVMemberStatisticBase.ts
 * Location: src\views\models\base\
 * The class that represents the view model for DB view dbo.V_MemberStatistics.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import moment from 'moment';

/**
* Abstract Class: DboVMemberStatisticBase
*
* Base class to define the @see DboVMemberStatisticBase model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DboVMemberStatisticBase.
*
* @implements {constructor} The constructor for the @see DboVMemberStatisticBase class
*/
export abstract class DboVMemberStatisticBase {
  // *** Declarations ***
  /** The dbo.V_MemberStatistics AverageBeginnerTime field. */
  averageBeginnerTime: number;
  /** The dbo.V_MemberStatistics AverageChallengingTime field. */
  averageChallengingTime: number;
  /** The dbo.V_MemberStatistics AverageEasyTime field. */
  averageEasyTime: number;
  /** The dbo.V_MemberStatistics AverageHardTime field. */
  averageHardTime: number;
  /** The dbo.V_MemberStatistics AverageMediumTime field. */
  averageMediumTime: number;
  /** The dbo.V_MemberStatistics CreateDate field. */
  createDate: Date;
  /** The dbo.V_MemberStatistics FastestBeginnerTime field. */
  fastestBeginnerTime: number;
  /** The dbo.V_MemberStatistics FastestChallengingTime field. */
  fastestChallengingTime: number;
  /** The dbo.V_MemberStatistics FastestEasyTime field. */
  fastestEasyTime: number;
  /** The dbo.V_MemberStatistics FastestHardTime field. */
  fastestHardTime: number;
  /** The dbo.V_MemberStatistics FastestMediumTime field. */
  fastestMediumTime: number;
  /** The dbo.V_MemberStatistics LongestBeginnerTime field. */
  longestBeginnerTime: number;
  /** The dbo.V_MemberStatistics LongestChallengingTime field. */
  longestChallengingTime: number;
  /** The dbo.V_MemberStatistics LongestEasyTime field. */
  longestEasyTime: number;
  /** The dbo.V_MemberStatistics LongestHardTime field. */
  longestHardTime: number;
  /** The dbo.V_MemberStatistics LongestMediumTime field. */
  longestMediumTime: number;
  /** The dbo.V_MemberStatistics MemberId field. */
  memberId: number;
  /** The dbo.V_MemberStatistics TotalAttempted field. */
  totalAttempted: number;
  /** The dbo.V_MemberStatistics TotalBeginnerAttempted field. */
  totalBeginnerAttempted: number;
  /** The dbo.V_MemberStatistics TotalBeginnerCompleted field. */
  totalBeginnerCompleted: number;
  /** The dbo.V_MemberStatistics TotalChallengingAttempted field. */
  totalChallengingAttempted: number;
  /** The dbo.V_MemberStatistics TotalChallengingCompleted field. */
  totalChallengingCompleted: number;
  /** The dbo.V_MemberStatistics TotalCompleted field. */
  totalCompleted: number;
  /** The dbo.V_MemberStatistics TotalDailyAttempted field. */
  totalDailyAttempted: number;
  /** The dbo.V_MemberStatistics TotalDailyCompleted field. */
  totalDailyCompleted: number;
  /** The dbo.V_MemberStatistics TotalEasyAttempted field. */
  totalEasyAttempted: number;
  /** The dbo.V_MemberStatistics TotalEasyCompleted field. */
  totalEasyCompleted: number;
  /** The dbo.V_MemberStatistics TotalHardAttempted field. */
  totalHardAttempted: number;
  /** The dbo.V_MemberStatistics TotalHardCompleted field. */
  totalHardCompleted: number;
  /** The dbo.V_MemberStatistics TotalLogins field. */
  totalLogins: number;
  /** The dbo.V_MemberStatistics TotalMediumAttempted field. */
  totalMediumAttempted: number;
  /** The dbo.V_MemberStatistics TotalMediumCompleted field. */
  totalMediumCompleted: number;
  /** The dbo.V_MemberStatistics UserInitials field. */
  userInitials: string;

  /**
  * Function [constructor]: 
  * The constructor for the @see DboVMemberStatisticBase class
  */
  constructor() {
      this.averageBeginnerTime = 0;
      this.averageChallengingTime = 0;
      this.averageEasyTime = 0;
      this.averageHardTime = 0;
      this.averageMediumTime = 0;
      this.createDate = new Date();
      this.fastestBeginnerTime = 0;
      this.fastestChallengingTime = 0;
      this.fastestEasyTime = 0;
      this.fastestHardTime = 0;
      this.fastestMediumTime = 0;
      this.longestBeginnerTime = 0;
      this.longestChallengingTime = 0;
      this.longestEasyTime = 0;
      this.longestHardTime = 0;
      this.longestMediumTime = 0;
      this.memberId = 0;
      this.totalAttempted = 0;
      this.totalBeginnerAttempted = 0;
      this.totalBeginnerCompleted = 0;
      this.totalChallengingAttempted = 0;
      this.totalChallengingCompleted = 0;
      this.totalCompleted = 0;
      this.totalDailyAttempted = 0;
      this.totalDailyCompleted = 0;
      this.totalEasyAttempted = 0;
      this.totalEasyCompleted = 0;
      this.totalHardAttempted = 0;
      this.totalHardCompleted = 0;
      this.totalLogins = 0;
      this.totalMediumAttempted = 0;
      this.totalMediumCompleted = 0;
      this.userInitials = '';
  } // constructor

}
