<template>
  <div class="filterWrapper">
    <q-input
      v-model="fieldValueFrom"
      :for="fieldIdFrom"
      :label="label + ' from'"
      clearable
      dense
      filled
      lazy-rules
      @update:model-value="dateFromChanged()"
    >
      <template v-slot:prepend>
        <q-icon class="cursor-pointer" color="primary" name="event">
          <q-popup-proxy cover transition-show="scale" transition-hide="scale">
            <q-date v-model="fieldValueFrom" mask="YYYY-MM-DD"></q-date>
          </q-popup-proxy>
        </q-icon>
      </template>
    </q-input>
  </div>
  <div class="filterWrapper">
    <q-input
      v-model="fieldValueTo"
      :for="fieldIdTo"
      :label="label + ' to'"
      clearable
      dense
      filled
      lazy-rules
      @update:model-value="dateToChanged()"
    >
      <template v-slot:prepend>
        <q-icon class="cursor-pointer" color="primary" name="event">
          <q-popup-proxy cover transition-show="scale" transition-hide="scale">
            <q-date v-model="fieldValueTo" mask="YYYY-MM-DD"></q-date>
          </q-popup-proxy>
        </q-icon>
      </template>
    </q-input>
  </div>
</template>

<script lang="ts">
import { FieldConfiguration } from 'src/common/models/fieldConfiguration';
import { FilterFieldArgs } from 'src/common/models/arguments';
import { QDataType } from 'src/common/models/quasar';

export default {
  name: 'DateFilter',
  props: {
    configuration: {
      type: FieldConfiguration,
      required: true,
      default: new FieldConfiguration(
        'propertyName',
        'label',
        QDataType.string
      ),
    },
    initialValueFrom: {
      required: false,
      default: '',
    },
    initialValueTo: {
      required: false,
      default: '',
    },
  },
  data() {
    return {
      fieldIdFrom: '',
      fieldIdTo: '',
      fieldValueFrom: '',
      fieldValueTo: '',
      helpText: '',
      label: '',
    };
  },
  mounted() {
    this.label = this.configuration.label;
    this.helpText = this.configuration.helpText;
    this.fieldIdFrom = 'filter_' + this.configuration.propertyName + 'From';
    this.fieldValueFrom = '';
    if (this.initialValueFrom != null) {
      this.fieldValueFrom = this.initialValueFrom.toString().split('T')[0];
    }

    this.fieldIdTo = 'filter_' + this.configuration.propertyName + 'To';
    this.fieldValueTo = '';
    if (this.initialValueTo != null) {
      this.fieldValueTo = this.initialValueTo.toString().split('T')[0];
    }
  },
  methods: {
    dateFromChanged() {
      this.$emit(
        'filterChanged',
        new FilterFieldArgs(this.fieldValueTo, this.configuration, {
          type: 'From',
        })
      );
    },
    dateToChanged() {
      this.$emit(
        'filterChanged',
        new FilterFieldArgs(this.fieldValueTo, this.configuration, {
          type: 'To',
        })
      );
    },
  },
};
</script>
