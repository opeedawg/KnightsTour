<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h1>You have been signed out as requested.</h1>
  </div>
</template>

<script lang="ts">
import { SessionStorage } from 'quasar';
import { UtilityInstance } from 'src/models/Support/global';

export default {
  Name: 'LogoutPage',
  data() {
    return {
      utilityInstance: UtilityInstance,
    };
  },
  created() {
    if (this.utilityInstance.GetHistory() != '')
      this.utilityInstance.ReloadScreen(true);
    SessionStorage.clear();
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
