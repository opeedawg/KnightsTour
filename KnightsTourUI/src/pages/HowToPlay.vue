<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h3 class="center">How To Play</h3>
    <q-card dark>
      <q-tabs
        v-model="tab"
        tab
        class="text-grey"
        active-color="white"
        indicator-color="white"
        align="justify"
        dark
      >
        <q-tab name="movement" label="1. How a knight moves" />
        <q-tab name="process" label="2. The process" />
        <q-tab name="winning" label="3. How to win" />
        <q-tab name="complicated" label="4. It's complicated!" />
        <q-tab name="levels" label="5. Difficulty Levels" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated dark>
        <q-tab-panel name="movement">
          A knight moves like a
          <a
            href="https://en.wikipedia.org/wiki/Knight_(chess)"
            target="_new"
            title="External link to wikipedia.org"
            >knight does in chess</a
          >, that is 2 steps in 1 direction and 1 step in a perpendicular
          direction:<br />
          <img
            src="images/KnightMoves.png"
            height="300"
            width="300"
            class="center"
          />
          <ol>
            <li>The destination must be a valid square.</li>
            <li>The destination must be open.</li>
            <li>
              Notice the white knight has 8 possible moves (the maximum
              possible) while the black knight is more restricted.
            </li>
          </ol>
        </q-tab-panel>

        <q-tab-panel name="process">
          A knight's tour is a sequence of moves of a knight on a chessboard
          such that the knight visits every square exactly once:
          <img
            src="images/TourPath.gif"
            height="300"
            width="300"
            class="center"
          />
          <ol>
            <li>
              The first square will always be one of the hints, decorated as
              follows:
              <td class="puzzleCell puzzleCellStart clickable">1</td>
            </li>
            <li>
              The final square will always be one of the hints, decorated as
              follows:
              <td class="puzzleCell puzzleCellEnd clickable">64</td>
            </li>
            <li>
              Hints (filled in certain squares) will look like this and are not
              editable:
              <td class="puzzleCell puzzleHint clickable">13</td>
              The number of hints the tour will start with depends on the
              difficuly level.
            </li>
            <li>
              Empty squares in which you can type (only numbers are allowed)
              will appear as follows:
              <td class="puzzleCell editable">
                <input
                  v-model="testInput"
                  @keypress="isNumber($event)"
                  @input="puzzleInputChanged()"
                  class="puzzleInput"
                  type="number"
                />
              </td>
              This test square assumes the puzzle has a maximum value of 64.
            </li>
          </ol>
        </q-tab-panel>

        <q-tab-panel name="winning">
          If you can determine a path that allows the knight to visit each
          square once and only once, you win!
          <img
            src="images/ClosedTour.gif"
            height="300"
            width="300"
            class="center"
          />
        </q-tab-panel>

        <q-tab-panel name="complicated">
          <ul>
            <li>
              Sounds easy, but keep in mind for an 8x8 board there are
              19,591,828,170,979,904 possible tours!
            </li>
            <li>
              The puzzle aspect comes into play where you are seeded with a
              partially completed puzzle which will at the very least always
              contain the <span style="color: green">first</span> and
              <span style="color: orange">last</span> squares as follows:
              <br />
              <img
                src="images/SolvableEasyBoard.png"
                height="300"
                width="300"
                class="center"
              />
            </li>
            <li>
              The following puzzle represents an "easy" 6x6 board - which took
              20,817,763 process iterations to discover.
            </li>
            <li>
              Common pitfalls (learned through extensive personal experience)
              include:
              <ul>
                <li>Entering the same guess twice</li>
                <li>
                  Filling in an incorrect guess (obviously, but not always
                  <em>so</em> obvious)
                </li>
                <li>Entering a guess that already has a fixed hint</li>
                <li>Typos (input errors)</li>
                <li>Typos (square/location errors)</li>
              </ul>
            </li>
            <li>
              The difficuly levels (next tab) and online help features are
              designed to help with exactly these pitfalls.
            </li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="levels">
          <q-table
            title="There are 5 distinct difficulty levels"
            :rows="rows"
            :columns="cols"
            row-key="name"
            dark
            :hide-pagination="true"
          >
            <template #body-cell-rating="props">
              <q-td style="text-align: center">
                <DifficultyLevelControl
                  :value="props.row.difficultyLevelId"
                ></DifficultyLevelControl>
              </q-td>
            </template>
            <template #body-cell-HighlightClosestEnabled="props">
              <TableBoolean
                :value="props.row.highlightClosestEnabled"
              ></TableBoolean>
            </template>
            <template #body-cell-DuplicateCheckingEnabled="props">
              <TableBoolean
                :value="props.row.duplicateCheckingEnabled"
              ></TableBoolean>
            </template>
            <template #body-cell-GuessFilterEnabled="props">
              <TableBoolean
                :value="props.row.guessFilterEnabled"
              ></TableBoolean>
            </template>
            <template #body-cell-BadLinkEnabled="props">
              <TableBoolean :value="props.row.badLinkEnabled"></TableBoolean>
            </template>
          </q-table>
          <p class="doc-note doc-note--tip">
            The idea is to assist you with a greater number of hints and support
            functionality as you learn how to play Knights Tours. We highly
            recommend starting with the easier levels (with the most support!)
            and slowly progressing through the harder levels.
          </p>
          <h5>Explanations</h5>
          <ul>
            <li>
              <span class="definition">Max Gap:</span>The maximum number of
              missing numbers between hints.
            </li>
            <li>
              <span class="definition">Min Dimension:</span>The minimum columns
              or rows in the size of the tour.
            </li>
            <li>
              <span class="definition">Max Dimension:</span>The maximum columns
              or rows in the size of the tour.
            </li>
            <li>
              <span class="definition">Hints:</span>The percentage of squares
              that are initially filled in.
            </li>
            <li>
              <span class="definition">Show Closest:</span>If enabled, when
              clicking on a filled in square the next highest and next lowest in
              sequence squares will be highlighted as follows:
              <td class="puzzleCell closest">#</td>
            </li>
            <li>
              <span class="definition">Show Duplicates:</span>A common mistake
              is to fill in a square with a value that already exists - this
              will notify you if that occurs as follows:
              <td class="puzzleCell duplicate">#</td>
            </li>
            <li>
              <span class="definition">Show Guess Filter:</span>To help
              visualize what guesses are left, a sequential grid is displayed
              showing the used and unsed tour values.
            </li>
            <li>
              <span class="definition">Show Disconnected:</span>Disconnected
              Squares are highlighted as follows:
              <td class="puzzleCell disconnected">#</td>
            </li>
          </ul>
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue';
import { QTableProps } from 'quasar';
import { DifficultyLevel } from 'src/models/DifficultyLevel';
import { ApiService } from 'src/API/apiService';
import { DXResponse } from 'src/models/Support/dxterity';
import {
  ToastPositionType,
  Utility,
  UtilityInstance,
} from 'src/models/Support/global';
import TableBoolean from 'src/controls/TableBoolean.vue';
import DifficultyLevelControl from 'src/controls/DifficultyLevelControl.vue';
import { ToastType } from 'src/models/Support/quasar';

export default {
  Name: 'HowToPlay',
  components: {
    TableBoolean,
    DifficultyLevelControl,
  },
  data() {
    return {
      utilityInstance: new Utility(),
    };
  },
  setup() {
    const api = new ApiService();
    const tab = ref('movement');
    const cols = ref([] as QTableProps['columns']);
    const rows = ref([] as DifficultyLevel[]);
    const testInput = ref('');

    cols.value?.push({
      name: 'level',
      label: 'Level',
      align: 'left',
      field: 'name',
      sortable: false,
    });
    cols.value?.push({
      name: 'rating',
      label: 'Rating',
      align: 'center',
      field: 'rating',
      sortable: false,
    });
    cols.value?.push({
      name: 'description',
      label: 'Description',
      align: 'left',
      field: 'description',
      sortable: false,
    });
    cols.value?.push({
      name: 'maximumGap',
      label: 'Max Gap',
      align: 'center',
      field: 'maximumGap',
      sortable: false,
    });
    cols.value?.push({
      name: 'MinimumDimension',
      label: 'Min Dimension',
      align: 'center',
      field: 'minimumDimension',
      sortable: false,
    });
    cols.value?.push({
      name: 'MaximumDimension',
      label: 'Max Dimension',
      align: 'center',
      field: 'maximumDimension',
      sortable: false,
    });
    cols.value?.push({
      name: 'percentVisibility',
      label: 'Hints',
      align: 'center',
      field: 'percentVisibility',
      format: (val: number) => {
        return val * 100 + '%';
      },
      sortable: false,
    });
    cols.value?.push({
      name: 'HighlightClosestEnabled',
      label: 'Show Closest',
      align: 'center',
      field: 'highlightClosestEnabled',
      sortable: false,
    });
    cols.value?.push({
      name: 'DuplicateCheckingEnabled',
      label: 'Show Duplicates',
      align: 'center',
      field: 'duplicateCheckingEnabled',
      sortable: false,
    });
    cols.value?.push({
      name: 'GuessFilterEnabled',
      label: 'Show Guess Filter',
      align: 'center',
      field: 'guessFilterEnabled',
      sortable: false,
    });
    cols.value?.push({
      name: 'BadLinkEnabled',
      label: 'Show Disconnected',
      align: 'center',
      field: 'badLinkEnabled',
      sortable: false,
    });

    api.getLevels().then(function (response: DXResponse) {
      if (response.isValid) {
        rows.value = response.dataObject;
      } else {
        UtilityInstance.toastResponse(response);
      }
    });

    return {
      tab,
      cols,
      rows,
      testInput,
    };
  },
  methods: {
    getLevel(row: DifficultyLevel): number {
      return this.utilityInstance.GetRatingLevel(row.difficultyLevelId);
    },

    isNumber: function (evt: KeyboardEvent) {
      var charCode = evt.which ? evt.which : evt.keyCode;
      if (charCode < 48 || charCode > 57) {
        evt.preventDefault();
      } else {
        return true;
      }
    },

    puzzleInputChanged: function () {
      if (Number(this.testInput) > 64) {
        UtilityInstance.toast(
          this.testInput + ' exceeds the maximum value (64) for this puzzle.',
          ToastType.Warning,
          ToastPositionType.Center,
          true
        );

        this.testInput = '';
      }
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
