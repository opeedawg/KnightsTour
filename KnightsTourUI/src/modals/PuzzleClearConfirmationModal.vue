<template>
  <div class="q-pa-md q-gutter-sm">
    <q-dialog v-model="showModal" persistent dark>
      <q-card class="messageModal" dark>
        <q-toolbar style="border-bottom: solid 1px white">
          <q-icon name="report" color="yellow" size="24px"> </q-icon>

          <q-toolbar-title
            ><span class="text-weight-bold"
              >Are you sure?</span
            ></q-toolbar-title
          >
        </q-toolbar>
        <br />
        <p class="message">This will reset the tour to it's original state.</p>
        <p class="message">It will NOT reset the start time or puzzle timer!</p>
        <p class="message">Once this is done it can not be un-done!</p>
        <q-card-actions>
          <span>
            <q-btn
              icon="restart_alt"
              label="Yes, reset the tour"
              class="button positive"
              @click="yes"
            >
            </q-btn>
            <q-btn
              icon="cancel"
              label="No, let me keep trying"
              class="button action"
              @click="no"
            >
            </q-btn>
          </span>
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts">
export default {
  Name: 'PuzzleClearConfirmationModal',
  data() {
    return {
      showModal: true,
    };
  },
  methods: {
    yes: function () {
      this.showModal = false;
      this.$emit('yes');
    },
    no: function () {
      this.showModal = false;
      this.$emit('no');
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
