<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <div class="q-pa-xl row justify-center" v-if="!loaded">
      <q-spinner color="green" size="10em" :thickness="10" />
    </div>
    <div v-if="loaded">
      <h3 class="center">
        Tour Of The Day for {{ puzzle.puzzleDayFormatted }}
      </h3>
      <div v-if="puzzleComplete">
        <div class="center doc-note doc-note--tip">
          <p class="doc-note__title">
            Daily tour compelted - check back tomorrow for more!
          </p>
          You completed the daily tour in
          {{ puzzle.memberSolution?.solutionDurationFormatted }}.
        </div>
        <q-table
          title="Member Rankings"
          :rows="rankings"
          :columns="rankColumns"
          row-key="rank"
          dark
          :hide-pagination="true"
        >
        </q-table>
      </div>
      <div class="row" v-if="!puzzleComplete">
        <div :class="puzzle.difficultyLevel == 'Easy' ? 'col-6' : 'col'">
          <span class="center"
            >Started at:
            {{ puzzle.memberSolution?.solutionStartDateFormatted }} ({{
              getPercentageComplete()
            }}
            % complete)
          </span>
          <table class="puzzleBoard" v-if="puzzleVisible">
            <tr
              class="puzzleRow"
              v-for="row in puzzle.rowIndexes"
              v-bind:key="row"
            >
              <td
                v-for="col in puzzle.colIndexes"
                v-bind:class="{
                  puzzleCell: true,
                  puzzleCellStart: puzzle.puzzleCells[row][col] == 1,
                  puzzleCellEnd:
                    puzzle.puzzleCells[row][col] == puzzle.rows * puzzle.cols,
                  editable: puzzle.puzzleCells[row][col] == 0,
                  clickable: puzzle.puzzleCells[row][col] > 0,
                  closest:
                    (row == prevRowIndex && col == prevColIndex) ||
                    (row == nextRowIndex && col == nextColIndex),
                  duplicate:
                    (puzzle.difficultyLevel == 'Beginner' ||
                      puzzle.difficultyLevel == 'Easy' ||
                      puzzle.difficultyLevel == 'Medium') &&
                    duplicateValues.filter((d) => {
                      if (d == puzzle.puzzleCells[row][col]) {
                        return d;
                      }
                    }).length > 0,
                  disconnected:
                    puzzle.difficultyLevel == 'Beginner' &&
                    disconnectedValues.filter((d) => {
                      if (
                        puzzle.memberSolution &&
                        d == puzzle.memberSolution.memberCells[row][col]
                      ) {
                        return d;
                      }
                    }).length > 0,
                }"
                v-bind:key="col"
                clickable
                @click="boardCellClick(row, col)"
              >
                <span
                  v-if="puzzle.puzzleCells[row][col] > 0"
                  class="puzzleHint"
                  >{{ puzzle.puzzleCells[row][col] }}</span
                >
                <input
                  v-model="form.cellInput[getId(row, col)]"
                  @keypress="isNumber($event)"
                  @input="puzzleInputChanged(row, col)"
                  v-bind:class="{
                    puzzleInput: true,
                    puzzleInputHighlight:
                      (row == prevRowIndex && col == prevColIndex) ||
                      (row == nextRowIndex && col == nextColIndex),
                    duplicate:
                      (puzzle.difficultyLevel == 'Beginner' ||
                        puzzle.difficultyLevel == 'Easy' ||
                        puzzle.difficultyLevel == 'Medium') &&
                      duplicateValues.filter((d) => {
                        if (d == Number(form.cellInput[getId(row, col)])) {
                          return d;
                        }
                      }).length > 0,
                    disconnected:
                      puzzle.difficultyLevel == 'Beginner' &&
                      disconnectedValues.filter((d) => {
                        if (
                          puzzle.memberSolution &&
                          d == puzzle.memberSolution.memberCells[row][col]
                        ) {
                          return d;
                        }
                      }).length > 0,
                  }"
                  v-if="puzzle.puzzleCells[row][col] == 0"
                  type="number"
                />
              </td>
            </tr>
          </table>
          <div
            v-if="
              (puzzle.difficultyLevel == 'Beginner' ||
                puzzle.difficultyLevel == 'Easy' ||
                puzzle.difficultyLevel == 'Medium') &&
              duplicateValues.length > 0
            "
            class="doc-note doc-note--warning center"
          >
            {{ duplicateValues.length }} duplicate values detected!
          </div>
          <div
            v-if="
              puzzle.difficultyLevel == 'Beginner' &&
              disconnectedValues.length > 0
            "
            class="doc-note doc-note--warning center"
          >
            {{ disconnectedValues.length }} disconnected values detected!
          </div>
          <span class="center">Notes</span>
          <q-input
            v-model="notes"
            dark
            filled
            type="textarea"
            style="max-width: 600px"
            class="center"
          />
          <q-card-actions class="q-px-md center">
            <q-btn
              unelevated
              color="primary"
              label="Clear &amp; Restart"
              @click="clearPuzzleRequested"
              icon="recycling"
            />
          </q-card-actions>
        </div>
        <div
          v-if="
            puzzle.difficultyLevel == 'Beginner' ||
            puzzle.difficultyLevel == 'Easy'
          "
          class="col-6"
        >
          <span class="center"> Guess Filter Helper </span>
          <table class="puzzleBoard" v-if="puzzleVisible">
            <tr
              class="puzzleRow"
              v-for="row in puzzle.rowIndexes"
              v-bind:key="row"
            >
              <td
                v-for="col in puzzle.colIndexes"
                v-bind:class="{
                  puzzleCell: true,
                  helperCell: true,
                  puzzleCellStart: getId(row, col) == 0,
                  puzzleCellEnd:
                    getId(row, col) == puzzle.rows * puzzle.cols - 1,
                }"
                v-bind:key="col"
                clickable
                @click="hintCellClick(getId(row, col) + 1)"
              >
                <span
                  v-if="
                    filledValues.filter((v) => {
                      if (v == getId(row, col) + 1) {
                        return v;
                      }
                    }).length > 0
                  "
                  >{{ getId(row, col) + 1 }}</span
                >
              </td>
            </tr>
          </table>
        </div>
      </div>
      <div class="center" style="width: 650px; text-align: left">
        <ul>
          <li>
            <span class="definition">Discovered on:</span
            >{{ puzzle.discoveryDate }}
          </li>
          <li>
            <span class="definition">Difficulty level:</span
            >{{ puzzle.difficultyLevel }}
          </li>
          <li>
            <span class="definition">Dimmenstions:</span>{{ puzzle.cols }} x
            {{ puzzle.rows }}
          </li>
          <li>
            <span class="definition">Discovery iterations:</span
            >{{ puzzle.discoveryIterationCount.toLocaleString() }}
          </li>
          <li><span class="definition">Author:</span>{{ puzzle.author }}</li>
          <li>
            <span class="definition">Puzzle Code:</span>{{ puzzle.puzzleCode }}
          </li>
        </ul>
      </div>

      <p class="message" v-if="member.memberId == 0">
        <q-icon name="warning" color="orange" size="24px"> </q-icon>
      </p>
    </div>
  </div>

  <!-- Modals -->
  <NewPuzzleOfTheDayWarningModal
    v-if="newModalVisible"
    :puzzleId="puzzle.puzzleId"
    @startPuzzle="startNewPuzzle"
  ></NewPuzzleOfTheDayWarningModal>

  <ExistingPuzzleOfTheDayWarningModal
    v-if="existingModalVisible"
    @continuePuzzle="continuePuzzle"
  ></ExistingPuzzleOfTheDayWarningModal>

  <MembershipRequiredModal
    v-if="membershipRequiredVisible"
  ></MembershipRequiredModal>

  <PuzzleClearConfirmationModal
    v-if="clearConfirmationModalVisible"
    @yes="clearPuzzle"
    @no="clearConfirmationModalVisible = false"
  ></PuzzleClearConfirmationModal>
</template>

<script lang="ts">
import { QTableProps, SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import { ToastPositionType, UtilityInstance } from 'src/models/Support/global';
import { DboVPuzzleOfTheDay } from 'src/models/views/DboVPuzzleOfTheDay';
import { ref } from 'vue';
import NewPuzzleOfTheDayWarningModal from 'src/modals/NewPuzzleOfTheDayWarningModal.vue';
import ExistingPuzzleOfTheDayWarningModal from 'src/modals/ExistingPuzzleOfTheDayWarningModal.vue';
import MembershipRequiredModal from 'src/modals/MembershipRequiredModal.vue';
import PuzzleClearConfirmationModal from 'src/modals/PuzzleClearConfirmationModal.vue';
import { ToastType } from 'src/models/Support/quasar';
import { DboVSolutionRanking } from 'src/models/views/DboVSolutionRanking';

export default {
  Name: 'TourOfTheDay',
  components: {
    NewPuzzleOfTheDayWarningModal,
    MembershipRequiredModal,
    ExistingPuzzleOfTheDayWarningModal,
    PuzzleClearConfirmationModal,
  },
  data() {
    return {
      utilityInstance: UtilityInstance,
      loadStep: 0,
      puzzleComplete: false,
      prevRowIndex: -1,
      prevColIndex: -1,
      nextRowIndex: -1,
      nextColIndex: -1,
      filledValues: [] as number[],
      duplicateValues: [] as number[],
      disconnectedValues: [] as number[],
      form: {
        cellInput: [] as string[],
      },
      rankings: [] as DboVSolutionRanking[],
      notes: '',
    };
  },
  setup() {
    const api = new ApiService();
    const member = ref(new Member());
    const puzzle = ref(new DboVPuzzleOfTheDay());
    const newModalVisible = ref(false);
    const existingModalVisible = ref(false);
    const membershipRequiredVisible = ref(false);
    const clearConfirmationModalVisible = ref(false);
    const rankColumns = ref([] as QTableProps['columns']);

    rankColumns.value?.push({
      name: 'rank',
      label: 'Rank',
      align: 'center',
      field: 'rank',
      sortable: false,
    });
    rankColumns.value?.push({
      name: 'userInitials',
      label: 'Member Initials',
      align: 'center',
      field: 'userInitials',
      sortable: false,
    });
    rankColumns.value?.push({
      name: 'durationFormatted',
      label: 'Solution Time',
      align: 'center',
      field: 'durationFormatted',
      sortable: false,
    });

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
    }

    return {
      api,
      member,
      puzzle,
      newModalVisible,
      existingModalVisible,
      membershipRequiredVisible,
      rankColumns,
      clearConfirmationModalVisible,
    };
  },
  created() {
    this.utilityInstance.ReloadScreen();
  },
  methods: {
    isNumber: function (evt: KeyboardEvent) {
      var charCode = evt.which ? evt.which : evt.keyCode;
      if (charCode < 48 || charCode > 57) {
        evt.preventDefault();
      } else {
        return true;
      }
    },

    puzzleInputChanged: function (row: number, col: number) {
      const id = this.getId(row, col);
      if (
        Number(this.form.cellInput[id]) >
        this.puzzle.rows * this.puzzle.cols
      ) {
        UtilityInstance.toast(
          this.form.cellInput[id] +
            ' exceeds the maximum value (' +
            this.puzzle.rows * this.puzzle.cols +
            ') for this puzzle.',
          ToastType.Warning,
          ToastPositionType.Center,
          true
        );

        this.form.cellInput[id] = '';
      } else {
        if (this.puzzle.memberSolution) {
          this.puzzle.memberSolution.memberCells[row][col] = Number(
            this.form.cellInput[id]
          );
        }
      }

      this.highlightClosestSquares(row, col);
      this.updateSolutionPath();
      this.updateHelpData();
      this.checkForCompleteness();
    },

    updateHelpData: function () {
      this.updateFilledValues();
      this.updateDuplicateValues();
      this.updateDisconnectedSquares();
    },

    updateDisconnectedSquares: function () {
      this.disconnectedValues = [];

      if (this.puzzle.memberSolution) {
        for (let i = 1; i <= this.puzzle.rows * this.puzzle.cols; i++) {
          const valueLocation = this.getMemberValueLocation(i);
          if (valueLocation != null) {
            // This value exists
            if (
              (this.filledValueExists(i - 1) &&
                !this.isKnightConnected(
                  i - 1,
                  valueLocation[0],
                  valueLocation[1]
                )) ||
              (this.filledValueExists(i + 1) &&
                !this.isKnightConnected(
                  i + 1,
                  valueLocation[0],
                  valueLocation[1]
                ))
            ) {
              this.disconnectedValues.push(i);
            }
          }
        }
      }
    },

    filledValueExists: function (value: number) {
      return (
        this.filledValues.filter((v) => {
          if (v == value) {
            return v;
          }
        }).length > 0
      );
    },

    getMemberValueLocation: function (value: number) {
      if (this.puzzle.memberSolution) {
        for (let r = 0; r < this.puzzle.rows; r++) {
          for (let c = 0; c < this.puzzle.cols; c++) {
            if (this.puzzle.memberSolution.memberCells[r][c] == value) {
              let location = [];
              location.push(r);
              location.push(c);
              return location;
            }
          }
        }
      } else {
        return null;
      }
    },

    checkForCompleteness: function () {
      let self = this;
      if (this.puzzle.memberSolution) {
        if (
          this.filledValues.length == this.puzzle.rows * this.puzzle.cols &&
          this.duplicateValues.length == 0
        ) {
          if (this.isValidSolution()) {
            this.api
              .completeSolution(this.puzzle.memberSolution.solutionId)
              .then(function (response: DXResponse) {
                self.loadDailyPuzzle(false); //This will both refresh and show rankings
              });
          } else {
            UtilityInstance.toast(
              'This is not a valid solution to this knights tour - there are squares that are not connected.',
              ToastType.Negative,
              ToastPositionType.Center,
              true
            );
          }
        }
      }
    },

    isValidSolution: function () {
      if (!this.puzzle.memberSolution) {
        return false;
      } else {
        for (let r = 0; r < this.puzzle.rows; r++) {
          for (let c = 0; c < this.puzzle.cols; c++) {
            let cellValue = this.puzzle.memberSolution.memberCells[r][c];

            if (cellValue == 0) {
              return false;
            } else if (cellValue == 1) {
              if (!this.isKnightConnected(cellValue + 1, r, c)) {
                return false;
              }
            } else if (cellValue == this.puzzle.rows * this.puzzle.cols) {
              if (!this.isKnightConnected(cellValue - 1, r, c)) {
                return false;
              }
            } else {
              if (
                !this.isKnightConnected(cellValue - 1, r, c) ||
                !this.isKnightConnected(cellValue + 1, r, c)
              ) {
                return false;
              }
            }
          }
        }

        return true;
      }
    },

    isKnightConnected(value: number, row: number, col: number) {
      for (let r = 0; r < this.puzzle.rows; r++) {
        for (let c = 0; c < this.puzzle.cols; c++) {
          if (this.puzzle.memberSolution?.memberCells[r][c] == value) {
            return Math.abs(row - r) + Math.abs(col - c) == 3;
          }
        }
      }

      return false;
    },

    updateFilledValues: function () {
      this.filledValues = [];

      if (this.puzzle.memberSolution) {
        for (let r = 0; r < this.puzzle.rows; r++) {
          for (let c = 0; c < this.puzzle.cols; c++) {
            if (this.puzzle.memberSolution.memberCells[r][c] > 0) {
              this.filledValues.push(
                this.puzzle.memberSolution.memberCells[r][c]
              );
            }
          }
        }
      }
    },

    getPathString: function () {
      let pathString = '{"Path":['; //this.puzzle.memberSolution?.memberCells.toString();
      for (let r = 0; r < this.puzzle.rows; r++) {
        pathString += '[';
        for (let c = 0; c < this.puzzle.cols; c++) {
          pathString += this.puzzle.memberSolution?.memberCells[r][c];
          if (c < this.puzzle.cols - 1) {
            pathString += ',';
          }
        }
        if (r < this.puzzle.rows - 1) {
          pathString += '],';
        } else {
          pathString += ']';
        }
      }

      pathString += ']}';

      return pathString;
    },

    updateSolutionPath: function () {
      if (this.puzzle.memberSolution) {
        let pathString = this.getPathString();

        this.api
          .updateSolution(
            this.puzzle.memberSolution.solutionId,
            pathString,
            this.notes
          )
          .then(function (response: DXResponse) {
            if (!response.isValid) {
              UtilityInstance.toastResponse(response);
            }
          });
      }
    },

    updateDuplicateValues: function () {
      this.duplicateValues = [];
      for (let i = 1; i <= this.puzzle.rows * this.puzzle.cols; i++) {
        let count = 0;

        for (let r = 0; r < this.puzzle.rows; r++) {
          for (let c = 0; c < this.puzzle.cols; c++) {
            if (Number(this.puzzle.memberSolution?.memberCells[r][c]) == i) {
              count++;
            }
          }
        }

        if (count > 1) {
          this.duplicateValues.push(i);
        }
      }
    },

    getId: function (row: number, col: number) {
      return col + row * this.puzzle.cols;
    },

    boardCellClick: function (row: number, col: number) {
      this.highlightClosestSquares(row, col);
    },

    hintCellClick: function (id: number) {
      this.prevRowIndex = -1;
      this.prevColIndex = -1;
      this.nextRowIndex = -1;
      this.nextColIndex = -1;
      let cellLocation = this.getMemberValueLocation(id);
      if (cellLocation != null) {
        this.boardCellClick(cellLocation[0], cellLocation[1]);
      }
    },

    highlightClosestSquares(row: number, col: number) {
      this.prevRowIndex = -1;
      this.prevColIndex = -1;
      this.nextRowIndex = -1;
      this.nextColIndex = -1;
      if (
        this.puzzle.difficultyLevel != 'Challenging' &&
        this.puzzle.memberSolution &&
        this.puzzle.memberSolution?.memberCells[row][col] > 0
      ) {
        const cellValue = this.puzzle.memberSolution.memberCells[row][col];

        let prevVal = 0;
        let nextVal = this.puzzle.rows * this.puzzle.cols + 1;

        if (cellValue > 1) {
          // Previous number.
          for (let r = 0; r < this.puzzle.rows; r++) {
            for (let c = 0; c < this.puzzle.cols; c++) {
              let testValue = this.puzzle.memberSolution.memberCells[r][c];

              if (
                testValue > 0 &&
                testValue < cellValue &&
                testValue > prevVal
              ) {
                prevVal = testValue;
                this.prevRowIndex = r;
                this.prevColIndex = c;
              }
            }
          }
        }
        if (
          this.puzzle.memberSolution?.memberCells[row][col] <
          this.puzzle.rows * this.puzzle.cols
        ) {
          // Next number.
          for (let r = 0; r < this.puzzle.rows; r++) {
            for (let c = 0; c < this.puzzle.cols; c++) {
              let testValue = this.puzzle.memberSolution.memberCells[r][c];
              if (
                testValue > 0 &&
                testValue > cellValue &&
                testValue < nextVal
              ) {
                nextVal = testValue;
                this.nextRowIndex = r;
                this.nextColIndex = c;
              }
            }
          }
        }
      }
    },

    startNewPuzzle: function () {
      this.newModalVisible = false;

      this.loadDailyPuzzle(false);
    },

    continuePuzzle: function () {
      this.existingModalVisible = false;
    },

    loadDailyPuzzle: function (showWarningModal: boolean) {
      this.loadStep = 0;
      let self = this;
      this.api
        .getDailyPuzzle(this.member.memberId)
        .then(function (response: DXResponse) {
          if (response.isValid) {
            self.puzzle = response.dataObject;
            if (
              !self.puzzle.memberSolution ||
              self.puzzle.memberSolution?.solutionDuration == 0
            ) {
              self.onPuzzleLoaded(showWarningModal);
            } else {
              self.loadPuzzleRankings();
            }
          } else {
            UtilityInstance.toastResponse(response);
          }
        });
    },

    onPuzzleLoaded: function (showWarningModal: boolean) {
      this.filledValues = [];
      if (this.puzzle.memberSolution == null) {
        this.newModalVisible = true;
      } else if (this.puzzle.memberSolution.solutionDuration == 0) {
        this.existingModalVisible = showWarningModal;
        console.log('this.puzzle.memberSolution', this.puzzle.memberSolution);
        this.loadInputValues(this.puzzle.memberSolution.memberCells);
        this.notes = this.puzzle.memberSolution.note;
        this.updateHelpData();
      }

      this.loadStep++;
    },

    loadPuzzleRankings: function () {
      this.loadStep = 0;
      this.rankings = [];
      let self = this;
      this.api
        .getPuzzleRankings(this.puzzle.puzzleId, this.member.memberId)
        .then(function (response: DXResponse) {
          if (response.isValid) {
            self.rankings = response.dataObject;
            self.puzzleComplete = true;
            self.loadStep++;
          } else {
            UtilityInstance.toastResponse(response);
          }
        });
    },

    loadInputValues: function (sourceArray: number[][]) {
      for (let r = 0; r < this.puzzle.rows; r++) {
        for (let c = 0; c < this.puzzle.cols; c++) {
          const id = this.getId(r, c);
          if (sourceArray[r][c] > 0) {
            this.form.cellInput[id] = sourceArray[r][c].toString();
            this.filledValues.push(sourceArray[r][c]);
          }
        }
      }
    },

    getPercentageComplete: function () {
      if (this.puzzle.memberSolution) {
        return Math.round(
          (this.filledValues.length / (this.puzzle.rows * this.puzzle.cols)) *
            100
        );
      } else {
        return '0';
      }
    },

    clearPuzzleRequested: function () {
      this.clearConfirmationModalVisible = true;
    },

    clearPuzzle: function () {
      this.clearConfirmationModalVisible = false;

      if (this.puzzle.memberSolution) {
        // This is the key line, effectively resetting everything back to the original state.
        this.puzzle.memberSolution.memberCells = this.copyValues(
          this.puzzle.puzzleCells
        );

        this.form.cellInput = [];
        this.updateSolutionPath();
        this.updateFilledValues();
        this.updateDuplicateValues();
      }

      this.form.cellInput = [];
      this.filledValues = [];
    },

    copyValues(source: number[][]) {
      return JSON.parse(JSON.stringify(source));
    },
  },
  mounted() {
    this.loadStep = 0;
    if (this.member.memberId == 0) {
      this.membershipRequiredVisible = true;
    } else {
      this.loadDailyPuzzle(true);
    }
  },
  computed: {
    loaded: function () {
      return this.loadStep == 1;
    },
    puzzleVisible: function () {
      return this.puzzle.memberSolution != null;
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
