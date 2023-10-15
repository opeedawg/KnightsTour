/**
 * File:     MemberConfigBase.ts
 * Location: src\entities\Member\models\base\
 * The base configuration information for the @see Member entity. It is highly recommended NOT to modify this file, it will be overwritten to stay in sync with the model.  You can overwrite or extend the functionality in the provided see file MemberConfig.ts.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:15 AM
 */

// Imports
import { CommonRestrictionType, FieldConfiguration, FieldConfigurationFromDB, FieldConfigurationFromExisting } from 'src/common/models/fieldConfiguration';
import { DBColumn, QDataType, QTableColumnHeader, QTableColumnHeaderFromDBColumn } from 'src/common/models/quasar';
import { DXCustomAction } from 'src/common/models/dxterity';
import { MaterialDesignIcon } from 'src/common/models/enumerations';
import { MemberEntitySettings } from '../entitySettings';
import { MemberPropertyNames } from './MemberBase';
import AuthorizationInstance from 'src/common/models/authorization';

/** A map of @see DBColumn with the property name as the key. */
export const MemberDBFields = new Map<string, DBColumn>();
MemberDBFields.set(MemberPropertyNames.code, new DBColumn(MemberPropertyNames.code, 'Code', 'Code', QDataType.string));
MemberDBFields.set(MemberPropertyNames.confirmationDate, new DBColumn(MemberPropertyNames.confirmationDate, 'ConfirmationDate', 'Confirmation date', QDataType.date));
MemberDBFields.set(MemberPropertyNames.confirmationDateFormatted, new DBColumn(MemberPropertyNames.confirmationDateFormatted,'ConfirmationDate','Confirmation date formatted for presentation', QDataType.string));
MemberDBFields.set(MemberPropertyNames.createDate, new DBColumn(MemberPropertyNames.createDate, 'CreateDate', 'Create date', QDataType.date));
MemberDBFields.set(MemberPropertyNames.createDateFormatted, new DBColumn(MemberPropertyNames.createDateFormatted,'CreateDate','Create date formatted for presentation', QDataType.string));
MemberDBFields.set(MemberPropertyNames.displayName, new DBColumn(MemberPropertyNames.displayName, 'DisplayName', 'Display name', QDataType.string));
MemberDBFields.set(MemberPropertyNames.emailAddress, new DBColumn(MemberPropertyNames.emailAddress, 'EmailAddress', 'Email address', QDataType.string));
MemberDBFields.set(MemberPropertyNames.instanceLabel, new DBColumn(MemberPropertyNames.instanceLabel, '', 'The derived instance label.', QDataType.string));
MemberDBFields.set(MemberPropertyNames.isAdministrator, new DBColumn(MemberPropertyNames.isAdministrator, 'IsAdministrator', 'Is administrator', QDataType.boolean));
MemberDBFields.set(MemberPropertyNames.memberId, new DBColumn(MemberPropertyNames.memberId, 'MemberId', 'Member id', QDataType.number));
MemberDBFields.set(MemberPropertyNames.password, new DBColumn(MemberPropertyNames.password, 'Password', 'Password', QDataType.string));
MemberDBFields.set(MemberPropertyNames.userInitials, new DBColumn(MemberPropertyNames.userInitials, 'UserInitials', 'User initials', QDataType.string));

/** The Code column that can be used in header construction. */
export const colCode: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.code));

/** The Confirmation date column that can be used in header construction. */
export const colConfirmationDate: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.confirmationDate));

/** The Confirmation date column formatted for display that can be used in header construction. */
export const colConfirmationDateFormatted: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.confirmationDateFormatted));

/** The Create date column that can be used in header construction. */
export const colCreateDate: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.createDate));

/** The Create date column formatted for display that can be used in header construction. */
export const colCreateDateFormatted: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.createDateFormatted));

/** The Display name column that can be used in header construction. */
export const colDisplayName: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.displayName));

/** The Email address column that can be used in header construction. */
export const colEmailAddress: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.emailAddress));

/** The instance label column that can be used in header construction. */
export const colInstanceLabel: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.instanceLabel));

/** The Is administrator column that can be used in header construction. */
export const colIsAdministrator: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.isAdministrator));

/** The Member id column that can be used in header construction. */
export const colMemberId: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.memberId));

/** The Password column that can be used in header construction. */
export const colPassword: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.password));

/** The User initials column that can be used in header construction. */
export const colUserInitials: QTableColumnHeaderFromDBColumn = new QTableColumnHeaderFromDBColumn(MemberDBFields.get(MemberPropertyNames.userInitials));

/** The configured base custom actions configured in the model. */
export const customActionsBase: DXCustomAction[] = [];

// Configurable delete multiple custom action.
const entitySettings = new MemberEntitySettings();
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
export const fieldConfigurationCode = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.code), MaterialDesignIcon.Abc, 'The Code');

/** The detailed Confirmation date field configuration used for all form displays. */
export const fieldConfigurationConfirmationDate = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.confirmationDate), MaterialDesignIcon.Event, 'The Confirmation date date.');

/** The detailed Confirmation date formatted field configuration used for all form displays. */
export const fieldConfigurationConfirmationDateFormatted = new FieldConfigurationFromExisting(fieldConfigurationConfirmationDate);
fieldConfigurationConfirmationDateFormatted.propertyName = MemberPropertyNames.confirmationDateFormatted;
fieldConfigurationConfirmationDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);

/** The detailed Create date field configuration used for all form displays. */
export const fieldConfigurationCreateDate = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.createDate), MaterialDesignIcon.Event, 'The Create date date.');
// This field was detected as a concurrency field, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationCreateDate.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Create date formatted field configuration used for all form displays. */
export const fieldConfigurationCreateDateFormatted = new FieldConfigurationFromExisting(fieldConfigurationCreateDate);
fieldConfigurationCreateDateFormatted.propertyName = MemberPropertyNames.createDateFormatted;
fieldConfigurationCreateDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);
// This field was detected as a concurrency field, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationCreateDateFormatted.addRestriction(CommonRestrictionType.InsertHidden);
fieldConfigurationCreateDateFormatted.addRestriction(CommonRestrictionType.EditHidden);
fieldConfigurationCreateDateFormatted.addRestriction(CommonRestrictionType.Disabled);

/** The detailed Display name field configuration used for all form displays. */
export const fieldConfigurationDisplayName = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.displayName), MaterialDesignIcon.Abc, 'The Display name');

/** The detailed Email address field configuration used for all form displays. */
export const fieldConfigurationEmailAddress = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.emailAddress), MaterialDesignIcon.Abc, 'The Email address');

/** The instance label field configuration used for all form displays. */
export const fieldConfigurationInstanceLabel = new FieldConfiguration(MemberPropertyNames.instanceLabel, 'Label', QDataType.string, 'key', 'The instance label.');
// This field is used as a label for UI purposes, it should really never be represented on any screen.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationInstanceLabel.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Is administrator field configuration used for all form displays. */
export const fieldConfigurationIsAdministrator = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.isAdministrator), MaterialDesignIcon.Done, 'Toggle the Is administrator setting.');

/** The detailed Member id field configuration used for all form displays. */
export const fieldConfigurationMemberId = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.memberId), MaterialDesignIcon.Key, 'The primary identifier.');
// This field is the primary key for the table, thus further restrictions have been automatically added.
// As with all base code, these can be removed, replaced or added to in the extended class.
fieldConfigurationMemberId.addRestriction(CommonRestrictionType.Disabled);
fieldConfigurationMemberId.addRestriction(CommonRestrictionType.Hidden);

/** The detailed Password field configuration used for all form displays. */
export const fieldConfigurationPassword = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.password), MaterialDesignIcon.Abc, 'The Password');

/** The detailed User initials field configuration used for all form displays. */
export const fieldConfigurationUserInitials = new FieldConfigurationFromDB(MemberDBFields.get(MemberPropertyNames.userInitials), MaterialDesignIcon.Abc, 'The User initials');

/** The columns to show in the list view.  Order is respected here. */
export const columnsBase: QTableColumnHeader[] = [colMemberId, colDisplayName, colEmailAddress];

/** A map of @see FieldConfiguration with the property name as the key. */
export const fieldConfigurationsBase = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.set(MemberPropertyNames.code, fieldConfigurationCode);
fieldConfigurationsBase.set(MemberPropertyNames.confirmationDate, fieldConfigurationConfirmationDate);
fieldConfigurationsBase.set(MemberPropertyNames.confirmationDateFormatted, fieldConfigurationConfirmationDateFormatted);
fieldConfigurationsBase.set(MemberPropertyNames.createDate, fieldConfigurationCreateDate);
fieldConfigurationsBase.set(MemberPropertyNames.createDateFormatted, fieldConfigurationCreateDateFormatted);
fieldConfigurationsBase.set(MemberPropertyNames.displayName, fieldConfigurationDisplayName);
fieldConfigurationsBase.set(MemberPropertyNames.emailAddress, fieldConfigurationEmailAddress);
fieldConfigurationsBase.set(MemberPropertyNames.instanceLabel, fieldConfigurationInstanceLabel);
fieldConfigurationsBase.set(MemberPropertyNames.isAdministrator, fieldConfigurationIsAdministrator);
fieldConfigurationsBase.set(MemberPropertyNames.memberId, fieldConfigurationMemberId);
fieldConfigurationsBase.set(MemberPropertyNames.password, fieldConfigurationPassword);
fieldConfigurationsBase.set(MemberPropertyNames.userInitials, fieldConfigurationUserInitials);
