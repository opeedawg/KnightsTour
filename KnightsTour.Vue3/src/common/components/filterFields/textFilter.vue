<template>
  <div class="filterWrapper">
    <q-input
      v-model="fieldValue"
      clearable
      dense
      for="filter_Text"
      filled
      label="Generic text search"
    >
      <template v-slot:prepend>
        <q-icon color="primary" name="search" />
      </template>
    </q-input>
  </div>
</template>

<script lang="ts">
import { FilterFieldArgs } from 'src/common/models/arguments';

export default {
  name: 'TextFitler',
  props: {
    initialValue: {
      type: String,
      required: false,
      default: '',
    },
  },
  data() {
    return {
      fieldValue: '',
    };
  },
  mounted() {
    this.fieldValue = this.initialValue;
  },
  methods: {
    valueChanged() {
      this.$emit('filterChanged', new FilterFieldArgs(this.fieldValue));
    },
  },
};
</script>
