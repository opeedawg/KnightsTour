<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <div class="q-pa-xl row justify-center" v-if="!loaded">
      <q-spinner color="green" size="10em" :thickness="10" />
    </div>
    <div v-if="loaded && errorMessage.length == 0">
      <p class="center success">
        <strong>{{ shareSolution.memberName }}</strong> completed this Knights
        Tour in <strong>{{ shareSolution.solutionDuration }}</strong> seconds on
        {{ shareSolution.startDateFormatted }}
      </p>
      <table class="puzzleBoard" v-if="loaded">
        <tr class="puzzleRow" v-for="row in puzzle.rowIndexes" v-bind:key="row">
          <td
            v-for="col in puzzle.colIndexes"
            v-bind:class="{
              puzzleCell: true,
              puzzleCellStart: puzzle.puzzleCells[row][col] == 1,
              puzzleCellEnd:
                puzzle.puzzleCells[row][col] == puzzle.rows * puzzle.cols,
            }"
            v-bind:key="col"
            clickable
          >
            <span v-if="puzzle.puzzleCells[row][col] > 0" class="puzzleHint">{{
              puzzle.puzzleCells[row][col]
            }}</span>
          </td>
        </tr>
      </table>

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
      <p class="center info">Can you do better?!?</p>
    </div>
    <div v-if="errorMessage.length > 0">
      <p class="center error">
        {{ errorMessage }}
      </p>
    </div>
  </div>
</template>

<script lang="ts">
import { SessionStorage } from 'quasar';
import { ApiService } from 'src/API/apiService';
import { Member } from 'src/models/Member';
import { DXResponse } from 'src/models/Support/dxterity';
import { UtilityInstance } from 'src/models/Support/global';
import { DboVPuzzleOfTheDay } from 'src/models/views/DboVPuzzleOfTheDay';
import { ref } from 'vue';
import { DboVShareSolution } from 'src/models/views/DboVShareSolution';
import { useRoute } from 'vue-router';

export default {
  Name: 'SharePage',
  data() {
    return {
      utilityInstance: UtilityInstance,
      form: {
        cellInput: [] as string[],
      },
    };
  },
  setup() {
    const api = new ApiService();
    const member = ref(new Member());
    const puzzle = ref(new DboVPuzzleOfTheDay());
    const loadStep = ref(0);
    const shareSolution = ref(new DboVShareSolution());
    const errorMessage = ref('');
    const startDateFormatted = ref('');

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
    }

    const route = useRoute();
    console.log(route.query.code);
    let solutionCode = '';
    if (route.query.code) {
      solutionCode = route.query.code.toString();
    }
    api.getPuzzle(solutionCode).then(function (response: DXResponse) {
      console.log('response', response);
      if (response.isValid) {
        puzzle.value = response.dataObject;
        api
          .getShareSolution(solutionCode)
          .then(function (response: DXResponse) {
            if (response.isValid) {
              shareSolution.value = response.dataObject;
            } else {
              UtilityInstance.toastResponse(response);
            }

            loadStep.value++;
          });
      } else {
        errorMessage.value = response.messages[0].content;
        loadStep.value++;
      }

      loadStep.value++;
    });

    return {
      api,
      member,
      puzzle,
      shareSolution,
      loadStep,
      errorMessage,
      startDateFormatted,
    };
  },
  computed: {
    loaded: function () {
      return this.loadStep == 2;
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
