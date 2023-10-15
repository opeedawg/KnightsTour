import { Notify, QNotifyAction } from 'quasar';
import {
  DXCustomAction,
  DXMessage,
  DXMessageType,
  DXResponse,
} from './dxterity';
import { Environment } from './environment';
import { ProjectSettings } from './projectSettings';
import { QTransitionType, ToastType } from './quasar';

/** Possible page states, can be extended as required. */
export enum PageState {
  /** View only. */
  View = 'view',
  /** Editing state. */
  Edit = 'edit',
  /** Inserting state. */
  Insert = 'insert',
}

/**
 * Class: GenericConfirmationConfiguration
 *
 * - Supports the detailed configuration of a generic confirmation dialog.
 */
export class GenericConfirmationConfiguration {
  id: string;
  operation: string;
  message: string;
  title: string;
  cancelText: string;
  confirmationText: string;
  isCustomAction: boolean;
  transitionShow: QTransitionType;
  transitionHide: QTransitionType;
  transitionDuration: number;
  heightMax: string;
  widthMax: string;
  dialogClass: string;
  cardClass: string;
  titleClass: string;
  messageClass: string;
  actionClass: string;
  confirmationButtonColor: SystemColor;
  cancelButtonColor: SystemColor;
  customAction: DXCustomAction;
  confirmationIcon: MaterialDesignIcon;
  cancelIcon: MaterialDesignIcon;
  confirmationTextColor: SystemColor;
  cancelTextColor: SystemColor;
  data: any;

  constructor(id: string, operation: string) {
    this.id = id;
    this.operation = operation;
    this.message = 'Are you sure?';
    this.title = 'Please confirm this time';
    this.cancelText = 'Cancel';
    this.confirmationText = 'Yes';
    this.transitionShow = QTransitionType.None;
    this.transitionHide = QTransitionType.None;
    this.transitionDuration = 500;
    this.isCustomAction = false;
    this.heightMax = '400vh';
    this.widthMax = '700px';
    this.dialogClass = '';
    this.cardClass = 'q-pt-none';
    this.titleClass = 'text-h6';
    this.messageClass = '';
    this.actionClass = '';
    this.confirmationButtonColor = SystemColor.Primary;
    this.cancelButtonColor = SystemColor.Charcoal;
    this.customAction = new DXCustomAction('', '');
    this.confirmationIcon = MaterialDesignIcon.ThumbUp;
    this.cancelIcon = MaterialDesignIcon.ThumbDown;
    this.confirmationTextColor = SystemColor.White;
    this.cancelTextColor = SystemColor.White;
  }
}

/**
 * Class: Utility
 *
 * - General helper class for the project.
 *
 * @implements {toast} Creates a notification message to the user.
 * @implements {Logout} The universal call to logout a user from the application.
 */
export class Utility {
  logoutIntervalTimer: number;
  constructor() {
    this.logoutIntervalTimer = 0;
  }
  /**
   * Function [toast]:
   * - Determines whether or not a field exists.
   * @param {string} message The text to display.
   * @param {ToastType} type The notification type.
   * @param {boolean} showDismiss (Optional) Should a dismiss option be rendered?  By default TRUE.
   */
  toast(
    message: string,
    type?: ToastType,
    position?: ToastPositionType,
    showDismiss?: boolean,
    timeout?: number
  ): void {
    if (showDismiss == null) {
      showDismiss = true;
    }
    let alertActions: QNotifyAction[] = [];
    if (showDismiss) {
      alertActions = [
        {
          label: 'Dismiss',
          color: 'white',
          handler: () => {
            /* ... */
          },
        },
      ];
    }
    let derivedType: ToastType = ToastType.Positive;
    if (type != null) {
      derivedType = type;
    }

    const projectSettings = new ProjectSettings();
    let derivedPosition: ToastPositionType = projectSettings.toastPosition;
    if (position != null) {
      derivedPosition = position;
    }

    let derivedTimeout = 3000;
    if (timeout != null) {
      derivedTimeout = timeout;
    }

    Notify.create({
      type: derivedType,
      message: message,
      actions: alertActions,
      position: derivedPosition,
      timeout: derivedTimeout,
      progress: true,
    });
  }
  toastResponse(response: DXResponse, errorDurationSeconds?: number): void {
    let errorDuration = 10 * 1000;
    if (errorDurationSeconds != null) {
      errorDuration = errorDurationSeconds * 1000;
    }
    response.messages.forEach(function (message: DXMessage) {
      if (message.type == DXMessageType.Positive) {
        UtilityInstance.toast(message.content, ToastType.Positive);
      } else if (message.type == DXMessageType.Negative) {
        UtilityInstance.toast(
          message.content,
          ToastType.Negative,
          undefined,
          true,
          errorDuration
        );
      } else if (message.type == DXMessageType.Information) {
        UtilityInstance.toast(message.content, ToastType.Information);
      } else if (message.type == DXMessageType.Warning) {
        UtilityInstance.toast(message.content, ToastType.Warning);
      }
    });
  }

  Logout() {
    window.location.replace(Environment.getInstance().publicPath + '/#/Logout');
  }

  Login() {
    window.location.replace(Environment.getInstance().publicPath + '/#/');
  }

  Unauthorized() {
    window.location.replace(
      Environment.getInstance().publicPath + '/#/Unauthorized'
    );
  }

  SystemError() {
    window.location.replace(
      Environment.getInstance().publicPath + '/#/SystemError'
    );
  }
}

export const UtilityInstance: Utility = new Utility();

/** The possible toast positions. */
export enum ToastPositionType {
  /** Center top of page. */
  Top = 'top',
  /** Top left of page. */
  TopLeft = 'top-left',
  /** Top right of page. */
  TopRight = 'top-right',
  /** Left center of page. */
  Left = 'left',
  /** Middle of page. */
  Center = 'center',
  /** Right center of page. */
  Right = 'right',
  /** Bottom center of page. */
  Bottom = 'bottom',
  /** Bottom left of page. */
  BottomLeft = 'bottom-left',
  /** Bottom right of page. */
  BottomRight = 'bottom-right',
}

/** Routing action options to take after after an insert. */
export enum PostInsertNavigationOption {
  /** Navigate to the new entities page in view mode. */
  View = 'View',
  /** Navigate to the new entities list page. */
  List = 'List',
  /** Navigate to the new entities page in edit mode. */
  Edit = 'Edit',
}

/** A mix of web safe and quasar defined colors.
 * - You should feel free to add new definition here,
 * - OR remove to restrict color pallet usage.
 */
export enum SystemColor {
  /** Yellowish color as defined by Quasar. */
  Amber = 'amber',
  /** Standard web safe aqua. */
  Aqua = 'green',
  /** Standard web safe black. */
  Black = 'black',
  /** Standard web safe blue. */
  Blue = 'blue',
  /**Custom web safe charcoal */
  Charcoal = '#595d5f',
  /** Standard web safe fuchsia. */
  Fuchsia = 'fuchsia',
  /** Standard web safe gray. */
  Gray = 'gray',
  /** Custom web safe green. */
  Green = '#60A60F',
  /** Standard web safe lime. */
  Lime = 'lime',
  /** Standard web safe maroon. */
  Maroon = 'maroon',
  /** Standard web safe olive. */
  Olive = 'olive',
  /** Deep purple color as defined by Quasar. */
  Primary = '#006699',
  /** Standard web safe purple. */
  Purple = 'purple',
  /** Standard web safe red. */
  Red = 'red',
  /** Aqua blue color as defined by Quasar. */
  Secondary = '#3399cc',
  /** Standard web safe silver. */
  Silver = 'silver',
  /** Standard web safe teal. */
  Teal = 'teal',
  /** Custom web safe yellow. */
  Yellow = '#f9bb02',
  /** Standard html white. */
  White = 'white',
}

/** A list of material design icons.
 * - Source: https://fonts.google.com/icons?icon.set=Material+Icons
 * - Refreshed: November 23, 2022 9:25:31 PM */
export enum MaterialDesignIcon {
  /** NO ICON */
  NONE = '',
  /** Abc */
  Abc = 'abc',
  /** Account Circle */
  AccountCircle = 'account_circle',
  /** Add */
  Add = 'add',
  /** Cancel */
  Cancel = 'cancel',
  /** Close */
  Close = 'close',
  /** Delete */
  Delete = 'delete',
  /** Description */
  Description = 'description',
  /** Done */
  Done = 'done',
  /** Edit */
  Edit = 'edit',
  /** Event */
  Event = 'event',
  /** Format List Bulleted */
  FormatListBulleted = 'format_list_bulleted',
  /** Key */
  Key = 'key',
  /** Keyboard Return */
  KeyboardReturn = 'keyboard_return',
  /** Link */
  Link = 'link',
  /** List */
  List = 'list',
  /** Picture As Pdf */
  PictureAsPdf = 'picture_as_pdf',
  /** Pin */
  Pin = 'pin',
  /** Save */
  Save = 'save',
  /** TextSnippet */
  TextSnippet = 'text_snippet',
  /** Thumb Down */
  ThumbDown = 'thumb_down',
  /** Thumb Up */
  ThumbUp = 'thumb_up',
  /** Warning */
  Warning = 'warning',
}
