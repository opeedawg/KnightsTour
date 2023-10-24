/**
 * File:     SolutionConfigBase.ts
 * Location: src\entities\Solution\models\base\
 * The base configuration information for the @see Solution entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file SolutionConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:27 AM
 */

// Imports
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB, FieldConfigurationFromExisting, FieldMaskType } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DXCustomAction } from 'src/common/models/dxterity';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import { SolutionEntitySettings } from '../entitySettings';
import { SolutionPropertyNames } from './SolutionBase';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const SolutionDBFields = new Map<string, DBColumn>();
SolutionDBFields.set(SolutionPropertyNames.code, new DBColumn(SolutionPropertyNames.code, 'Code', 'Code', QDataType.string));
SolutionDBFields.set(SolutionPropertyNames.instanceLabel, new DBColumn(SolutionPropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
SolutionDBFields.set(SolutionPropertyNames.memberId, new DBColumn(SolutionPropertyNames.memberId, 'MemberId', 'Member id', QDataType.number));
SolutionDBFields.set(SolutionPropertyNames.nonMemberIp, new DBColumn(SolutionPropertyNames.nonMemberIp, 'NonMemberIP', 'Non member IP', QDataType.string));
SolutionDBFields.set(SolutionPropertyNames.nonMemberName, new DBColumn(SolutionPropertyNames.nonMemberName, 'NonMemberName', 'Non member name', QDataType.string));
SolutionDBFields.set(SolutionPropertyNames.note, new DBColumn(SolutionPropertyNames.note, 'Note', 'Note', QDataType.string));
SolutionDBFields.set(SolutionPropertyNames.path, new DBColumn(SolutionPropertyNames.path, 'Path', 'Path', QDataType.string));
SolutionDBFields.set(SolutionPropertyNames.puzzleId, new DBColumn(SolutionPropertyNames.puzzleId, 'PuzzleId', 'Puzzle id', QDataType.number));
SolutionDBFields.set(SolutionPropertyNames.solutionDuration, new DBColumn(SolutionPropertyNames.solutionDuration, 'SolutionDuration', 'Solution duration', QDataType.number));
SolutionDBFields.set(SolutionPropertyNames.solutionId, new DBColumn(SolutionPropertyNames.solutionId, 'SolutionId', 'Solution id', QDataType.number));
SolutionDBFields.set(SolutionPropertyNames.solutionStartDate, new DBColumn(SolutionPropertyNames.solutionStartDate, 'SolutionStartDate', 'Solution start date', QDataType.date));
SolutionDBFields.set(SolutionPropertyNames.solutionStartDateFormatted, new DBColumn(SolutionPropertyNames.solutionStartDateFormatted,'SolutionStartDate','Solution start date formatted for presentation', QDataType.string));

/** The Code column that can be used in header construction. */
export const colCode: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.code));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.instanceLabel));

/** The Member id column that can be used in header construction. */
export const colMemberId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.memberId));

/** The Non member IP column that can be used in header construction. */
export const colNonMemberIp: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.nonMemberIp));

/** The Non member name column that can be used in header construction. */
export const colNonMemberName: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.nonMemberName));

/** The Note column that can be used in header construction. */
export const colNote: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.note));

/** The Path column that can be used in header construction. */
export const colPath: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.path));

/** The Puzzle id column that can be used in header construction. */
export const colPuzzleId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.puzzleId));

/** The Solution duration column that can be used in header construction. */
export const colSolutionDuration: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.solutionDuration));

/** The Solution id column that can be used in header construction. */
export const colSolutionId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.solutionId));

/** The Solution start date column that can be used in header construction. */
export const colSolutionStartDate: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.solutionStartDate));

/** The Solution start date column formatted for display that can be used in header construction. */
export const colSolutionStartDateFormatted: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(SolutionDBFields.get(SolutionPropertyNames.solutionStartDateFormatted));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new SolutionEntitySettings();
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


/** The detailed Code field configuration used for all form displays. */
export const fieldConfigurationCode = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.code), MaterialDesignIcon.Abc, 'The Code');

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(SolutionPropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Member id field configuration used for all form displays. */
export const fieldConfigurationMemberId = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.memberId), MaterialDesignIcon.List, 'Select one of the Member ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationMemberId.maskType = FieldMaskType.Number;
fieldConfigurationMemberId.optionFilter = 'SQL|SELECT CAST([MemberId] AS nvarchar(2000)), [DisplayName] FROM [dbo].[Member]  ORDER BY [DisplayName]';

/** The detailed Non member IP field configuration used for all form displays. */
export const fieldConfigurationNonMemberIp = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.nonMemberIp), MaterialDesignIcon.Abc, 'The Non member IP');

/** The detailed Non member name field configuration used for all form displays. */
export const fieldConfigurationNonMemberName = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.nonMemberName), MaterialDesignIcon.Abc, 'The Non member name');

/** The detailed Note field configuration used for all form displays. */
export const fieldConfigurationNote = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.note), MaterialDesignIcon.Abc, 'The Note');

/** The detailed Path field configuration used for all form displays. */
export const fieldConfigurationPath = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.path), MaterialDesignIcon.Abc, 'The Path');

/** The detailed Puzzle id field configuration used for all form displays. */
export const fieldConfigurationPuzzleId = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.puzzleId), MaterialDesignIcon.List, 'Select one of the Puzzle ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationPuzzleId.maskType = FieldMaskType.Number;
fieldConfigurationPuzzleId.optionFilter = 'SQL|SELECT CAST([PuzzleId] AS nvarchar(2000)), PuzzleId FROM [dbo].[Puzzle]  ORDER BY PuzzleId';

/** The detailed Solution duration field configuration used for all form displays. */
export const fieldConfigurationSolutionDuration = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.solutionDuration), MaterialDesignIcon.Pin, 'The numeric Solution duration.');

/** The detailed Solution id field configuration used for all form displays. */
export const fieldConfigurationSolutionId = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.solutionId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationSolutionId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationSolutionId.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Solution start date field configuration used for all form displays. */
export const fieldConfigurationSolutionStartDate = new FieldConfigurationFromDB(SolutionDBFields.get(SolutionPropertyNames.solutionStartDate), MaterialDesignIcon.Event, 'The Solution start date date.');

/** The detailed Solution start date formatted field configuration used for all form displays. */
export const fieldConfigurationSolutionStartDateFormatted = new FieldConfigurationFromExisting(fieldConfigurationSolutionStartDate);
fieldConfigurationSolutionStartDateFormatted.propertyName = SolutionPropertyNames.solutionStartDateFormatted;
fieldConfigurationSolutionStartDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colSolutionId, colNonMemberName, colPath];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(SolutionPropertyNames.code, fieldConfigurationCode);
fieldConfigurationsBase.set(SolutionPropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(SolutionPropertyNames.memberId, fieldConfigurationMemberId);
fieldConfigurationsBase.set(SolutionPropertyNames.nonMemberIp, fieldConfigurationNonMemberIp);
fieldConfigurationsBase.set(SolutionPropertyNames.nonMemberName, fieldConfigurationNonMemberName);
fieldConfigurationsBase.set(SolutionPropertyNames.note, fieldConfigurationNote);
fieldConfigurationsBase.set(SolutionPropertyNames.path, fieldConfigurationPath);
fieldConfigurationsBase.set(SolutionPropertyNames.puzzleId, fieldConfigurationPuzzleId);
fieldConfigurationsBase.set(SolutionPropertyNames.solutionDuration, fieldConfigurationSolutionDuration);
fieldConfigurationsBase.set(SolutionPropertyNames.solutionId, fieldConfigurationSolutionId);
fieldConfigurationsBase.set(SolutionPropertyNames.solutionStartDate, fieldConfigurationSolutionStartDate);
fieldConfigurationsBase.set(SolutionPropertyNames.solutionStartDateFormatted, fieldConfigurationSolutionStartDateFormatted);
