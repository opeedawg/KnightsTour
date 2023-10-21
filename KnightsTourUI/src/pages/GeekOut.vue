<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h3 class="center">Geek Out!</h3>
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
        <q-tab name="math" label="The math" />
        <q-tab name="history" label="The history" />
        <q-tab name="software" label="The software" />
        <q-tab name="edgecases" label="Edge Cases" />
        <q-tab name="future" label="The future?!?" />
      </q-tabs>

      <q-separator />

      <q-tab-panels v-model="tab" animated dark>
        <q-tab-panel name="math">
          <ul>
            <li>
              First let me note that Math need not be boring or usless - it can
              be fun at many levels!
            </li>
            <li>
              The key is we are working with big numbers here, like really big.
            </li>
            <li>
              Investigate the mathematics of permutations and factorials to get
              an idea.
            </li>
            <li>
              The take away is you need to be smart to solve this problem, brute
              force (except in trivial cases) will not get you there!
            </li>
            <li>
              Some cool links to learn more and dig a little deeper:
              <ul>
                <li>
                  <a href="https://oeis.org/A003192" target="_new"
                    >Online encyclopedia of integer sequences: Length of
                    uncrossed knight's path on an n X n board.</a
                  >
                </li>
                <li>
                  <a href="https://oeis.org/A157416" target="_new"
                    >Online encyclopedia of integer sequences: Length of maximal
                    uncrossed cycle of knight moves on n X n board.</a
                  >
                </li>
                <li>
                  <a
                    href="https://ibmathsresources.com/2013/11/19/knights-tour/"
                    target="_new"
                    >IB Math Resources</a
                  >
                </li>
                <li>
                  <a
                    href="https://soulofmathematics.com/index.php/the-knights-tour/"
                    target="_new"
                    >Soul of Mathematics</a
                  >
                </li>
                <li>
                  <a
                    href="https://www.math.toronto.edu/yqing/knightstour.pdf"
                    target="_new"
                    >Cubes? Oh My!</a
                  >
                </li>
              </ul>
            </li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="history">
          <ul>
            <li>
              The earliest known reference to the knight's tour problem dates
              back to the 9th century AD.
            </li>
            <li class="quote">
              In
              <a href="https://en.wikipedia.org/wiki/Rudrata" target="_new"
                >Rudrata's Kavyalankara</a
              >, a Sanskrit work on Poetics, the pattern of a knight's tour on a
              half-board has been presented as an elaborate poetic figure
              (citra-alaṅkāra) called the turagapadabandha or 'arrangement in
              the steps of a horse'. The same verse in four lines of eight
              syllables each can be read from left to right or by following the
              path of the knight on tour. Since the Indic writing systems used
              for Sanskrit are syllabic, each syllable can be thought of as
              representing a square on a chessboard.
              <br />
              <img
                src="images/history1.png"
                height="126"
                width="178"
                class="center"
              />
              Translated:
              <br />
              <img
                src="images/history2.png"
                height="121"
                width="196"
                class="center"
              />
            </li>
            <li class="quote">
              A tour reported in the fifth book of Bhagavantabaskaraby by Bhat
              Nilakantha, a cyclopedic work in Sanskrit on ritual, law and
              politics, written either about 1600 or about 1700 describes three
              knight's tours. The tours are not only reentrant but also
              symmetrical, and the verses are based on the same tour, starting
              from different squares. Nilakantha's work is an extraordinary
              achievement being a fully symmetric closed tour, predating the
              work of Euler (1759) by at least 60 years.
            </li>
            <li class="quote">
              After Nilakantha, one of the first mathematicians to investigate
              the knight's tour was Leonhard Euler. The first procedure for
              completing the knight's tour was Warnsdorf's rule, first described
              in 1823 by H. C. von Warnsdorf.
            </li>
            <li class="quote">
              The sixth game of the World Chess Championship 2010 between
              Viswanathan Anand and Veselin Topalov saw Anand making 13
              consecutive knight moves (albeit using both knights); online
              commentators jested that Anand was trying to solve the knight's
              tour problem during the game.
            </li>
            <li>
              All sources taken from
              <a
                href="https://en.wikipedia.org/wiki/Knight%27s_tour"
                target="_new"
                >Wikipedia.org</a
              >
            </li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="software">
          <ul>
            <li>
              Without going into too much detail, one of my passions (and I
              suppose my job?) is as a software engineer, specifically I am the
              founder and CTO of a company based in the US which strives to
              change the entire enterprise software industry.
            </li>
            <li>
              This Knight's Tour software and site is simply a passion project,
              I like puzzles!
            </li>
            <li>
              I hold several patents in software engineering specific to the
              sub-domain of software patterns and architectural structures, not
              bragging just some validation that I am not a total hack.
            </li>
            <li>
              So as alluded to elsewhere, I wrote my own software (written in
              C#) which manages several aspects of this process for me including
              but not limited to:
              <ul>
                <li>Discovery of puzzles (random starting points)</li>
                <li>Persistance of solutions to a data model I created</li>
                <li>Configurable and automated puzzle creations</li>
                <li>
                  Board rotations and transposition duplication validations
                </li>
                <li>
                  Most importantly - and I am not going to give away the farm
                  here - my solution finder does not "strictly" implement
                  Warnsdorff's rule - yet still functions in a hybrid linear
                  fashion
                </li>
                <li>
                  My software will also aid me greatly in rendering large
                  aspects of my forthcoming Knight's Tour puzzle book series.
                </li>
              </ul>
            </li>
            <li>
              Anyhow, I have several servers that are running solver all the
              time, depending on the size of the puzzle it can be as slow as a
              single solution in 12 hours, or several a minute.
            </li>
            <li>
              For you, the user of the site there is very minimal risk you will
              ever solve "all" of the problems - as new ones are constantly
              being added.
            </li>
            <li>
              If you are a software engineer or inspired to investigate this fun
              and challenging puzzle domain, here are some basic resources to
              get you started!
            </li>
            <ul>
              <li>
                <a
                  href="https://python.plainenglish.io/where-chess-programming-and-math-meet-the-knights-tour-aac623abda09"
                  target="_new"
                  >Solutions using: Python</a
                >
              </li>
              <li>
                <a
                  href="https://www.geeksforgeeks.org/the-knights-tour-problem/"
                  target="_new"
                  >Solutions using: C</a
                >
              </li>
              <li>
                <a
                  href="https://www.codeproject.com/Articles/1175908/Knights-tour-on-a-square-chess-board-coding-challe"
                  target="_new"
                  >Solutions using: C#</a
                >
              </li>
              <li>
                <a
                  href="https://www.geeksforgeeks.org/the-knights-tour-problem/"
                  target="_new"
                  >Solutions using: C++</a
                >
              </li>
              <li>
                <a
                  href="https://www.geeksforgeeks.org/the-knights-tour-problem/"
                  target="_new"
                  >Solutions using: Java</a
                >
              </li>
              <li>
                <a
                  href="https://www.geeksforgeeks.org/the-knights-tour-problem/"
                  target="_new"
                  >Solutions using: Javascript</a
                >
              </li>
            </ul>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="edgecases">
          <ul>
            <li>
              Knights tours need not be done on a standard chess board, in fact
              they don't even need to be done on a square board!
            </li>
            <li>
              I have it on my to do list to investigate even odder shapes,
              including various polynomials and even donuts (from a
              topographical standpoint - my kids loved it when I told them that
              a donut and a teacup where the same shape!)
            </li>
            <li>
              <a
                href="https://web.archive.org/web/20190526154119/https://pdfs.semanticscholar.org/c3f5/e69e771771de1be50a8a8bf2561804026d69.pdf"
                target="_new"
                >Allen J. Schwenk</a
              >
              proved that for any m × n board with m ≤ n, a closed knight's tour
              is always possible unless one or more of these three conditions
              are met:
            </li>
            <ol>
              <li>m and n are both odd</li>
              <li>m = 1, 2, or 4</li>
              <li>m = 3 and n = 4, 6, or 8.</li>
            </ol>
            <li>
              Further more,
              <a
                href="https://www.fq.math.ca/Scanned/16-3/cull.pdf"
                target="_new"
                >Cull et al. and Conrad et al.</a
              >
              proved that on any rectangular board whose smaller dimension is at
              least 5, there is a (possibly open) knight's tour. For any m × n
              board with m ≤ n, a knight's tour is always possible unless one or
              more of these three conditions are met:
              <ol>
                <li>m and n are both odd</li>
                <li>m = 1, 2, or 4</li>
                <li>m = 3 and n = 4, 6, or 8.</li>
              </ol>
            </li>

            <li class="quote">
              The longest uncrossed (or nonintersecting) knight's path is a
              mathematical problem involving a knight on the standard 8×8
              chessboard or, more generally, on a square n×n board. The problem
              is to find the longest path the knight can take on the given
              board, such that the path does not intersect itself. A further
              distinction can be made between a closed path, which ends on the
              same field as where it begins, and an open path, which ends on a
              different field from where it begins.This knowledge can be
              extended further by considering that these patterns are more
              likely to be true at lower levels, as most software solving
              algorithms would typically start at 1 and count up while searching
              for solutions.
              <br />
              <img
                src="images/Uncrossed.png"
                height="359"
                width="607"
                class="center"
              />
            </li>
          </ul>
        </q-tab-panel>

        <q-tab-panel name="future">
          <ul>
            <li>
              As a general NP class of problem, in theory any future quantumn
              computer could solve any size tour in almost no time at all.<br />
              <img
                src="images/NPHard.png"
                height="238"
                width="375"
                class="center"
              />
              Euler diagram for P, NP, NP-complete, and NP-hard set of problems.
              Under the assumption that P ≠ NP, the existence of problems within
              NP but outside both P and NP-complete was established by Ladner.
              [Wikipedia.org]
            </li>
            <li>
              From
              <a
                href="https://en.wikipedia.org/wiki/Quantum_computing"
                target="_new"
                >wikipedia.org article on quantumn computing:</a
              ><br />
              <img
                src="images/PSSpace.png"
                height="286"
                width="304"
                class="center"
              />
            </li>
            <li class="quote">
              The class of problems that can be efficiently solved by a quantum
              computer with bounded error is called BQP, for "bounded error,
              quantum, polynomial time". More formally, BQP is the class of
              problems that can be solved by a polynomial-time quantum Turing
              machine with an error probability of at most 1/3. As a class of
              probabilistic problems, BQP is the quantum counterpart to BPP
              ("bounded error, probabilistic, polynomial time"), the class of
              problems that can be solved by polynomial-time probabilistic
              Turing machines with bounded error. It is known that BPP ⊆ BQP and
              is widely suspected that BQP ⊊ BPP, which intuitively would mean
              that quantum computers are more powerful than classical computers
              in terms of time complexity.
            </li>
            <li class="quote">
              The exact relationship of BQP to P, NP, and PSPACE is not known.
              However, it is known that P ⊆ BQP ⊆ PSPACE that is, all problems
              that can be efficiently solved by a deterministic classical
              computer can also be efficiently solved by a quantum computer, and
              all problems that can be efficiently solved by a quantum computer
              can also be solved by a deterministic classical computer with
              polynomial space resources. It is further suspected that BQP is a
              strict superset of P, meaning there are problems that are
              efficiently solvable by quantum computers that are not efficiently
              solvable by deterministic classical computers.
            </li>
            <li>
              Aritficial intelligence can also be applied through the use of
              neural networks, pioneered by work done by Y. Takefuji and K. C.
              Lee "Neural network computing for knight's tour problems."
              [Neurocomputing, 4(5):249–254, 1992]
              <br />
              <img
                src="images/NeuralNetwork.png"
                height="430"
                width="284"
                class="center"
              />
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
  Name: 'GeekOut',
  setup() {
    const tab = ref('math');

    return {
      tab,
    };
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
