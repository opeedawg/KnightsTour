<template>
  <q-dialog v-model="isOpen"
            :class="configuration.dialogClass"
            :max-height="configuration.heightMax"
            :max-width="configuration.widthMax"
            :transition-show="configuration.transitionShow"
            :transition-hide="configuration.transitionHide"
            :transition-duration="configuration.transitionDuration">
    <!-- The card wwrapper -->
    <q-card style="min-width: 350px" :class="configuration.cardClass">
      <q-card-section>
        <div :class="configuration.titleClass">{{ configuration.title }}</div>
      </q-card-section>
      <q-card-section :class="configuration.messageClass">
        {{ configuration.message }}
      </q-card-section>
      <q-card-actions :class="configuration.actionClass">
        <q-btn flat
               :icon="configuration.cancelIcon"
               :label="configuration.cancelText"
               :style="
            'margin-right: 10px; color: ' +
            configuration.cancelTextColor +
            '; background-color: ' +
            configuration.cancelButtonColor +
            ';'
          "
               @click="no" />
        <q-btn flat
               :icon="configuration.confirmationIcon"
               :label="configuration.confirmationText"
               :style="
            'margin-right: 10px; color: ' +
            configuration.confirmationTextColor +
            '; background-color: ' +
            configuration.confirmationButtonColor +
            ';'
          "
               @click="yes" />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script lang="ts">
  import { GenericConfirmationConfiguration } from '../models/global';
  import { GenericConfirmationArgs } from '../models/arguments';
  export default {
    name: 'GenericConfirmationModal',

    props: {
      configuration: {
        type: GenericConfirmationConfiguration,
        required: true,
      },
    },
    data() {
      return {
        isOpen: true,
      };
    },
    methods: {
      no() {
        this.$emit(
          'response',
          new GenericConfirmationArgs(
            false,
            this.configuration.id,
            this.configuration.customAction,
            this.configuration.data
          )
        );
      },
      yes() {
        this.$emit(
          'response',
          new GenericConfirmationArgs(
            true,
            this.configuration.id,
            this.configuration.customAction,
            this.configuration.data
          )
        );
      },
    },
  };
</script>
