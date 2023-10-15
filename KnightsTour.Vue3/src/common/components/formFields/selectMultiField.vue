<!-- eslint-disable vue/no-v-text-v-html-on-component -->
<template>
  <div class="fieldWrapper">
    <input type="hidden" :id="fieldId + '_selectedValues'" :value="model" />
    <q-select
      v-show="!hidden"
      v-model="model"
      class="textField"
      :dense="projectSettings.renderDenseControls"
      :disable="disabled"
      :for="fieldId"
      :label="label + (mandatory ? ' *' : '')"
      :options="options"
      :rules="validationRules"
      clearable
      :clear-icon="materialDesignIcon.CheckBoxOutlineBlank"
      outlined
      lazy-rules
      use-input
      input-debounce="0"
      @filter="filterFn"
      behavior="menu"
      multiple
      emit-value
      map-options
    >
      <template v-slot:append>
        <q-icon
          :name="materialDesignIcon.FactCheck"
          @click="selectAll"
          class="cursor-pointer"
          title="Select all"
        />
      </template>
      <template v-slot:option="{ itemProps, opt, selected, toggleOption }">
        <q-item v-bind="itemProps">
          <q-item-section>
            <q-item-label v-html="opt.label" />
          </q-item-section>
          <q-item-section side>
            <q-toggle
              :model-value="selected"
              @update:model-value="toggleOption(opt)"
            />
          </q-item-section>
        </q-item>
      </template>
    </q-select>
  </div>
</template>

<script lang="ts">
import {
  FieldConfiguration,
  FieldState,
} from 'src/common/models/fieldConfiguration';
import { MaterialDesignIcon, PageState } from 'src/common/models/enumerations';
import { ProjectSettings } from 'src/common/models/projectSettings';
import { PropType, ref } from 'vue';
import { QDataType } from 'src/common/models/quasar';
import { QSelectOption, ValidationRule } from 'quasar';

export default {
  name: 'SelectMultiField',
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
  setup() {
    return {
      model: ref([] as string[]),
    };
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
      materialDesignIcon: MaterialDesignIcon,
      mandatory: false,
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
    if (this.currentValue != null && this.currentValue.toString().length > 0) {
      const validOption = this.options.find(
        (option) => option.value == this.currentValue
      );
      if (validOption != null) {
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
    selectAll() {
      let self = this;
      self.model = [];
      this.options.forEach(function (o: QSelectOption) {
        self.model.push(o.value);
      });
    },
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
<style lang="scss">
@import '../../../css/app.scss';
</style>
