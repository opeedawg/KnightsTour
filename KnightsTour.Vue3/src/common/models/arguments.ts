import { DXCustomAction } from './dxterity';
import { FieldConfiguration } from './fieldConfiguration';
import { QDataType } from './quasar';

/**
 * Class: FormActionArgs
 *sdf
 * - Arguments passed from a form back to its calling page.
 */
export class FormActionArgs {
  action: string;
  data: any;

  constructor(action: string, data?: any) {
    this.action = action;
    this.data = null;
    if (data != null) {
      this.data = data;
    }
  }
}

/**
 * Class: GenericConfirmationArgs
 *
 * - Arguments passed from a generic confirmation to its calling page.
 */
export class GenericConfirmationArgs {
  result: boolean;
  id: string;
  customAction: DXCustomAction;
  data: any;

  constructor(
    result: boolean,
    id: string,
    customAction: DXCustomAction,
    data: any
  ) {
    this.result = result;
    this.id = id;
    this.data = data;
    this.customAction = new DXCustomAction('', ''); // Blank id will cause the isDefined property to be false.
    if (customAction != null) {
      this.customAction = customAction;
    }
  }
}

/**
 * Class: FilterFieldArgs
 *
 * - Arguments passed from a filter field to the control - executes a filter event.
 */
export class FilterFieldArgs {
  field: FieldConfiguration;
  value: string;
  options: any;

  constructor(value: string, field?: FieldConfiguration, options?: any) {
    this.field = new FieldConfiguration('', '', QDataType.string);
    if (field != null) {
      this.field = field;
    }
    this.value = value;
    this.options = {};
    if (options != null) {
      this.options = options;
    }
  }
}
