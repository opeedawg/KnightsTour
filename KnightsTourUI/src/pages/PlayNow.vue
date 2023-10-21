<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <div class="q-pa-xl row justify-center" v-if="!loaded">
      <q-spinner color="green" size="10em" :thickness="10" />
    </div>
    <div v-if="loaded" class="search">
      <q-expansion-item
        v-model="searchVisible"
        :header-inset-level="0"
        :content-inset-level="0"
        expand-separator
        icon="search"
        default-opened
        label="Pick a Knights Tour!"
      >
        <q-card dark>
          <q-card-section>
            <div class="row q-pa-sm">
              <div class="col q-pa-md">
                <q-select
                  dark
                  label="Size"
                  v-model="sizeId"
                  :options="sizeOptions"
                ></q-select>
              </div>
              <div class="col q-pa-md">
                <q-select
                  dark
                  label="Difficuly Level"
                  v-model="difficultyLevelId"
                  :options="difficultyLevelOptions"
                >
                </q-select>
              </div>
              <div class="col q-pa-md">
                <q-input
                  dark
                  label="Puzzle Code"
                  v-model="puzzleCode"
                  bottom-slots
                >
                  <template v-slot:prepend>
                    <q-icon name="fingerprint" />
                  </template>

                  <template v-slot:hint>
                    <p class="hint">
                      A specific puzzle code - this option will override the
                      other filter criteria.
                    </p>
                  </template>
                </q-input>
              </div>
            </div>
            <div class="row q-pa-sm">
              <div class="col q-pa-md" style="text-align: center">
                <q-btn
                  unelevated
                  color="green"
                  label="Find a tour"
                  @click="getRandomTour"
                  icon="search"
                />
                <q-checkbox
                  v-if="memberId > 0"
                  v-model="newPuzzlesOnly"
                  label="New puzzles only"
                />
              </div>
            </div>
            <div class="row q-pa-xs" v-if="puzzleLoaded">
              <div
                class="col q-pa-xs doc-note--danger"
                style="text-align: center; color: red"
              >
                Warning: Choosing a new puzzle will cause you to lose your
                current progress!
              </div>
            </div>
          </q-card-section>
        </q-card>
      </q-expansion-item>
    </div>

    <div class="row" v-if="loaded">
      <div class="q-pa-md q-gutter-sm" style="height: 100%; width: 100%">
        <div class="q-pa-xl row justify-center" v-if="!loaded">
          <q-spinner color="green" size="10em" :thickness="10" />
        </div>
        <div v-if="loaded">
          <div class="center" v-if="puzzle.puzzleCode != ''">
            <h5 style="margin: 0; padding 0">
              Knights Tour Puzzle: {{ puzzle.difficultyLevel }}
              {{ puzzle.cols }} x
              {{ puzzle.rows }}
            </h5>
            <DifficultyLevelControl
              :value="puzzle.difficultyLevelId"
            ></DifficultyLevelControl>
          </div>
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
          <PuzzleControl
            v-if="puzzleLoaded && !puzzleComplete"
            :puzzleInput="puzzle"
            :key="puzzleId"
            @puzzleComplete="tourCompleted"
          ></PuzzleControl>
        </div>
      </div>
    </div>
  </div>
  <NameRequiredModal
    v-if="nameRequiredVisible"
    @nameSet="hideNameRequiredModal"
  ></NameRequiredModal>
</template>

<script lang="ts">
import { QSelectOption, QTableProps, SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { DifficultyLevel } from 'src/models/DifficultyLevel';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import {
  ScreenRoute,
  ToastPositionType,
  UtilityInstance,
} from 'src/models/Support/global';
import { DboVPuzzleOfTheDay } from 'src/models/views/DboVPuzzleOfTheDay';
import PuzzleControl from 'src/controls/PuzzleControl.vue';
import { ref } from 'vue';
import { DboVSolutionRanking } from 'src/models/views/DboVSolutionRanking';
import { ToastType } from 'src/models/Support/quasar';
import DifficultyLevelControl from 'src/controls/DifficultyLevelControl.vue';
import NameRequiredModal from 'src/modals/NameRequiredModal.vue';
import { Solution } from 'src/models/Solution';

export default {
  Name: 'PlayNow',
  components: {
    PuzzleControl,
    DifficultyLevelControl,
    NameRequiredModal,
  },
  data() {
    return {
      difficultyLevelId: { label: 'Random', value: '0' },
      sizeId: { label: 'Random', value: '' },
      puzzleCode: '',
      puzzleComplete: false,
      rankings: [] as DboVSolutionRanking[],
      puzzleLoaded: false,
      puzzleId: '',
    };
  },
  setup() {
    const api = new ApiService();
    const utilityInstance = UtilityInstance;
    let difficultyLevelOptions = ref([] as QSelectOption[]);
    let sizeOptions = ref([] as QSelectOption[]);
    const puzzle = ref(new DboVPuzzleOfTheDay());
    const loadStep = ref(0);
    const member = ref(new Member());
    const newPuzzlesOnly = ref(false);
    const rankColumns = ref([] as QTableProps['columns']);
    const searchVisible = ref(true);
    const nameRequiredVisible = ref(false);
    const memberId = ref(0);

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
      memberId.value = member.value.memberId;
      newPuzzlesOnly.value = true;
    } else {
      let nonMemberName = SessionStorage.getItem('nonMemberName');

      nameRequiredVisible.value =
        !nonMemberName || nonMemberName.toString().length == 0;
    }

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

    sizeOptions.value = [];
    api.getDistinctBoardSizes().then(function (response: DXResponse) {
      if (response.isValid) {
        sizeOptions.value = response.dataObject;
        sizeOptions.value.push({ label: 'Random', value: '' });
        loadStep.value++;
      } else {
        utilityInstance.toastResponse(response);
      }
    });

    difficultyLevelOptions.value = [];
    api.getLevels().then(function (response: DXResponse) {
      if (response.isValid) {
        response.dataObject.forEach(function (level: DifficultyLevel) {
          difficultyLevelOptions.value.push({
            label: level.name,
            value: level.difficultyLevelId.toString(),
          });
        });
        difficultyLevelOptions.value.push({ label: 'Random', value: '0' });
        loadStep.value++;
      } else {
        utilityInstance.toastResponse(response);
      }
    });

    return {
      api,
      utilityInstance,
      sizeOptions,
      difficultyLevelOptions,
      loadStep,
      member,
      memberId,
      newPuzzlesOnly,
      rankColumns,
      searchVisible,
      puzzle,
      nameRequiredVisible,
    };
  },
  methods: {
    hideNameRequiredModal: function () {
      this.nameRequiredVisible = false;
      this.utilityInstance.Navigate(ScreenRoute.PlayNow, true);
    },
    getRandomTour: function () {
      let self = this;
      this.api
        .getRandomPuzzle(
          this.member.memberId,
          this.newPuzzlesOnly,
          Number(this.difficultyLevelId.value),
          this.sizeId.value,
          this.puzzleCode
        )
        .then(function (response: DXResponse) {
          if (response.isValid) {
            self.puzzle = response.dataObject;
            self.puzzleLoaded = true;
            self.puzzleId = self.puzzle.puzzleCode;
            self.searchVisible = false;
            console.log('self.puzzle', self.puzzle);
          } else {
            self.utilityInstance.toastResponse(response);
          }
        });

      // Do search
    },
    tourCompleted: function (solution: Solution) {
      console.log('Playnow Solution', solution);

      // Do something?
      console.log('completed solution', solution);
      UtilityInstance.toast(
        'You did it!',
        ToastType.Positive,
        ToastPositionType.Center,
        true
      );
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
  },
  computed: {
    loaded: function () {
      return this.loadStep > 1;
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
