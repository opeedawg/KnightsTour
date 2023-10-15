<template>
  <q-dialog
    v-model="isOpen"
    class=""
    max-height="400vh"
    max-width="700px"
    transition-show="slide-up"
    transition-hide="slide-down"
    transition-duration="500"
  >
    <!-- The card wrapper -->
    <q-card style="min-width: 550px" class="q-pt-none">
      <q-card-section class="timeOut_modal-title">
        <q-icon class="warning-Icon" :name="materialDesignIcon.Warning" />
      </q-card-section>
      <q-card-section class="generic_modal-title">
        <div class="text-h2">Session is about to expire!</div>
      </q-card-section>
      <q-card-section class="generic_modal-message">
        <strong>You will be logged out at {{ logoutTime }}</strong>
      </q-card-section>
      <q-card-section class="generic_modal-message">
        Would you like to stay signed in?
      </q-card-section>
      <q-card-actions class="generic_modal-footer">
        <q-btn
          class="q-ml-md"
          flat
          label="No, log me out"
          style="margin-right: 10px; color: white; background-color: gray"
          @click="no"
        />
        <q-btn
          flat
          label="Yes, keep me signed in"
          style="margin-right: 10px; color: white; background-color: #006699"
          @click="yes"
        />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script lang="ts">
import { MaterialDesignIcon, SystemColor } from '../models/enumerations';
import { GenericConfirmationArgs } from '../models/arguments';
import { DXCustomAction } from '../models/dxterity';
import moment from 'moment';

export default {
  name: 'TimeOutModal',

  props: {
    logOutTime: {
      type: Date,
      required: true,
    },
  },
  data() {
    return {
      isOpen: true,
      materialDesignIcon: MaterialDesignIcon,
      systemColor: SystemColor,
    };
  },
  setup(props) {
    let logoutTime = moment(props.logOutTime).format('YYYY/MM/DD, HH:mm:ss A.');
    return {
      logoutTime,
    };
  },
  methods: {
    no() {
      this.$emit(
        'response',
        new GenericConfirmationArgs(false, '', new DXCustomAction('logout'), {})
      );
    },
    yes() {
      this.$emit(
        'response',
        new GenericConfirmationArgs(true, '', new DXCustomAction('reset'), {})
      );
    },
  },
};
</script>

<style lang="scss">
@import '../../css/app.scss';

.timeOut_modal-title {
  display: flex;
  justify-content: center;
  padding: 25px 0px 0px 0px;
}
</style>
