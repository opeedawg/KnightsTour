import { SystemColor } from './global';

export enum DXMessageType {
  Information,
  Negative,
  Positive,
  Warning,
}
/**
 * Class: DXAuthenticatedUser
 *
 * - A custom action that can be bound to the UI, or initialized from the model.
 */
export class DXAuthenticatedUser {
  firstName: string;
  lastName: string;
  lastLoginDate: string;
  roles: string[];
  permissions: string[];
  authenticatedDate: Date | null;
  lastAction: Date | null;
  showNotProductionMessage: boolean;
  timeoutAlertDuration: number;
  timeoutDuration: number;
  timeoutRefreshDuration: number;

  constructor() {
    this.firstName = '';
    this.lastName = 'UNATUTHENTICATED';
    this.lastLoginDate = '';
    this.roles = [];
    this.permissions = [];
    this.authenticatedDate = null;
    this.lastAction = null;
    this.showNotProductionMessage = false;
    this.timeoutAlertDuration = 120;
    this.timeoutDuration = 900;
    this.timeoutRefreshDuration = 30;
  }

  isAuthenticated(): boolean {
    return this.authenticatedDate != null;
  }

  getFullName(): string {
    return `${this.firstName} ${this.lastName}`;
  }
}

/**
 * Class: DXCustomAction
 *
 * - A custom action that can be bound to the UI, or initialized from the model.
 */
export class DXCustomAction {
  label: string;
  value: string;
  description: string;
  icon: string;
  iconColor: string;
  confirmationMessage: string;
  isMultiple: boolean;
  isSingle: boolean;
  isDefined: boolean;
  selectedItems: any[];

  constructor(label: string, value?: string) {
    this.label = label;
    this.value = label;
    if (value != null) {
      this.value = value;
    }
    this.description = '';
    this.icon = '';
    this.iconColor = SystemColor.Primary;
    this.confirmationMessage = '';
    this.isMultiple = false;
    this.isSingle = false;
    this.isDefined = this.label.length > 0;
    this.selectedItems = [] as any[];
  }
}

export class DXEntityFilter {
  pageIndex: number;
  pageSize: number;
  textFilter: string;
  defaultSortColumn: string;
  filters: string[];
  orderBys: string[];
  textColumns: string[];

  constructor(
    pageIndex: number,
    pageSize: number,
    defaultSortColumn: string,
    textColumns?: string[],
    filters?: string[],
    textFilter?: string
  ) {
    this.pageIndex = pageIndex;
    this.pageSize = pageSize;
    this.defaultSortColumn = defaultSortColumn;
    this.textColumns = [];
    if (textColumns != null) {
      this.textColumns = textColumns;
    }
    this.filters = [];
    if (filters != null) {
      this.filters = filters;
    }
    this.orderBys = [];
    if (defaultSortColumn != null) {
      this.orderBys.push(defaultSortColumn);
    }
    this.textFilter = '';
    if (textFilter != null) {
      this.textFilter = textFilter;
    }
  }
}

export class DXMessage {
  content: string;
  entityType: string;
  type: DXMessageType;

  constructor(content: string, messageType?: DXMessageType) {
    this.content = content;
    if (messageType == null) {
      this.type = DXMessageType.Positive;
    } else {
      this.type = messageType;
    }
    this.entityType = 'DXMessage';
  }
}

export class DXResponse {
  context: string;
  messages: DXMessage[];
  entityType: string;
  dataObject: any;
  isValid: boolean;
  count: number;

  constructor(context: string) {
    this.context = context;

    this.messages = [];

    this.entityType = 'DXResponse';

    this.dataObject = null;

    this.isValid = false;
    this.count = 0;
  }

  isValidComputed(): boolean {
    let valid = true;
    this.messages.forEach(function (message: DXMessage) {
      if (message.type == DXMessageType.Negative) {
        valid = false;
      }
    });

    return valid;
  }
}
