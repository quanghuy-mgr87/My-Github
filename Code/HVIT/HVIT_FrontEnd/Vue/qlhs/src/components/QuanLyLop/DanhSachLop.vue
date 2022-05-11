<template>
  <v-data-table :headers="headers" :search="search" :items="lstLop" sort-by="id" class="elevation-1">
    <template v-slot:top>
      <v-toolbar flat color="white">
        <v-toolbar-title>DANH SÁCH LỚP</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field color="indigo lighten-1" class="mr-10 mt-5" placeholder="Tìm kiếm" append-icon="fas fa-search" v-model="search"></v-text-field>
        <v-btn color="indigo" dark class="mb-2" @click="openDialog">Thêm lớp</v-btn>
        <ModalThemLop />
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon size="20" color="green darken-2" class="mr-2" @click="editItem(item)">
        mdi-pencil
      </v-icon>
      <v-icon size="20" color="red darken-2" @click="deleteItem(item)">
        mdi-delete
      </v-icon>
    </template>
  </v-data-table>
</template>

<script>
import axios from "axios";
import ModalThemLop from "./ModalThemLop";
import { eventBus } from "../../main";
export default {
  components: {
    ModalThemLop,
  },
  data: () => ({
    search: "",
    dialog: false,
    headers: [
      {
        text: "ID",
        align: "start",
        value: "id",
      },
      { text: "Tên lớp", value: "tenLop" },
      { text: "Sĩ số", value: "siSo" },
      { text: "Actions", value: "actions", sortable: false },
    ],
    lstLop: [],
    editedIndex: -1,
    editedItem: {
      id: "",
      tenLop: 0,
      siSo: 0,
    },
    defaultItem: {
      id: "",
      tenLop: 0,
      siSo: 0,
    },
  }),

  created() {
    this.getClassList();
    eventBus.$on("reloadClassList", this.reloadClassList);
  },

  methods: {
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((res) => {
        this.lstLop = res.data;
      });
    },
    deleteClass(classId) {
      axios.delete(`https://localhost:44389/api/lop/${classId}`).then(() => {
        this.getClassList();
      });
    },

    editItem(item) {
      this.editedIndex = this.lstLop.indexOf(item);
      this.editedItem = Object.assign({}, item);
      eventBus.$emit("checkIndex", this.editedIndex);
      this.dialog = true;
      eventBus.$emit("openDialog", this.dialog);
      eventBus.$emit("currentClass", item);
    },

    deleteItem(item) {
      if (item.siSo != 0) {
        confirm("Lớp này hiện tại đang có học sinh, bạn có chắc chắn muốn xóa?") && this.deleteClass(item.id);
      } else {
        confirm("Bạn có chắc chắn muốn xóa lớp này không?") && this.deleteClass(item.id);
      }
    },

    openDialog() {
      this.dialog = true;
      this.editedItem = {};
      this.editedIndex = -1;
      eventBus.$emit("openDialog", this.dialog);
      eventBus.$emit("checkIndex", this.editedIndex);
      eventBus.$emit("currentClass", this.editedItem);
    },

    reloadClassList(val) {
      this.lstLop = val;
    },
  },
};
</script>
