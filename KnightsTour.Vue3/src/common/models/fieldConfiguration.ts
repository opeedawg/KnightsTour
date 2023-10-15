import { QSelectOption, ValidationRule } from 'quasar';
import { PageState } from './global';
import { IBaseEntity } from './interfaces';
import { DBColumn, QDataType } from './quasar';

/** Possible field states, may be extended as required. */
export enum FieldState {
  /** Not visible at all. */
  Hidden = 'hidden',
  /** Visible but disabled. */
  Disabled = 'disabled',
}

/**
 * Class: RestrictionStatus
 *
 * - A restriction status applied to a field.
 */
export class RestrictionStatus {
  pageState: PageState;
  fieldState: FieldState;
  permissionOverride: string[]; // Ignore this restriction if they have this permission.
  //permissionImplementation: string[]; // Apply this reistriction ONLY IF they contain the proper permission.
  roleOverride: string[]; // Ignore this restriction if they have this role.
  //roleImplementation: string[]; // Apply this reistriction ONLY IF they contain the proper role.

  constructor(pageState: PageState, fieldState: FieldState) {
    this.pageState = pageState;
    this.fieldState = fieldState;
    this.permissionOverride = [] as string[];
    //this.permissionImplementation = [] as string[];
    this.roleOverride = [] as string[];
    //this.roleImplementation = [] as string[];
  }
}

// Common restrictions
class EditDisabled extends RestrictionStatus {
  constructor() {
    super(PageState.Edit, FieldState.Disabled);
  }
}
class EditHidden extends RestrictionStatus {
  constructor() {
    super(PageState.Edit, FieldState.Hidden);
  }
}
class InsertDisabled extends RestrictionStatus {
  constructor() {
    super(PageState.Insert, FieldState.Disabled);
  }
}
class InsertHidden extends RestrictionStatus {
  constructor() {
    super(PageState.Insert, FieldState.Hidden);
  }
}
class ViewHidden extends RestrictionStatus {
  constructor() {
    super(PageState.View, FieldState.Hidden);
  }
}
class ViewDisabled extends RestrictionStatus {
  constructor() {
    super(PageState.View, FieldState.Disabled);
  }
}

/**  An enumeration of common field restriction types to assist in easy rule applications. */
export enum CommonRestrictionType {
  /** Disabled in all page states. */
  Disabled,
  /** Hidden in all page states. */
  Hidden,
  /** Disabled in the edit page state. */
  EditDisabled,
  /** Hidden in the edit page state. */
  EditHidden,
  /** Disabled in the insert page state. */
  InsertDisabled,
  /** Hidden in the insert page state. */
  InsertHidden,
  /** Disabled in the view page state (Note: This is the default for all fields and is automatically applied). */
  ViewDisabled,
  /** Hidden in the view page state. */
  ViewHidden,
}

/**  An enumeration of mask types to be applied to an HTML input field. */
export enum FieldMaskType {
  /** Will render hidden to the user with atrixes (*). */
  Password = 'password',
  /** Will restrict input to numerical values. */
  Number = 'number',
  /** Default: a normal input field. */
  Text = 'text',
  /** Will add a telephone mask. */
  Telephone = 'tel',
  /** Will render as a file picker. */
  File = 'file',
  /** Will add a URL mask. */
  Url = 'url',
}

/**
 * Class: FieldConfiguration
 *
 * - A configuration for a field to assist in page rendering.
 *
 * @implements {addRestriction} Adds a restriction to the field.
 */
export class FieldConfiguration {
  propertyName!: string;
  label: string;
  helpText: string;
  icon: string;
  restrictionStatus: RestrictionStatus[];
  validation: ValidationRule<any>[];
  optionFilter: string;
  options: QSelectOption[];
  maskType!: FieldMaskType;
  dataType: QDataType;

  constructor(
    propertyName: string,
    label: string,
    dataType: QDataType,
    icon?: string,
    helpText?: string
  ) {
    this.propertyName = propertyName;
    this.label = label;
    this.dataType = dataType;
    this.restrictionStatus = [] as RestrictionStatus[];
    this.addRestriction(CommonRestrictionType.ViewDisabled);
    this.helpText = '';
    if (helpText != null) {
      this.helpText = helpText;
    }
    this.icon = '';
    if (icon != null) {
      this.icon = icon;
    }
    this.validation = [] as ValidationRule<any>[];
    this.optionFilter = '';
    this.options = [];
    this.maskType = FieldMaskType.Text;
  }

  /**
   * Function [addRestriction]:
   * Adds a generic restriction type (just a helper function, you can still add your own custom ones).
   * @returns {FieldConfiguration} The updated @see FieldConfiguration
   */
  addRestriction(type: CommonRestrictionType): FieldConfiguration {
    if (type == CommonRestrictionType.EditDisabled) {
      this.restrictionStatus.push(new EditDisabled());
    } else if (type == CommonRestrictionType.EditHidden) {
      this.restrictionStatus.push(new EditHidden());
    } else if (type == CommonRestrictionType.InsertDisabled) {
      this.restrictionStatus.push(new InsertDisabled());
    } else if (type == CommonRestrictionType.InsertHidden) {
      this.restrictionStatus.push(new InsertHidden());
    } else if (type == CommonRestrictionType.ViewHidden) {
      this.restrictionStatus.push(new ViewHidden());
    } else if (type == CommonRestrictionType.Hidden) {
      this.restrictionStatus.push(new InsertHidden());
      this.restrictionStatus.push(new EditHidden());
      this.restrictionStatus.push(new ViewHidden());
    } else if (type == CommonRestrictionType.Disabled) {
      this.restrictionStatus.push(new InsertDisabled());
      this.restrictionStatus.push(new EditDisabled());
      this.restrictionStatus.push(new ViewDisabled());
    } else if (type == CommonRestrictionType.ViewDisabled) {
      this.restrictionStatus.push(new ViewDisabled());
    } else {
      alert('Error adding common restriction: ' + type);
    }

    return this;
  }

  isVisible(pageState: string): boolean {
    let isVisible = true;
    this.restrictionStatus.forEach(function (restriction: RestrictionStatus) {
      if (
        isVisible &&
        restriction.pageState == pageState &&
        restriction.fieldState == FieldState.Hidden
      ) {
        isVisible = false;
      }
    });

    return isVisible;
  }

  isEnabled(pageState: string): boolean {
    let isEnabled = true;
    this.restrictionStatus.forEach(function (restriction: RestrictionStatus) {
      if (
        isEnabled &&
        restriction.pageState == pageState &&
        restriction.fieldState == FieldState.Disabled
      ) {
        isEnabled = false;
      }
    });

    return isEnabled;
  }

  requiresOptionPopulation(pageState: string): boolean {
    return this.optionFilter.length > 0 && this.isVisible(pageState);
  }
}

/**
 * Class: FieldConfigurationFromDB
 *
 * - Initializes and adds a @see FieldConfiguration from a @see DBColumn.
 *
 * @extends FieldConfiguration
 *
 */
export class FieldConfigurationFromDB extends FieldConfiguration {
  constructor(
    dbColumn: DBColumn | undefined,
    icon?: string,
    helpText?: string
  ) {
    if (dbColumn != null) {
      super(dbColumn.name, dbColumn.label, dbColumn.dataType, icon, helpText);
    } else {
      throw 'Don`t be dumb.';
    }
  }
}

/**
 * Class: FieldConfigurationFromExisting
 *
 * - Initializes and adds a @see FieldConfiguration from a existing @see FieldConfiguration.
 *
 * @extends FieldConfiguration
 *
 */
export class FieldConfigurationFromExisting extends FieldConfiguration {
  constructor(configuration: FieldConfiguration, copyRestrictions?: boolean) {
    super(
      configuration.propertyName,
      configuration.label,
      configuration.dataType,
      configuration.icon,
      configuration.helpText
    );

    // Copies over any restrictions by value (not reference).
    if (copyRestrictions != null && copyRestrictions) {
      this.restrictionStatus = JSON.parse(
        JSON.stringify(configuration.restrictionStatus)
      );
    }
  }
}

/**
 * Class: FieldSupport
 *
 * - Takes in a pages document (DOM) and performs dynamic field manipulation and other support functions.
 *
 * @implements {fieldExists} Determines if a field even exists.
 * @implements {getElementReference} Returns an HTML element of the field, or null if it does not exist.
 * @implements {setAttribute} Sets an attribute of an HTML element, or does nothing if it does not exist.
 * @implements {getBooleanValue} Returns the value of an element as a boolean.
 * @implements {getNumberValue} Returns the value of an element as a number.
 * @implements {getTextValue} Returns the value of an element as a string.
 * @implements {getSelectValue} Returns the selected value of an element as a string.
 * @implements {updateEntity} Given an IBaseEntity, the map of DBColumns and the Field configurations, updates an entity with all field values from the document.
 *
 */ export class FieldSupport {
  document: Document;

  constructor(document: Document) {
    this.document = document;
  }

  /**
   * Function [fieldExists]:
   * - Determines whether or not a field exists.
   * @param {string} property The control name.
   * @returns {boolean} Whether or not the control is found or not.
   */
  fieldExists(property: string): boolean {
    return this.getElementReference(property) != null;
  }

  /**
   * Function [getElementReference]:
   * - Gets a referenec to a field (or null if it does not exist).
   * @param {string} property The control name.
   * @returns {HTMLElement | null} The HTMLElement or null.
   */
  getElementReference(property: string): HTMLElement | null {
    let ele: HTMLElement | null = null;
    ele = this.document.getElementById('field_' + property);
    if (ele == null) {
      const elements: NodeListOf<Element> = this.document.querySelectorAll(
        "[for='field_" + property + "']"
      );
      if (elements.length > 0) {
        ele = elements[0] as HTMLElement;
      } else {
        const elements: NodeListOf<Element> = this.document.querySelectorAll(
          "[name='field_" + property + "']"
        );
        if (elements.length > 0) {
          ele = elements[0] as HTMLElement;
        }
      }
    }

    return ele;
  }

  /**
   * Function [setAttribute]:
   * - Sets an attributeto a field (or nothing if the field does not exist).
   * @param {string} property The control name.
   * @param {string} property The attribute name
   * @param {any} value The value to set.
   * @returns {HTMLElement | null} The HTMLElement or null.
   */
  setAttribute(property: string, attributeName: string, value: any) {
    if (this.fieldExists(property)) {
      this.getElementReference(property)?.setAttribute(attributeName, value);
    }
  }

  /**
   * Function [getBooleanValue]:
   * - Gets the value of a field as a boolean value.
   * @param {string} property The control name.
   * @returns {boolean} The value of the field as a boolean.
   */
  getBooleanValue(property: string): boolean {
    const elms = this.document.querySelectorAll(
      "[for='field_" + property + "']"
    );

    if (elms.length > 0) {
      return elms[0].getAttribute('aria-checked') == 'true';
    }

    return false;
  }

  /**
   * Function [getNumberValue]:
   * - Gets the value of a field as a numeric value.
   * @param {string} property The control name.
   * @returns {number} The value of the field as a number.
   */
  getNumberValue(property: string): number {
    return parseInt(this.getTextValue(property));
  }

  /**
   * Function [getTextValue]:
   * - Gets the value of a field as a string value.
   * @param {string} property The control name.
   * @returns {string} The value of the field as a string.
   */
  getTextValue(property: string): string {
    return (<HTMLInputElement>this.document.getElementById('field_' + property))
      .value;
  }

  /**
   * Function [getSelectValue]:
   * - Gets the value of a select control as a string value.
   * @param {string} property The control name.
   * @returns {string} The value of the field as a string.
   */
  getSelectValue(property: string): string {
    const elms = document.querySelectorAll("[name='field_" + property + "']");

    if (elms.length > 0) {
      return (<HTMLInputElement>elms[0]).value;
    }

    return '';
  }

  /**
   * Function [getSelectMultiValue]:
   * - Gets the value of a multi select control as am array of strings value.
   * @param {string} property The control name.
   * @returns {string} The value of the field as a string.
   */
  getSelectMultiValue(property: string): string[] {
    const rawValue = this.getTextValue(property + '_selectedValues');
    let returnValues = [] as string[];
    if (rawValue && rawValue.length > 0) {
      returnValues = rawValue.split(',');
    }

    return returnValues;
  }

  /**
   * Function [updateEntity]:
   * - Updates the entity from values on the screen.
   * @param {IBaseEntity} entity The entity to update.
   * @param {Map<string, DBColumn>} dbFields The map of @see DBColumn for the entity.
   * @param {Map<string, FieldConfiguration>} fieldConfigurations The map of @see FieldConfiguration for the entity.
   * @returns {void} The entity is updated by reference.
   */
  updateEntity(
    entity: IBaseEntity,
    dbFields: Map<string, DBColumn>,
    fieldConfigurations: Map<string, FieldConfiguration>
  ): void {
    dbFields.forEach((value: DBColumn, propertyName: string) => {
      if (this.fieldExists(propertyName)) {
        if (value.dataType == QDataType.boolean) {
          entity.set(propertyName, this.getBooleanValue(propertyName));
        } else if (value.dataType == QDataType.number) {
          entity.set(propertyName, this.getNumberValue(propertyName));
        } else {
          // We need to know a bit more about the field for this option.
          // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
          const fieldConfiguration = fieldConfigurations.get(propertyName)!;

          if (fieldConfiguration.options.length > 0) {
            entity.set(propertyName, this.getSelectValue(propertyName));
          } else {
            entity.set(propertyName, this.getTextValue(propertyName));
          }
        }
      }
    });
  }
}
