<!--
* Component: MemberViewPage
* Location:  src\entities\Member\pages\
* 
* The page for viewing a @see Member.
* Note: The field states are configured in @see MemberConfig class.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on January 21, 2023 at 7:35:06 AM
-->

<template>
  <q-layout>
    <q-card style="min-width: 350px">
      <q-card-section>
        <div class="text-h6">Member '{{ entity.instanceLabel }}'</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        <MemberFieldsComponent
          v-if="pageLoaded && entityLoaded"
          :pageState="pageState"
          :entity="entity"
          :formActions="actions"
          @userAction="processFieldsAction"
        ></MemberFieldsComponent>
      </q-card-section>
    </q-card>
  </q-layout>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { FormAction } from 'src/common/models/formAction';
  import { 
    FormActionArgs,
    GenericConfirmationArgs,
  } from 'src/common/models/arguments';
  import { 
    GenericConfirmationConfiguration,
    PageState,
    UtilityInstance,
  } from 'src/common/models/global';
  import { Member } from '../models/Member';
  import { MemberEntitySettings } from '../models/entitySettings';
  import { MemberStore } from '../stores/Member.store';
  import { 
    MessageType,
    Messaging,
  } from 'src/common/models/messaging';
  import { ProjectSettings } from '../../../common/models/projectSettings';
  import { route } from 'quasar/wrappers';
  import { ToastType } from 'src/common/models/quasar';
  import { useRouter } from 'vue-router';
  import MemberFieldsComponent from '../components/MemberFieldsComponent.vue';

  /** Enumerations */
  /** Defines the various possible modal types used on this screen. */
  enum modalType {
    /** The generic confirmation modal. */
    GenericConfirmation = 'GenericConfirmation',
  }


// Modal visibility states (initialized to all hidden).
const modalState = new Map<string, boolean>();
modalState.set(modalType.GenericConfirmation, false);
/** Component: MemberViewPage
* - The page for viewing a @see Member.
* Note: The field states are configured in @see MemberConfig class.
*/
export default {
  Name: 'MemberViewPage',
  /** Registration of all child components used by this component. */
  components: {
    MemberFieldsComponent,
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** A refererence to the global router to grab the passed parameters. */
      $route: route,
      /** The list of @see FormAction do be rendered on this page. */
      actions: [] as FormAction[],
      /** The @see Member in which to render. */
      entity: new Member(),
      /** Used in react entity state management. */
      entityLoaded: false,
      /** Provides access to entity level settings. */
      entitySettings: new MemberEntitySettings(),
      /** The @see GenericConfirmationConfiguration.  Customizable for each invocation of the modal. */
      genericConfirmationConfiguration: new GenericConfirmationConfiguration('notSet', 'notSet'),
      /** The store reference to access all @see Member related functionality. */
      memberStore: new MemberStore(),
      /** Initialized a local messaging class for access to all common system wide messaging constructs. */
      message: new Messaging(),
      /** The modal states (map of boolean values) to be accessible and manipulated by the controls and functions. */
      modalState,
      /** The modal type enum - required by the controls. */
      modalType,
      /** Used in react page state management. */
      pageLoaded: false,
      /** The @see PageState (applies various field rules). */
      pageState: '',
      /** Provides access to project level settings. */
      projectSettings: new ProjectSettings(),
      /** A refererence to the global router to allow for programatic navigation. */
      router: useRouter(),
      /** The selected row. */
      selectedMember: new Member(),
    };
  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // This determines the form field states, based on the rule configurations defined in @see MemberConfig.
    this.pageState = PageState.View;

    // Attempt to grab the id from the URL
    const entityId: number = parseInt(this.$route.params.id as string);
    if (isNaN(entityId)) {
      // Redirect or do warn the user.
    } else {
      this.memberStore.get(entityId).then((response) => {
        this.entity = response;
        this.entityLoaded = true;
      });
    }

    // You can add other actions here if required.
    this.actions.push(this.entitySettings.listAction);

    if (this.entitySettings.deleteSingleOnPage) {
      this.actions.push(this.entitySettings.deleteAction);
    }

    if (this.entitySettings.navigateEdit) {
      this.actions.push(this.entitySettings.editAction);
    }

    // Set the page as loaded.
    this.pageLoaded = true;
  },
  /** https://vuejs.org/guide/essentials/reactivity-fundamentals.html#declaring-methods */
  methods: {
    /**
    * Computed variable genericConfirmationReponse: 
    * - Invoked when the generic confirmation modal raises an event.
    * @param {GenericConfirmationArgs} confirmationArguments: The @see GenericConfirmationArgs response object.
    * @returns {void} Nothing
    */
    genericConfirmationReponse: function (
      confirmationArguments: GenericConfirmationArgs
    ): void {
      if (confirmationArguments.id == this.projectSettings.deleteActionName) {
        if (confirmationArguments.result) {
          this.memberStore.delete(this.selectedMember.memberId).then((response) => {
            if (response.isValid) {
              if (this.entitySettings.toastOnDelete) {
                UtilityInstance.toast(
                  this.message.getMessage(MessageType.DeleteSingleConfirmation, {
                    entitySettings: this.entitySettings,
                    instanceLabel: this.selectedMember.instanceLabel
                  }),
                  ToastType.Positive
                );
              }
            } else {
              UtilityInstance.toast(
                this.message.getMessage(MessageType.DeleteSingleConfirmation, {
                  entitySettings: this.entitySettings,
                  message: response.messages[0].content
                }),
                ToastType.Negative
              );
            }
          });
        } else {
          if (this.entitySettings.toastOnCancel) {
            UtilityInstance.toast(
              this.message.getMessage(MessageType.DeleteSingleConfirmation),
              ToastType.Information
            );
          }
        }
      }

      // This gets toggled off every time not matter what the result.
      this.toggleModal(modalType.GenericConfirmation);
    }, // genericConfirmationReponse

    /**
    * Computed variable processFieldsAction: 
    * - 'Generically gathers an attribute collection for field binding.'
    * @param {FormActionArgs} args: The action performed on this component, raised to the parent page.
    * @returns {any} Dynamic object of attributes to bind to the control.
    */
    processFieldsAction: function (
      args: FormActionArgs
    ): any {
      if (args.action == this.projectSettings.listActionName) {
        // Perform the navigation.
        this.router.push({ name: 'MemberList' });
      } else if (args.action == this.projectSettings.deleteActionName) {
        //Todo: implement
      } else if (args.action == this.projectSettings.editActionName) {
        // Perform the navigation.
        this.router.push({ name: 'MemberEdit', params: { id: this.entity.memberId} });
      }
    }, // processFieldsAction

    /**
    * Computed variable showConfirmationModal: 
    * - Shows the generic confirmation modal with any customizations applied.
    * @param {string} genericModalType: The name of the generic modal.
    * @param {Member} payload?: The optional @see Member data related to the toggle event.
    * @returns {void} Nothing
    */
    showConfirmationModal: function (
      genericModalType: string,
      payload?: Member
    ): void {
      // Set the payload.
      if (payload != null) {
        this.selectedMember = payload;
      }
      this.genericConfirmationConfiguration.id = genericModalType;

      // Customize the generic modal based on type.  @see GenericConfirmationConfiguration for all possible options.
      switch (genericModalType) {
        case this.projectSettings.deleteActionName: {
          this.genericConfirmationConfiguration.message =
            this.message.getMessage(MessageType.DeleteSingleConfirmation, {
              entitySettings: this.entitySettings,
              instanceLabel: this.selectedMember.instanceLabel,
            });
          this.genericConfirmationConfiguration.title = this.message.getMessage(MessageType.DeleteSingleConfirmationTitle);
          this.genericConfirmationConfiguration.confirmationText = this.message.getMessage(MessageType.DeleteSingleConfirmationText);
          this.genericConfirmationConfiguration.cancelText = this.message.getMessage(MessageType.DeleteSingleCancelText);
          break;
        }
      }

      // Show the modal.
      this.modalState.set(modalType.GenericConfirmation, true);
    }, // showConfirmationModal

    /**
    * Computed variable toggleModal: 
    * - Toggles the specific modal (reversing its current visibility state), if nothing is passed all modals are closed.  If a payload is passed it is assigned and passed through to the modal.
    * @param {modalType} modal?: The @see modalType to toggle (optional).
    * @param {any} payload?: The optional data related to the toggle event.
    * @returns {void} Nothing
    */
    toggleModal: function (
      modal?: modalType,
      payload?: any
    ): void {
      if (modal != null) {
        // Set the payload - null is acceptable here.
        this.selectedMember = payload;

        // Switch the visibility status.
        this.modalState.set(modal, !modalState.get(modal));
      } else {
        // If no modal is passed, close them all (dynamically).
        this.modalState.forEach((value, key) => {
          this.modalState.set(key, false);
        });
      }
    }, // toggleModal

  },
};
</script>