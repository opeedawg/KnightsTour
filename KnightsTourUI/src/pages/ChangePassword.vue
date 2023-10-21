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
            <h4>Change Password</h4>
            <q-input
              square
              filled
              bg-color="white"
              clearable
              bottom-slots
              v-model="passwordCurrent"
              type="password"
              label="Current Password"
            >
              <template v-slot:prepend>
                <q-icon name="password" />
              </template>

              <template v-slot:hint>
                <p class="hint">Your current password.</p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              clearable
              bottom-slots
              v-model="passwordNew1"
              type="password"
              label="New Password"
            >
              <template v-slot:prepend>
                <q-icon name="password" />
              </template>

              <template v-slot:hint>
                <p class="hint">Your new password.</p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              clearable
              bottom-slots
              v-model="passwordNew2"
              type="password"
              label="New Password (repeated)"
            >
              <template v-slot:prepend>
                <q-icon name="password" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  Your new password again to guard against typographical errors.
                </p>
              </template>
            </q-input>
          </q-form>
        </q-card-section>
        <q-card-actions class="q-px-md">
          <q-btn
            unelevated
            color="green"
            label="Change Password"
            @click="changePassword"
          />
        </q-card-actions>
      </q-card>
    </div>
  </div>
</template>

<script lang="ts">
import { SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';
import { ref } from 'vue';

export default {
  Name: 'ChangePassword',
  data() {
    return {
      passwordCurrent: '',
      passwordNew1: '',
      passwordNew2: '',
      api: new ApiService(),
      utilityInstance: UtilityInstance,
    };
  },
  setup() {
    const member = ref(new Member());
    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
    }

    return { member };
  },
  methods: {
    register: function () {
      this.utilityInstance.Navigate(ScreenRoute.SignUp);
    },
    changePassword: function () {
      let self = this;
      this.api
        .changePassword(
          this.member.memberId,
          this.passwordCurrent,
          this.passwordNew1,
          this.passwordNew2
        )
        .then(function (response: DXResponse) {
          self.utilityInstance.toastResponse(response);
          if (response.isValid) {
            SessionStorage.set('member', response.dataObject);
            self.passwordCurrent = '';
            self.passwordNew1 = '';
            self.passwordNew2 = '';
          }
        });
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
