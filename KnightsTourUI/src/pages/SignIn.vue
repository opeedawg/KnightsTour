<!-- eslint-disable @typescript-eslint/no-this-alias -->
<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%; width: 100%">
    <div>
      <q-card
        square
        bordered
        class="q-pa-lg shadow-1 center"
        dark
        style="width: 460px"
      >
        <q-card-section>
          <q-form class="q-gutter-md">
            <h4>Sign In</h4>
            <q-input
              square
              filled
              bg-color="white"
              bottom-slots
              clearable
              v-model="emailAddress"
              label="Email Address"
            >
              <template v-slot:prepend>
                <q-icon name="email" />
              </template>

              <template v-slot:hint>
                <p class="hint">The email address you registered with.</p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              clearable
              bottom-slots
              v-model="password"
              type="password"
              label="Password"
              v-on:keyup.enter="signIn"
            >
              <template v-slot:prepend>
                <q-icon name="password" />
              </template>

              <template v-slot:hint>
                <p class="hint">Your super private and secure password.</p>
              </template>
            </q-input>
          </q-form>
        </q-card-section>
        <q-card-actions class="q-px-md">
          <q-btn
            unelevated
            color="green"
            label="Sign In"
            @click="signIn"
            icon="login"
          />
          <q-btn
            unelevated
            color="primary"
            label="Not a member yet? Register"
            @click="register"
            icon="how_to_reg"
          />
        </q-card-actions>
      </q-card>
    </div>
  </div>
</template>

<script lang="ts">
import { SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { DXResponse } from 'src/models/Support/dxterity';
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';

export default {
  Name: 'SignIn',
  data() {
    return {
      emailAddress: '',
      password: '',
      api: new ApiService(),
      utilityInstance: UtilityInstance,
    };
  },
  setup() {
    return {};
  },
  methods: {
    register: function () {
      this.utilityInstance.Navigate(ScreenRoute.SignUp);
    },
    signIn: function () {
      let self = this;
      this.api
        .signIn(this.emailAddress, this.password)
        .then(function (response: DXResponse) {
          if (response.isValid) {
            SessionStorage.set('member', response.dataObject);
            self.utilityInstance.Navigate(ScreenRoute.TourOfTheDay, true);
          } else {
            self.utilityInstance.toastResponse(response);
          }
        });
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
