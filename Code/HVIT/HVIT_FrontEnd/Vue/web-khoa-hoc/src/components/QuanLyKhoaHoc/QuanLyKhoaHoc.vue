<template>
  <v-container fluid id="screen">
    <v-container class="home">
      <v-data-table :headers="headers" :items="lstLop" :search="search" sort-by="tenLop" :items-per-page="12" class="elevation-1">
        <template v-slot:top>
          <v-toolbar flat>
            <v-toolbar-title>Danh sách khoá học</v-toolbar-title>
            <v-divider class="mx-4" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-text-field color="indigo lighten-1" class="mr-10 mt-5" placeholder="Tìm kiếm" prepend-inner-icon="fas fa-search" v-model="search"></v-text-field>
            <v-btn color="brown darken-1" dark class="mb-2 mr-2" @click="addClass">Thêm lớp</v-btn>
            <v-btn color="indigo" dark class="mb-2" @click="typeOfCourse">Chủ đề</v-btn>
          </v-toolbar>
        </template>
        <template v-slot:[`item.linkAnh`]="{ item }">
          <div class="linkAnh">
            {{ item.linkAnh }}
          </div>
        </template>
        <template v-slot:[`item.tenLop`]="{ item }">
          <div class="tenLop">
            {{ item.tenLop }}
          </div>
        </template>
        <template v-slot:[`item.actions`]="{ item }">
          <v-icon color="green" class="mr-2" @click="editClass(item)">
            mdi-pencil
          </v-icon>
          <v-icon color="red" @click="deleteItem(item)">
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>
      <ModalThemKhoaHoc />
      <ModalChuDe />
    </v-container>
  </v-container>
</template>
<script>
import axios from "axios";
import ModalThemKhoaHoc from "../QuanLyKhoaHoc/ModalThemKhoaHoc";
import ModalChuDe from "../QuanLyKhoaHoc/ModalChuDe";
import { eventBus } from "../../main";
export default {
  components: {
    ModalThemKhoaHoc,
    ModalChuDe,
  },
  data: () => ({
    search: "",
    dialog: false,
    dialogDelete: false,
    headers: [
      {
        text: "Mã lớp",
        align: "start",
        value: "id",
      },
      { text: "Tên khoá học", value: "tenLop" },
      { text: "Sĩ số", value: "siSo" },
      { text: "Link ảnh", value: "linkAnh" },
      { text: "Học phí (đ)", value: "gia" },
      { text: "Hình thức", value: "hinhThuc" },
      { text: "Khuyến mãi (%)", value: "khuyenMai" },
      { text: "Chủ đề", value: "loaiKhoaHoc.chuDe" },
      { text: "Actions", value: "actions", sortable: false },
    ],
    lstLop: [],
    editedIndex: -1,
    editedClass: {},
    defaultItem: {},
  }),

  computed: {},

  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  created() {
    this.getClassList();
    eventBus.$on("reloadClassList", this.reloadClassList);
  },

  methods: {
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((response) => {
        this.lstLop = response.data;
      });
    },

    deleteClass(classId) {
      axios.delete(`https://localhost:44389/api/lop/${classId}`).then(() => {
        this.getClassList();
      });
    },

    addClass() {
      this.dialog = true;
      this.editedIndex = -1;
      eventBus.$emit("checkIndex", this.editedIndex);
      eventBus.$emit("openDialog", this.dialog);
    },

    typeOfCourse() {
      this.dialog = true;
      eventBus.$emit("typeOfCourse", this.dialog);
    },

    reloadClassList(val) {
      this.lstLop = val;
    },

    editClass(item) {
      this.editedIndex = this.lstLop.indexOf(item);
      this.editedClass = Object.assign({}, item);
      this.dialog = true;
      eventBus.$emit("checkIndex", this.editedIndex);
      eventBus.$emit("openDialog", this.dialog);
      eventBus.$emit("currentStudent", this.editedClass);
    },

    deleteItem(item) {
      if (item.siSo != 0) {
        confirm("Lớp này hiện tại đang có học sinh, bạn có chắc chắn muốn xóa?") && this.deleteClass(item.id);
      } else {
        confirm("Bạn có chắc chắn muốn xóa lớp này không?") && this.deleteClass(item.id);
      }
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedClass = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedClass = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.lstLop[this.editedIndex], this.editedClass);
      } else {
        this.lstLop.push(this.editedClass);
      }
      this.close();
    },
  },
};
</script>
<style scoped>
.className {
  height: 150px;
  padding: 0 auto;
}
.linkAnh {
  width: 500px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: pre-wrap;
}
.tenLop {
  width: 300px;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
