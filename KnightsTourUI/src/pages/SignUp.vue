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
            <h4>Registration</h4>
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
                <p class="hint">
                  A valid email address. Used only for recovery purposes.
                </p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              bottom-slots
              clearable
              v-model="displayName"
              label="Display name"
            >
              <template v-slot:prepend>
                <q-icon name="badge" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  Strictly for you, what you want the site to refer to you as.
                </p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              bottom-slots
              clearable
              v-model="initials"
              label="Initials"
            >
              <template v-slot:prepend>
                <q-icon name="abc" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  2 or 3 characters exactly. Used in public display rankings.
                </p>
              </template></q-input
            >
            <q-input
              square
              filled
              bg-color="white"
              clearable
              bottom-slots
              v-model="password"
              type="password"
              label="Password"
              v-on:keyup.enter="register"
            >
              <template v-slot:prepend>
                <q-icon name="password" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  A good strong password of at least 5 characters in length.
                </p>
              </template>
            </q-input>
          </q-form>
        </q-card-section>
        <q-card-actions class="q-px-md">
          <q-btn unelevated color="green" label="Register" @click="register" icon="how_to_reg"
 />
          <q-btn unelevated color="primary" label="Already a member?  Sign In" @click="signIn" icon="login"/>
        </q-card-actions>
        <div class="center" style="width: 450px; text-align: left">
          <q-card-section class="q-pa-none" >
            <p class="text-grey-6">
              Registration grants you the following benefits:
              <ul>
                <li>Compare your skills against other members!</li>
                <li>Participate in the daily tour challenge!</li>
                <li>Track your overall statistics!</li>
              </ul>
            </p>
          </q-card-section>
        </div>
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
  Name: 'SignUp',
  data() {
    return {
      emailAddress: '',
      displayName: '',
      initials: '',
      password: '',
      api: new ApiService(),
      utilityInstance: UtilityInstance,
    };
  },
  setup() {
    return {};
  },
  methods: {
    signIn: function(){
      this.utilityInstance.Navigate(ScreenRoute.SignIn);
    },
    register: function () {
      let self = this;
      this.api
        .signUp(this.emailAddress, this.displayName, this.initials, this.password)
        .then(function (response: DXResponse) {
          if (response.isValid) {
            self.utilityInstance.toastResponse(response);
            SessionStorage.set('member', response.dataObject);
            self.utilityInstance.Navigate(ScreenRoute.TourOfTheDay, true);
          } else {
            UtilityInstance.toastResponse(response);
          }
        });
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
