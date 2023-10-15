/**
 * File:     projectSettingsBase.ts
 * Location: src\common\models\
 * The project settings that stay in sync with the DXterity model.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on October 14, 2023 at 10:21:16 AM
 */

// Imports
import { MaterialDesignIcon, PostInsertNavigationOption, SystemColor, ToastPositionType } from './enumerations';

/**
* Abstract Class: ProjectSettingsBase
*
* Class to define all the possible project settings.  Stays in sync with the model on regeneration.  Add or overwrite in @see ProjectSettings.
*
* @implements {constructor} The constructor for the @see ProjectSettingsBase class
*/
export abstract class ProjectSettingsBase {
  // *** Declarations ***
  /** The action name when performing the add function on an entity: add */
  addActionName: string;
  /** The background color to render on all add buttons: Primary */
  addButtonBackgroundColor: SystemColor;
  /** The icon to appear on all add buttons: AddCircle */
  addButtonIcon: MaterialDesignIcon;
  /** The text to appear on all add buttons: Add */
  addButtonText: string;
  /** The text color to render on all add buttons: White */
  addButtonTextColor: SystemColor;
  /** The action name when performing the cancel function on an entity: cancel */
  cancelActionName: string;
  /** The background color to render on all cancel buttons: secondary */
  cancelButtonBackgroundColor: SystemColor;
  /** The icon to appear on all cancel buttons: Cancel */
  cancelButtonIcon: MaterialDesignIcon;
  /** The text to appear on all cancel buttons: Cancel */
  cancelButtonText: string;
  /** The text color to render on all cancel buttons: Black */
  cancelButtonTextColor: SystemColor;
  /** The action name when performing the close function on an entity: close */
  closeActionName: string;
  /** The background color to render on all close buttons: Gray */
  closeButtonBackgroundColor: SystemColor;
  /** The icon to appear on all close buttons: KeyboardReturn */
  closeButtonIcon: MaterialDesignIcon;
  /** The text to appear on all close buttons: Close */
  closeButtonText: string;
  /** The text color to render on all close buttons: White */
  closeButtonTextColor: SystemColor;
  /** The default date format: yyyy-MM-dd */
  dateFormat: string;
  /** The action name when performing the delete function on an entity: delete */
  deleteActionName: string;
  /** The background color to render on all delete buttons: Red */
  deleteButtonBackgroundColor: SystemColor;
  /** The icon to appear on all delete buttons: Delete */
  deleteButtonIcon: MaterialDesignIcon;
  /** The text to appear on all delete buttons: Delete  */
  deleteButtonText: string;
  /** The text color to render on all delete buttons: White */
  deleteButtonTextColor: SystemColor;
  /** The action name when performing the edit function on an entity: edit */
  editActionName: string;
  /** The background color to render on all edit buttons: Primary */
  editButtonBackgroundColor: SystemColor;
  /** The icon to appear on all edit buttons: Edit */
  editButtonIcon: MaterialDesignIcon;
  /** The text to appear on all edit buttons: Edit */
  editButtonText: string;
  /** The text color to render on all edit buttons: White */
  editButtonTextColor: SystemColor;
  /** The text to place in the footer: Your custom footer */
  footerText: string;
  /** The action name when performing the insert function on an entity: insert */
  insertActionName: string;
  /** The background color to render on all insert buttons: Green */
  insertButtonBackgroundColor: SystemColor;
  /** The icon to appear on all insert buttons: Add */
  insertButtonIcon: MaterialDesignIcon;
  /** The text to appear on all insert buttons: Insert  */
  insertButtonText: string;
  /** The text color to render on all insert buttons: White */
  insertButtonTextColor: SystemColor;
  /** The last time this settings file was synced with the DXterity model: October 14, 2023 10:21:16 AM */
  lastUpdated: Date;
  /** The action name when performing the list function on an entity: list */
  listActionName: string;
  /** The background color to render on all list buttons: Yellow */
  listButtonBackgroundColor: SystemColor;
  /** The icon to appear on all list buttons: FormatListBulleted */
  listButtonIcon: MaterialDesignIcon;
  /** The text to appear on all list buttons: List */
  listButtonText: string;
  /** The text color to render on all list buttons: Black */
  listButtonTextColor: SystemColor;
  /** The path to the logo URL:  */
  logoUrl: string;
  /** The application name: Knights Tour */
  name: string;
  /** The routing action to execute after the insert of the entity: View */
  navigationAfterInsert: PostInsertNavigationOption;
  /** A numeric array of numbers representing the various page sizes: [10,25,50,100] */
  paginationOptions: number[];
  /** The default page size, can be overridden at the entity level: 15 */
  paginationSize: number;
  /** Determines whether or not all form controls should be rendered in dense form or not: true */
  renderDenseControls: boolean;
  /** Should a toast appear on cancel?  Can be overridden at the entity level: false */
  toastOnCancel: boolean;
  /** Should a toast appear on close?  Can be overridden at the entity level: false */
  toastOnClose: boolean;
  /** Should a toast appear on delete?  Can be overridden at the entity level: false */
  toastOnDelete: boolean;
  /** Should a toast appear on exception?  Can be overridden at the entity level: true */
  toastOnException: boolean;
  /** Should a toast appear on insert?  Can be overridden at the entity level: false */
  toastOnInsert: boolean;
  /** Should a toast appear on update?  Can be overridden at the entity level: false */
  toastOnUpdate: boolean;
  /** The default toast position.  @see ToastPositionType. Can be overridden at the entity level: Center */
  toastPosition: ToastPositionType;
  /** The action name when performing the update function on an entity: update */
  updateActionName: string;
  /** The background color to render on all update buttons: Primary */
  updateButtonBackgroundColor: SystemColor;
  /** The icon to appear on all update buttons: Save */
  updateButtonIcon: MaterialDesignIcon;
  /** The text to appear on all update buttons: Update */
  updateButtonText: string;
  /** The text color to render on all update buttons: White */
  updateButtonTextColor: SystemColor;
  /** The action name when performing the view function on an entity: view */
  viewActionName: string;
  /** The background color to render on all view buttons: Black */
  viewButtonBackgroundColor: SystemColor;
  /** The icon to appear on all view buttons: Description */
  viewButtonIcon: MaterialDesignIcon;
  /** The text to appear on all view buttons: View */
  viewButtonText: string;
  /** The text color to render on all view buttons: White */
  viewButtonTextColor: SystemColor;

  /**
  * Function [constructor]: 
  * The constructor for the @see ProjectSettingsBase class
  */
  constructor() {
    this.addActionName = 'add';
    this.addButtonBackgroundColor = SystemColor.Primary;
    this.addButtonIcon = MaterialDesignIcon.AddCircle;
    this.addButtonText = 'Add';
    this.addButtonTextColor = SystemColor.White;
    this.cancelActionName = 'cancel';
    this.cancelButtonBackgroundColor = SystemColor.Secondary;
    this.cancelButtonIcon = MaterialDesignIcon.Cancel;
    this.cancelButtonText = 'Cancel';
    this.cancelButtonTextColor = SystemColor.Black;
    this.closeActionName = 'close';
    this.closeButtonBackgroundColor = SystemColor.Gray;
    this.closeButtonIcon = MaterialDesignIcon.KeyboardReturn;
    this.closeButtonText = 'Close';
    this.closeButtonTextColor = SystemColor.White;
    this.dateFormat = 'yyyy-MM-dd';
    this.deleteActionName = 'delete';
    this.deleteButtonBackgroundColor = SystemColor.Red;
    this.deleteButtonIcon = MaterialDesignIcon.Delete;
    this.deleteButtonText = 'Delete ';
    this.deleteButtonTextColor = SystemColor.White;
    this.editActionName = 'edit';
    this.editButtonBackgroundColor = SystemColor.Primary;
    this.editButtonIcon = MaterialDesignIcon.Edit;
    this.editButtonText = 'Edit';
    this.editButtonTextColor = SystemColor.White;
    this.footerText = 'Your custom footer';
    this.insertActionName = 'insert';
    this.insertButtonBackgroundColor = SystemColor.Green;
    this.insertButtonIcon = MaterialDesignIcon.Add;
    this.insertButtonText = 'Insert ';
    this.insertButtonTextColor = SystemColor.White;
    this.lastUpdated = new Date('2023-10-14T10:21:16');
    this.listActionName = 'list';
    this.listButtonBackgroundColor = SystemColor.Yellow;
    this.listButtonIcon = MaterialDesignIcon.FormatListBulleted;
    this.listButtonText = 'List';
    this.listButtonTextColor = SystemColor.Black;
    this.logoUrl = '';
    this.name = 'Knights Tour';
    this.navigationAfterInsert = PostInsertNavigationOption.View;
    this.paginationOptions = [10,25,50,100];
    this.paginationSize = 15;
    this.renderDenseControls = true;
    this.toastOnCancel = false;
    this.toastOnClose = false;
    this.toastOnDelete = false;
    this.toastOnException = true;
    this.toastOnInsert = false;
    this.toastOnUpdate = false;
    this.toastPosition = ToastPositionType.Center;
    this.updateActionName = 'update';
    this.updateButtonBackgroundColor = SystemColor.Primary;
    this.updateButtonIcon = MaterialDesignIcon.Save;
    this.updateButtonText = 'Update';
    this.updateButtonTextColor = SystemColor.White;
    this.viewActionName = 'view';
    this.viewButtonBackgroundColor = SystemColor.Black;
    this.viewButtonIcon = MaterialDesignIcon.Description;
    this.viewButtonText = 'View';
    this.viewButtonTextColor = SystemColor.White;
  } // constructor

}
