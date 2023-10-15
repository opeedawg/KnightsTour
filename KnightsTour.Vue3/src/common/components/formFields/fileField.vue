<template>
  <div class="fieldWrapper">
    <q-file
      v-show="!hidden"
      v-model="fieldValue"
      :dense="projectSettings.renderDenseControls"
      :disable="disabled"
      :for="fieldId"
      :label="label + (mandatory ? ' *' : '')"
      :rules="validationRules"
      clearable
      outlined
      name="asd"
    >
    </q-file>
  </div>
</template>

<script lang="ts">
import {
  FieldConfiguration,
  FieldMaskType,
  FieldState,
} from 'src/common/models/fieldConfiguration';
import { PageState } from 'src/common/models/enumerations';
import { ProjectSettings } from 'src/common/models/projectSettings';
import { PropType } from 'vue';
import { QDataType } from 'src/common/models/quasar';
import { ValidationRule } from 'quasar';

export default {
  name: 'FileField',
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
      default: null,
    },
    multiple: {
      type: Boolean,
      required: false,
      default: false,
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
      FieldMaskType,
      fieldType: '',
      fieldValue: null,
      helpText: '',
      hidden: false,
      icon: '',
      label: '',
      projectSettings: new ProjectSettings(),
      mandatory: false,
    };
  },
  mounted() {
    this.label = this.configuration.label;
    this.helpText = this.configuration.helpText;
    this.icon = this.configuration.icon;
    this.fieldId = 'field_' + this.configuration.propertyName;
    this.fieldType = this.configuration.maskType;
    this.mandatory = this.configuration.mandatory;
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

<style lang="scss">
@import '../../../css/app.scss';
</style>
