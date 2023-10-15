import { GenericConfirmationArgs } from './arguments';
import { DXCustomAction } from './dxterity';
import { IEntitySettings } from './interfaces';

/** The system defined message types. */
export enum MessageType {
  /** Params = null */
  FormClosed = 'Form closed',
  /** Params = null */
  EditCancelled = 'Edit cancelled',
  /** Params = null */
  DeleteCancelled = 'Delete cancelled',
  /** Params = ['entitySettings'] */
  DeleteSuccess = 'Delete success',
  /** Params = ['entitySettings', 'instanceLabel'] */
  DeleteSingleConfirmation = 'Delete single confirmation',
  /** Params = null */
  DeleteSingleConfirmationTitle = 'Delete single confirmation title',
  /** Params = null */
  DeleteSingleConfirmationText = 'Delete single confirmation text',
  /** Params = null */
  DeleteSingleCancelText = 'Delete single cancel title',
  /** Params = ['entitySettings', 'error'] */
  DeleteSingleFailed = 'Delete single failed',
  /** Params = ['confirmationArgs'] */
  GenericConfirmation = 'Generic confirmation',
  /** Params = null */
  InsertCanceled = 'Insert cancelled',
  /** Params = ['entitySettings', 'error'] */
  InsertFailed = 'Insert failed',
  /** Params = ['entitySettings'] */
  InsertSuccess = 'Insert success',
  /**Params = ['operation'] */
  OperationSuccess = 'Operation success',
  /**Params = ['operation'] */
  OperationFailed = 'Operation failed',
  /** Params = ['entitySettings', 'error'] */
  UpdateFailed = 'Update failed',
  /** Params = ['entitySettings'] */
  UpdateSuccess = 'Update success',
}
export class Messaging {
  getMessage(type: MessageType, params?: any): string {
    switch (type) {
      case MessageType.DeleteCancelled: {
        return 'Delete cancelled.';
      }
      case MessageType.DeleteSuccess: {
        const expectedParams = ['entitySettings'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          return 'The ' + entitySettings.label + ' was deleted successfully.';
        }
      }
      case MessageType.DeleteSingleConfirmationTitle: {
        return 'Delete confirmation.';
      }
      case MessageType.DeleteSingleConfirmationText: {
        return 'Delete';
      }
      case MessageType.DeleteSingleCancelText: {
        return 'Cancel';
      }
      case MessageType.DeleteSingleConfirmation: {
        const expectedParams = ['entitySettings', 'instanceLabel'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          const instanceLabel = params.instanceLabel as string;
          return (
            'Are you sure you want to delete the ' +
            entitySettings.label +
            ' ' +
            instanceLabel +
            '?'
          );
        }
      }
      case MessageType.DeleteSingleFailed: {
        const expectedParams = ['entitySettings', 'error'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          const error = params.message as string;
          return 'Error deleting the ' + entitySettings.label + ': ' + error;
        }
      }
      case MessageType.EditCancelled: {
        return 'Edit cancelled.';
      }
      case MessageType.FormClosed: {
        return 'Form closed.';
      }
      case MessageType.GenericConfirmation: {
        const expectedParams = ['genericConfirmationArgs'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const genericConfirmationArgs =
            params.genericConfirmationArgs as GenericConfirmationArgs;
          return (
            genericConfirmationArgs.id +
            ' executed with response ' +
            genericConfirmationArgs.result
          );
        }
      }
      case MessageType.InsertFailed: {
        const expectedParams = ['entitySettings', 'error'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          const error = params.message as string;
          return 'Error inserting the ' + entitySettings.label + ': ' + error;
        }
      }
      case MessageType.InsertSuccess: {
        const expectedParams = ['entitySettings'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          return entitySettings.label + ' successfully inserted.';
        }
      }
      case MessageType.InsertCanceled: {
        return 'Insert cancelled.';
      }
      case MessageType.OperationSuccess: {
        const expectedParams = ['customAction'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const operation = params.operation as DXCustomAction;
          return (
            'Operation ' +
            operation.value +
            ' was performed against ' +
            operation.selectedItems.length +
            ' features.'
          );
        }
      }
      case MessageType.OperationFailed: {
        const expectedParams = ['customAction'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const operation = params.operation as DXCustomAction;
          return (
            'A problem occurred while executing operation ' +
            operation +
            ' against ' +
            operation.selectedItems.length +
            ' features: '
          );
        }
      }
      case MessageType.UpdateFailed: {
        const expectedParams = ['entitySettings', 'error'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          const error = params.error as any;
          return (
            'Error updating the ' + entitySettings.label + ': ' + error.message
          );
        }
      }
      case MessageType.UpdateSuccess: {
        const expectedParams = ['entitySettings'];
        if (!this.hasParameters(expectedParams, params)) {
          return this.expectedParamErrorMessage(expectedParams);
        } else {
          const entitySettings = params.entitySettings as IEntitySettings;
          return entitySettings.label + ' successfully updated.';
        }
      }
      default: {
        return 'Unconfigured MessageType: ' + type;
      }
    }
  }

  hasParameters(parameterNames: string[], params?: any): boolean {
    parameterNames.forEach((paramName: string) => {
      if (!params.hasOwnProperty(paramName)) {
        return false;
      }
    });

    // Otherwise all the properties exist;
    return true;
  }

  expectedParamErrorMessage(paramNames: string[]): string {
    if (paramNames.length == 1) {
      return (
        'Messaging configuration error: Missing expected parameter: ' +
        paramNames[0] +
        '.'
      );
    } else {
      return (
        'Messaging configuration error: Missing expected parameters: ' +
        paramNames.join() +
        '.'
      );
    }
  }
}
