<template>
  <q-rating
    :model-value="getLevel()"
    :size="size + 'em'"
    :color="getColor()"
    readonly
  >
  </q-rating>
  <q-tooltip>{{ getHelpText() }}</q-tooltip>
</template>

<script lang="ts">
export default {
  Name: 'DifficultyLevelControl',
  props: {
    value: {
      type: Number,
      required: true,
      default: 0,
    },
    size: {
      type: Number,
      required: false,
      default: 1,
    },
  },
  methods: {
    getLevel(): number {
      if (this.value == 9) return 1;
      else if (this.value == 1) return 2;
      else if (this.value == 5) return 3;
      else if (this.value == 6) return 4;
      else if (this.value == 7) return 5;
      else return 0;
    },
    getColor(): string {
      if (this.value == 9) return 'green-10';
      else if (this.value == 1) return 'green-2';
      else if (this.value == 5) return 'blue';
      else if (this.value == 6) return 'orange';
      else if (this.value == 7) return 'deep-orange-10';
      else return 'yellow';
    },
    getHelpText(): string {
      if (this.value == 9) return 'Beginner';
      else if (this.value == 1) return 'Easy';
      else if (this.value == 5) return 'Medium';
      else if (this.value == 6) return 'Hard';
      else if (this.value == 7) return 'Challenging';
      else return 'UNKNOWN DIFFICULTY LEVEL ' + this.value;
    },
  },
};
</script>

<style lang="scss">
@import 'src/css/app.scss';
</style>
