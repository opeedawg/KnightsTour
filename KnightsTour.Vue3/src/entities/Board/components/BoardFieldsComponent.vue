<!--
* Component: BoardFieldsComponent
* Location:  src\entities\Board\components\
* 
* Renders fields related to the @see Board class.
* - Note: fields are rendered based on rules defined in the @see BoardConfig class.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on January 21, 2023 at 7:35:06 AM
-->

<template>
  <!-- Loading icon -->
  <div class="q-pa-xl row justify-center" v-if="!fieldsLoaded">
    <q-spinner color="green" size="5em" :thickness="10" />
  </div>

  <q-form class="q-gutter-md" v-show="fieldsLoaded" id="lFeatureToggleForm">
    <div class="q-pa-md row q-gutter-sm" style="max-width: 1200px">
  <q-card
    v-if="textFieldCount > 0"
    bordered
    class="my-card"
    flat
    :style="cardStyle"
  >
    <q-card-section class="header">
      <div class="text-h6">Information</div>
    </q-card-section>
    <q-card-section class="q-pt-none">
  	   <TextField v-if="fieldsLoaded" v-bind="attr_InstanceLabel"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_BoardId"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_BoardCode"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_RowDimension"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_ColDimension"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_Author"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_DiscoveryIterationCount"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_DiscoveryRandomness"></TextField>
  	   <TextField v-if="fieldsLoaded" v-bind="attr_Path"></TextField>
    </q-card-section>
  </q-card>
  <q-card
    v-if="selectFieldCount > 0"
    bordered
    class="my-card"
    flat
    :style="cardStyle"
  >
    <q-card-section class="header">
      <div class="text-h6">Assignments</div>
    </q-card-section>
    <q-card-section class="q-pt-none">
  	   <SelectField v-if="fieldsLoaded" v-bind="attr_SourceBoardId"></SelectField>
    </q-card-section>
  </q-card>
  <q-card
    v-if="dateFieldCount > 0"
    bordered
    class="my-card"
    flat
    :style="cardStyle"
  >
    <q-card-section class="header">
      <div class="text-h6">Dates/Times</div>
    </q-card-section>
    <q-card-section class="q-pt-none">
  	   <DateField v-if="fieldsLoaded" v-bind="attr_DiscoveryDate"></DateField>
      <DateField v-if="fieldsLoaded" v-bind="attr_DiscoveryDateFormatted"></DateField>
    </q-card-section>
  </q-card>
  <q-card
    v-if="booleanFieldCount > 0"
    bordered
    class="my-card"
    flat
    :style="cardStyle"
  >
    <q-card-section class="header">
      <div class="text-h6">Options</div>
    </q-card-section>
    <q-card-section class="q-pt-none">
    </q-card-section>
  </q-card>

  	   <q-card-actions>
  	     <span v-for="action in formActions" :key="action.id">
    		   <q-btn
            :icon="action.icon"
    		     :id="action.id"
            :label="action.label"
  		       :style="
  		         'margin-right: 10px; color: ' +
  		         action.textColor +
  		         '; background-color: ' +
  		         action.backgroundColor +
  		         ';'
  		       "
    		     @click="emitResponse(action)"
      		 >
  	       </q-btn>
  	     </span>
  	   </q-card-actions>
    </div>
  </q-form>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { BaseStore } from 'src/common/stores/base.store';
  import { Board } from '../models/Board';
  import { BoardDBFields } from '../models/base/BoardConfigBase';
  import { BoardPropertyNames } from '../models/base/BoardBase';
  import { DXResponse } from 'src/common/models/dxterity';
  import { 
    FieldConfiguration,
    FieldSupport,
  } from 'src/common/models/fieldConfiguration';
  import { fieldConfigurations } from '../models/BoardConfig';
  import { FormAction } from 'src/common/models/formAction';
  import { FormActionArgs } from 'src/common/models/arguments';
  import { PageState } from 'src/common/models/global';
  import { PropType } from 'vue';
  import { 
    QDataType,
    QSelectOption,
  } from 'src/common/models/quasar';
  import DateField from 'src/common/components/formFields/dateField.vue';
  import SelectField from 'src/common/components/formFields/selectField.vue';
  import TextField from 'src/common/components/formFields/textField.vue';


/** Component: BoardFieldsComponent
* - Renders fields related to the @see Board class.
* - Note: fields are rendered based on rules defined in the @see BoardConfig class.
*/
export default {
  Name: 'BoardFieldsComponent',
  /** Registration of all child components used by this component. */
  components: {
    DateField,
    SelectField,
    TextField,
  },
  /** https://vuejs.org/guide/components/props.html */
  props: {
    /** The Board to render. */
    entity: {
      type: Board,
      required: true,
      default: new Board(),
    },
    /** The form actions to render. */
    formActions: {
      type: Array as PropType<FormAction[]>,
      required: true,
    },
    /** The @see PageState to render these fields in. */
    pageState: {
      type: String,
      required: true,
      default: PageState.View.toString(),
    },
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** A generic object used for binding the dynamically built controls. */
      attributes: {},
      /** Property names accessed locally in this section only.  If ever required outside Setup, just add it to the return section. */
      boardPropertyNames: BoardPropertyNames,
      /** The number of visible boolean fields. */
      booleanFieldCount: 0,
      /** Derived card block style. */
      cardStyle: '',
      /** The number of visible date fields. */
      dateFieldCount: 0,
      /** Field configurations for the @see Board. */
      fieldConfigurations,
      /** Required to do some fancy DOM manipulation. */
      fieldSupport: new FieldSupport(document),
      /** Used to refresh attributes when requied by computed code. */
      refreshAttributes: 0,
      /** Dynsmically determines the number of steps required before the screen is considered 'loaded'. */
      refreshAttributeTotal: 0,
      /** The number of visible select fields. */
      selectFieldCount: 0,
      /** The number of visible text fields. */
      textFieldCount: 0,
    };
  },
  /** https://vuejs.org/guide/essentials/computed.html */
  computed: {
    /**
    * Computed function [attr_Author] for variable attr_Author: 
    * - Assigns the attribute collection for the Author property for field binding.
    * @returns {any} Anything
    */
    attr_Author: function attr_Author(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.author);
    }, // attr_Author

    /**
    * Computed function [attr_BoardCode] for variable attr_BoardCode: 
    * - Assigns the attribute collection for the BoardCode property for field binding.
    * @returns {any} Anything
    */
    attr_BoardCode: function attr_BoardCode(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.boardCode);
    }, // attr_BoardCode

    /**
    * Computed function [attr_BoardId] for variable attr_BoardId: 
    * - Assigns the attribute collection for the BoardId property for field binding.
    * @returns {any} Anything
    */
    attr_BoardId: function attr_BoardId(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.boardId);
    }, // attr_BoardId

    /**
    * Computed function [attr_ColDimension] for variable attr_ColDimension: 
    * - Assigns the attribute collection for the ColDimension property for field binding.
    * @returns {any} Anything
    */
    attr_ColDimension: function attr_ColDimension(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.colDimension);
    }, // attr_ColDimension

    /**
    * Computed function [attr_DiscoveryDate] for variable attr_DiscoveryDate: 
    * - Assigns the attribute collection for the DiscoveryDate property for field binding.
    * @returns {any} Anything
    */
    attr_DiscoveryDate: function attr_DiscoveryDate(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.discoveryDate);
    }, // attr_DiscoveryDate

    /**
    * Computed function [attr_DiscoveryIterationCount] for variable attr_DiscoveryIterationCount: 
    * - Assigns the attribute collection for the DiscoveryIterationCount property for field binding.
    * @returns {any} Anything
    */
    attr_DiscoveryIterationCount: function attr_DiscoveryIterationCount(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.discoveryIterationCount);
    }, // attr_DiscoveryIterationCount

    /**
    * Computed function [attr_DiscoveryRandomness] for variable attr_DiscoveryRandomness: 
    * - Assigns the attribute collection for the DiscoveryRandomness property for field binding.
    * @returns {any} Anything
    */
    attr_DiscoveryRandomness: function attr_DiscoveryRandomness(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.discoveryRandomness);
    }, // attr_DiscoveryRandomness

    /**
    * Computed function [attr_InstanceLabel] for variable attr_InstanceLabel: 
    * - Assigns the attribute collection for the instance label property for field binding.
    * @returns {any} Anything
    */
    attr_InstanceLabel: function attr_InstanceLabel(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.instanceLabel);
    }, // attr_InstanceLabel

    /**
    * Computed function [attr_Path] for variable attr_Path: 
    * - Assigns the attribute collection for the Path property for field binding.
    * @returns {any} Anything
    */
    attr_Path: function attr_Path(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.path);
    }, // attr_Path

    /**
    * Computed function [attr_RowDimension] for variable attr_RowDimension: 
    * - Assigns the attribute collection for the RowDimension property for field binding.
    * @returns {any} Anything
    */
    attr_RowDimension: function attr_RowDimension(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.rowDimension);
    }, // attr_RowDimension

    /**
    * Computed function [attr_SourceBoardId] for variable attr_SourceBoardId: 
    * - Assigns the attribute collection for the SourceBoardId property for field binding.
    * @returns {any} Anything
    */
    attr_SourceBoardId: function attr_SourceBoardId(): any {
      this.refreshAttributeTotal;
      return this.getAttribute(this.boardPropertyNames.sourceBoardId);
    }, // attr_SourceBoardId

    /**
    * Computed function [fieldsLoaded] for variable fieldsLoaded: 
    * - Determines when all fields have been loaded for presentation on this screen.
    * @returns {boolean} Whether or not all fields have been loaded.
    */
    fieldsLoaded: function fieldsLoaded(): boolean {
      return this.refreshAttributes >= this.refreshAttributeTotal;
    }, // fieldsLoaded

  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // Get a distinct list of option filters that require population.
    // This is so we only do a single call if we need to populate multiple drop downs with the same data.
    let self = this;
    let filterFieldLoadCount = 0;
    self.refreshAttributes = 0;
    self.refreshAttributeTotal = 9999;
    const baseStore = new BaseStore();
    const distinctFilters = [] as string[];
    fieldConfigurations.forEach((value: FieldConfiguration) => {
      self.incrementVisibileFieldCount(value);
      if (value.requiresOptionPopulation(self.pageState)) {
    	if (distinctFilters.indexOf(value.optionFilter) === -1) {
    	  distinctFilters.push(value.optionFilter);
    	}
    	filterFieldLoadCount++;
      }
    });

    self.refreshAttributeTotal = filterFieldLoadCount;

    if (distinctFilters.length > 0) {
      distinctFilters.forEach(function (filter: string) {
    	fieldConfigurations.forEach((value: FieldConfiguration) => {
    	  if (
    		value.requiresOptionPopulation(self.pageState) &&
    		value.optionFilter === filter
    	  ) {
    		// Clear any existing options.
    		value.options = [];

    		if (filter.toUpperCase().trim().startsWith('SQL|')) {
    		  if (value.isEnabled(self.pageState)) {
    			// We only need to load all the values
    			baseStore
    			  .getSelectOptions(filter)
    			  .then(function (response: DXResponse) {
    				if (response.isValid) {
    				  response.dataObject.forEach(function (
    					option: QSelectOption
    				  ) {
    					value.options.push(option);
    				  });
    				}

    				self.refreshAttributes++;
    			  });
    		  } else {
    			// We only need to load a single value
    			baseStore
    			  .getSelectOption(
    				filter,
    				(self.entity as any)[value.propertyName]
    			  )
    			  .then(function (response: DXResponse) {
    				if (response.isValid) {
    				  response.dataObject.forEach(function (
    					option: QSelectOption
    				  ) {
    					value.options.push(option);
    				  });
    				}

    				self.refreshAttributes++;
    			  });
    		  }
    		} else if (filter.toUpperCase().trim().startsWith('VALUES|')) {
    		  filter
    			.trim()
    			.substring(7)
    			.split('|')
    			.forEach(function (selectOption: string) {
    			  value.options.push(new QSelectOption(selectOption));
    			});

    		  setTimeout(function () {
    			self.refreshAttributes++;
    		  }, 100);
    		} else if (filter.toUpperCase().trim().startsWith('JSON|')) {
    		  const jsonText = filter.trim().substring(5);
    		  const obj = JSON.parse(jsonText);

    		  obj.forEach(function (selectObject: any) {
    			value.options.push(
    			  new QSelectOption(selectObject.Key, selectObject.Value)
    			);
    		  });

    		  setTimeout(function () {
    			self.refreshAttributes++;
    		  }, 100);
    		}
    	  }
    	});
      });
    } else {
      self.refreshAttributes++;
    }

    // Now we can determine the card sections widths - dynamic based on the number of visible card sections.
    /** The default card style width - defaulted assuming all sections (4) are visible */
    this.cardStyle = 'max-width: 250px;';
    let totalSections = 0;
    if (this.textFieldCount > 0) totalSections++;
    if (this.dateFieldCount > 0) totalSections++;
    if (this.selectFieldCount > 0) totalSections++;
    if (this.booleanFieldCount > 0) totalSections++;

    // Calculated loosely assuming the total page width is 1200px - less some buffers for user experience
    if (totalSections == 3) this.cardStyle = 'max-width: 375px;';
    if (totalSections == 2) this.cardStyle = 'max-width: 575px;';
    // If only a single section is required, then this will default it to the entire page width - winning!
    if (totalSections == 1) this.cardStyle = '';
  },
  /** https://vuejs.org/guide/essentials/reactivity-fundamentals.html#declaring-methods */
  methods: {
    /**
    * Computed variable collectFormData: 
    * - 'Collects all the form data.'
    * @returns {Board} @see Board
    */
    collectFormData: function (): Board {
      var updatedEntity = new Board();
      let self = this;

      this.fieldSupport.updateEntity(
        updatedEntity,
        BoardDBFields,
        self.fieldConfigurations
      );

      return updatedEntity;
    }, // collectFormData

    /**
    * Computed variable emitResponse: 
    * - 'Sends the action back to the calling page.'
    * @param {FormAction} action: The action which was performed, sent back to the calling page.
    * @returns {any} Anything
    */
    emitResponse: function (
      action: FormAction
    ): any {
      this.$emit(
        'userAction',
        action.sendData
          ? new FormActionArgs(action.id, this.collectFormData())
          : new FormActionArgs(action.id)
      );
    }, // emitResponse

    /**
    * Computed variable getAttribute: 
    * - 'Generically gathers an attribute collection for field binding.'
    * @param {GradePropertyNames} property: The property attribute configuration to retrieve.
    * @returns {any} An object for binding to a form control.
    */
    getAttribute: function (
      property: GradePropertyNames
    ): any {
      const configuration = fieldConfigurations.get(property);
      if (configuration != null) {
        return {
          for: property,
          pageState: this.pageState,
          currentValue: this.entity[property],
          configuration: configuration,
        };
      }
    }, // getAttribute

    /**
    * Computed variable incrementVisibileFieldCount: 
    * - Increments visible field counts for dynamicrender support.
    * @param {FieldConfiguration} configuration: The field configuration to analyze.
    * @returns {void} Nothing.
    */
    incrementVisibileFieldCount: function (
      configuration: FieldConfiguration
    ): void {
      // Only visible fields matter, and this is calculated dynamically!
      if (configuration.isVisible(this.pageState)) {
        if (configuration.optionFilter.length > 0) {
          this.selectFieldCount++;
        } else if (configuration.dataType == QDataType.boolean) {
          this.booleanFieldCount++;
        } else if (configuration.dataType == QDataType.date) {
          this.dateFieldCount++;
        } else {
          this.textFieldCount++;
        }
      }
    }, // incrementVisibileFieldCount

  },
};
</script>

  <style scoped>
    .my-card {
      width: 100%;
      display: flex;
      flex-direction: column;
    }

    .header {
      background-color: rgba(0, 0, 0, 0.03);
      padding-top: 5px;
      padding-bottom: 5px;
      border-bottom: solid 1px rgba(0, 0, 0, 0.12);
      margin-bottom: 5px;
    }
  </style>