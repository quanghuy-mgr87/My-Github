<template>
  <div>
    <v-btn id="btn" @click="changeAge()">change age</v-btn>
  </div>
</template>
<script>
import { eventBus } from "../main.js";
export default {
  name: "thirdComponent",
  props: {
    age: Number,
  },
  methods: {
    changeAge() {
      this.age = 30;
      eventBus.$emit("ageChanged", this.age);
    },
  },
};
</script>
<style scoped>
*{
    text-align: center;
}
#btn {
  color: green;
  margin-top: 10px;
}
</style>
