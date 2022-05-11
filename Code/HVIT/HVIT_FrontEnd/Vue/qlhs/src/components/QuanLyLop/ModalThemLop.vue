<template>
  <v-dialog v-model="dialog" max-width="300px">
    <v-card>
      <v-card-title>
        <span class="headline">{{ formTitle }}</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12">
              <v-text-field v-model="editedClass.tenLop" color="info" label="Tên lớp"></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" @click="cancel" text>Cancel</v-btn>
        <v-btn color="blue darken-1" @click="save" text>Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
import { eventBus } from "../../main";
import axios from "axios";
export default {
  data() {
    return {
      dialog: false,
      editedIndex: -1,
      editedClass: {
        id: 0,
        tenLop: "",
        siSo: 0,
      },
      lstLop: [],
    };
  },
  created() {
    eventBus.$on("openDialog", this.openDialog);
    eventBus.$on("checkIndex", this.checkIndex);
    eventBus.$on("currentClass", this.currentClass);
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Thêm lớp" : "Sửa lớp";
    },
  },
  methods: {
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((res) => {
        this.lstLop = res.data;
        eventBus.$emit("reloadClassList", this.lstLop);
      });
    },
    createNewClass(newClass) {
      axios.post("https://localhost:44389/api/lop", newClass).then((res) => {
        this.getClassList();
        alert(`Thêm lớp ${res.data.tenLop} thành công!`);
      });
    },
    updateClass(newClass) {
      axios.put("https://localhost:44389/api/lop", newClass).then(() => {
        this.getClassList();
      });
    },
    openDialog(val) {
      this.dialog = val;
    },

    checkIndex(val) {
      this.editedIndex = val;
    },

    currentClass(val) {
      this.editedClass.id = val.id;
      this.editedClass.tenLop = val.tenLop;
      this.editedClass.siSo = val.siSo;
    },

    cancel() {
      this.dialog = false;
    },

    save() {
      if (this.editedIndex > -1) {
        this.updateClass(this.editedClass);
      } else {
        this.createNewClass(this.editedClass);
      }
      this.dialog = false;
    },
  },
};
</script>
