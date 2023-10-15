/**
 * File:     BoardConfig.ts
 * Location: src\entities\Board\models\
 * The extended configuration information for the @see Board entity. 
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { BoardEntitySettings } from './entitySettings';
import { colRowAction } from 'src/common/models/columns';
import { 
  columnsBase,
  customActionsBase,
  fieldConfigurationsBase,
} from './base/BoardConfigBase';
import { DXCustomAction } from 'src/common/models/dxterity';
import { FieldConfiguration } from 'src/common/models/fieldConfiguration';
import { QTableColumnHeader } from 'src/common/models/quasar';

/** Decorate the column headers as required. */
export const columns: QTableColumnHeader[] = columnsBase;

// Dynamically att the action row only if the settings require it.
// NOTE: This is in the extended code to allow a custom action to be added to a row, hence another OR condition.
const entitySettings = new BoardEntitySettings();
if (
  entitySettings.modalEdit ||
  entitySettings.modalView ||
  entitySettings.deleteSingleInList ||
  entitySettings.navigateView ||
  entitySettings.navigateEdit
) { 
  columns.push(colRowAction);
}

/** Add any custom actions. */
export const customActions: DXCustomAction[] = customActionsBase;

/** Extend and field configurations here. */
export const fieldConfigurations = new Map<string, FieldConfiguration>();
fieldConfigurationsBase.forEach(function (fieldBase: FieldConfiguration, key: string) {
  fieldConfigurations.set(key, fieldBase);
});

/** Add or remove or reorder filter fields here.
* Note: any string fields will be combined into a single text filter in the header. */
export const filterFields: string[] = [];
columnsBase.forEach(function (header: QTableColumnHeader) {
  if (header.originalName != colRowAction.name) {
    filterFields.push(header.originalName);
  }
});
// If you wish fields to be searchable that are not displayed, add them here!
