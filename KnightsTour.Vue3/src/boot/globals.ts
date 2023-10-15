import { boot } from 'quasar/wrappers';

const genericModalVisible = false;

export default boot(async ({ app }) => {
  app.config.globalProperties.$genericModalVisible = genericModalVisible;
});

export { genericModalVisible };
