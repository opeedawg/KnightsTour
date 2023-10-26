<template>
  <div class="row">
    <div
      :class="
        puzzle.difficultyLevel == 'Beginner' || puzzle.difficultyLevel == 'Easy'
          ? 'col-8'
          : 'col'
      "
    >
      <span class="center"
        >{{ getPercentageComplete() }} % complete started at
        {{ solutionStartDateFormatted }}<br />Puzzle Duration:
        {{ puzzleDuration }}
      </span>
      <table class="puzzleBoard" v-if="puzzleVisible">
        <tr class="puzzleRow" v-for="row in puzzle.rowIndexes" v-bind:key="row">
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
                  if (d == solution.memberCells[row][col]) {
                    return d;
                  }
                }).length > 0,
              disconnected:
                puzzle.difficultyLevel == 'Beginner' &&
                disconnectedValues.filter((d) => {
                  if (d == solution.memberCells[row][col]) {
                    return d;
                  }
                }).length > 0,
            }"
            v-bind:key="col"
            clickable
            @click="boardCellClick(row, col)"
          >
            <span v-if="puzzle.puzzleCells[row][col] > 0" class="puzzleHint">{{
              puzzle.puzzleCells[row][col]
            }}</span>
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
                    if (d == solution.memberCells[row][col]) {
                      return d;
                    }
                  }).length > 0,
              }"
              v-if="puzzle.puzzleCells[row][col] == 0"
              type="number"
              maxlength:2
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
          puzzle.difficultyLevel == 'Beginner' && disconnectedValues.length > 0
        "
        class="doc-note doc-note--warning center"
      >
        {{ disconnectedValues.length }} disconnected values detected!
      </div>
    </div>
    <div
      v-if="
        puzzle.difficultyLevel == 'Beginner' || puzzle.difficultyLevel == 'Easy'
      "
      class="col-4"
    >
      <span class="center"> Guess Filter Helper </span>
      <table class="puzzleBoard" v-if="puzzleVisible">
        <tr class="puzzleRow" v-for="row in puzzle.rowIndexes" v-bind:key="row">
          <td
            v-for="col in puzzle.colIndexes"
            v-bind:class="{
              puzzleCell: true,
              helperCell: true,
              puzzleCellStart: getId(row, col) == 0,
              puzzleCellEnd: getId(row, col) == puzzle.rows * puzzle.cols - 1,
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
  <div class="row">
    <q-tabs
      v-model="tab"
      dense
      class="text-grey"
      active-color="primary"
      indicator-color="primary"
      align="justify"
      dark
      style="width: 100%"
    >
      <q-tab name="notes" label="Notes" />
      <q-tab name="details" label="Puzzle Details" />
    </q-tabs>

    <q-tab-panels v-model="tab" animated dark style="width: 100%">
      <q-tab-panel name="notes" style="width: 100%">
        <q-input
          v-model="solution.note"
          dark
          filled
          type="textarea"
          style="width: 600px"
          class="center"
        />
      </q-tab-panel>

      <q-tab-panel name="details">
        <div
          class="center"
          style="width: 100%; text-align: left; margin-left: 30%"
        >
          <ul>
            <li>
              <span class="definition">Discovered on:</span
              >{{ puzzle.discoveryDate }}
            </li>
            <li>
              <span class="definition">Difficulty level:</span
              >{{ puzzle.difficultyLevel }}
              <DifficultyLevelControl
                :value="puzzle.difficultyLevelId"
              ></DifficultyLevelControl>
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
              <span class="definition">Puzzle Code:</span
              >{{ puzzle.puzzleCode }}
            </li>
          </ul>
        </div>
      </q-tab-panel>
    </q-tab-panels>
  </div>
  <div class="row">
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

  <!-- Modals -->
  <PuzzleClearConfirmationModal
    v-if="clearConfirmationModalVisible"
    @yes="clearPuzzle"
    @no="clearConfirmationModalVisible = false"
  ></PuzzleClearConfirmationModal>
</template>

<script lang="ts">
import { SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import { ToastPositionType, UtilityInstance } from 'src/models/Support/global';
import { DboVPuzzleOfTheDay } from 'src/models/views/DboVPuzzleOfTheDay';
import { ref } from 'vue';
import PuzzleClearConfirmationModal from 'src/modals/PuzzleClearConfirmationModal.vue';
import { ToastType } from 'src/models/Support/quasar';
import { DboVSolutionRanking } from 'src/models/views/DboVSolutionRanking';
import { DboVPuzzleOfTheDaySolution } from 'src/models/views/DboVPuzzleOfTheDaySolution';
import DifficultyLevelControl from './DifficultyLevelControl.vue';
import { Solution } from 'src/models/Solution';

export default {
  Name: 'PuzzleControl',
  components: {
    PuzzleClearConfirmationModal,
    DifficultyLevelControl,
  },
  props: {
    puzzleInput: {
      type: DboVPuzzleOfTheDay,
      required: true,
      default: new DboVPuzzleOfTheDay(),
    },
  },
  data() {
    return {
      puzzleComplete: false,
      prevRowIndex: -1,
      prevColIndex: -1,
      nextRowIndex: -1,
      nextColIndex: -1,
      duplicateValues: [] as number[],
      disconnectedValues: [] as number[],
      form: {
        cellInput: [] as string[],
      },
      rankings: [] as DboVSolutionRanking[],
      refreshUI: 0,
      puzzleDuration: '',
      tab: ref('notes'),
      timerRefreshId: 0,
    };
  },
  setup(props) {
    const api = new ApiService();
    const member = ref(new Member());
    const newModalVisible = ref(false);
    const existingModalVisible = ref(false);
    const membershipRequiredVisible = ref(false);
    const clearConfirmationModalVisible = ref(false);
    const puzzle = ref(JSON.parse(JSON.stringify(props.puzzleInput)));
    const solution = ref(new DboVPuzzleOfTheDaySolution());
    const filledValues = ref([] as number[]);
    const solutionStartDateFormatted = ref('unknown');
    const utilityInstance = UtilityInstance;

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
    }

    // This is in case they refreshed the page for some reason, store a sessioned copy.
    let currentSolution = SessionStorage.getItem(
      'currentPuzzleSolution'
    ) as DboVPuzzleOfTheDaySolution;

    // This will be true if first load of a new puzzle!
    if (currentSolution == null) {
      currentSolution = JSON.parse(JSON.stringify(props.puzzleInput));
    }
    // If logged in, track this puzzle.
    if (member.value.memberId > 0) {
      api
        .startPuzzle(puzzle.value.puzzleId, member.value.memberId)
        .then(function (response: DXResponse) {
          if (response.isValid) {
            currentSolution.solutionId = response.dataObject.solutionId;
          } else if (!response.isValid) {
            utilityInstance.toastResponse(response);
          }
        });
    }

    currentSolution.memberCells = JSON.parse(
      JSON.stringify(puzzle.value.puzzleCells)
    );
    currentSolution.note = '';
    currentSolution.puzzleId = puzzle.value.puzzleId;
    currentSolution.solutionStartDate = new Date();

    solution.value = currentSolution;
    SessionStorage.set('currentPuzzleSolution', solution.value);

    const hours = String(currentSolution.solutionStartDate.getHours()).padStart(
      2,
      '0'
    );
    const minutes = String(
      currentSolution.solutionStartDate.getMinutes()
    ).padStart(2, '0');
    const seconds = String(
      currentSolution.solutionStartDate.getSeconds()
    ).padStart(2, '0');

    solutionStartDateFormatted.value = `${hours}:${minutes}:${seconds}`;

    return {
      api,
      member,
      newModalVisible,
      existingModalVisible,
      membershipRequiredVisible,
      clearConfirmationModalVisible,
      puzzle,
      solution,
      filledValues,
      solutionStartDateFormatted,
      utilityInstance,
    };
  },
  beforeMount() {
    this.updateFilledValues();
  },
  created() {
    this.utilityInstance.ReloadScreen();
    if (this.timerRefreshId == 0) {
      let id = setInterval(this.updatePuzzleDuration, 1000);
      this.timerRefreshId = parseInt(id.toString());
    }
    this.updatePuzzleDuration();
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

    updatePuzzleDuration: function () {
      let startDate: Date = new Date(this.solution.solutionStartDate);
      let currentDate: Date = new Date(); // Now?
      this.solution.solutionDuration = Math.round(
        Math.abs(startDate.getTime() - currentDate.getTime()) / 1000
      );
      // calculate (and subtract) whole days
      var days = Math.floor(this.solution.solutionDuration / 86400);
      this.solution.solutionDuration -= days * 86400;

      // calculate (and subtract) whole hours
      var hours = Math.floor(this.solution.solutionDuration / 3600) % 24;
      this.solution.solutionDuration -= hours * 3600;

      // calculate (and subtract) whole minutes
      var minutes = Math.floor(this.solution.solutionDuration / 60) % 60;
      this.solution.solutionDuration -= minutes * 60;

      // what's left is seconds
      var seconds = this.solution.solutionDuration % 60; // in theory the modulus is not required

      this.puzzleDuration =
        this.zeroPadding(hours, 2) +
        ':' +
        this.zeroPadding(minutes, 2) +
        ':' +
        this.zeroPadding(seconds, 2);
    },

    zeroPadding: function (num: number, digit: number) {
      var zero = '';
      for (var i = 0; i < digit; i++) {
        zero += '0';
      }
      return (zero + num).slice(-digit);
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
        this.solution.memberCells[row][col] = Number(this.form.cellInput[id]);
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
      for (let r = 0; r < this.puzzle.rows; r++) {
        for (let c = 0; c < this.puzzle.cols; c++) {
          if (this.solution.memberCells[r][c] == value) {
            let location = [];
            location.push(r);
            location.push(c);
            return location;
          }
        }
      }

      return null;
    },

    checkForCompleteness: function () {
      let self = this;

      if (
        this.filledValues.length == this.puzzle.rows * this.puzzle.cols &&
        this.duplicateValues.length == 0
      ) {
        if (this.isValidSolution()) {
          if (this.member.memberId > 0 && this.solution.solutionId > 0) {
            this.api
              .completeSolution(this.solution.solutionId)
              .then(function (response: DXResponse) {
                UtilityInstance.toastResponse(response);
                if (response.isValid) {
                  self.$emit('puzzleComplete', response.dataObject);
                  clearInterval(self.timerRefreshId);
                }
              });
          } else {
            let startDate: Date = new Date(this.solution.solutionStartDate);
            let currentDate: Date = new Date(); // Now?
            this.solution.solutionDuration =
              Math.abs(startDate.getTime() - currentDate.getTime()) / 1000;

            self.puzzle.solutionDuration = this.solution.solutionDuration;

            let nonMemberSolution = new Solution();
            nonMemberSolution.puzzleId = this.solution.puzzleId;
            nonMemberSolution.solutionStartDate = startDate;
            nonMemberSolution.solutionDuration = this.solution.solutionDuration;
            nonMemberSolution.path = this.getPathString();
            nonMemberSolution.note = this.solution.note;
            let nonMemberName = SessionStorage.getItem('nonMemberName');
            if (nonMemberName && nonMemberName.toString().length > 0)
              nonMemberSolution.nonMemberName = nonMemberName.toString();

            this.api
              .insertNonMemberSolution(nonMemberSolution)
              .then(function (response: DXResponse) {
                UtilityInstance.toastResponse(response);
                if (response.isValid) {
                  self.$emit('puzzleComplete', response.dataObject);
                  clearInterval(self.timerRefreshId);
                }
              });
          }
        } else {
          UtilityInstance.toast(
            'This is not a valid solution to this knights tour - keep trying - you will get it!',
            ToastType.Negative,
            ToastPositionType.Center,
            true
          );
        }
      }
    },

    isValidSolution: function () {
      for (let r = 0; r < this.puzzle.rows; r++) {
        for (let c = 0; c < this.puzzle.cols; c++) {
          let cellValue = this.solution.memberCells[r][c];

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
    },

    isKnightConnected(value: number, row: number, col: number) {
      for (let r = 0; r < this.puzzle.rows; r++) {
        for (let c = 0; c < this.puzzle.cols; c++) {
          if (this.solution.memberCells[r][c] == value) {
            return Math.abs(row - r) + Math.abs(col - c) == 3;
          }
        }
      }

      return false;
    },

    updateFilledValues: function () {
      let newValues = [] as number[];

      for (let r = 0; r < this.puzzle.rows; r++) {
        for (let c = 0; c < this.puzzle.cols; c++) {
          if (this.solution.memberCells[r][c] > 0) {
            newValues.push(this.solution.memberCells[r][c]);
          }
        }
      }

      this.filledValues.splice(0, newValues.length, ...newValues);

      Object.assign(this.filledValues);
    },

    getPathString: function () {
      let pathString = '{"Path":[';
      for (let r = 0; r < this.puzzle.rows; r++) {
        pathString += '[';
        for (let c = 0; c < this.puzzle.cols; c++) {
          pathString += this.solution.memberCells[r][c];
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
      let pathString = this.getPathString();
      if (this.puzzle.memberSolution) {
        this.api
          .updateSolution(
            this.puzzle.memberSolution.solutionId,
            pathString,
            this.solution.note
          )
          .then(function (response: DXResponse) {
            if (!response.isValid) {
              UtilityInstance.toastResponse(response);
            }
          });
      } else {
        this.solution.puzzlePath = pathString;
        SessionStorage.set('currentPuzzleSolution', this.solution);
      }
    },

    updateDuplicateValues: function () {
      this.duplicateValues = [];
      for (let i = 1; i <= this.puzzle.rows * this.puzzle.cols; i++) {
        let count = 0;

        for (let r = 0; r < this.puzzle.rows; r++) {
          for (let c = 0; c < this.puzzle.cols; c++) {
            if (Number(this.solution.memberCells[r][c]) == i) {
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
        this.solution.memberCells[row][col] > 0
      ) {
        const cellValue = this.solution.memberCells[row][col];

        let prevVal = 0;
        let nextVal = this.puzzle.rows * this.puzzle.cols + 1;

        if (cellValue > 1) {
          // Previous number.
          for (let r = 0; r < this.puzzle.rows; r++) {
            for (let c = 0; c < this.puzzle.cols; c++) {
              let testValue = this.solution.memberCells[r][c];

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
          this.solution.memberCells[row][col] <
          this.puzzle.rows * this.puzzle.cols
        ) {
          // Next number.
          for (let r = 0; r < this.puzzle.rows; r++) {
            for (let c = 0; c < this.puzzle.cols; c++) {
              let testValue = this.solution.memberCells[r][c];
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

    continuePuzzle: function () {
      this.existingModalVisible = false;
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
      return Math.round(
        (this.filledValues.length / (this.puzzle.rows * this.puzzle.cols)) * 100
      );
    },

    clearPuzzleRequested: function () {
      this.clearConfirmationModalVisible = true;
    },

    clearPuzzle: function () {
      this.clearConfirmationModalVisible = false;

      // This is the key line, effectively resetting everything back to the original state.
      this.solution.memberCells = this.copyValues(this.puzzle.puzzleCells);
      this.solution.note = '';

      this.form.cellInput = [];
      this.updateSolutionPath();
      this.updateFilledValues();
      this.updateDuplicateValues();

      this.form.cellInput = [];
      this.refreshUI++;
    },

    copyValues(source: number[][]) {
      return JSON.parse(JSON.stringify(source));
    },
  },
  computed: {
    puzzleVisible: function () {
      this.refreshUI;
      return this.solution != null;
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
