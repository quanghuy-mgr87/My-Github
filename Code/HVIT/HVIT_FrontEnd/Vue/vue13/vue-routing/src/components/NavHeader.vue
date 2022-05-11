<template>
  <div>
    <ul>
      <li><router-link active-class="active" to="/home">Home</router-link></li>
      <li><router-link active-class="active" to="/news">News</router-link></li>
      <li><router-link active-class="active" to="/contact">Contact</router-link></li>
      <li><router-link active-class="active" to="/user/1">User1</router-link></li>
      <li><router-link active-class="active" to="/user/2">User2</router-link></li>
      <li><router-link active-class="active" to="/user/3">User3</router-link></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "navHeader",
};
</script>
<style scoped>
ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: #333;
}

li {
  float: left;
}

li a {
  display: block;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

li a:hover:not(.active) {
  background-color: #111;
}

.active {
  background-color: #4caf50;
}
</style>
