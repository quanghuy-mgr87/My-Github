<template>
  <div class="status-bar">
    <p>Done</p>
    <ul>
      <li v-for="todo in doneTodos" :key="todo.id">
        {{ todo.title }}
      </li>
    </ul>
  </div>
</template>

<script>
// import { mapState } from "vuex";
export default {
  name: "StatusBar",
  computed: {
    doneTodos() {
      return this.$store.state.todos.filter((x) => x.completed);
    },
  },
};
</script>

<style>
.status-bar {
  padding: 5px;
  text-align: center;
  background: rgb(240, 240, 240);
  color: black;
}
</style>
