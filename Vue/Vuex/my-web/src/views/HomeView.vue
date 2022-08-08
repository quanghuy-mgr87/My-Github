<template>
  <div>
    <todos-component />
    <status-bar />
    <progress-bar />
  </div>
</template>

<script>
import TodosComponent from "@/components/TodosComponent.vue";
import StatusBar from "@/components/StatusBar.vue";
import ProgressBar from "@/components/ProgressBar.vue";
export default {
  name: "HomeComponent",

  components: { TodosComponent, StatusBar, ProgressBar },
};
</script>
