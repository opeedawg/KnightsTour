<template>
  <q-layout view="lhh lpr lFf">
    <q-header class="app-headerSection" elevated>
      <q-toolbar>
        <q-toolbar-title>
          <headerComponent :showUserMenu="false" />
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <q-inner-loading
        :showing="!pageLoaded"
        color="primary"
        label="Loading..."
        size="100px"
        transition-duration="1000"
        transition-hide="scale"
        transition-show="scale"
      />
      <router-view />
    </q-page-container>

    <q-footer class="bg-grey-8 text-white app-footerSection" bordered reveal>
      <footerComponent />
    </q-footer>
  </q-layout>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import footerComponent from '../components/FooterComponent.vue';
import headerComponent from '../components/HeaderComponent.vue';
import { LastUserActionTime } from '../../boot/globals';

export default defineComponent({
  name: 'AuthenticatedLayout',
  components: {
    footerComponent,
    headerComponent,
  },
  data() {
    return {
      pageLoaded: false,
      lastUserActionTime: LastUserActionTime,
      timeSinceLastAction: 0,
    };
  },
  mounted() {
    this.pageLoaded = true;
  },
});
</script>
<style lang="scss">
@import '../../css/app.scss';
</style>
