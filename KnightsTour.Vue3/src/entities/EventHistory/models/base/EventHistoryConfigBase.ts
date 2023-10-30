/**
 * File:     EventHistoryConfigBase.ts
 * Location: src\entities\EventHistory\models\base\
 * The base configuration information for the @see EventHistory entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file EventHistoryConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 26, 2023 at 9:31:47 AM
 */

// Imports
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB, FieldConfigurationFromExisting, FieldMaskType } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DXCustomAction } from 'src/common/models/dxterity';
import { EventHistoryEntitySettings } from '../entitySettings';
import { EventHistoryPropertyNames } from './EventHistoryBase';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const EventHistoryDBFields = new Map<string, DBColumn>();
EventHistoryDBFields.set(EventHistoryPropertyNames.city, new DBColumn(EventHistoryPropertyNames.city, 'City', 'City', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.context, new DBColumn(EventHistoryPropertyNames.context, 'Context', 'Context', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.country, new DBColumn(EventHistoryPropertyNames.country, 'Country', 'Country', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.eventDate, new DBColumn(EventHistoryPropertyNames.eventDate, 'EventDate', 'Event date', QDataType.date));
EventHistoryDBFields.set(EventHistoryPropertyNames.eventDateFormatted, new DBColumn(EventHistoryPropertyNames.eventDateFormatted,'EventDate','Event date formatted for presentation', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.eventHistoryId, new DBColumn(EventHistoryPropertyNames.eventHistoryId, 'EventHistoryId', 'Event history id', QDataType.number));
EventHistoryDBFields.set(EventHistoryPropertyNames.eventTypeId, new DBColumn(EventHistoryPropertyNames.eventTypeId, 'EventTypeId', 'Event type id', QDataType.number));
EventHistoryDBFields.set(EventHistoryPropertyNames.instanceLabel, new DBColumn(EventHistoryPropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.memberId, new DBColumn(EventHistoryPropertyNames.memberId, 'MemberId', 'Member id', QDataType.number));
EventHistoryDBFields.set(EventHistoryPropertyNames.region, new DBColumn(EventHistoryPropertyNames.region, 'Region', 'Region', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.sourceInternetAddress, new DBColumn(EventHistoryPropertyNames.sourceInternetAddress, 'SourceInternetAddress', 'Source internet address', QDataType.string));
EventHistoryDBFields.set(EventHistoryPropertyNames.zipPostal, new DBColumn(EventHistoryPropertyNames.zipPostal, 'ZipPostal', 'Zip postal', QDataType.string));

/** The City column that can be used in header construction. */
export const colCity: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.city));

/** The Context column that can be used in header construction. */
export const colContext: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.context));

/** The Country column that can be used in header construction. */
export const colCountry: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.country));

/** The Event date column that can be used in header construction. */
export const colEventDate: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.eventDate));

/** The Event date column formatted for display that can be used in header construction. */
export const colEventDateFormatted: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.eventDateFormatted));

/** The Event history id column that can be used in header construction. */
export const colEventHistoryId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.eventHistoryId));

/** The Event type id column that can be used in header construction. */
export const colEventTypeId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.eventTypeId));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.instanceLabel));

/** The Member id column that can be used in header construction. */
export const colMemberId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.memberId));

/** The Region column that can be used in header construction. */
export const colRegion: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.region));

/** The Source internet address column that can be used in header construction. */
export const colSourceInternetAddress: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.sourceInternetAddress));

/** The Zip postal column that can be used in header construction. */
export const colZipPostal: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(EventHistoryDBFields.get(EventHistoryPropertyNames.zipPostal));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new EventHistoryEntitySettings();
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


/** The detailed City field configuration used for all form displays. */
export const fieldConfigurationCity = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.city), MaterialDesignIcon.Abc, 'The City');

/** The detailed Context field configuration used for all form displays. */
export const fieldConfigurationContext = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.context), MaterialDesignIcon.Abc, 'The Context');

/** The detailed Country field configuration used for all form displays. */
export const fieldConfigurationCountry = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.country), MaterialDesignIcon.Abc, 'The Country');

/** The detailed Event date field configuration used for all form displays. */
export const fieldConfigurationEventDate = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.eventDate), MaterialDesignIcon.Event, 'The Event date date.');

/** The detailed Event date formatted field configuration used for all form displays. */
export const fieldConfigurationEventDateFormatted = new FieldConfigurationFromExisting(fieldConfigurationEventDate);
fieldConfigurationEventDateFormatted.propertyName = EventHistoryPropertyNames.eventDateFormatted;
fieldConfigurationEventDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);

/** The detailed Event history id field configuration used for all form displays. */
export const fieldConfigurationEventHistoryId = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.eventHistoryId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationEventHistoryId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationEventHistoryId.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Event type id field configuration used for all form displays. */
export const fieldConfigurationEventTypeId = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.eventTypeId), MaterialDesignIcon.List, 'Select one of the Event type ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationEventTypeId.maskType = FieldMaskType.Number;
fieldConfigurationEventTypeId.optionFilter = 'SQL|SELECT CAST([EventTypeId] AS nvarchar(2000)), [Name] FROM [dbo].[EventType]  ORDER BY [Name]';

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(EventHistoryPropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Member id field configuration used for all form displays. */
export const fieldConfigurationMemberId = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.memberId), MaterialDesignIcon.List, 'Select one of the Member ids.');
// A derived numeric mask is being added due to an auto detection of an appropriate field name.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationMemberId.maskType = FieldMaskType.Number;
fieldConfigurationMemberId.optionFilter = 'SQL|SELECT CAST([MemberId] AS nvarchar(2000)), [DisplayName] FROM [dbo].[Member]  ORDER BY [DisplayName]';

/** The detailed Region field configuration used for all form displays. */
export const fieldConfigurationRegion = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.region), MaterialDesignIcon.Abc, 'The Region');

/** The detailed Source internet address field configuration used for all form displays. */
export const fieldConfigurationSourceInternetAddress = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.sourceInternetAddress), MaterialDesignIcon.Abc, 'The Source internet address');

/** The detailed Zip postal field configuration used for all form displays. */
export const fieldConfigurationZipPostal = new FieldConfigurationFromDB(EventHistoryDBFields.get(EventHistoryPropertyNames.zipPostal), MaterialDesignIcon.Abc, 'The Zip postal');

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colEventHistoryId, colSourceInternetAddress];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(EventHistoryPropertyNames.city, fieldConfigurationCity);
fieldConfigurationsBase.set(EventHistoryPropertyNames.context, fieldConfigurationContext);
fieldConfigurationsBase.set(EventHistoryPropertyNames.country, fieldConfigurationCountry);
fieldConfigurationsBase.set(EventHistoryPropertyNames.eventDate, fieldConfigurationEventDate);
fieldConfigurationsBase.set(EventHistoryPropertyNames.eventDateFormatted, fieldConfigurationEventDateFormatted);
fieldConfigurationsBase.set(EventHistoryPropertyNames.eventHistoryId, fieldConfigurationEventHistoryId);
fieldConfigurationsBase.set(EventHistoryPropertyNames.eventTypeId, fieldConfigurationEventTypeId);
fieldConfigurationsBase.set(EventHistoryPropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(EventHistoryPropertyNames.memberId, fieldConfigurationMemberId);
fieldConfigurationsBase.set(EventHistoryPropertyNames.region, fieldConfigurationRegion);
fieldConfigurationsBase.set(EventHistoryPropertyNames.sourceInternetAddress, fieldConfigurationSourceInternetAddress);
fieldConfigurationsBase.set(EventHistoryPropertyNames.zipPostal, fieldConfigurationZipPostal);
