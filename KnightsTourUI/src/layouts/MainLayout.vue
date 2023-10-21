<template>
  <q-layout view="hHh lpR fFf">
    <q-header
      reveal
      bordered
      class="bg-grey-10 text-grey-6"
      style="border-bottom: solid 1px white"
    >
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />

        <q-toolbar-title class="text-center">
          <span class="header">
            <q-avatar>
              <img src="/images/WhiteKnight.svg" />
            </q-avatar>
            Knights Tour Puzzles</span
          >
        </q-toolbar-title>
        <q-btn-dropdown split :color="ddColor" push no-caps>
          <template v-slot:label>
            <div class="row items-center no-wrap">
              <q-avatar text-color="white" size="30px" class="q-mr-md">
                <q-icon name="person" />
              </q-avatar>
              <div class="text-center white">{{ displayName }}</div>
            </div>
          </template>

          <q-list>
            <q-item
              v-if="member.memberId == 0"
              clickable
              v-close-popup
              @click="onUserMenuClick('signUp')"
            >
              <q-item-section avatar>
                <q-avatar
                  icon="add_circle_outline"
                  color="orange"
                  text-color="white"
                />
              </q-item-section>
              <q-item-section>
                <q-item-label>Sign Up</q-item-label>
                <q-item-label caption
                  >Not a member? Sign up today, it's free!</q-item-label
                >
              </q-item-section>
            </q-item>
            <q-item
              v-if="member.memberId == 0"
              clickable
              v-close-popup
              @click="onUserMenuClick('signIn')"
            >
              <q-item-section avatar>
                <q-avatar icon="login" color="green" text-color="white" />
              </q-item-section>
              <q-item-section>
                <q-item-label>Sign In</q-item-label>
                <q-item-label caption
                  >Already a member? Sign in now</q-item-label
                >
              </q-item-section>
            </q-item>
            <q-item
              v-if="member.memberId == 0"
              clickable
              v-close-popup
              @click="onUserMenuClick('clearNonMemberName')"
            >
              <q-item-section avatar>
                <q-avatar icon="backspace" color="red" text-color="white" />
              </q-item-section>
              <q-item-section>
                <q-item-label>Clear Name</q-item-label>
                <q-item-label caption
                  >Clear your temporary display name.</q-item-label
                >
              </q-item-section>
            </q-item>
            <q-item
              v-if="member.memberId > 0"
              clickable
              v-close-popup
              @click="onUserMenuClick('memberStatistics')"
            >
              <q-item-section avatar>
                <q-avatar icon="bar_chart" color="primary" text-color="white" />
              </q-item-section>
              <q-item-section>
                <q-item-label>Statistics</q-item-label>
                <q-item-label caption>View your statistics</q-item-label>
              </q-item-section>
            </q-item>
            <q-item
              v-if="member.memberId > 0"
              clickable
              v-close-popup
              @click="onUserMenuClick('changePassword')"
            >
              <q-item-section avatar>
                <q-avatar
                  icon="verified_user"
                  color="orange"
                  text-color="white"
                />
              </q-item-section>
              <q-item-section>
                <q-item-label>Change Password</q-item-label>
                <q-item-label caption>Change your password often!</q-item-label>
              </q-item-section>
            </q-item>
            <q-item
              v-if="member.memberId > 0"
              clickable
              v-close-popup
              @click="onUserMenuClick('logout')"
            >
              <q-item-section avatar>
                <q-avatar icon="logout" color="red" text-color="white" />
              </q-item-section>
              <q-item-section>
                <q-item-label>Logout</q-item-label>
                <q-item-label caption
                  >Logout and secure this browser</q-item-label
                >
              </q-item-section>
            </q-item>
          </q-list>
        </q-btn-dropdown>
      </q-toolbar>
    </q-header>

    <q-drawer
      class="bg-grey-10 text-grey-6"
      v-model="leftDrawerOpen"
      side="left"
      bordered
    >
      <q-list>
        <template
          v-for="(menuItem, index) in utilityInstance.menuList"
          :key="index"
        >
          <q-item
            clickable
            :active="menuItem.label === utilityInstance.breadCrumb"
            v-ripple
            @click="onMenuNavigationClick(menuItem.route)"
            active-class="selectedMenuLink"
          >
            <q-item-section avatar>
              <q-icon :name="menuItem.icon" :color="menuItem.iconColor" />
            </q-item-section>
            <q-item-section>
              {{ menuItem.label }}
            </q-item-section>
          </q-item>
          <q-separator
            :key="'sep' + index"
            v-if="menuItem.separator"
            color="grey-6"
          />
        </template>
      </q-list>
    </q-drawer>

    <q-page-container class="bg-grey-10 text-grey-6" style="height: 100vh">
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import { SessionStorage } from 'quasar';
import { Member } from 'src/models/Member';
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';
import { ref } from 'vue';

export default {
  setup() {
    const utilityInstance = ref(UtilityInstance);
    const leftDrawerOpen = ref(true);
    const member = ref(new Member());
    const displayName = ref('Guest');
    const ddColor = ref('grey-6');

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
      displayName.value = 'Welcome back ' + member.value.displayName + '!';
      ddColor.value = 'secondary';
    } else {
      let nonMemberName = SessionStorage.getItem('nonMemberName');
      if (nonMemberName && nonMemberName.toString().length > 0)
        displayName.value = nonMemberName.toString() + ' (Guest)';
    }

    function toggleLeftDrawer() {
      leftDrawerOpen.value = !leftDrawerOpen.value;
    }

    function onUserMenuClick(action: string) {
      if (action == 'signIn') {
        utilityInstance.value.Navigate(ScreenRoute.SignIn);
      } else if (action == 'signUp') {
        utilityInstance.value.Navigate(ScreenRoute.SignUp);
      } else if (action == 'logout') {
        utilityInstance.value.Navigate(ScreenRoute.Logout, true);
      } else if (action == 'changePassword') {
        utilityInstance.value.Navigate(ScreenRoute.ChangePassword);
      } else if (action == 'memberStatistics') {
        utilityInstance.value.Navigate(ScreenRoute.MemberStatistics);
      } else if (action == 'clearNonMemberName') {
        SessionStorage.remove('nonMemberName');
        displayName.value = 'Guest';
        utilityInstance.value.Navigate(ScreenRoute.PlayNow, true);
      }
      //
    }

    function onMenuNavigationClick(route: ScreenRoute) {
      utilityInstance.value.Navigate(route);
    }

    return {
      leftDrawerOpen,
      member,
      toggleLeftDrawer,
      onMenuNavigationClick,
      onUserMenuClick,
      utilityInstance,
      displayName,
      ddColor,
    };
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
