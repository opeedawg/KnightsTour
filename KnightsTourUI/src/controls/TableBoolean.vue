<template>
  <q-td style="text-align: center">
    <q-icon v-if="value" name="done" color="green" size="2em"></q-icon>
    <q-icon v-if="!value" name="close" color="red" size="2em"></q-icon>
  </q-td>
</template>

<script lang="ts">
export default {
  Name: 'TableBoolean',
  props: {
    value: {
      type: Boolean,
      required: true,
      default: false,
    },
  },
  data() {
    return {
      showModal: true,
    };
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
