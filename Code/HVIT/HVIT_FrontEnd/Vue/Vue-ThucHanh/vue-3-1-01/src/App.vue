<template>
  <div>
    <div class="row p-5">
      <div class="col-lg-6 p-3">
        <main-component></main-component>
      </div>
      <div class="col-lg-6 p-3">
        <second-component></second-component>
      </div>
    </div>
  </div>
</template>
<script>
import MainComponent from "./components/MainComponent";
import SecondComponent from "./components/SecondComponent";
export default {
  components: {
    MainComponent,
    SecondComponent,
  },
};
</script>
<style scoped>
.col-lg-6 {
  border: solid 1px gray;
}
</style>
