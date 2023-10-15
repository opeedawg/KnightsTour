<template>
  <div>
    <h1 style="padding-left: 30px">Welcome Home!</h1>
  </div>
</template>

<script lang="ts">
  import { defineComponent } from 'vue';

  export default defineComponent({
    name: 'HomePage',
    data: function () {
      return {
        pageLoaded: false,
      };
    },
  });
</script>
