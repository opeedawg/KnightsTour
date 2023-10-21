<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h3 class="center">Security</h3>
    <ul>
      <li>
        Although you are free to use this site and play casually - because this
        is a very good source of healthy fun - if you do elect to sign up and
        take full advantage of what this site has to offer we care greatly about
        your security.
      </li>
      <li>
        Becoming a member (It's free!) allows for competitive and puzzle
        statistics to be created and registered - which is really fun and cool.
      </li>
      <li>
        Although we do not collect any user information (we strive to be
        minimalists) due to the competitive nature of this site, we want to make
        sure you are who you say you are - and your identity is not hijacked by
        a nefarious 3rd party or other bad actor!
      </li>
      <li>
        We have researched and chosen to use
        <a
          href="https://play.google.com/store/apps/details?id=com.google.android.apps.authenticator2&hl=en_CA&gl=US&pli=1"
          target="_new"
          >Google Authenticator</a
        >
        for our 2 factor authentication, it is quick, free and easy to use and
        should give you the peace of mind to know your records and rankings are
        secure and really yours to keep, improve and be proud of!
        <br />
        <img
          src="images/GoogleAuthenticator.png"
          height="300"
          width="300"
          class="center"
        />
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue';

export default {
  Name: 'SecurityPage',
  setup() {
    const tab = ref('intuition');

    return {
      tab,
    };
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
