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
      type="textarea"
    >
      <template v-if="icon.length > 0" v-slot:prepend>
        <q-icon :name="icon" color="primary" />
      </template>
      <template v-if="helpText.length > 0" v-slot:hint>{{ helpText }}</template>
    </q-input>
    <div v-if="helpText.length > 0" v-show="!hidden" class="helpText">
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
import { PropType } from 'vue';
import { QDataType } from 'src/common/models/quasar';
import { ValidationRule } from 'quasar';

export default {
  name: 'TextField',
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
    currentValue: {
      required: true,
      default: '',
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
  },
  data() {
    return {
      disabled: false,
      fieldId: '',
      fieldValue: '',
      helpText: '',
      hidden: false,
      icon: '',
      label: '',
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
    this.fieldValue = this.currentValue;

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
