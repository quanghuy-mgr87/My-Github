<template>
  <div id="app">
    <h1 style="text-align: center;">Routing</h1>
    <nav-header></nav-header>
    <router-view></router-view>
  </div>
</template>

<script>
import NavHeader from "./components/NavHeader.vue";
export default {
  name: "App",
  components: {
    NavHeader,
  },
};
</script>
