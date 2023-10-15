// Imports
import { DXResponse } from 'src/common/models/dxterity';
import { BaseService } from '../services/base.service';

/**
 * Class: BaseStore
 *
 * Class to implement any decoration on data returned from the api service endpoints.
 *
 * @implements {getSelectOptions} Performs the retrieval of generic select lookup options.
 */
export class BaseStore {
  service: BaseService;

  constructor() {
    // This is a spcecial case, a new service instance should be initialted with the proper endpoint in each call.
    this.service = new BaseService('');
  }

  /**
   * Function [getSelectOptions]:
   * Retrives a list of select values for binding to a select field..
   * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
   */
  async getSelectOptions(filter: string): Promise<DXResponse> {
    this.service = new BaseService('lookup');
    const result = await this.service.getSelectOptions(filter);

    return result.data;
  } // getSelectOptions

  /**
   * Function [getSelectOption]:
   * Retrives a list of select values for binding to a select field..
   * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
   */
  async getSelectOption(filter: string, value: string): Promise<DXResponse> {
    this.service = new BaseService('lookup');
    const result = await this.service.getSelectOption(filter, value);

    return result.data;
  } // getSelectOptions

  /**
   * Function [getEnvironmentSettings]:
   * Retrives a complete set of required enviromnetal settings.
   * @returns {Promise<DXResponse>} The promise of an object of type @see DXResponse.
   */
  async getEnvironmentSettings(): Promise<DXResponse> {
    this.service = new BaseService('lookup');
    const result = await this.service.getEnvironmentSettings();

    return result.data;
  } // getEnvironmentSettings
}
