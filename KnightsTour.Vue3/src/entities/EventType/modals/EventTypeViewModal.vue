<!--
* Component: EventTypeViewModal
* Location:  src\entities\EventType\modals\
* 
* The modal pop up when viewing a @see EventType.
* Note: The field states are configured in @see EventTypeConfig class.
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
        <div class="text-h6">Event type '{{ entity.instanceLabel }}'</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        <EventTypeFieldsComponent
          v-if="pageLoaded"
          :pageState="pageState"
          :entity="entity"
          :formActions="actions"
          @userAction="processFieldsAction"
        ></EventTypeFieldsComponent>
      </q-card-section>
    </q-card>
  </q-dialog>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { EventType } from '../models/EventType';
  import { EventTypeEntitySettings } from '../models/entitySettings';
  import { FormAction } from 'src/common/models/formAction';
  import { FormActionArgs } from 'src/common/models/arguments';
  import { PageState } from 'src/common/models/global';
  import EventTypeFieldsComponent from '../components/EventTypeFieldsComponent.vue';


/** Component: EventTypeViewModal
* - The modal pop up when viewing a @see EventType.
* Note: The field states are configured in @see EventTypeConfig class.
*/
export default {
  Name: 'EventTypeViewModal',
  /** Registration of all child components used by this component. */
  components: {
    EventTypeFieldsComponent,
  },
  /** https://vuejs.org/guide/components/props.html */
  props: {
    /** The @see EventType to display. */
    entity: {
      type: EventType,
      required: true,
      default: new EventType(),
    },
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** The list of @see FormAction do be rendered on this page. */
      actions: [] as FormAction[],
      /** Provides access to entity level settings. */
      entitySettings: new EventTypeEntitySettings(),
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
    // This determines the form field states, based on the rule configurations defined in @see EventTypeConfig.
    this.pageState = PageState.View;

    // You can add other actions here if required.
    this.actions.push(this.entitySettings.closeAction);

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