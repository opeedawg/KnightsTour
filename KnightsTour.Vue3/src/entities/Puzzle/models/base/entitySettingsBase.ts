/**
 * File:     entitySettingsBase.ts
 * Location: src\entities\Puzzle\models\base\
 * The entity settings for the Puzzle class that stay in sync with the DXterity model.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:16 AM
 */

// Imports
import { CommonEntitySettings } from 'src/common/models/commonEntitySettings';
import { FormAction } from 'src/common/models/formAction';
import { IEntitySettings } from 'src/common/models/interfaces';
import { MaterialDesignIcon, PostInsertNavigationOption, SystemColor, ToastPositionType } from 'src/common/models/enumerations';
import { ProjectSettings } from 'src/common/models/projectSettings';

/**
* Abstract Class: EntitySettingsBase
* @extends {CommonEntitySettings}
* @implements {IEntitySettings}
*
* Class to define all the possible entity settings for the Puzzle class.  Stays in sync with the model on regeneration.  Add or overwrite in @see EntitySettings.
*
* @implements {constructor} The constructor for the @see EntitySettingsBase class
*/
export abstract class EntitySettingsBase extends CommonEntitySettings implements IEntitySettings {
  // *** Declarations ***
  /** The customized form action to add this entity.
   * - Value : [Computed @see FormAction] */
  addAction: FormAction;
  /** The background color to render on all add buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Add -> Add button background color (Lookup)
   * - Value : projectSettings.addButtonBackgroundColor */
  addButtonBackgroundColor: SystemColor;
  /** The icon to appear on all add buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Add -> Add button icon (Text)
   * - Value : projectSettings.addButtonIcon */
  addButtonIcon: MaterialDesignIcon;
  /** The text to appear on all add buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Add -> Add button text (Text)
   * - Value : projectSettings.addButtonText */
  addButtonText: string;
  /** The text color to render on all add buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Add -> Add button text color (Lookup)
   * - Value : projectSettings.addButtonTextColor */
  addButtonTextColor: SystemColor;
  /** The customized form action to cancel this entity.
   * - Value : [Computed @see FormAction] */
  cancelAction: FormAction;
  /** The background color to render on all cancel buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Cancel -> Cancel button background color (Lookup)
   * - Value : projectSettings.cancelButtonBackgroundColor */
  cancelButtonBackgroundColor: SystemColor;
  /** The icon to appear on all cancel buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Cancel -> Cancel button icon (Text)
   * - Value : projectSettings.cancelButtonIcon */
  cancelButtonIcon: MaterialDesignIcon;
  /** The text to appear on all cancel buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Cancel -> Cancel button text (Text)
   * - Value : projectSettings.cancelButtonText */
  cancelButtonText: string;
  /** The text color to render on all cancel buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Cancel -> Cancel button text color (Lookup)
   * - Value : projectSettings.cancelButtonTextColor */
  cancelButtonTextColor: SystemColor;
  /** The class name for this entity.
   * - Model Entity Setting: User Interface -> Pagination -> Pagination Options (Text)
   * - Value : Puzzle */
  className: string;
  /** The customized form action to close this entity.
   * - Value : [Computed @see FormAction] */
  closeAction: FormAction;
  /** The background color to render on all close buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Close -> Close button background color (Lookup)
   * - Value : projectSettings.closeButtonBackgroundColor */
  closeButtonBackgroundColor: SystemColor;
  /** The icon to appear on all close buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Close -> Close button icon (Text)
   * - Value : projectSettings.closeButtonIcon */
  closeButtonIcon: MaterialDesignIcon;
  /** The text to appear on all close buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Close -> Close button text (Text)
   * - Value : projectSettings.closeButtonText */
  closeButtonText: string;
  /** The text color to render on all close buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Close -> Close button text color (Lookup)
   * - Value : projectSettings.closeButtonTextColor */
  closeButtonTextColor: SystemColor;
  /** The customized form action to delete this entity.
   * - Value : [Computed @see FormAction] */
  deleteAction: FormAction;
  /** The background color to render on all delete buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Delete -> Delete button background color (Lookup)
   * - Value : projectSettings.deleteButtonBackgroundColor */
  deleteButtonBackgroundColor: SystemColor;
  /** The icon to appear on all delete buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Delete -> Delete button icon (Text)
   * - Value : projectSettings.deleteButtonIcon */
  deleteButtonIcon: MaterialDesignIcon;
  /** The text to appear on all delete buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Delete -> Delete button text (Text)
   * - Value : projectSettings.deleteButtonText */
  deleteButtonText: string;
  /** The text color to render on all delete buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Delete -> Delete button text color (Lookup)
   * - Value : projectSettings.deleteButtonTextColor */
  deleteButtonTextColor: SystemColor;
  /** Enable the deletion of many objects at a time on a list page.
   * - Model Entity Setting: User Interface -> Functionality -> Delete Multiple In List (Yes/No)
   * - Value : false */
  deleteMultipleInList: boolean;
  /** Enable the deletion of the object on a list page.
   * - Model Entity Setting: User Interface -> Functionality -> Delete Single In List (Yes/No)
   * - Value : false */
  deleteSingleInList: boolean;
  /** Enable the deletion of the object on a view page.
   * - Model Entity Setting: User Interface -> Functionality -> Delete Single On Page (Yes/No)
   * - Value : false */
  deleteSingleOnPage: boolean;
  /** The customized form action to edit this entity.
   * - Value : [Computed @see FormAction] */
  editAction: FormAction;
  /** The background color to render on all edit buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Edit -> Edit button background color (Lookup)
   * - Value : projectSettings.editButtonBackgroundColor */
  editButtonBackgroundColor: SystemColor;
  /** The icon to appear on all edit buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Edit -> Edit button icon (Text)
   * - Value : projectSettings.editButtonIcon */
  editButtonIcon: MaterialDesignIcon;
  /** The text to appear on all edit buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Edit -> Edit button text (Text)
   * - Value : projectSettings.editButtonText */
  editButtonText: string;
  /** The text color to render on all edit buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Edit -> Edit button text color (Lookup)
   * - Value : projectSettings.editButtonTextColor */
  editButtonTextColor: SystemColor;
  /** The icon that best represents this entity.
   * - Model Entity Setting: User Interface -> User experience -> Icon (Text)
   * - Value : MaterialDesignIcon.NONE */
  icon: MaterialDesignIcon;
  /** The customized form action to insert this entity.
   * - Value : [Computed @see FormAction] */
  insertAction: FormAction;
  /** The background color to render on all insert buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Insert -> Insert button background color (Lookup)
   * - Value : projectSettings.insertButtonBackgroundColor */
  insertButtonBackgroundColor: SystemColor;
  /** The icon to appear on all insert buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Insert -> Insert button icon (Text)
   * - Value : projectSettings.insertButtonIcon */
  insertButtonIcon: MaterialDesignIcon;
  /** The text to appear on all insert buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Insert -> Insert button text (Text)
   * - Value : projectSettings.insertButtonText */
  insertButtonText: string;
  /** The text color to render on all insert buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Insert -> Insert button text color (Lookup)
   * - Value : projectSettings.insertButtonTextColor */
  insertButtonTextColor: SystemColor;
  /** The UI friendly label for this entity.
   * - Model Entity Setting: User Interface -> User experience -> UI Label (Text)
   * - Value : Puzzle */
  label: string;
  /** The customized form action to list this entity.
   * - Value : [Computed @see FormAction] */
  listAction: FormAction;
  /** The background color to render on all list buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - List -> List button background color (Lookup)
   * - Value : projectSettings.listButtonBackgroundColor */
  listButtonBackgroundColor: SystemColor;
  /** The icon to appear on all list buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - List -> List button icon (Text)
   * - Value : projectSettings.listButtonIcon */
  listButtonIcon: MaterialDesignIcon;
  /** The text to appear on all list buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - List -> List button text (Text)
   * - Value : projectSettings.listButtonText */
  listButtonText: string;
  /** The text color to render on all list buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - List -> List button text color (Lookup)
   * - Value : projectSettings.listButtonTextColor */
  listButtonTextColor: SystemColor;
  /** Enables the editing of this feature in a modal from the list view.
   * - Model Entity Setting: User Interface -> Functionality -> Modal Edit (Yes/No)
   * - Value : false */
  modalEdit: boolean;
  /** Enables the insering of this feature in a modal from the list view.
   * - Model Entity Setting: User Interface -> Functionality -> Modal Insert (Yes/No)
   * - Value : false */
  modalInsert: boolean;
  /** Enables the viewing of this feature in a modal from the list view.
   * - Model Entity Setting: User Interface -> Functionality -> Modal View (Yes/No)
   * - Value : false */
  modalView: boolean;
  /** Is the entity configured to allow for editing on a new page?
   * - Model Entity Setting: User Interface -> Functionality -> Navigate Edit (Yes/No)
   * - Value : false */
  navigateEdit: boolean;
  /** Is the entity configured to allow for inserts to a new page?
   * - Model Entity Setting: User Interface -> Functionality -> Navigate Insert (Yes/No)
   * - Value : false */
  navigateInsert: boolean;
  /** Is the entity configured to allow for views on a new page?
   * - Model Entity Setting: User Interface -> Functionality -> Navigate View (Yes/No)
   * - Value : false */
  navigateView: boolean;
  /** The routing action to execute after the insert of the entity.
   * - Model Entity Setting: User Experience -> Navigation -> Navigation after insert (Lookup)
   * - Value : projectSettings.navigationAfterInsert */
  navigationAfterInsert: PostInsertNavigationOption;
  /** List of numbers representing possible list page sizes for the entity.
   * - Model Entity Setting: User Interface -> Pagination -> Pagination Options (Text)
   * - Value : projectSettings.paginationOptions */
  paginationOptions: number[];
  /** The default page size, can be overridden at the entity level.
   * - Model Entity Setting: User Interface -> Pagination -> Pagination Size (Number)
   * - Value : projectSettings.paginationSize */
  paginationSize: number;
  /** The primary key field for the entity.
   * - Model Entity Setting: User Interface -> Pagination -> Pagination Options (Text)
   * - Value : PuzzleId */
  primaryKey: string;
  /** The original primary key field for the entity from the database.
   * - Model Entity Setting: User Interface -> Pagination -> Pagination Options (Text)
   * - Value : PuzzleId */
  primaryKeyDB: string;
  /** Should a toast appear on cancel?  If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast on Cancel (Yes/No)
   * - Value : projectSettings.toastOnCancel */
  toastOnCancel: boolean;
  /** Should a toast appear on close?  If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast on Close (Yes/No)
   * - Value : projectSettings.toastOnClose */
  toastOnClose: boolean;
  /** Should a toast appear on delete?  If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast on Delete (Yes/No)
   * - Value : projectSettings.toastOnDelete */
  toastOnDelete: boolean;
  /** Should a toast appear on exception?  If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast on Exception (Yes/No)
   * - Value : projectSettings.toastOnException */
  toastOnException: boolean;
  /** Should a toast appear on insert?  If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast on Insert (Yes/No)
   * - Value : projectSettings.toastOnInsert */
  toastOnInsert: boolean;
  /** Should a toast appear on update?  If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast on Update (Yes/No)
   * - Value : projectSettings.toastOnUpdate */
  toastOnUpdate: boolean;
  /** The default toast position.  @see ToastPositionType. If not configured it is derived from the project level settings.
   * - Model Entity Setting: User Experience -> Feedback -> Toast Position (Lookup)
   * - Value : projectSettings.toastPosition */
  toastPosition: ToastPositionType;
  /** The customized form action to update this entity.
   * - Value : [Computed @see FormAction] */
  updateAction: FormAction;
  /** The background color to render on all update buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Update -> Update button background color (Lookup)
   * - Value : projectSettings.updateButtonBackgroundColor */
  updateButtonBackgroundColor: SystemColor;
  /** The icon to appear on all update buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Update -> Update button icon (Text)
   * - Value : projectSettings.updateButtonIcon */
  updateButtonIcon: MaterialDesignIcon;
  /** The text to appear on all update buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Update -> Update button text (Text)
   * - Value : projectSettings.updateButtonText */
  updateButtonText: string;
  /** The text color to render on all update buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - Update -> Update button text color (Lookup)
   * - Value : projectSettings.updateButtonTextColor */
  updateButtonTextColor: SystemColor;
  /** The customized form action to view this entity.
   * - Value : [Computed @see FormAction] */
  viewAction: FormAction;
  /** The background color to render on all view buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - View -> View button background color (Lookup)
   * - Value : projectSettings.viewButtonBackgroundColor */
  viewButtonBackgroundColor: SystemColor;
  /** The icon to appear on all view buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - View -> View button icon (Text)
   * - Value : projectSettings.viewButtonIcon */
  viewButtonIcon: MaterialDesignIcon;
  /** The text to appear on all view buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - View -> View button text (Text)
   * - Value : projectSettings.viewButtonText */
  viewButtonText: string;
  /** The text color to render on all view buttons on this entity.
   * - Model Entity Setting: User Interface -> Action - View -> View button text color (Lookup)
   * - Value : projectSettings.viewButtonTextColor */
  viewButtonTextColor: SystemColor;

  /**
  * Function [constructor]: 
  * The constructor for the @see EntitySettingsBase class
  */
  constructor() {
      super();

    // Initialize a reference to the project settings for inheritance reasons.
    const projectSettings = new ProjectSettings();
    this.addButtonBackgroundColor = projectSettings.addButtonBackgroundColor;
    this.addButtonIcon = projectSettings.addButtonIcon;
    this.addButtonText = projectSettings.addButtonText;
    this.addButtonTextColor = projectSettings.addButtonTextColor;
    this.cancelButtonBackgroundColor = projectSettings.cancelButtonBackgroundColor;
    this.cancelButtonIcon = projectSettings.cancelButtonIcon;
    this.cancelButtonText = projectSettings.cancelButtonText;
    this.cancelButtonTextColor = projectSettings.cancelButtonTextColor;
    this.className = 'Puzzle';
    this.closeButtonBackgroundColor = projectSettings.closeButtonBackgroundColor;
    this.closeButtonIcon = projectSettings.closeButtonIcon;
    this.closeButtonText = projectSettings.closeButtonText;
    this.closeButtonTextColor = projectSettings.closeButtonTextColor;
    this.deleteButtonBackgroundColor = projectSettings.deleteButtonBackgroundColor;
    this.deleteButtonIcon = projectSettings.deleteButtonIcon;
    this.deleteButtonText = projectSettings.deleteButtonText;
    this.deleteButtonTextColor = projectSettings.deleteButtonTextColor;
    this.deleteMultipleInList = false;
    this.deleteSingleInList = false;
    this.deleteSingleOnPage = false;
    this.editButtonBackgroundColor = projectSettings.editButtonBackgroundColor;
    this.editButtonIcon = projectSettings.editButtonIcon;
    this.editButtonText = projectSettings.editButtonText;
    this.editButtonTextColor = projectSettings.editButtonTextColor;
    this.icon = MaterialDesignIcon.NONE;
    this.insertButtonBackgroundColor = projectSettings.insertButtonBackgroundColor;
    this.insertButtonIcon = projectSettings.insertButtonIcon;
    this.insertButtonText = projectSettings.insertButtonText;
    this.insertButtonTextColor = projectSettings.insertButtonTextColor;
    this.label = 'Puzzle';
    this.listButtonBackgroundColor = projectSettings.listButtonBackgroundColor;
    this.listButtonIcon = projectSettings.listButtonIcon;
    this.listButtonText = projectSettings.listButtonText;
    this.listButtonTextColor = projectSettings.listButtonTextColor;
    this.modalEdit = false;
    this.modalInsert = false;
    this.modalView = false;
    this.navigateEdit = false;
    this.navigateInsert = false;
    this.navigateView = false;
    this.navigationAfterInsert = projectSettings.navigationAfterInsert;
    this.navigationAfterInsert = projectSettings.navigationAfterInsert;
    this.paginationOptions = projectSettings.paginationOptions;
    this.paginationSize = projectSettings.paginationSize;
    this.primaryKey = 'PuzzleId';
    this.primaryKeyDB = 'PuzzleId';
    this.toastOnCancel = projectSettings.toastOnCancel;
    this.toastOnClose = projectSettings.toastOnClose;
    this.toastOnDelete = projectSettings.toastOnDelete;
    this.toastOnException = projectSettings.toastOnException;
    this.toastOnInsert = projectSettings.toastOnInsert;
    this.toastOnUpdate = projectSettings.toastOnUpdate;
    this.toastPosition = projectSettings.toastPosition;
    this.updateButtonBackgroundColor = projectSettings.updateButtonBackgroundColor;
    this.updateButtonIcon = projectSettings.updateButtonIcon;
    this.updateButtonText = projectSettings.updateButtonText;
    this.updateButtonTextColor = projectSettings.updateButtonTextColor;
    this.viewButtonBackgroundColor = projectSettings.viewButtonBackgroundColor;
    this.viewButtonIcon = projectSettings.viewButtonIcon;
    this.viewButtonText = projectSettings.viewButtonText;
    this.viewButtonTextColor = projectSettings.viewButtonTextColor;
    super.toastSettings = {
      toastOnCancel: this.toastOnCancel,
      toastOnClose: this.toastOnClose,
      toastOnDelete: this.toastOnDelete,
      toastOnInsert: this.toastOnInsert,
      toastOnUpdate: this.toastOnUpdate,
      toastOnException: this.toastOnException,
      toastPosition: this.toastPosition,
    };
    this.addAction = new FormAction(projectSettings.addActionName, this.addButtonText, false, this.addButtonIcon, this.addButtonTextColor, this.addButtonBackgroundColor);
    this.cancelAction = new FormAction(projectSettings.cancelActionName, this.cancelButtonText, false, this.cancelButtonIcon, this.cancelButtonTextColor, this.cancelButtonBackgroundColor);
    this.closeAction = new FormAction(projectSettings.closeActionName, this.closeButtonText, false, this.closeButtonIcon, this.closeButtonTextColor, this.closeButtonBackgroundColor);
    this.deleteAction = new FormAction(projectSettings.deleteActionName, this.deleteButtonText, true, this.deleteButtonIcon, this.deleteButtonTextColor, this.deleteButtonBackgroundColor);
    this.editAction = new FormAction(projectSettings.editActionName, this.editButtonText, true, this.editButtonIcon, this.editButtonTextColor, this.editButtonBackgroundColor);
    this.insertAction = new FormAction(projectSettings.insertActionName, this.insertButtonText, true, this.insertButtonIcon, this.insertButtonTextColor, this.insertButtonBackgroundColor);
    this.listAction = new FormAction(projectSettings.listActionName, this.listButtonText, true, this.listButtonIcon, this.listButtonTextColor, this.listButtonBackgroundColor);
    this.updateAction = new FormAction(projectSettings.updateActionName, this.updateButtonText, true, this.updateButtonIcon, this.updateButtonTextColor, this.updateButtonBackgroundColor);
    this.viewAction = new FormAction(projectSettings.viewActionName, this.viewButtonText, true, this.viewButtonIcon, this.viewButtonTextColor, this.viewButtonBackgroundColor);
  } // constructor

}
