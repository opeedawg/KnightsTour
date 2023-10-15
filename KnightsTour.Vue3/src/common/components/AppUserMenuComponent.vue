<template>
  <div class="app-userDropdown">
    <div class="app-profileCircle">
      <p class="app-userInitials">{{ userInitials }}</p>
      <q-popup-proxy class=".app-userPopup"
                     transition-show="scale"
                     transition-hide="scale"
                     touch-position="true">
        <q-banner>
          <div class="app-userName">
            <q-icon class="app-userIcon"
                    :name="materialDesignIcon.Person"
                    :color="systemColor.Primary" />
            <p>{{ userFullName }}</p>
          </div>
          <p>
            Last Logged In:
            <i>{{ currentUser.lastLoginDate }}</i>
          </p>
          <p class="app-userLogout" @click="logout()">Logout</p>
        </q-banner>
      </q-popup-proxy>
    </div>
  </div>
</template>

<script lang="ts">
import { Authentication } from '../models/authentication';
import {
  MaterialDesignIcon,
  SystemColor,
  UtilityInstance,
} from '../models/global';
import { DXAuthenticatedUser } from '../models/dxterity';

export default {
  name: 'AppUserMenu',

  data() {
    return {
      /**The authenticated logged in user. */
      currentUser: new DXAuthenticatedUser(),
      materialDesignIcon: MaterialDesignIcon,
      systemColor: SystemColor,
      userInitials: '',
      userFullName: '',
    };
  },

  mounted() {
    const auth = new Authentication();
    const context = this;
    auth.getCurrentUser().then(function (user: DXAuthenticatedUser | null) {
      if (user != null) {
        context.currentUser = user;
        context.userInitials = `${context.currentUser.firstName.charAt(
          0
        )}${context.currentUser.lastName.charAt(0)}`;
        context.userFullName = `${context.currentUser.firstName} ${context.currentUser.lastName}`;
      }
    });
  },
  methods: {
    logout() {
      UtilityInstance.logout();
    },
  },
};
</script>

<style lang="scss" scoped>
  @import '../../css/app.scss';
</style>
