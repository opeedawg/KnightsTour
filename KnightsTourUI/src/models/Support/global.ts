/* eslint-disable @typescript-eslint/no-this-alias */
import { Notify, QNotifyAction, SessionStorage } from 'quasar';
import { DXMessage, DXMessageType, DXResponse } from './dxterity';
import { ToastType } from './quasar';

/** Possible page states, can be extended as required. */
export enum PageState {
  /** View only. */
  View = 'view',
  /** Editing state. */
  Edit = 'edit',
  /** Inserting state. */
  Insert = 'insert',
}

export enum ScreenRoute {
  Strategy = 'Strategy',
  HowToPlay = 'HowToPlay',
  PlayOffline = 'PlayOffline',
  Security = 'Security',
  GeekOut = 'GeekOut',
  FAQ = 'FAQ',
  ContactUs = 'ContactUs',
  SignUp = 'SignUp',
  SignIn = 'SignIn',
  ClearName = 'ClearName',
  PlayNow = 'PlayNow',
  TourOfTheDay = 'TourOfTheDay',
  Logout = 'Logout',
  ChangePassword = 'ChangePassword',
  MemberStatistics = 'MemberStatistics',
  ShareSolution = 'Share',
}

export class MenuItem {
  label: string;
  separator: boolean;
  icon: string;
  iconColor: string;
  route: ScreenRoute;
  constructor(
    label: string,
    icon: string,
    iconColor: string,
    route: ScreenRoute
  ) {
    this.label = label;
    this.separator = false;
    this.icon = icon;
    this.iconColor = iconColor;
    this.route = route;
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
  refreshLayout: boolean;
  breadCrumb: string;
  menuList: MenuItem[];

  constructor() {
    this.logoutIntervalTimer = 0;
    this.refreshLayout = false;
    this.breadCrumb = 'Play now!';
    const sessionBreadCrumb = SessionStorage.getItem('breadCrumb');
    if (sessionBreadCrumb != null) {
      this.breadCrumb = sessionBreadCrumb.toString();
    }
    this.menuList = [];
    this.menuList.push(
      new MenuItem(
        'Play now!',
        'play_circle_outline',
        'green-10',
        ScreenRoute.PlayNow
      )
    );
    this.menuList.push(
      new MenuItem(
        'Tour of the day',
        'event_available',
        'white',
        ScreenRoute.TourOfTheDay
      )
    );
    this.menuList.push(
      new MenuItem('How to play', 'extension', 'green', ScreenRoute.HowToPlay)
    );
    this.menuList.push(
      new MenuItem('Strategies', 'route', 'blue-11', ScreenRoute.Strategy)
    );
    this.menuList.push(
      new MenuItem(
        'Play offline',
        'auto_stories',
        'grey',
        ScreenRoute.PlayOffline
      )
    );
    this.menuList.push(
      new MenuItem('Security', 'security', 'yellow-9', ScreenRoute.Security)
    );
    this.menuList.push(
      new MenuItem('Geek out!', 'functions', 'pink', ScreenRoute.GeekOut)
    );
    this.menuList.push(new MenuItem('FAQ', 'quiz', 'blue-10', ScreenRoute.FAQ));
    this.menuList.push(
      new MenuItem('Contact us', 'contact_mail', 'red', ScreenRoute.ContactUs)
    );
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

    let derivedPosition = ToastPositionType.Center;
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
    if (response && response.messages) {
      response.messages.forEach(function (message: DXMessage) {
        if (message.type == DXMessageType.Positive) {
          UtilityInstance.toast(message.content, ToastType.Positive);
        } else if (message.type == DXMessageType.Negative) {
          UtilityInstance.toast(
            message.content,
            ToastType.Negative,
            ToastPositionType.Bottom,
            true,
            errorDuration
          );
        } else if (message.type == DXMessageType.Information) {
          UtilityInstance.toast(message.content, ToastType.Information);
        } else if (message.type == DXMessageType.Warning) {
          UtilityInstance.toast(message.content, ToastType.Warning);
        }
      });
    } else {
      if (!response) {
        UtilityInstance.toast('Null reposnse received.', ToastType.Warning);
      } else if (!response.messages) {
        UtilityInstance.toast(
          'No reposnse messages received. Response validity: ' +
            response.isValid,
          ToastType.Warning
        );
      }
    }
  }

  Logout() {
    this.Navigate(ScreenRoute.Logout, true);
    window.location.reload();
  }

  Navigate(route: ScreenRoute, reload?: boolean) {
    this.AddHistory(route);
    if (reload != null && reload) {
      this.refreshLayout = true;
    }
    const menuItem = this.menuList.filter((i) => {
      if (i.route == route) {
        return i;
      }
    });

    if (menuItem.length > 0) {
      this.breadCrumb = menuItem[0].label;
      SessionStorage.set('breadCrumb', this.breadCrumb);
    }
    window.location.replace('/#/' + route);
    if (this.refreshLayout) {
      window.location.reload();
    }
  }

  AddHistory(route: ScreenRoute) {
    const historyStackSession = SessionStorage.getItem('historyStack');
    let historyStack = [] as ScreenRoute[];
    if (historyStackSession) {
      historyStack = historyStackSession as ScreenRoute[];
    }
    historyStack.push(route);
    SessionStorage.set('historyStack', historyStack);
  }

  GetHistory(): string {
    const historyStackSession = SessionStorage.getItem('historyStack');
    if (historyStackSession) {
      const historyStack = historyStackSession as ScreenRoute[];
      if (historyStack.length > 0) return historyStack[0].toString();
      else return '';
    } else return '';
  }

  ReloadScreen(overrideRefresh?: boolean) {
    if (overrideRefresh) this.refreshLayout = overrideRefresh;
    if (this.refreshLayout) {
      this.refreshLayout = false;
      window.location.reload();
    }
  }

  GetRatingLevel(difficultyLevelId: number): number {
    if (difficultyLevelId == 9) return 1;
    else if (difficultyLevelId == 1) return 2;
    else if (difficultyLevelId == 5) return 3;
    else if (difficultyLevelId == 6) return 4;
    else if (difficultyLevelId == 7) return 5;
    else return 0;
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
