<template>
  <div>
    <div v-for="val in posts" :key="val.id" style="padding-left: 20px;">
      <div><b>Id:</b> {{ val.id }}</div>
      <div><b>User Id:</b> {{ val.userId }}</div>
      <div><b>Title:</b> {{ val.title }}</div>
      <div><b>Body:</b> {{ val.body }}</div>
      <hr />
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      posts: [],
    };
  },
  created() {
    this.addPost([
      { id: 101, userId: 101, title: "title 101", body: "101" },
      { id: 102, userId: 102, title: "title 102", body: "102" },
    ]);
    this.getPosts();
    this.updatePost(100, { userId: 10, title: "new title" });
  },
  methods: {
    getPosts() {
      axios.get("https://jsonplaceholder.typicode.com/posts").then((response) => {
        this.posts = response.data;
        console.log(response.data);
      });
    },
    addPost(newPosts) {
      axios.post("https://jsonplaceholder.typicode.com/posts", newPosts);
    },
    updatePost(postId, post) {
      axios.put(`https://jsonplaceholder.typicode.com/posts/${postId}`, post).then((response) => {
        console.log(response.data);
      });
    },
  },
};
</script>
