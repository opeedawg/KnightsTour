<template>
  <div class="filterWrapper">
    <q-select
      v-model="fieldValue"
      :for="fieldId"
      :options="options"
      clearable
      dense
      filled
      @update:model-value="valueChanged()"
    >
      <template v-if="icon.length > 0" v-slot:prepend>
        <q-icon :name="icon" color="primary" />
      </template>
      <template v-slot:option="scope">
        <q-item v-bind="scope.itemProps">
          <q-item-section avatar>
            <q-icon :color="scope.opt.iconColor" :name="scope.opt.icon" />
          </q-item-section>
          <q-item-section>
            <q-item-label>{{ scope.opt.label }}</q-item-label>
            <q-item-label caption>{{ scope.opt.description }}</q-item-label>
          </q-item-section>
        </q-item>
      </template>
    </q-select>
  </div>
</template>
<script lang="ts">
import { DXCustomAction } from 'src/common/models/dxterity';
import { FieldConfiguration } from 'src/common/models/fieldConfiguration';
import { FilterFieldArgs } from 'src/common/models/arguments';

export default {
  name: 'BooleanFilter',
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
      options: [] as DXCustomAction[],
    };
  },
  mounted() {
    this.label = this.configuration.label;
    this.helpText = this.configuration.helpText;
    this.icon = this.configuration.icon;
    this.fieldId = 'filter_' + this.configuration.propertyName;

    let blankAction = new DXCustomAction('Any', '');
    blankAction.description = 'Does not apply a filter.';
    blankAction.icon = 'check_box_outline_blank';
    blankAction.iconColor = 'gray';
    this.options.push(blankAction);

    let yesAction = new DXCustomAction('Yes', 'true');
    yesAction.description =
      'Only records where ' + this.configuration.label + ' is true.';
    yesAction.icon = 'done';
    yesAction.iconColor = 'green';
    this.options.push(yesAction);

    let noAction = new DXCustomAction('No', 'false');
    noAction.description =
      'Only records where ' + this.configuration.label + ' is false.';
    noAction.icon = 'close';
    noAction.iconColor = 'red';
    this.options.push(noAction);

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
