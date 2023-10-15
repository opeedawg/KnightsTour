import { BaseStore } from '../stores/base.store';
import { DXResponse } from './dxterity';

export class Environment {
  private static instance: Environment;
  mode: string;
  apiRoot: string;
  debug: boolean;
  showNotProductionMessage: boolean;
  notProductionMessageAcknowledgeDate: Date | null;
  timeoutDuration: number;
  timeoutAlertDuration: number;
  timeoutRefreshDuration: number;
  publicPath: string;
  serverSettingsLoaded: boolean;

  //modern-dev, modern-qa, modern-demo, Dev, Stage, Training, prod
  constructor() {
    // Think of this section as the "default" settings.
    this.serverSettingsLoaded = false;
    this.mode = 'local';
    this.apiRoot = '';
    this.debug = false;
    this.notProductionMessageAcknowledgeDate = null;
    this.publicPath = '';
    // Set to defaults.
    this.timeoutDuration = 15 * 60;
    this.timeoutAlertDuration = 120;
    this.timeoutRefreshDuration = 30;
    this.showNotProductionMessage = false;

    if (process.env.mode != null) {
      this.mode = process.env.mode.toLowerCase();

      // This is a special case, we promote with a "Varaibale" based environment that gets set in the build script.
      // If this wasn't set, then we must be in dev mode!
      // Winning :p
      if (this.mode === '{env}' || this.mode === '') {
        this.mode = 'local';
      }

      switch (this.mode.toLowerCase()) {
        case 'local':
          this.apiRoot = 'http://localhost:3131/rest/';
          this.debug = true;
          break;

        case 'production':
          this.apiRoot = 'https://www.production.com/rest/';
          break;
      }
    }
  }

  public static getInstance(): Environment {
    if (!Environment.instance) {
      Environment.instance = new Environment();
    }

    return Environment.instance;
  }

  public async LoadServerSettings(): Promise<void> {
    const store = new BaseStore();
    const self = this;
    // We force a result because we actually want to block here, the settings must be loaded prior to continuing work!
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    const result = await store
      .getEnvironmentSettings()
      .then(function (response: DXResponse) {
        if (response.isValid) {
          self.timeoutDuration = response.dataObject.timeoutDuration;
          self.timeoutAlertDuration = response.dataObject.timeoutAlertDuration;
          self.timeoutRefreshDuration =
            response.dataObject.timeoutRefreshDuration;
          self.showNotProductionMessage =
            response.dataObject.showNotProductionMessage;
          self.serverSettingsLoaded = true;
        }
      });
  }
}
