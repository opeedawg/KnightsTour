import { api } from 'src/boot/axios';
import { AxiosError, AxiosResponse } from 'axios';
import { DXResponse } from '../models/dxterity';
import { Environment } from '../models/environment';

export class BaseService {
  restPath: string;
  constructor(restEndpoint: string) {
    this.restPath = Environment.getInstance().apiRoot + restEndpoint;
  }
  public ProcessServiceError(error: AxiosError) {
    if (Environment.getInstance().debug) {
      throw error.message + ' in ' + this.restPath + ': ' + error.code;
    }
  }

  /**
   * Custom function [getSelectOptions]:
   * Retrives a list of values for binding to a select field.
   * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
   */
  public async getSelectOptions(
    filter: string
  ): Promise<AxiosResponse<DXResponse>> {
    try {
      return await api.post(this.restPath, {
        selectionFilter: filter,
      });
    } catch (error) {
      this.ProcessServiceError(error as AxiosError);
      return Promise.reject(error);
    }
  } // getSelectOptions

  /**
   * Custom function [getSelectOption]:
   * Retrives a single value for binding to a select field.
   * @returns {Promise<AxiosResponse<DXResponse>>} The promise of an object of type @see AxiosResponse<DXResponse>.
   */
  public async getSelectOption(
    filter: string,
    value: string
  ): Promise<AxiosResponse<DXResponse>> {
    try {
      this.restPath = '';
      return await api.post(this.restPath + '/single', {
        selectionFilter: filter,
        value: value,
      });
    } catch (error) {
      this.ProcessServiceError(error as AxiosError);
      return Promise.reject(error);
    }
  } // getSelectOption
}
