/** Possible page states, can be extended as required. */
export enum PageState {
  /** View only. */
  View = 'view',
  /** Editing state. */
  Edit = 'edit',
  /** Inserting state. */
  Insert = 'insert',
}

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
  /** Add with a circle */
  AddCircle = 'add_circle',
  /** Cancel */
  Cancel = 'cancel',
  /** Check Box Outline Blank */
  CheckBoxOutlineBlank = 'check_box_outline_blank',
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
  /** Fact Check */
  FactCheck = 'fact_check',
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
  /** List */
  Logout = 'logout',
  /** Picture As Pdf */
  PictureAsPdf = 'picture_as_pdf',
  /** Pin */
  Pin = 'pin',
  /** Person */
  Person = 'person',
  /** Save */
  Save = 'save',
  /** Search */
  Search = 'search',
  /** TextSnippet */
  TextSnippet = 'text_snippet',
  /** Thumb Down */
  ThumbDown = 'thumb_down',
  /** Thumb Up */
  ThumbUp = 'thumb_up',
  /** Warning */
  Warning = 'warning',
}
