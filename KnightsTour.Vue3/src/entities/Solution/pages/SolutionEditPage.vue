<!--
* Component: SolutionEditPage
* Location:  src\entities\Solution\pages\
* 
* The page displayed when editing an existing @see Solution.
* Note: The field states are configured in @see SolutionConfig class.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on January 21, 2023 at 7:35:06 AM
-->

<template>
  <q-layout>
    <q-card style="min-width: 350px">
      <q-card-section>
        <div class="text-h6">Solution '{{ entity.instanceLabel }}'</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        <SolutionFieldsComponent
          v-if="pageLoaded && entityLoaded"
          :pageState="pageState"
          :entity="entity"
          :formActions="actions"
          @userAction="processFieldsAction"
        ></SolutionFieldsComponent>
      </q-card-section>
    </q-card>
  </q-layout>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { FormAction } from 'src/common/models/formAction';
  import { FormActionArgs } from 'src/common/models/arguments';
  import { 
    MessageType,
    Messaging,
  } from 'src/common/models/messaging';
  import { 
    PageState,
    UtilityInstance,
  } from 'src/common/models/global';
  import { ProjectSettings } from '../../../common/models/projectSettings';
  import { route } from 'quasar/wrappers';
  import { Solution } from '../models/Solution';
  import { SolutionEntitySettings } from '../models/entitySettings';
  import { SolutionStore } from '../stores/Solution.store';
  import { ToastType } from '../../../common/models/quasar';
  import { useRouter } from 'vue-router';
  import SolutionFieldsComponent from '../components/SolutionFieldsComponent.vue';


/** Component: SolutionEditPage
* - The page displayed when editing an existing @see Solution.
* Note: The field states are configured in @see SolutionConfig class.
*/
export default {
  Name: 'SolutionEditPage',
  /** Registration of all child components used by this component. */
  components: {
    SolutionFieldsComponent,
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** A refererence to the global router to grab the passed parameters. */
      $route: route,
      /** The list of @see FormAction do be rendered on this page. */
      actions: [] as FormAction[],
      /** The @see Solution in which to render. */
      entity: new Solution(),
      /** Used in react entity state management. */
      entityLoaded: false,
      /** Provides access to entity level settings. */
      entitySettings: new SolutionEntitySettings(),
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
      /** The store reference to access all @see Solution related functionality. */
      solutionStore: new SolutionStore(),
    };
  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // This determines the form field states, based on the rule configurations defined in @see SolutionConfig.
    this.pageState = PageState.Edit;

    // Attempt to grab the id from the URL
    const entityId: number = parseInt(this.$route.params.id as string);
    if (isNaN(entityId)) {
      // Redirect or do warn the user.
    } else {
      this.solutionStore.get(entityId).then((response) => {
        this.entity = response;
        this.entityLoaded = true;
      });
    }

    // You can add other actions here if required.
    this.actions.push(this.entitySettings.listAction);
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
      if (args.action == this.projectSettings.updateActionName) {
        try {
          this.entityLoaded = false;
          this.solutionStore.update(args.data).then((response) => {
            if (response.isValid) {
              if (this.entitySettings.toastOnUpdate) {
                UtilityInstance.toast(
                  this.message.getMessage(MessageType.UpdateSuccess,
                    {
                      entitySettings: this.entitySettings,
                    }
                  ),
                  ToastType.Positive
                );
              }
              this.entity = <Solution>response.dataObject;
              this.entityLoaded = true;
            } else {
              if (this.entitySettings.toastOnException) {
                UtilityInstance.toast(
                  this.message.getMessage(MessageType.UpdateFailed, {
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
              this.message.getMessage(MessageType.UpdateFailed,
                {
                  entitySettings: this.entitySettings,
                  error: err
                }
              ),
              ToastType.Negative
            );
          }
        }
      } else if (args.action == this.projectSettings.listActionName) {
        // Perform the navigation.
        this.router.push({ name: 'SolutionList' });
      }
    }, // processFieldsAction

  },
};
</script>