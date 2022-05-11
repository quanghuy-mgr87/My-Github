<template>
  <div>
    <h1>User</h1>
    <h2>UserId: {{ id }}</h2>
  </div>
</template>

<script>
export default {
  name: "User",
  data() {
    return {
      id: 0,
    };
  },
  created() {
    this.id = this.$route.params.id;
  },
};
</script>
