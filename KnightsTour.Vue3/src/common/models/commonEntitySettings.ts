import { UtilityInstance } from './global';
import { MessageType, Messaging } from './messaging';
import { ToastType } from './quasar';

export abstract class CommonEntitySettings {
  toastSettings: any;

  constructor() {
    this.toastSettings = {};
  }

  toast(type: MessageType, params?: any): void {
    /** Initialized a local messaging class for access to all common system wide messaging constructs. */
    const messaging = new Messaging();

    let toastType = ToastType.Positive;
    let message = '';
    let shouldToast = true;
    switch (type) {
      case MessageType.EditCancelled: {
        shouldToast = this.toastSettings.toastOnCancel;
        message = messaging.getMessage(MessageType.EditCancelled, params);
        toastType = ToastType.Information;
        break;
      }
      default: {
        message = 'Unhandled entity settings toast type: ' + type;
        toastType = ToastType.Negative;
      }
    }

    if (shouldToast) {
      UtilityInstance.toast(
        message,
        toastType,
        this.toastSettings.toastPosition
      );
    }
  }
}
