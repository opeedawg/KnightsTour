<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <div class="q-pa-xl row justify-center" v-if="!loaded">
      <q-spinner color="green" size="10em" :thickness="10" />
    </div>
    <div v-if="loaded">
      <h3 class="center">Joe completed this Knights Tour in 123.23 seconds!</h3>
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
          ></td>
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
import { DboVSolutionRanking } from 'src/models/views/DboVSolutionRanking';
import { useRoute } from 'vue-router';

export default {
  Name: 'SharePage',
  data() {
    return {
      utilityInstance: UtilityInstance,
      loadStep: 0,
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
    const loadStep = ref(0);

    if (SessionStorage.getItem('member') != null) {
      member.value = SessionStorage.getItem('member') as Member;
    }

    const route = useRoute();
    console.log(route.query);
    api.getPuzzle(route.query.toString()).then(function (response: DXResponse) {
      if (response.isValid) {
        puzzle.value = response.dataObject;
      } else {
        UtilityInstance.toastResponse(response);
      }

      loadStep.value++;
    });

    return {
      api,
      member,
      puzzle,
    };
  },
  computed: {
    loaded: function () {
      return this.loadStep == 1;
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
