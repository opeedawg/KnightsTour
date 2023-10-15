<!--
* Component: EventHistoryInsertPage
* Location:  src\entities\EventHistory\pages\
* 
* The page displayed inserting a new @see EventHistory.
* Note: The field states are configured in @see EventHistoryConfig class.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on January 21, 2023 at 7:35:06 AM
-->

<template>
  <q-layout>
    <q-card style="min-width: 350px">
      <q-card-section>
        <div class="text-h6">New Event history</div>
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
  </q-layout>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { EventHistory } from '../models/EventHistory';
  import { EventHistoryEntitySettings } from '../models/entitySettings';
  import { EventHistoryStore } from '../stores/EventHistory.store';
  import { FormAction } from 'src/common/models/formAction';
  import { FormActionArgs } from 'src/common/models/arguments';
  import { 
    MessageType,
    Messaging,
  } from 'src/common/models/messaging';
  import { 
    PageState,
    PostInsertNavigationOption,
    UtilityInstance,
  } from 'src/common/models/global';
  import { ProjectSettings } from '../../../common/models/projectSettings';
  import { ToastType } from '../../../common/models/quasar';
  import { useRouter } from 'vue-router';
  import EventHistoryFieldsComponent from '../components/EventHistoryFieldsComponent.vue';


/** Component: EventHistoryInsertPage
* - The page displayed inserting a new @see EventHistory.
* Note: The field states are configured in @see EventHistoryConfig class.
*/
export default {
  Name: 'EventHistoryInsertPage',
  /** Registration of all child components used by this component. */
  components: {
    EventHistoryFieldsComponent,
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** The list of @see FormAction do be rendered on this page. */
      actions: [] as FormAction[],
      /** The @see EventHistory in which to render. */
      entity: new EventHistory(),
      /** Provides access to entity level settings. */
      entitySettings: new EventHistoryEntitySettings(),
      /** The store reference to access all @see EventHistory related functionality. */
      eventhistoryStore: new EventHistoryStore(),
      /** Initialized a local messaging class for access to all common system wide messaging constructs. */
      message: new Messaging(),
      /** Used in react page state management. */
      pageLoaded: false,
      /** The @see PageState (applies various field rules). */
      pageState: '',
      /** Provides access to project level settings. */
      projectSettings: new ProjectSettings(),
      /** A refererence to the global router to allow for programatic navigation. */
      router: useRouter(),
    };
  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // This determines the form field states, based on the rule configurations defined in @see EventHistoryConfig.
    this.pageState = PageState.Insert;

    // You can customize these actions or add other actions here if required.
    this.actions.push(this.entitySettings.listAction);
    this.actions.push(this.entitySettings.insertAction);

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
      if (args.action == this.projectSettings.insertActionName) {
        try {
          this.eventhistoryStore.insert(args.data).then((response) => {
            if (response.isValid) {
              if (this.entitySettings.toastOnInsert) {
                UtilityInstance.toast(
                  this.message.getMessage(MessageType.InsertSuccess,
                    {
                      entitySettings: this.entitySettings,
                    }
                  ),
                  ToastType.Positive
                );
              }

              // Construct the route for post insert navigation.
              let postInsertRoute:any = {
                name: 'EventHistory' + this.entitySettings.navigationAfterInsert,
              };

              // We need to pass the id as a paramter if not navigating to the list page.
              if (
                this.entitySettings.navigationAfterInsert !=
                PostInsertNavigationOption.List
              ) {
                postInsertRoute['params'] = { id: (<EventHistory>response.dataObject).eventHistoryId };
              }

              // Perform the navigation.
              this.router.push(postInsertRoute);
            } else {
              if (this.entitySettings.toastOnException) {
                UtilityInstance.toast(
                  this.message.getMessage(MessageType.InsertFailed, {
                    entitySettings: this.entitySettings,
                    error: response.messages[0].content,
                  }),
                  ToastType.Negative
                );
              }
            }
          });
        } catch (err: any) {
          if (this.entitySettings.toastOnException) {
            UtilityInstance.toast(
              this.message.getMessage(MessageType.InsertFailed, {
                entitySettings: this.entitySettings,
                error: err.message,
              }),
              ToastType.Negative
            );
          }
        }
      } else if (args.action == this.projectSettings.listActionName) {
        // Perform the navigation.
        this.router.push({ name: 'EventHistoryList' });
      }
    }, // processFieldsAction

  },
};
</script>