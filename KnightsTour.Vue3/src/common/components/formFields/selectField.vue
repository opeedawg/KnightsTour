<template>
  <div class="fieldWrapper">
    <q-select v-show="!hidden"
      v-model="fieldValue"
      :dense="projectSettings.renderDenseControls"
      :disable="disabled"
      :for="fieldId"
      :label="label"
      :options="options"
      :rules="validationRules"
      clearable
      filled
      lazy-rules
      use-input
      input-debounce="0"
      @filter="filterFn"
      behavior="menu">
      <template v-if="icon.length > 0" v-slot:prepend>
        <q-icon color="primary" :name="icon" />
      </template>
    </q-select>
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
  import { QSelectOption, ValidationRule } from 'quasar';

  export default {
    name: 'SelectField',
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
        options: [] as QSelectOption[],
        originalOptions: [] as QSelectOption[],
        projectSettings: new ProjectSettings(),
      };
    },
    mounted() {
      this.label = this.configuration.label;
      this.helpText = this.configuration.helpText;
      this.icon = this.configuration.icon;
      this.fieldId = 'field_' + this.configuration.propertyName;
      let self = this;
      this.configuration.options.forEach(function (value: QSelectOption) {
        self.options.push(value);
      });
      this.updateOriginalOptions();
      this.configuration.validation.forEach((validation: ValidationRule<any>) => {
        // eslint-disable-next-line vue/no-mutating-props
        this.validationRules?.push(validation);
      });

      this.fieldValue = '';
      console.log('this.options', this.options);
      console.log('this.currentValue', this.currentValue);
      console.log('this.currentValue.length', this.currentValue.length);
      if (this.currentValue != null && this.currentValue.toString().length > 0) {
        console.log('currentValue detected');
        const validOption = this.options.find(
          (option) => option.value == this.currentValue
        );
        if (validOption != null) {
          console.log('validOption found', validOption);
          this.fieldValue = validOption.label;
        }
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
    methods: {
      updateOriginalOptions() {
        const originalJson = JSON.stringify(this.options);
        this.originalOptions = JSON.parse(originalJson);
      },
      filterFn(val: string, update: any) {
        const context = this;
        if (val === '') {
          update(() => {
            context.options = context.originalOptions;
          });
          return;
        }

        update(() => {
          const needle = val.toLowerCase();
          context.options = context.originalOptions.filter(
            (v) => v.label.toLowerCase().indexOf(needle) > -1
          );
        });
      },
    },
  };
</script>
