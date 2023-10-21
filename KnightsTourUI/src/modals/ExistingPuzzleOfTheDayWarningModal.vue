<template>
  <div class="q-pa-md q-gutter-sm">
    <q-dialog v-model="showModal" persistent dark>
      <q-card class="messageModal" dark>
        <q-toolbar style="border-bottom: solid 1px white">
          <q-icon name="warning" color="orange" size="24px"> </q-icon>

          <q-toolbar-title
            ><span class="text-weight-bold">Warning!</span></q-toolbar-title
          >
        </q-toolbar>
        <br />
        <p class="message">
          You have already started the <em>Tour of the Day</em> - your original
          start time is recorded and fixed.
        </p>
        <p class="message">
          Even if you reset the puzzle, leave the page or even log out - your
          personal timer will continue to run.
        </p>
        <p class="message">
          Completing the puzzle will stop the timer, record your time and
          display your ranking for the <em>Tour of the Day</em>.
        </p>
        <p class="message">
          We have attempted to save your progress so you can continue the
          puzzle!
        </p>
        <p class="message">
          Don't worry if you can't complete the <em>Tour of the Day</em> -
          nobody said life would be easy!
        </p>
        <q-card-actions>
          <span>
            <q-btn
              icon="play_circle"
              label="Continue"
              class="button positive"
              @click="continuePuzzle"
            >
            </q-btn>
          </span>
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { ApiService } from 'src/API/apiService';
import { ScreenRoute, UtilityInstance } from 'src/models/Support/global';
import { Member } from 'src/models/Member';
import { SessionStorage } from 'quasar';
import { ref } from 'vue';

export default {
  Name: 'ExistingPuzzleOfTheDayWarningModal',
  data() {
    return {
      showModal: true,
      api: new ApiService(),
      utilityInstance: UtilityInstance,
    };
  },
  setup() {
    const member = ref(new Member());

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
    }

    return {
      member,
    };
  },
  methods: {
    continuePuzzle: function () {
      this.$emit('continuePuzzle');
    },
    randomPuzzle: function () {
      this.$emit('playNow');
      this.showModal = false;
      this.utilityInstance.Navigate(ScreenRoute.PlayNow);
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
