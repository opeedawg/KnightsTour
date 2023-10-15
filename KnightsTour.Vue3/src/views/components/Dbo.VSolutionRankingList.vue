<!--
* Component: Dbo.VSolutionRankingList
* Location:  src\views\components\
* 
* The class that represents a compoenent to retrieve and list data from view dbo.V_SolutionRanking.
* 
* @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
* Generated on October 14, 2023 at 10:21:16 AM
-->

<template>
  <!-- Loading icon -->
  <div class="q-pa-xl row justify-center" v-if="!loaded">
    <q-spinner color="green" size="5em" :thickness="10" />
  </div>

  <div class="q-pa-md" v-if="loaded">
    <q-table
      title="Dbo. v solution ranking"
      row-key="UserInitials"
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
  import { Dbo.VSolutionRanking } from 'src/views/models/extended/Dbo.VSolutionRanking';
  import { DXEntityFilter, DXResponse } from 'src/common/models/dxterity';
  import { UtilityInstance } from 'src/common/models/global';
  import { ViewEnum } from '../viewEnum';


/** The definition of the columns, feel free to rearrange add or remove as required. */
const columns = [
  {
    name: 'UserInitials',
    required: true,
    label: 'User initial',
    field: (row: Dbo.VSolutionRanking) => row.userInitials,
    sortable: true,
  },
  {
    name: 'SolutionDuration',
    required: false,
    label: 'Solution duration',
    field: (row: Dbo.VSolutionRanking) => row.solutionDuration,
    sortable: true,
  },
  {
    name: 'PuzzleId',
    required: false,
    label: 'Puzzle id',
    field: (row: Dbo.VSolutionRanking) => row.puzzleId,
    sortable: true,
  },
  {
    name: 'MemberId',
    required: false,
    label: 'Member id',
    field: (row: Dbo.VSolutionRanking) => row.memberId,
    sortable: true,
  },
];

/** The definition of the rows element to be bound to the table. */
const rows = [] as Dbo.VSolutionRanking[];
/** Component: Dbo.VSolutionRankingList
* - The class that represents a compoenent to retrieve and list data from view dbo.V_SolutionRanking.
*/
export default {
  Name: 'Dbo.VSolutionRankingList',
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
      'UserInitials'
    );

    // If a filter has been passed, then use that instead.
    if (this.filter) {
      // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
      listFilter = this.filter;
    }

    // Retrieve the data from the view based on this filter.
    this.baseStore
      .getView(ViewEnum.DboVSolutionRanking, listFilter, true)
      .then(function (response: DXResponse) {
        if (response.isValid) {
          self.rows.splice(
          0,
          response.dataObject.length,
          ...response.dataObject
        );
      } else {
        UtilityInstance.toastResponse(response);
      }

      self.loadStep++;
    });
  },
};
</script>