export enum DXMessageType {
  Positive = 1,
  Negative = 4,
  Information = 2,
  Warning = 3,
}
/**
 * Class: DXAuthenticatedUser
 *
 * - A custom action that can be bound to the UI, or initialized from the model.
 */
export class DXAuthenticatedUser {
  name: string;
  isAdministrator: boolean;

  constructor() {
    this.name = '';
    this.isAdministrator = false;
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
