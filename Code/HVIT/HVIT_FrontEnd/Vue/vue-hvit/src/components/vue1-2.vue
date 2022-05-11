<template>
    <div class="hello">
        <h1 v-html="sayHi"></h1>
        <p v-bind:id="idTheP">Alo</p>
        <a v-bind:href="link">Click vào đây</a> <br>
        <!-- disalble là true thì show button -->
        <button v-bind:disabled="disable">Click</button> <br>
        <button v-on:click="showAlert()">Click</button>
        <!-- điều kiện là true thì show đoạn text ra -->
        <p v-if="dieuKien">Đây là đoạn text</p>
        <span v-html="showText"></span>
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
    props: {
        msg: String,
    },
    data() {
        return {
            sayHi: '<p style = "color: red;">Helu</p>',
            idTheP: "paragraph_1",
            disable: true,
            link:'https://www.facebook.com',
            dieuKien: false,
            showText: '<p style="color: #42b983; font-size: 20px;">Hello, I\'m hvit clan</p>',
        };
    },
    methods: {
      showAlert(){
        alert('adu');
      }
    }
};
</script>
<style>
#paragraph_1 {
    color: green;
}
</style>
