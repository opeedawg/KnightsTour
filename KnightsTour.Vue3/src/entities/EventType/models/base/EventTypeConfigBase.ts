/**
 * File:     EventTypeConfigBase.ts
 * Location: src\entities\EventType\models\base\
 * The base configuration information for the @see EventType entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventTypeConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DXCustomAction } from 'src/common/models/dxterity';
import { EventTypeEntitySettings } from '../entitySettings';
import { EventTypePropertyNames } from './EventTypeBase';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const EventTypeDBFields = new Map<string, DBColumn>();
EventTypeDBFields.set(EventTypePropertyNames.eventTypeId, new DBColumn(EventTypePropertyNames.eventTypeId, 'EventTypeId', 'Event type id', QDataType.number));
EventTypeDBFields.set(EventTypePropertyNames.instanceLabel, new DBColumn(EventTypePropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
EventTypeDBFields.set(EventTypePropertyNames.name, new DBColumn(EventTypePropertyNames.name, 'Name', 'Name', QDataType.string));

/** The Event type id column that can be used in header construction. */
export const colEventTypeId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventTypeDBFields.get(EventTypePropertyNames.eventTypeId));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventTypeDBFields.get(EventTypePropertyNames.instanceLabel));

/** The Name column that can be used in header construction. */
export const colName: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventTypeDBFields.get(EventTypePropertyNames.name));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new EventTypeEntitySettings();
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


/** The detailed Event type id field configuration used for all form displays. */
export const fieldConfigurationEventTypeId = new FieldConfigurationFromDB(EventTypeDBFields.get(EventTypePropertyNames.eventTypeId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationEventTypeId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationEventTypeId.addRestriction(CommonRestrictionType.Hidden);

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(EventTypePropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Name field configuration used for all form displays. */
export const fieldConfigurationName = new FieldConfigurationFromDB(EventTypeDBFields.get(EventTypePropertyNames.name), MaterialDesignIcon.Abc, 'The Name');

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colEventTypeId, colName, colName];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(EventTypePropertyNames.eventTypeId, fieldConfigurationEventTypeId);
fieldConfigurationsBase.set(EventTypePropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(EventTypePropertyNames.name, fieldConfigurationName);
