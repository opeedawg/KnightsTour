/**
 * File:     DifficultyLevelBase.ts
 * Location: src\entities\DifficultyLevel\models\base\
 * The base class for the @see DifficultyLevel entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file DifficultyLevel.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:15 AM
 */

// Imports
import { IDifficultyLevelBase } from './IDifficultyLevelBase';

/** An enumeration of all @see DifficultyLevel property names (includes computed fields). */
export enum DifficultyLevelPropertyNames {
  /** boolean(mandatory) */
  badLinkEnabled = 'badLinkEnabled',
  /** string(mandatory) */
  description = 'description',
  /** number(PRIMARY KEY mandatory) */
  difficultyLevelId = 'difficultyLevelId',
  /** boolean(mandatory) */
  duplicateCheckingEnabled = 'duplicateCheckingEnabled',
  /** boolean(mandatory) */
  guessFilterEnabled = 'guessFilterEnabled',
  /** boolean(mandatory) */
  highlightClosestEnabled = 'highlightClosestEnabled',
  /** string (mandatory) */
  instanceLabel = 'instanceLabel',
  /** number(mandatory) */
  maximumDimension = 'maximumDimension',
  /** number(mandatory) */
  maximumGap = 'maximumGap',
  /** number(mandatory) */
  minimumDimension = 'minimumDimension',
  /** string(mandatory) */
  name = 'name',
  /** number(mandatory) */
  percentVisibility = 'percentVisibility',
}

/**
* Abstract Class: DifficultyLevelBase
* @implements {IDifficultyLevelBase}
*
* Base class to define the @see DifficultyLevel model. It is highly recommended NOT to modify this class, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided class - @see DifficultyLevel.
*
* @implements {constructor} The constructor for the @see DifficultyLevelBase class
* @implements {get} Retrieves a value off the entity based on the property name (as a string).
* @implements {set} Sets a value on the entity based on the property name (as a string).
*/
export abstract class DifficultyLevelBase implements IDifficultyLevelBase {
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
  * The constructor for the @see DifficultyLevelBase class
  * @param {DifficultyLevelBase} initialDifficultyLevel?: An optional initial object to seed this class.
  */
  constructor(initialDifficultyLevel?: DifficultyLevelBase) {
    if (initialDifficultyLevel) {
      this.badLinkEnabled = initialDifficultyLevel.badLinkEnabled;
      this.description = initialDifficultyLevel.description;
      this.difficultyLevelId = initialDifficultyLevel.difficultyLevelId;
      this.duplicateCheckingEnabled = initialDifficultyLevel.duplicateCheckingEnabled;
      this.entityType = initialDifficultyLevel.entityType;
      this.guessFilterEnabled = initialDifficultyLevel.guessFilterEnabled;
      this.highlightClosestEnabled = initialDifficultyLevel.highlightClosestEnabled;
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


  /**
  * Function [get]: 
  * Retrieves a value off the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see DifficultyLevelPropertyNames enumeration.
  * @returns {any} The entity value of type whatever the property is defined as.
  */
  get(property: string): any {
    return this[property as keyof typeof this];
  } // get


  /**
  * Function [set]: 
  * Sets a value on the entity based on the property name (as a string).
  * @param {string} property: The name of the property to retrive. It is HIGHLY recommended to utilize the @see DifficultyLevelPropertyNames enumeration.
  * @param {any} value: The new value of the property to assign.
  * @returns {void} Performs the set by reference.
  */
  set(property: string, value: any): void {
    this[property as keyof typeof this] = value;
  } // set

}
