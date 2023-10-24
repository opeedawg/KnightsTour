/**
 * File:     PuzzleConfigBase.ts
 * Location: src\entities\Puzzle\models\base\
 * The base configuration information for the @see Puzzle entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file PuzzleConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB, FieldConfigurationFromExisting, FieldMaskType } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DXCustomAction } from 'src/common/models/dxterity';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import { PuzzleEntitySettings } from '../entitySettings';
import { PuzzlePropertyNames } from './PuzzleBase';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const PuzzleDBFields = new Map<string, DBColumn>();
PuzzleDBFields.set(PuzzlePropertyNames.boardId, new DBColumn(PuzzlePropertyNames.boardId, 'BoardId', 'Board id', QDataType.number));
PuzzleDBFields.set(PuzzlePropertyNames.difficultyLevelId, new DBColumn(PuzzlePropertyNames.difficultyLevelId, 'DifficultyLevelId', 'Difficulty level id', QDataType.number));
PuzzleDBFields.set(PuzzlePropertyNames.instanceLabel, new DBColumn(PuzzlePropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
PuzzleDBFields.set(PuzzlePropertyNames.path, new DBColumn(PuzzlePropertyNames.path, 'Path', 'Path', QDataType.string));
PuzzleDBFields.set(PuzzlePropertyNames.puzzleCode, new DBColumn(PuzzlePropertyNames.puzzleCode, 'PuzzleCode', 'Puzzle code', QDataType.string));
PuzzleDBFields.set(PuzzlePropertyNames.puzzleId, new DBColumn(PuzzlePropertyNames.puzzleId, 'PuzzleId', 'Puzzle id', QDataType.number));
PuzzleDBFields.set(PuzzlePropertyNames.puzzleOfTheDayDate, new DBColumn(PuzzlePropertyNames.puzzleOfTheDayDate, 'PuzzleOfTheDayDate', 'Puzzle of the day date', QDataType.date));
PuzzleDBFields.set(PuzzlePropertyNames.puzzleOfTheDayDateFormatted, new DBColumn(PuzzlePropertyNames.puzzleOfTheDayDateFormatted,'PuzzleOfTheDayDate','Puzzle of the day date formatted for presentation', QDataType.string));

/** The Board id column that can be used in header construction. */
export const colBoardId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.boardId));

/** The Difficulty level id column that can be used in header construction. */
export const colDifficultyLevelId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.difficultyLevelId));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.instanceLabel));

/** The Path column that can be used in header construction. */
export const colPath: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.path));

/** The Puzzle code column that can be used in header construction. */
export const colPuzzleCode: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.puzzleCode));

/** The Puzzle id column that can be used in header construction. */
export const colPuzzleId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.puzzleId));

/** The Puzzle of the day date column that can be used in header construction. */
export const colPuzzleOfTheDayDate: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.puzzleOfTheDayDate));

/** The Puzzle of the day date column formatted for display that can be used in header construction. */
export const colPuzzleOfTheDayDateFormatted: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(PuzzleDBFields.get(PuzzlePropertyNames.puzzleOfTheDayDateFormatted));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new PuzzleEntitySettings();
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


/** The detailed Board id field configuration used for all form displays. */
export const fieldConfigurationBoardId = new FieldConfigurationFromDB(PuzzleDBFields.get(PuzzlePropertyNames.boardId), MaterialDesignIcon.List, 'Select one of the Board ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationBoardId.maskType = FieldMaskType.Number;
fieldConfigurationBoardId.optionFilter = 'SQL|SELECT CAST([BoardId] AS nvarchar(2000)), BoardId FROM [dbo].[Board]  ORDER BY BoardId';

/** The detailed Difficulty level id field configuration used for all form displays. */
export const fieldConfigurationDifficultyLevelId = new FieldConfigurationFromDB(PuzzleDBFields.get(PuzzlePropertyNames.difficultyLevelId), MaterialDesignIcon.List, 'Select one of the Difficulty level ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationDifficultyLevelId.maskType = FieldMaskType.Number;
fieldConfigurationDifficultyLevelId.optionFilter = 'SQL|SELECT CAST([DifficultyLevelId] AS nvarchar(2000)), [Name] FROM [dbo].[DifficultyLevel]  ORDER BY [Name]';

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(PuzzlePropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Path field configuration used for all form displays. */
export const fieldConfigurationPath = new FieldConfigurationFromDB(PuzzleDBFields.get(PuzzlePropertyNames.path), MaterialDesignIcon.Abc, 'The Path');

/** The detailed Puzzle code field configuration used for all form displays. */
export const fieldConfigurationPuzzleCode = new FieldConfigurationFromDB(PuzzleDBFields.get(PuzzlePropertyNames.puzzleCode), MaterialDesignIcon.Key, 'A unique key.');

/** The detailed Puzzle id field configuration used for all form displays. */
export const fieldConfigurationPuzzleId = new FieldConfigurationFromDB(PuzzleDBFields.get(PuzzlePropertyNames.puzzleId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationPuzzleId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationPuzzleId.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Puzzle of the day date field configuration used for all form displays. */
export const fieldConfigurationPuzzleOfTheDayDate = new FieldConfigurationFromDB(PuzzleDBFields.get(PuzzlePropertyNames.puzzleOfTheDayDate), MaterialDesignIcon.Event, 'The Puzzle of the day date date.');

/** The detailed Puzzle of the day date formatted field configuration used for all form displays. */
export const fieldConfigurationPuzzleOfTheDayDateFormatted = new FieldConfigurationFromExisting(fieldConfigurationPuzzleOfTheDayDate);
fieldConfigurationPuzzleOfTheDayDateFormatted.propertyName = PuzzlePropertyNames.puzzleOfTheDayDateFormatted;
fieldConfigurationPuzzleOfTheDayDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colPuzzleId, colPath];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(PuzzlePropertyNames.boardId, fieldConfigurationBoardId);
fieldConfigurationsBase.set(PuzzlePropertyNames.difficultyLevelId, fieldConfigurationDifficultyLevelId);
fieldConfigurationsBase.set(PuzzlePropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(PuzzlePropertyNames.path, fieldConfigurationPath);
fieldConfigurationsBase.set(PuzzlePropertyNames.puzzleCode, fieldConfigurationPuzzleCode);
fieldConfigurationsBase.set(PuzzlePropertyNames.puzzleId, fieldConfigurationPuzzleId);
fieldConfigurationsBase.set(PuzzlePropertyNames.puzzleOfTheDayDate, fieldConfigurationPuzzleOfTheDayDate);
fieldConfigurationsBase.set(PuzzlePropertyNames.puzzleOfTheDayDateFormatted, fieldConfigurationPuzzleOfTheDayDateFormatted);
