<!--
* Component: EventHistoryEditModal
* Location:  src\entities\EventHistory\modals\
* 
* The modal pop up when editing an existing @see EventHistory.
* - Note: The field states are configured in @see EventHistoryConfig class.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on January 21, 2023 at 7:35:06 AM
-->

<template>
  <q-dialog
    v-model="isOpen"
    max-height="400vh"
    max-width="700px"
    transition-show="flip-down"
    transition-hide="flip-up"
  >
    <q-card style="min-width: 350px">
      <q-card-section>
        <div class="text-h6">Event history '{{ entity.instanceLabel }}'</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        <EventHistoryFieldsComponent
          v-if="pageLoaded"
          :pageState="pageState"
          :entity="entity"
          :formActions="actions"
          @userAction="processFieldsAction"
        ></EventHistoryFieldsComponent>
      </q-card-section>
    </q-card>
  </q-dialog>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { EventHistory } from '../models/EventHistory';
  import { EventHistoryEntitySettings } from '../models/entitySettings';
  import { FormAction } from 'src/common/models/formAction';
  import { FormActionArgs } from 'src/common/models/arguments';
  import { PageState } from 'src/common/models/global';
  import EventHistoryFieldsComponent from '../components/EventHistoryFieldsComponent.vue';


/** Component: EventHistoryEditModal
* - The modal pop up when editing an existing @see EventHistory.
* - Note: The field states are configured in @see EventHistoryConfig class.
*/
export default {
  Name: 'EventHistoryEditModal',
  /** Registration of all child components used by this component. */
  components: {
    EventHistoryFieldsComponent,
  },
  /** https://vuejs.org/guide/components/props.html */
  props: {
    /** The @see EventHistory to display. */
    entity: {
      type: EventHistory,
      required: true,
      default: new EventHistory(),
    },
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** The list of @see FormAction do be rendered on this page. */
      actions: [] as FormAction[],
      /** Provides access to entity level settings. */
      entitySettings: new EventHistoryEntitySettings(),
      /** Determines whether this modal should be visible or not. */
      isOpen: true,
      /** Used in react page state management. */
      pageLoaded: false,
      /** The @see PageState (applies various field rules). */
      pageState: '',
    };
  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // This determines the form field states, based on the rule configurations defined in @see EventHistoryConfig.
    this.pageState = PageState.Edit;

    // You can add other actions here if required.
    this.actions.push(this.entitySettings.cancelAction);
    this.actions.push(this.entitySettings.updateAction);

    // Set the page as loaded.
    this.pageLoaded = true;
  },
  /** https://vuejs.org/guide/essentials/reactivity-fundamentals.html#declaring-methods */
  methods: {
    /**
    * Computed variable processFieldsAction: 
    * - 'Generically gathers an attribute collection for field binding.'
    * @param {FormActionArgs} args: The action performed on this component, raised to the parent page.
    * @returns {any} Dynamic object of attributes to bind to the control.
    */
    processFieldsAction: function (
      args: FormActionArgs
    ): any {
      this.$emit('userAction', args);
    }, // processFieldsAction

  },
};
</script>