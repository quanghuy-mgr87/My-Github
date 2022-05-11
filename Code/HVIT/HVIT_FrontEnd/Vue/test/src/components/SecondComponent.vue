<template>
  <div>
    <button @click="changeName">Change Name</button>
  </div>
</template>
<script>
export default {
  props: {
    user: Object,
  },
  methods: {
    changeName() {
      this.user.name = "James";
      this.$emit("nameChanged", this.user);
    },
  },
};
</script>
