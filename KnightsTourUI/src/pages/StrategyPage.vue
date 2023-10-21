<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h3 class="center">Strategies</h3>
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
        <q-tab name="intuition" label="Fight your intuition" />
        <q-tab name="corners" label="Corners are your friend" />
        <q-tab name="forced" label="Forced squares" />
        <q-tab name="advanced" label="Advanced strategies" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated dark>
        <q-tab-panel name="intuition">
          <ul>
            <li>
              Intuitively, you will want to attack a new puzzle systematically,
              starting from 1 and working towards the conclusion.
              <img
                src="images/IntellectIntuition.png"
                height="300"
                class="center"
              />
              <a
                class="reference center"
                ref="https://www.conscious.enterprises/insights/2018/3/28/intellect-vs-intuition"
                title="To learn more visit www.conscious.enterprises."
                >See www.conscious.enterprises</a
              >
            </li>
            <li>
              Although this is possible, it is very rarely the optimal strategy!
            </li>
            <li>
              If you consider it, numbers (like letters) are arbitrary - these
              puzzles have NOTHING to do with mathematics at all!
              <img src="images/mathhate.png" height="300" class="center" />
            </li>
            <li>
              Feel free to work backwards, or start in the middle - be creative!
              <img src="images/Creativity.png" height="300" class="center" />
              <a
                class="reference center"
                ref="https://www.theladders.com/career-advice/this-study-explains-why-humans-are-creative"
                title="To learn more visit www.theladders.com."
                >See www.theladders.com</a
              >
            </li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="corners">
          <ul>
            <li>
              A corner square is the most limited square available with only 2
              possible options.
            </li>
            <li>You can use this to your advantage in several scenarios.</li>
            <li>
              Example #1: The red square must be 29 since the corner square (30)
              can only be attached to 29 or 31, and 31 is visible:<br />
              <img
                src="images/CornerExample1.png"
                height="200"
                width="200"
                class="center"
              />
            </li>
            <li>
              Example #2: The red square must be 35 as the other possibility is
              already populated and must differ by one from the corner, which
              happens to be the final square!<br />
              <img
                src="images/CornerExample2.png"
                height="200"
                width="200"
                class="center"
              />
            </li>
            <li>
              Example #3: The red square must be 5 as it is the only value that
              differs by 1 from 4 and 6:<br />
              <img
                src="images/CornerExample3.png"
                height="200"
                width="200"
                class="center"
              />
            </li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="forced">
          <ul>
            <li>
              Often you will discover squares that are forced (due to puzzle
              restrictions) to be a particular value.
            </li>
            <li>You can use this to your advantage in several scenarios.</li>
            <li>
              Example #1: The red square must be either 35 as it is the only
              available square that can join 34 and 36:<br />
              <img
                src="images/ForcedExample1.png"
                height="128"
                width="268"
                class="center"
              />
            </li>
            <li>Sometimes these forced squares can be 2 or 3 chains long.</li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="advanced">
          <ul>
            <li>
              I am not going to give too much away - it is fun to discover your
              own strategies :p
            </li>
            <li>
              One advanced strategy however is to note that a Knights Tour
              puzzle is instance of the more general
              <a
                href="https://en.wikipedia.org/wiki/Hamiltonian_path_problem"
                target="_new"
                >Hamiltonian path problem</a
              >
              in
              <a href="https://en.wikipedia.org/wiki/Graph_theory" target="_new"
                >graph theory</a
              >
              which is typically
              <a href="https://en.wikipedia.org/wiki/NP-hardness" target="_new"
                >NP-hard</a
              >.
            </li>
            <li>
              However, by applying
              <a
                href="https://books.google.ca/books?id=w5FZAAAAYAAJ&printsec=frontcover&dq=h.+c.+von+warnsdorf&hl=en&sa=X&ei=2QZmU9-jJIaXO8-hgKgL&redir_esc=y#v=onepage&q=h.%20c.%20von%20warnsdorf&f=false"
                target="_new"
                >Warnsdorff</a
              >'s rule and extended work by
              <a
                href="https://dl.acm.org/doi/10.1145/363427.363463"
                target="_new"
                >Ira Pohl</a
              >
              and
              <a
                href="https://dl.acm.org/doi/10.1145/503720.503806"
                target="_new"
                >Karla Alwan and Kelly Waters</a
              >, this particular problem variation can be solved in linear time.
            </li>
            <li>
              All this can be summarized by saying that an OPTIMAL solution when
              you have a choice is to choose the square with the fewest
              possibilities available to it (this is a gross over
              simplification, read the papers and do the math if you want to
              master this).
              <img src="images/Warnsdorff.gif" width="200" class="center" />
            </li>
            <li>
              Be aware since I have studied these papers my Knights Tour solving
              software was created with a somewhat advanced heuristic to defeat
              this flaw (pattern?!?) and balance the ability to find a solution
              while still implementing some randomness into the solution.
            </li>
            <li>
              Of interest I have discovered that other published Knights Tour
              books have all taken the easy path (Implementing Warnsdorff rule
              systematically so that it was easier to discover solutions).
              Learning and exlpoiting these rules is of great advantage in those
              cases - but again they will only have limited value on this site.
            </li>
            <li>
              Application of Warnsdorff's rule: The bottom square is MORE LIKELY
              to be 11 (since it is an edge square and has fewer possible moves
              available to it then a central square) even though either red
              squares COULD be 11.<br />
              <img
                src="images/WarnsdorffStrategy.png"
                height="270"
                width="174"
                class="center"
              />
            </li>
            <li>
              This knowledge can be extended further by considering that these
              patterns are more likely to be true at lower levels, as most
              software solving algorithms would typically start at 1 and count
              up while searching for solutions.
            </li>
            <li>
              A final note on Warnsdorff's rule: if there is a "tie" of the
              number of options for a candidate square, the rule can be applied
              recurrsively. If you wish to learn more about recursion,
              <a
                href="https://www.geeksforgeeks.org/introduction-to-recursion-data-structure-and-algorithm-tutorials/"
                target="_new"
                >this article</a
              >
              is a decent introduction.
              <img src="images/recursion.png" height="250" class="center" />
            </li>
          </ul>
        </q-tab-panel>
      </q-tab-panels>
    </q-card>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue';

export default {
  Name: 'StrategyPage',
  setup() {
    const tab = ref('intuition');

    return {
      tab,
    };
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
