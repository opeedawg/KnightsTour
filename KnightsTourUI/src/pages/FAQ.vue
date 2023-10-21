<template>
  <div class="q-pa-md q-gutter-sm" style="height: 100%">
    <h3 class="center">Frequently Asked Questions</h3>
    <q-list padding bordered class="rounded-borders" dark>
      <q-expansion-item
        dense
        dense-toggle
        expand-separator
        icon="help_outline"
        label="How much does it cost to become a member?"
      >
        <q-card dark>
          <q-card-section class="faqAnswer">
            <p>Knight Tour Daily is free to play.</p>
            <p>
              <a href="http://localhost:9000/#/SignUp"
                >Membership has many benefits</a
              >
              but no costs either!
            </p>
          </q-card-section>
        </q-card>
      </q-expansion-item>
      <q-expansion-item
        dense
        dense-toggle
        expand-separator
        icon="help_outline"
        label="Why did you create this application?"
      >
        <q-card dark>
          <q-card-section class="faqAnswer"
            ><p>
              I was introduced to Knight's Tour puzzles not that long ago and
              immediately both fell in love with the game as well as recognized
              its small footprint in the puzzle community as well as the
              opportunities to improve upon the classic format - which led to
              this site!
            </p>
            <p>
              It is certainly a side/passion project for me - but basically I
              get joy in making other people happy!
            </p></q-card-section
          >
        </q-card>
      </q-expansion-item>
      <q-expansion-item
        dense
        dense-toggle
        expand-separator
        icon="help_outline"
        label="How long did it take you to make the Knight Tour Daily site?"
      >
        <q-card dark>
          <q-card-section class="faqAnswer"
            ><p>It's a bit compliacted...</p>
            <p>
              First I bought a few puzzle books (I enjoy logic puzzles in
              general) and learned more about the game, which naturally led to
              research the finer details and history surrounding this puzzle. My
              background in Mathmatics from the
              <a href="https://uwaterloo.ca/math/" target="_new"
                >Univerity of Waterloo</a
              >
              helped me here come up to speed quickly.
            </p>
            <p>
              Secondly I happen to be a
              <a href="https://dxteritysolutions.com/" target="_new"
                >software enginner</a
              >
              by trade, so I created all the "back end" functionality first,
              such as representing tours and finding solutions.
            </p>
            <p>
              After this I began to generate puzzles and improve the solution
              finder software.
            </p>
            <p>
              Initially I thought about publishing a
              <a href="http://localhost:9000/#/PlayOffline">series of books</a>,
              but realized that there would be several cool benefits to playing
              this game online.
            </p>
            <p>
              So here we are. The front end took me a few weeks to build, but it
              is always under improvement as all software should be. The back
              end took a bit longer, but I am more passionate about logic
              processing so perhaps that was innevitable.
            </p>
          </q-card-section>
        </q-card>
      </q-expansion-item>
      <q-expansion-item
        dense
        dense-toggle
        expand-separator
        icon="help_outline"
        label="When will the books be published?"
      >
        <q-card dark>
          <q-card-section class="faqAnswer"
            ><p>
              Soon I hope - but realistically the summer of 2024 would be the
              earliest.
            </p>
            <p>
              Initially the plan was to publish the books first but I realized
              creating an online buzz could help book sales, so I did the site
              first! Plus online Knight's Tours are really more fun :p
            </p>
            <p>
              Ulimately if I seek a publisher, it will take months. Going
              forward with the self publishing route (<a
                href="https://www.myjourneyoutofdarkness.com/"
                target="_new"
                >which I have some experience with</a
              >) would be a bit faster, but it is not a passion.
            </p>
          </q-card-section>
        </q-card>
      </q-expansion-item>
    </q-list>
  </div>
</template>

<script lang="ts">
import { ref } from 'vue';

export default {
  Name: 'FAQ',
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
