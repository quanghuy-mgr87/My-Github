<template>
  <p class="progress-bar">Progress: {{ progress }}%</p>
</template>

<script>
export default {
  name: "ProgressBar",
  computed: {
    progress() {
      return (
        Math.round(
          this.$store.state.todos.filter((x) => x.completed).length /
            this.$store.state.todos.length
        ) * 100
      );
    },
  },
};
</script>

<style></style>
