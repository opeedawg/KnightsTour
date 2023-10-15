<template>
  <div class="app-header">
    <h3>{{ projectSettings.name }}</h3>
    <AppUserMenu />
  </div>
</template>

<script lang="ts">
  import { ProjectSettings } from 'src/common/models/projectSettings';
  import AppUserMenu from 'src/common/components/AppUserMenuComponent.vue';
  export default {
    name: 'headerComponent',
    components: {
      AppUserMenu,
    },
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
