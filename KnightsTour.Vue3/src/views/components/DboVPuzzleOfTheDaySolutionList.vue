<!--
* Component: DboVPuzzleOfTheDaySolutionList
* Location:  src\views\components\
* 
* The class that represents a compoenent to retrieve and list data from view dbo.V_PuzzleOfTheDaySolution.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on October 26, 2023 at 9:29:54 AM
-->

<template>
  <!-- Loading icon -->
  <div class="q-pa-xl row justify-center" v-if="!loaded">
    <q-spinner color="green" size="5em" :thickness="10" />
  </div>

  <div class="q-pa-md" v-if="loaded">
    <q-table
      title="Dbo v puzzle of the day solution"
      row-key="PuzzleId"
      :class="{hiddenHeader: !showHeader }"
      :columns="columns"
      :rows="rows"
      :filter="searchFilter"
    >
      <template v-slot:top-right>
        <q-input
          dense
          debounce="300"
          v-model="searchFilter"
          placeholder="Search"
          input-class="tableSearch"
        >
          <template v-slot:append>
            <q-icon name="search" color="white" />
          </template>
        </q-input>
      </template>
    </q-table>
  </div>
</template>
<script lang="ts">
  /** Imports: Required classes, components, controls etc. for this component. */
  import { BaseStore } from 'src/common/stores/base.store';
  import { DboVPuzzleOfTheDaySolution } from 'src/views/models/extended/DboVPuzzleOfTheDaySolution';
  import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
  import { ref } from 'vue';
  import { UtilityInstance } from 'src/common/models/global';
  import { ViewEnum } from '../viewEnum';


/** The definition of the columns, feel free to rearrange add or remove as required. */
const columns = [
  {
    name: 'PuzzleId',
    required: true,
    label: 'Puzzle id',
    field: (row: DboVPuzzleOfTheDaySolution) => row.puzzleId,
    sortable: true,
  },
  {
    name: 'MemberId',
    required: false,
    label: 'Member id',
    field: (row: DboVPuzzleOfTheDaySolution) => row.memberId,
    sortable: true,
  },
  {
    name: 'Rows',
    required: false,
    label: 'Row',
    field: (row: DboVPuzzleOfTheDaySolution) => row.rows,
    sortable: true,
  },
  {
    name: 'Cols',
    required: false,
    label: 'Col',
    field: (row: DboVPuzzleOfTheDaySolution) => row.cols,
    sortable: true,
  },
  {
    name: 'PuzzlePath',
    required: false,
    label: 'Puzzle path',
    field: (row: DboVPuzzleOfTheDaySolution) => row.puzzlePath,
    sortable: true,
  },
  {
    name: 'SolutionDuration',
    required: false,
    label: 'Solution duration',
    field: (row: DboVPuzzleOfTheDaySolution) => row.solutionDuration,
    sortable: true,
  },
  {
    name: 'SolutionStartDate',
    required: false,
    label: 'Solution start date',
    field: (row: DboVPuzzleOfTheDaySolution) => row.solutionStartDate,
    sortable: true,
  },
  {
    name: 'Difficulty',
    required: false,
    label: 'Difficulty',
    field: (row: DboVPuzzleOfTheDaySolution) => row.difficulty,
    sortable: true,
  },
  {
    name: 'PuzzleOfTheDayDate',
    required: false,
    label: 'Puzzle of the day date',
    field: (row: DboVPuzzleOfTheDaySolution) => row.puzzleOfTheDayDate,
    sortable: true,
  },
  {
    name: 'MemberPath',
    required: false,
    label: 'Member path',
    field: (row: DboVPuzzleOfTheDaySolution) => row.memberPath,
    sortable: true,
  },
  {
    name: 'SolutionId',
    required: false,
    label: 'Solution id',
    field: (row: DboVPuzzleOfTheDaySolution) => row.solutionId,
    sortable: true,
  },
  {
    name: 'Note',
    required: false,
    label: 'Note',
    field: (row: DboVPuzzleOfTheDaySolution) => row.note,
    sortable: true,
  },
];

/** The definition of the rows element to be bound to the table. */
const rows = [] as DboVPuzzleOfTheDaySolution[];
/** Component: DboVPuzzleOfTheDaySolutionList
* - The class that represents a compoenent to retrieve and list data from view dbo.V_PuzzleOfTheDaySolution.
*/
export default {
  Name: 'DboVPuzzleOfTheDaySolutionList',
  /** https://vuejs.org/guide/components/props.html */
  props: {
    /** The filter to apply to the data retrieval, if not provided all data will be returned. */
    filter: {
      type: DXEntityFilter,
      required: false,
    },
    /** Should the header of the table be displayed or not. */
    showHeader: {
      type: Boolean,
      required: false,
      default: false,
    },
  },
  /** https://vuejs.org/api/composition-api-setup.html */
  setup() {
    let searchFilter = ref('');

    return {
      searchFilter,
      columns,
      rows,
    }
  },
  /** https://vuejs.org/api/options-state.html */
  data: function () {
    return {
      /** The reference to the generic base store which provides the access to all the view data retrieval. */
      baseStore: new BaseStore(),
      /** The current load step. */
      loadStep: 0,
      /** The number of steps required to load this component, if you add more increase this and increment as required. */
      totalSteps: 1,
    };
  },
  /** https://vuejs.org/guide/essentials/computed.html */
  computed: {
    /**
    * Computed function [loaded] for variable loaded: 
    * - Determines with the data for this component has been loaded.
    * @returns {boolean} TRUE if loaded.
    */
    loaded: function loaded(): boolean {
      return this.loadStep >= this.totalSteps;
    }, // loaded

  },
  /** https://programeasily.com/2021/05/16/lifecycle-hooks-in-vue-3/ */
  mounted: function () {
    // A required reference to this component for sub references.
    let self = this;

    // Set a default pagination and sort filter if none is passed.

    let listFilter: DXEntityFilter = new DXEntityFilter(
      0,
      10,
      'PuzzleId'
    );

    // If a filter has been passed, then use that instead.
    if (this.filter) {
      // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
      listFilter = this.filter;
    }

    this.$emit('loading');
    // Retrieve the data from the view based on this filter.
    this.baseStore
      .getView(ViewEnum.DboVPuzzleOfTheDaySolution, listFilter, true)
      .then(function (response: DXResponse) {
        if (response.isValid) {
          self.rows = [];
          self.rows.splice(
          0,
          response.dataObject.length,
          ...response.dataObject
        );
        self.$emit('loaded', true);
      } else {
        UtilityInstance.toastResponse(response);
        self.$emit('loaded', false);
      }

      self.loadStep++;
    });
  },
};
</script>