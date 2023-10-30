/**
 * File:     IDifficultyLevelBase.ts
 * Location: src\entities\DifficultyLevel\models\base\
 * Interface to represent the base properties and functions of the @see DifficultyLevel. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file IDifficultyLevel.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { IBaseEntity } from 'src/common/models/interfaces';

/**
* Interface: IDifficultyLevelBase
* @extends {IBaseEntity}
*
* Interface to define the DifficultyLevel model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see IDifficultyLevel.
*
* @implements {constructor} The constructor for the @see IDifficultyLevelBase class
*/
export interface IDifficultyLevelBase extends IBaseEntity {
  // *** Declarations ***
  /** The Bad link enabled field. [dbo.DifficultyLevel.BadLinkEnabled] */
  badLinkEnabled: boolean;
  /** The Description field. [dbo.DifficultyLevel.Description] */
  description: string;
  /** The Difficulty level id field. [dbo.DifficultyLevel.DifficultyLevelId] */
  difficultyLevelId: number;
  /** The Duplicate checking enabled field. [dbo.DifficultyLevel.DuplicateCheckingEnabled] */
  duplicateCheckingEnabled: boolean;
  /** The Guess filter enabled field. [dbo.DifficultyLevel.GuessFilterEnabled] */
  guessFilterEnabled: boolean;
  /** The Highlight closest enabled field. [dbo.DifficultyLevel.HighlightClosestEnabled] */
  highlightClosestEnabled: boolean;
  /** The instance label. [Computed] */
  instanceLabel: string;
  /** The Maximum dimension field. [dbo.DifficultyLevel.MaximumDimension] */
  maximumDimension: number;
  /** The Maximum gap field. [dbo.DifficultyLevel.MaximumGap] */
  maximumGap: number;
  /** The Minimum dimension field. [dbo.DifficultyLevel.MinimumDimension] */
  minimumDimension: number;
  /** The Name field. [dbo.DifficultyLevel.Name] */
  name: string;
  /** The Percent visibility field. [dbo.DifficultyLevel.PercentVisibility] */
  percentVisibility: number;
}
