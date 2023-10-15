<template>
  <div class="fieldWrapper">
    <q-input
      v-show="!hidden"
      v-model="displayValue"
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
        <q-icon class="cursor-pointer" color="primary" name="event">
          <q-popup-proxy cover transition-hide="scale" transition-show="scale">
            <q-date v-model="fieldValue" mask="YYYY-MM-DD" range></q-date>
          </q-popup-proxy>
        </q-icon>
      </template>
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
import { PropType, ref } from 'vue';
import { QDataType } from 'src/common/models/quasar';
import { ValidationRule } from 'quasar';

class DateRange {
  from: Date;
  to: Date;

  constructor() {
    this.from = new Date();
    this.to = new Date();
  }
}

export default {
  name: 'DateRangeField',
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
      type: DateRange,
      required: true,
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
      controlValue: ref(null),
      disabled: false,
      fieldId: '',
      fieldValue: new DateRange(),
      helpText: '',
      hidden: false,
      icon: '',
      label: '',
      projectSettings: new ProjectSettings(),
    };
  },
  computed: {
    displayValue: function (): string {
      var result = '';
      if (
        this.fieldValue.from &&
        this.fieldValue.from.toString().length > 0 &&
        this.fieldValue.to &&
        this.fieldValue.to.toString().length > 0
      ) {
        result += this.fieldValue.from + ' thru ' + this.fieldValue.to;
      } else if (
        this.fieldValue.from &&
        this.fieldValue.from.toString().length > 0 &&
        this.fieldValue.to == null
      ) {
        result += this.fieldValue.from + ' thru ...';
      } else if (
        this.fieldValue.from == null &&
        this.fieldValue.to &&
        this.fieldValue.to.toString().length > 0
      ) {
        result += '... thru ' + this.fieldValue.to;
      }

      return result;
    },
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
    this.fieldValue.to = this.currentValue.to;
    this.fieldValue.from = this.currentValue.from;
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
