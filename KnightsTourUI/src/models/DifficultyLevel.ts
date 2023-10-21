/**
 * File:     DifficultyLevel.ts
 * Location: src\models\
 * The base class for the @see DifficultyLevel entity.
 *
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on March 12, 2023 at 10:52:40 AM
 */

/**
 * Class: DifficultyLevel
 *
 * Base class to define the @see DifficultyLevel model.
 *
 * @implements {constructor} The constructor for the @see DifficultyLevel class
 */
export class DifficultyLevel {
  // *** Declarations ***
  /** The Bad link enabled field. [dbo.DifficultyLevel.BadLinkEnabled] */
  badLinkEnabled: boolean;
  /** The Description field. [dbo.DifficultyLevel.Description] */
  description: string;
  /** The Difficulty level id field PRIMARY KEY. [dbo.DifficultyLevel.DifficultyLevelId] */
  difficultyLevelId: number;
  /** The Duplicate checking enabled field. [dbo.DifficultyLevel.DuplicateCheckingEnabled] */
  duplicateCheckingEnabled: boolean;
  /** The entity type. [Computed] */
  entityType: string;
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

  /**
   * Function [constructor]:
   * The constructor for the @see DifficultyLevel class
   * @param {DifficultyLevel} initialDifficultyLevel?: An optional initial object to seed this class.
   */
  constructor(initialDifficultyLevel?: DifficultyLevel) {
    if (initialDifficultyLevel) {
      this.badLinkEnabled = initialDifficultyLevel.badLinkEnabled;
      this.description = initialDifficultyLevel.description;
      this.difficultyLevelId = initialDifficultyLevel.difficultyLevelId;
      this.duplicateCheckingEnabled =
        initialDifficultyLevel.duplicateCheckingEnabled;
      this.entityType = initialDifficultyLevel.entityType;
      this.guessFilterEnabled = initialDifficultyLevel.guessFilterEnabled;
      this.highlightClosestEnabled =
        initialDifficultyLevel.highlightClosestEnabled;
      this.instanceLabel = initialDifficultyLevel.instanceLabel;
      this.maximumDimension = initialDifficultyLevel.maximumDimension;
      this.maximumGap = initialDifficultyLevel.maximumGap;
      this.minimumDimension = initialDifficultyLevel.minimumDimension;
      this.name = initialDifficultyLevel.name;
      this.percentVisibility = initialDifficultyLevel.percentVisibility;
    } else {
      this.badLinkEnabled = false;
      this.description = '';
      this.difficultyLevelId = 0;
      this.duplicateCheckingEnabled = false;
      this.entityType = 'DifficultyLevelBase';
      this.guessFilterEnabled = false;
      this.highlightClosestEnabled = false;
      this.instanceLabel = '';
      this.maximumDimension = 0;
      this.maximumGap = 0;
      this.minimumDimension = 0;
      this.name = '';
      this.percentVisibility = 0;
    }
  } // constructor
}
