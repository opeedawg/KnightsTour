<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%; width: 100%">
    <div>
      <q-card
        square
        bordered
        class="q-pa-lg shadow-1 center"
        dark
        style="width: 600px"
      >
        <q-card-section>
          <q-form class="q-gutter-md">
            <h4>Contact Us</h4>
            <q-input
              square
              filled
              bg-color="white"
              bottom-slots
              clearable
              v-model="contactName"
              label="Your preferred title/name."
            >
              <template v-slot:prepend>
                <q-icon name="record_voice_over" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  How you would like us to refer to you as in any communication
                </p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              bottom-slots
              clearable
              v-model="emailAddress"
              label="Your Email Address (optional)"
            >
              <template v-slot:prepend>
                <q-icon name="email" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  A valid email address. Used only if you are looking for a
                  response
                </p>
              </template>
            </q-input>
            <q-input
              square
              filled
              bg-color="white"
              bottom-slots
              clearable
              v-model="subject"
              label="Subject/Topic"
            >
              <template v-slot:prepend>
                <q-icon name="lightbulb" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  The subject or topic of your commuication (optional)
                </p>
              </template>
            </q-input>
            <q-select
              dark
              label="Purpose"
              v-model="purpose"
              :options="purposeOptions"
            ></q-select>
            <q-input
              square
              filled
              dark
              bottom-slots
              clearable
              v-model="body"
              type="textarea"
              label="Tell us what you think"
            >
              <template v-slot:prepend>
                <q-icon name="abc" />
              </template>

              <template v-slot:hint>
                <p class="hint">
                  Your feedback. All feedback will be kept confidential.
                </p>
              </template></q-input
            >
          </q-form>
        </q-card-section>
        <q-card-actions class="q-px-md">
          <q-btn
            unelevated
            color="primary"
            label="Clear"
            @click="clearForm"
            icon="clear"
          />
          <q-btn
            unelevated
            color="green"
            label="Submit"
            @click="submitForm"
            icon="forward_to_inbox"
          />
        </q-card-actions>
      </q-card>
    </div>
  </div>
</template>

<script lang="ts">
import { QSelectOption, SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';
import { ref } from 'vue';

export default {
  Name: 'ContactUs',
  data() {
    return {
      subject: '',
      body: '',
      utilityInstance: UtilityInstance,
      purpose: { label: 'Other', value: 'Other' },
    };
  },
  setup() {
    const contactName = ref('');
    const emailAddress = ref('');
    const api = new ApiService();
    const member = ref(new Member());
    let purposeOptions = ref([] as QSelectOption[]);

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
      contactName.value = member.value.userInitials;
      emailAddress.value = member.value.emailAddress;
    }

    purposeOptions.value.push({ label: 'Other', value: 'Other' });
    purposeOptions.value.push({
      label: 'I have a question',
      value: 'Question',
    });
    purposeOptions.value.push({
      label: 'I have an amazing idea!',
      value: 'Idea',
    });
    purposeOptions.value.push({
      label: 'I found a bug!  Oh no!',
      value: 'Bug',
    });
    purposeOptions.value.push({
      label: 'I have a specail request...',
      value: 'Request',
    });

    return {
      api,
      member,
      contactName,
      emailAddress,
      purposeOptions,
    };
  },
  methods: {
    clearForm: function () {
      // Do
      this.subject = '';
      this.body = '';
      this.purpose = { label: 'Other', value: 'Other' };
      this.contactName = '';
      this.emailAddress = '';
      this.contactName = this.member.userInitials;
      this.emailAddress = this.member.emailAddress;
    },
    submitForm: function () {
      let self = this;
      this.api
        .communicationSubmit(
          this.contactName,
          this.subject,
          this.emailAddress,
          this.purpose.value,
          this.body
        )
        .then(function (response: DXResponse) {
          self.utilityInstance.toastResponse(response);
          if (response.isValid) {
            self.clearForm();
          }
        });

      // Do something
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
