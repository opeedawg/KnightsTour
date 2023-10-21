<template>
  <div class="q-pa-md q-gutter-sm">
    <q-dialog v-model="showModal" persistent dark>
      <q-card class="messageModal" dark>
        <q-toolbar style="border-bottom: solid 1px white">
          <q-icon name="lock" color="red" size="24px"> </q-icon>

          <q-toolbar-title
            ><span class="text-weight-bold"
              >Exclusive to Members!</span
            ></q-toolbar-title
          >
        </q-toolbar>
        <br />
        <p class="message">
          The content you are attempting to access is only available to members.
        </p>
        <p class="message">
          It is free, quick and easy to sign up and offers many perks!
        </p>
        Registration grants you the following perks:
        <ul>
          <li>Compare your skills against other members!</li>
          <li>Participate in the daily tour challenge!</li>
          <li>Track your overall statistics!</li>
        </ul>
        <q-card-actions>
          <span>
            <q-btn
              icon="how_to_reg"
              label="Sign up now"
              class="button positive"
              @click="signUp"
            >
            </q-btn>
            <q-btn
              icon="login"
              label="Already a member?  Signin"
              class="button action"
              @click="signIn"
            >
            </q-btn>
            <q-btn
              icon="quiz"
              label="Learn more"
              class="button action"
              @click="learnMore"
            >
            </q-btn>
          </span>
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';

export default {
  Name: 'MembershipRequiredModal',
  data() {
    return {
      showModal: true,
      utilityInstance: UtilityInstance,
    };
  },
  methods: {
    signUp: function () {
      this.showModal = false;
      this.utilityInstance.Navigate(ScreenRoute.SignUp);
    },
    signIn: function () {
      this.showModal = false;
      this.utilityInstance.Navigate(ScreenRoute.SignIn);
    },
    learnMore: function () {
      this.showModal = false;
      this.utilityInstance.Navigate(ScreenRoute.FAQ);
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
