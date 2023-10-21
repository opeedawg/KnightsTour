import { boot } from 'quasar/wrappers';
import axios from 'axios';

const apiRoot = 'http://localhost:3131/rest/mediaCentre/';

const api = axios.create({
  baseURL: apiRoot,
  withCredentials: false,
});

export default boot(({ app }) => {
  app.config.globalProperties.$axios = axios;
  app.config.globalProperties.$api = api;
});

export { axios, api };
