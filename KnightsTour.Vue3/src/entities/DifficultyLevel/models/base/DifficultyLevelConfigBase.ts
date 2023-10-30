/**
 * File:     DifficultyLevelConfigBase.ts
 * Location: src\entities\DifficultyLevel\models\base\
 * The base configuration information for the @see DifficultyLevel entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file DifficultyLevelConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB, FieldMaskType } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DifficultyLevelEntitySettings } from '../entitySettings';
import { DifficultyLevelPropertyNames } from './DifficultyLevelBase';
import { DXCustomAction } from 'src/common/models/dxterity';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const DifficultyLevelDBFields = new Map<string, DBColumn>();
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.badLinkEnabled, new DBColumn(DifficultyLevelPropertyNames.badLinkEnabled, 'BadLinkEnabled', 'Bad link enabled', QDataType.boolean));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.description, new DBColumn(DifficultyLevelPropertyNames.description, 'Description', 'Description', QDataType.string));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.difficultyLevelId, new DBColumn(DifficultyLevelPropertyNames.difficultyLevelId, 'DifficultyLevelId', 'Difficulty level id', QDataType.number));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.duplicateCheckingEnabled, new DBColumn(DifficultyLevelPropertyNames.duplicateCheckingEnabled, 'DuplicateCheckingEnabled', 'Duplicate checking enabled', QDataType.boolean));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.guessFilterEnabled, new DBColumn(DifficultyLevelPropertyNames.guessFilterEnabled, 'GuessFilterEnabled', 'Guess filter enabled', QDataType.boolean));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.highlightClosestEnabled, new DBColumn(DifficultyLevelPropertyNames.highlightClosestEnabled, 'HighlightClosestEnabled', 'Highlight closest enabled', QDataType.boolean));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.instanceLabel, new DBColumn(DifficultyLevelPropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.maximumDimension, new DBColumn(DifficultyLevelPropertyNames.maximumDimension, 'MaximumDimension', 'Maximum dimension', QDataType.number));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.maximumGap, new DBColumn(DifficultyLevelPropertyNames.maximumGap, 'MaximumGap', 'Maximum gap', QDataType.number));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.minimumDimension, new DBColumn(DifficultyLevelPropertyNames.minimumDimension, 'MinimumDimension', 'Minimum dimension', QDataType.number));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.name, new DBColumn(DifficultyLevelPropertyNames.name, 'Name', 'Name', QDataType.string));
DifficultyLevelDBFields.set(DifficultyLevelPropertyNames.percentVisibility, new DBColumn(DifficultyLevelPropertyNames.percentVisibility, 'PercentVisibility', 'Percent visibility', QDataType.number));

/** The Bad link enabled column that can be used in header construction. */
export const colBadLinkEnabled: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.badLinkEnabled));

/** The Description column that can be used in header construction. */
export const colDescription: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.description));

/** The Difficulty level id column that can be used in header construction. */
export const colDifficultyLevelId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.difficultyLevelId));

/** The Duplicate checking enabled column that can be used in header construction. */
export const colDuplicateCheckingEnabled: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.duplicateCheckingEnabled));

/** The Guess filter enabled column that can be used in header construction. */
export const colGuessFilterEnabled: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.guessFilterEnabled));

/** The Highlight closest enabled column that can be used in header construction. */
export const colHighlightClosestEnabled: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.highlightClosestEnabled));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.instanceLabel));

/** The Maximum dimension column that can be used in header construction. */
export const colMaximumDimension: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.maximumDimension));

/** The Maximum gap column that can be used in header construction. */
export const colMaximumGap: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.maximumGap));

/** The Minimum dimension column that can be used in header construction. */
export const colMinimumDimension: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.minimumDimension));

/** The Name column that can be used in header construction. */
export const colName: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.name));

/** The Percent visibility column that can be used in header construction. */
export const colPercentVisibility: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.percentVisibility));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new DifficultyLevelEntitySettings();
if (
  entitySettings.deleteMultipleInList &&
  AuthorizationInstance.hasPermission('UserDelete')
) {
  const deleteAction: DXCustomAction = new DXCustomAction(
    entitySettings.deleteButtonText,
    'deleteMultiple'
  );
deleteAction.description = 'Deletes all the selected ' + entitySettings.label + ' rows.';
deleteAction.icon = entitySettings.deleteAction.icon;
deleteAction.iconColor = entitySettings.deleteAction.backgroundColor;
deleteAction.isMultiple = true;
customActionsBase.push(deleteAction);
}


/** The detailed Bad link enabled field configuration used for all form displays. */
export const fieldConfigurationBadLinkEnabled = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.badLinkEnabled), MaterialDesignIcon.Done, 'Toggle the Bad link enabled setting.');

/** The detailed Description field configuration used for all form displays. */
export const fieldConfigurationDescription = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.description), MaterialDesignIcon.Abc, 'The Description');

/** The detailed Difficulty level id field configuration used for all form displays. */
export const fieldConfigurationDifficultyLevelId = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.difficultyLevelId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationDifficultyLevelId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationDifficultyLevelId.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Duplicate checking enabled field configuration used for all form displays. */
export const fieldConfigurationDuplicateCheckingEnabled = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.duplicateCheckingEnabled), MaterialDesignIcon.Done, 'Toggle the Duplicate checking enabled setting.');

/** The detailed Guess filter enabled field configuration used for all form displays. */
export const fieldConfigurationGuessFilterEnabled = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.guessFilterEnabled), MaterialDesignIcon.Done, 'Toggle the Guess filter enabled setting.');

/** The detailed Highlight closest enabled field configuration used for all form displays. */
export const fieldConfigurationHighlightClosestEnabled = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.highlightClosestEnabled), MaterialDesignIcon.Done, 'Toggle the Highlight closest enabled setting.');

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(DifficultyLevelPropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Maximum dimension field configuration used for all form displays. */
export const fieldConfigurationMaximumDimension = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.maximumDimension), MaterialDesignIcon.Pin, 'The numeric Maximum dimension.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationMaximumDimension.maskType = FieldMaskType.Number;

/** The detailed Maximum gap field configuration used for all form displays. */
export const fieldConfigurationMaximumGap = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.maximumGap), MaterialDesignIcon.Pin, 'The numeric Maximum gap.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationMaximumGap.maskType = FieldMaskType.Number;

/** The detailed Minimum dimension field configuration used for all form displays. */
export const fieldConfigurationMinimumDimension = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.minimumDimension), MaterialDesignIcon.Pin, 'The numeric Minimum dimension.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationMinimumDimension.maskType = FieldMaskType.Number;

/** The detailed Name field configuration used for all form displays. */
export const fieldConfigurationName = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.name), MaterialDesignIcon.Abc, 'The Name');

/** The detailed Percent visibility field configuration used for all form displays. */
export const fieldConfigurationPercentVisibility = new FieldConfigurationFromDB(DifficultyLevelDBFields.get(DifficultyLevelPropertyNames.percentVisibility), MaterialDesignIcon.Pin, 'The numeric Percent visibility.');

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colDifficultyLevelId, colName, colDescription, colName];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.badLinkEnabled, fieldConfigurationBadLinkEnabled);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.description, fieldConfigurationDescription);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.difficultyLevelId, fieldConfigurationDifficultyLevelId);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.duplicateCheckingEnabled, fieldConfigurationDuplicateCheckingEnabled);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.guessFilterEnabled, fieldConfigurationGuessFilterEnabled);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.highlightClosestEnabled, fieldConfigurationHighlightClosestEnabled);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.maximumDimension, fieldConfigurationMaximumDimension);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.maximumGap, fieldConfigurationMaximumGap);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.minimumDimension, fieldConfigurationMinimumDimension);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.name, fieldConfigurationName);
fieldConfigurationsBase.set(DifficultyLevelPropertyNames.percentVisibility, fieldConfigurationPercentVisibility);
