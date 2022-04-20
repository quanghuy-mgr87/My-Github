<template>
  <div>
    <div class="app">
      <ckeditor class="ckeditor" :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor>
      <button @click="test">Test</button>
    </div>
    <div v-html="editorData" style="text-align: justify"></div>
  </div>
  <!-- <div>
    <input ref="" type="file" id="ctrl" webkitdirectory directory v-on:input="getData" />
    <input ref="" type="file" :value="file" @input="test" />
  </div> -->
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";

export default {
  name: "app",
  data() {
    return {
      editor: ClassicEditor,
      editorData: "",
      editorConfig: {
        // The configuration of the editor.
      },
      // data: null,
      // file: "",
    };
  },
  methods: {
    test() {
      console.log(this.editorData);
    },
    // getData() {
    //   var inp = document.getElementById("ctrl");
    //   // console.log(inp)
    //   for (let i = 0; i < inp.files.length; i++) {
    //     let file = inp.files[i];
    //     console.log(file);
    //     // do things with file
    //   }
    // },

    // test(value) {
    //   // console.log([this.file]);
    //   console.log(value)
    // },
  },
};
</script>
<style>
.ckeditor {
  height: 500px;
}
</style>
