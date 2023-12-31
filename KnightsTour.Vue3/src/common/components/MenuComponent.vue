<!--
* Component: menuComponent
* Location:  src\common\components\
* 
* The default menu.  It is assumed that this will be overwritten with a custom implementation.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on January 21, 2023 at 7:35:06 AM
-->

<template>
  <div>
    <img
      class="app-Logo"
      :src="projectSettings.logoUrl"
      :alt="projectSettings.name + ' logo'"
      :title="projectSettings.name + ' logo'"
    />
    <div class="q-pa-md q-gutter-sm">
      <q-list>
        <q-expansion-item
          v-for="section in menuSections"
          v-bind:key="section.label"
          expand-separator
          :icon="section.icon"
          :label="section.label"
          :caption="section.description"
        >
          <div class="q-pa-md" style="max-width: 250px">
            <q-list
              padding
              class="text-information"
              v-for="node in section.nodes"
              v-bind:key="node.id"
            >
              <q-item
                clickable
                v-ripple
                :active="selectedNode === node.id"
                @click="selectedNode = node.id"
                :to="node.route"
                active-class="selected-menu-link"
              >
                <q-item-section avatar v-if="node.icon.length > 0">
                  <q-item-label>
                    <q-icon
                      v-if="node.icon.length > 0"
                      :name="node.icon"
                    ></q-icon>
                    {{ node.label }}
                  </q-item-label>
                  <q-item-label caption v-if="node.description.length > 0">{{
                    node.description
                  }}</q-item-label>
                </q-item-section>
              </q-item>
            </q-list>
          </div>
        </q-expansion-item>
      </q-list>
    </div>
  </div>
</template>
<script lang="ts">
  /** Imports: Required classes, compoenents, controls etc. for this component. */
  import { BoardEntitySettings } from 'src/entities/Board/models/entitySettings';
  import { DifficultyLevelEntitySettings } from 'src/entities/DifficultyLevel/models/entitySettings';
  import { EventHistoryEntitySettings } from 'src/entities/EventHistory/models/entitySettings';
  import { EventTypeEntitySettings } from 'src/entities/EventType/models/entitySettings';
  import { MemberEntitySettings } from 'src/entities/Member/models/entitySettings';
  import { 
    MenuSection,
    MenuSectionFromSettings,
  } from '../models/menu';
  import { ProjectSettings } from 'src/common/models/projectSettings';
  import { PuzzleEntitySettings } from 'src/entities/Puzzle/models/entitySettings';
  import { SolutionEntitySettings } from 'src/entities/Solution/models/entitySettings';


/** Component: menuComponent
* - The default menu.  It is assumed that this will be overwritten with a custom implementation.
*/
export default {
  Name: 'menuComponent',
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** The collection of @see MenuSection groups to render. */
      menuSections: [] as MenuSection[],
      /** Grants local access to the project level settings. */
      projectSettings: new ProjectSettings(),
      /** The selected note (to set a special class on for rendering purposes). */
      selectedNode: '',
    };
  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // Initializes the menu.
    this.loadMenu();
  },
  /** https://vuejs.org/guide/essentials/reactivity-fundamentals.html#declaring-methods */
  methods: {
    /**
    * Computed variable loadMenu: 
    * - Loads the menu.
    * @returns {void} Nothing.
    */
    loadMenu: function (): void {
      // Loads the Board List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new BoardEntitySettings())
      );

      // Loads the DifficultyLevel List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new DifficultyLevelEntitySettings())
      );

      // Loads the EventHistory List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new EventHistoryEntitySettings())
      );

      // Loads the EventType List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new EventTypeEntitySettings())
      );

      // Loads the Member List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new MemberEntitySettings())
      );

      // Loads the Puzzle List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new PuzzleEntitySettings())
      );

      // Loads the Solution List and Add functions (by default) onto the menu structure.
      this.menuSections.push(
        new MenuSectionFromSettings(new SolutionEntitySettings())
      );


    }, // loadMenu

  },
};
</script>

  <style scoped>
    .selected-menu-link {
      color: white;
      background: #1976d2;
    }
  </style>