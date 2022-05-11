<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <div v-for="val in posts" :key="val.id">post id: {{ val.id }}, title: {{ val.title }}</div>
    <div>post id: {{ post.id }}, title: {{ post.title }}, body: {{ post.body }}</div>
  </div>
</template>

<script>
// @ is an alias to /src
import axios from "axios";
export default {
  name: "Home",
  components: {},
  data() {
    return {
      posts: [],
      post: {},
    };
  },
  created() {
    // this.getPosts();
    // this.getPostById(100);
    // this.createPost({ title: "bai viet 1", userId: 1, body: "noi dung bai viet" });
    // this.updatePost(100, { title: "bai viet 100", userId: 1, body: "noi dung bai viet 100" });
    // this.deletePost(99);
  },
  methods: {
    getPosts() {
      axios.get("https://jsonplaceholder.typicode.com/posts").then((response) => {
        console.log(response.data);
        this.posts = response.data;
      });
    },
    getPostById(id) {
      axios.get(`https://jsonplaceholder.typicode.com/posts/${id}`).then((response) => {
        this.post = response.data;
      });
    },
    createPost(post) {
      axios.post("https://jsonplaceholder.typicode.com/posts", post).then((response) => {
        console.log(response.data);
      });
    },
    updatePost(postId, post) {
      axios.put(`https://jsonplaceholder.typicode.com/posts/${postId}`, post).then((response) => {
        console.log(response.data);
      });
    },
    deletePost(postId) {
      axios.delete(`https://jsonplaceholder.typicode.com/posts/${postId}`).then((response) => {
        console.log(response.data);
      });
    },
  },
};
</script>
