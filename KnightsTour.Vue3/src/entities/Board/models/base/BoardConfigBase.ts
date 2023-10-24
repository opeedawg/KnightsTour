/**
 * File:     BoardConfigBase.ts
 * Location: src\entities\Board\models\base\
 * The base configuration information for the @see Board entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file BoardConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 21, 2023 at 9:45:26 AM
 */

// Imports
import { BoardEntitySettings } from '../entitySettings';
import { BoardPropertyNames } from './BoardBase';
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB, FieldConfigurationFromExisting, FieldMaskType } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DXCustomAction } from 'src/common/models/dxterity';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const BoardDBFields = new Map<string, DBColumn>();
BoardDBFields.set(BoardPropertyNames.author, new DBColumn(BoardPropertyNames.author, 'Author', 'Author', QDataType.string));
BoardDBFields.set(BoardPropertyNames.boardCode, new DBColumn(BoardPropertyNames.boardCode, 'BoardCode', 'Board code', QDataType.string));
BoardDBFields.set(BoardPropertyNames.boardId, new DBColumn(BoardPropertyNames.boardId, 'BoardId', 'Board id', QDataType.number));
BoardDBFields.set(BoardPropertyNames.colDimension, new DBColumn(BoardPropertyNames.colDimension, 'ColDimension', 'Col dimension', QDataType.number));
BoardDBFields.set(BoardPropertyNames.discoveryDate, new DBColumn(BoardPropertyNames.discoveryDate, 'DiscoveryDate', 'Discovery date', QDataType.date));
BoardDBFields.set(BoardPropertyNames.discoveryDateFormatted, new DBColumn(BoardPropertyNames.discoveryDateFormatted,'DiscoveryDate','Discovery date formatted for presentation', QDataType.string));
BoardDBFields.set(BoardPropertyNames.discoveryIterationCount, new DBColumn(BoardPropertyNames.discoveryIterationCount, 'DiscoveryIterationCount', 'Discovery iteration count', QDataType.number));
BoardDBFields.set(BoardPropertyNames.discoveryRandomness, new DBColumn(BoardPropertyNames.discoveryRandomness, 'DiscoveryRandomness', 'Discovery randomness', QDataType.number));
BoardDBFields.set(BoardPropertyNames.instanceLabel, new DBColumn(BoardPropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
BoardDBFields.set(BoardPropertyNames.path, new DBColumn(BoardPropertyNames.path, 'Path', 'Path', QDataType.string));
BoardDBFields.set(BoardPropertyNames.rowDimension, new DBColumn(BoardPropertyNames.rowDimension, 'RowDimension', 'Row dimension', QDataType.number));
BoardDBFields.set(BoardPropertyNames.sourceBoardId, new DBColumn(BoardPropertyNames.sourceBoardId, 'SourceBoardId', 'Source board id', QDataType.number));

/** The Author column that can be used in header construction. */
export const colAuthor: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.author));

/** The Board code column that can be used in header construction. */
export const colBoardCode: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.boardCode));

/** The Board id column that can be used in header construction. */
export const colBoardId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.boardId));

/** The Col dimension column that can be used in header construction. */
export const colColDimension: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.colDimension));

/** The Discovery date column that can be used in header construction. */
export const colDiscoveryDate: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.discoveryDate));

/** The Discovery date column formatted for display that can be used in header construction. */
export const colDiscoveryDateFormatted: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.discoveryDateFormatted));

/** The Discovery iteration count column that can be used in header construction. */
export const colDiscoveryIterationCount: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.discoveryIterationCount));

/** The Discovery randomness column that can be used in header construction. */
export const colDiscoveryRandomness: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.discoveryRandomness));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.instanceLabel));

/** The Path column that can be used in header construction. */
export const colPath: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.path));

/** The Row dimension column that can be used in header construction. */
export const colRowDimension: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.rowDimension));

/** The Source board id column that can be used in header construction. */
export const colSourceBoardId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(BoardDBFields.get(BoardPropertyNames.sourceBoardId));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new BoardEntitySettings();
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


/** The detailed Author field configuration used for all form displays. */
export const fieldConfigurationAuthor = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.author), MaterialDesignIcon.Abc, 'The Author');

/** The detailed Board code field configuration used for all form displays. */
export const fieldConfigurationBoardCode = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.boardCode), MaterialDesignIcon.Key, 'A unique key.');

/** The detailed Board id field configuration used for all form displays. */
export const fieldConfigurationBoardId = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.boardId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationBoardId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationBoardId.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Col dimension field configuration used for all form displays. */
export const fieldConfigurationColDimension = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.colDimension), MaterialDesignIcon.Pin, 'The numeric Col dimension.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationColDimension.maskType = FieldMaskType.Number;

/** The detailed Discovery date field configuration used for all form displays. */
export const fieldConfigurationDiscoveryDate = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.discoveryDate), MaterialDesignIcon.Event, 'The Discovery date date.');

/** The detailed Discovery date formatted field configuration used for all form displays. */
export const fieldConfigurationDiscoveryDateFormatted = new FieldConfigurationFromExisting(fieldConfigurationDiscoveryDate);
fieldConfigurationDiscoveryDateFormatted.propertyName = BoardPropertyNames.discoveryDateFormatted;
fieldConfigurationDiscoveryDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);

/** The detailed Discovery iteration count field configuration used for all form displays. */
export const fieldConfigurationDiscoveryIterationCount = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.discoveryIterationCount), MaterialDesignIcon.Pin, 'The numeric Discovery iteration count.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationDiscoveryIterationCount.maskType = FieldMaskType.Number;

/** The detailed Discovery randomness field configuration used for all form displays. */
export const fieldConfigurationDiscoveryRandomness = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.discoveryRandomness), MaterialDesignIcon.Pin, 'The numeric Discovery randomness.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationDiscoveryRandomness.maskType = FieldMaskType.Number;

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(BoardPropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Path field configuration used for all form displays. */
export const fieldConfigurationPath = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.path), MaterialDesignIcon.Abc, 'The Path');

/** The detailed Row dimension field configuration used for all form displays. */
export const fieldConfigurationRowDimension = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.rowDimension), MaterialDesignIcon.Pin, 'The numeric Row dimension.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationRowDimension.maskType = FieldMaskType.Number;

/** The detailed Source board id field configuration used for all form displays. */
export const fieldConfigurationSourceBoardId = new FieldConfigurationFromDB(BoardDBFields.get(BoardPropertyNames.sourceBoardId), MaterialDesignIcon.List, 'Select one of the Source board ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationSourceBoardId.maskType = FieldMaskType.Number;
fieldConfigurationSourceBoardId.optionFilter = 'SQL|SELECT CAST([BoardId] AS nvarchar(2000)), BoardId FROM [dbo].[Board]  ORDER BY BoardId';

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colBoardId, colAuthor];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(BoardPropertyNames.author, fieldConfigurationAuthor);
fieldConfigurationsBase.set(BoardPropertyNames.boardCode, fieldConfigurationBoardCode);
fieldConfigurationsBase.set(BoardPropertyNames.boardId, fieldConfigurationBoardId);
fieldConfigurationsBase.set(BoardPropertyNames.colDimension, fieldConfigurationColDimension);
fieldConfigurationsBase.set(BoardPropertyNames.discoveryDate, fieldConfigurationDiscoveryDate);
fieldConfigurationsBase.set(BoardPropertyNames.discoveryDateFormatted, fieldConfigurationDiscoveryDateFormatted);
fieldConfigurationsBase.set(BoardPropertyNames.discoveryIterationCount, fieldConfigurationDiscoveryIterationCount);
fieldConfigurationsBase.set(BoardPropertyNames.discoveryRandomness, fieldConfigurationDiscoveryRandomness);
fieldConfigurationsBase.set(BoardPropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(BoardPropertyNames.path, fieldConfigurationPath);
fieldConfigurationsBase.set(BoardPropertyNames.rowDimension, fieldConfigurationRowDimension);
fieldConfigurationsBase.set(BoardPropertyNames.sourceBoardId, fieldConfigurationSourceBoardId);
