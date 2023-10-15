<template>
  <div class="filterWrapper">
    <q-select
      v-model="fieldValue"
      :for="fieldId"
      :label="label"
      :options="options"
      clearable
      dense
      filled
      @update:model-value="valueChanged()"
    >
      <template v-if="icon.length > 0" v-slot:prepend>
        <q-icon :name="icon" color="primary" />
      </template>
    </q-select>
  </div>
</template>
<script lang="ts">
import { FieldConfiguration } from 'src/common/models/fieldConfiguration';
import { FilterFieldArgs } from 'src/common/models/arguments';
import { QSelectOption } from 'quasar';

export default {
  name: 'SelectFilter',
  props: {
    configuration: {
      type: FieldConfiguration,
      required: true,
    },
    initialValue: {
      required: true,
      default: '',
    },
  },
  data() {
    return {
      fieldId: '',
      fieldValue: '',
      helpText: '',
      icon: '',
      label: '',
      options: [] as QSelectOption[],
    };
  },
  mounted() {
    this.label = this.configuration.label;
    this.helpText = this.configuration.helpText;
    this.icon = this.configuration.icon;
    this.fieldId = 'filter_' + this.configuration.propertyName;
    let self = this;
    this.configuration.options.forEach(function (value: QSelectOption) {
      self.options.push(value);
    });
    this.fieldValue = this.initialValue;
  },
  methods: {
    valueChanged() {
      this.$emit(
        'filterChanged',
        new FilterFieldArgs(this.fieldValue, this.configuration)
      );
    },
  },
};
</script>
