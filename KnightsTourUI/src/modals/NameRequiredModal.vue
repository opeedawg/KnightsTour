<template>
  <div class="q-pa-md q-gutter-sm">
    <q-dialog v-model="showModal" persistent dark>
      <q-card class="messageModal" dark>
        <q-toolbar style="border-bottom: solid 1px white">
          <q-icon name="share" color="blue" size="24px"> </q-icon>

          <q-toolbar-title
            ><span class="text-weight-bold"
              >A name is required for sharing!</span
            ></q-toolbar-title
          >
        </q-toolbar>
        <br />
        <p class="message">
          We are pleased you wish to play at Knight's Tour, however in order to
          share your results we need to call you something!
        </p>
        <p>
          <q-input
            color="black"
            standout
            bottom-slots
            v-model="name"
            label="Your Name"
            clearable
            dark
          >
            <template v-slot:prepend>
              <q-icon name="badge" color="blue" />
            </template>

            <template v-slot:hint>
              This is only stored temporarilly in your browser, and only used
              for the purposes of sharing your results with your friends!
            </template>
          </q-input>
          <br />
          <q-btn
            color="primary"
            icon="play_circle"
            label="Set name and begin!"
            @click="setName"
          />
        </p>
        <q-separator dark />
        <br />
        <p class="message">
          Or feel free to become a member, it is free, quick and easy to sign up
          and offers many perks!
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
import { SessionStorage } from 'quasar';
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';

export default {
  Name: 'NameRequiredModal',
  data() {
    return {
      showModal: true,
      utilityInstance: UtilityInstance,
      name: '',
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
    setName: function () {
      if (this.name && this.name.length > 0) {
        SessionStorage.set('nonMemberName', this.name);
        this.$emit('nameSet', this.name);
      }
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
