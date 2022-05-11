<template>
  <div>
    <v-btn @click="changeName()" id="btn">change name</v-btn>
  </div>
</template>
<script>
export default {
  props: {
    name: String,
    gen: String,
  },
  methods: {
    changeName() {
      this.name = "James";
      this.gen = "Male";
      this.$emit("nameChanged", this.name, this.gen);
    },
  },
};
</script>
<style scoped>
* {
  text-align: center;
}
#btn {
  color: brown;
}
</style>
