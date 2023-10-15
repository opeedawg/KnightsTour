<template>
  <q-layout view="lHh lpr lFf">
    <q-header class="app-headerSection" elevated>
      <q-toolbar>
        <q-btn dense flat icon="menu" round @click="toggleLeftDrawer" />

        <q-toolbar-title>
          <headerComponent />
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer show-if-above
              v-model="leftDrawerOpen"
              class="app-drawerSection"
              :breakpoint="700"
              :width="300"
              elevated
              side="left">
      <menuComponent />
    </q-drawer>

    <q-page-container>
      <q-inner-loading :showing="!pageLoaded"
                       color="primary"
                       label="Loading..."
                       size="100px"
                       transition-duration="1000"
                       transition-hide="scale"
                       transition-show="scale" />
      <router-view />
    </q-page-container>

    <q-footer class="bg-grey-8 text-white app-footerSection" bordered reveal>
      <footerComponent />
    </q-footer>
  </q-layout>
</template>

<script lang="ts">
  import { ref, defineComponent } from 'vue';
  import footerComponent from '../components/FooterComponent.vue';
  import headerComponent from '../components/HeaderComponent.vue';
  import menuComponent from '../components/MenuComponent.vue';

  export default defineComponent({
    name: 'AuthenticatedLayout',
    components: {
      footerComponent,
      headerComponent,
      menuComponent,
    },
    setup() {
      const leftDrawerOpen = ref(false);

      return {
        leftDrawerOpen,
        toggleLeftDrawer() {
          leftDrawerOpen.value = !leftDrawerOpen.value;
        },
      };
    },
    data() {
      return {
        pageLoaded: false,
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
