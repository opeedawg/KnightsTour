<template>
  <div class="fieldWrapper">
    <q-input
      v-show="!hidden"
      v-model="fieldValue"
      :dense="projectSettings.renderDenseControls"
      :disable="disabled"
      :for="fieldId"
      :label="label"
      :rules="validationRules"
      clearable
      filled
      lazy-rules
    >
      <template v-slot:prepend>
        <q-icon name="event" class="cursor-pointer" color="primary">
          <q-popup-proxy cover transition-show="scale" transition-hide="scale">
            <q-date v-model="fieldValue" mask="YYYY-MM-DD"></q-date>
          </q-popup-proxy>
        </q-icon>
      </template>
    </q-input>
    <div class="helpText" v-if="helpText.length > 0" v-show="!hidden">
      {{ helpText }}
    </div>
  </div>
</template>
<script lang="ts">
import {
  FieldConfiguration,
  FieldState,
} from 'src/common/models/fieldConfiguration';
import { PageState } from 'src/common/models/global';
import { ProjectSettings } from 'src/common/models/projectSettings';
import { ValidationRule } from 'quasar';
import { ref, PropType } from 'vue';
import { QDataType } from 'src/common/models/quasar';

export default {
  name: 'DateField',
  props: {
    configuration: {
      type: FieldConfiguration,
      required: true,
      default: new FieldConfiguration('propertyName', 'label', QDataType.date),
    },
    pageState: {
      type: String,
      required: true,
      default: PageState.View.toString(),
    },
    validationRules: {
      type: Array as PropType<ValidationRule[]>,
      required: false,
    },
    currentValue: {
      required: true,
      default: '',
    },
  },
  data() {
    return {
      label: '',
      helpText: '',
      fieldValue: '',
      disabled: false,
      hidden: false,
      icon: '',
      controlValue: ref(null),
      fieldId: '',
      projectSettings: new ProjectSettings(),
    };
  },
  mounted() {
    this.label = this.configuration.label;
    this.helpText = this.configuration.helpText;
    this.icon = this.configuration.icon;
    this.fieldId = 'field_' + this.configuration.propertyName;
    this.configuration.validation.forEach((validation: ValidationRule<any>) => {
      // eslint-disable-next-line vue/no-mutating-props
      this.validationRules?.push(validation);
    });

    this.fieldValue = '';
    if (this.currentValue != null) {
      this.fieldValue = this.currentValue.toString().split('T')[0];
    }

    this.disabled =
      this.configuration.restrictionStatus.find(
        (r) =>
          r.pageState == this.pageState && r.fieldState == FieldState.Disabled
      ) != null;
    this.hidden =
      this.configuration.restrictionStatus.find(
        (r) =>
          r.pageState == this.pageState && r.fieldState == FieldState.Hidden
      ) != null;
  },
};
</script>
