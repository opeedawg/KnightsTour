<template>
  <p class="app-footerSection-text">{{ projectSettings.footerText }}</p>
</template>

<script lang="ts">
  import { ProjectSettings } from '../models/projectSettings';

  export default {
    name: 'footerComponent',
    data() {
      return {
        projectSettings: new ProjectSettings(),
      };
    },
  };
</script>

<style lang="scss">
  @import '../../css/app.scss';
</style>
