<template>
  <v-data-table :headers="headers" :items="studentList" :search="search" sort-by="id" class="elevation-1">
    <template v-slot:top>
      <v-toolbar flat color="white">
        <v-toolbar-title>DANH SÁCH HỌC SINH</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field color="indigo lighten-1" class="mr-10 mt-5" placeholder="Tìm kiếm" append-icon="fas fa-search" v-model="search"></v-text-field>
        <v-btn color="indigo" dark class="mb-2" @click="openDialog">Thêm học sinh</v-btn>
        <ModalThemHS />
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon size="20" color="green darken-2" class="mr-2" @click="editStudent(item)">
        mdi-pencil
      </v-icon>
      <v-icon size="20" color="red darken-2" @click="deleteBtn(item)">
        mdi-delete
      </v-icon>
    </template>
  </v-data-table>
</template>

<script>
import axios from "axios";
import ModalThemHS from "./ModalThemHS";
import { eventBus } from "../../main";
import moment from "moment";
export default {
  components: {
    ModalThemHS,
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
      {
        text: "Họ tên",
        value: "hoTen",
      },
      { text: "Giới tính", value: "gioiTinh" },
      { text: "Lớp", value: "lop.tenLop" },
      { text: "Ngày sinh", value: "ngaySinh" },
      { text: "Địa chỉ", value: "queQuan" },
      { text: "Nhiệm vụ", value: "actions", sortable: false },
    ],
    studentList: [],
    temp: [],
    editedIndex: -1,
    editedStudent: {
      id: "",
      hoTen: "",
      lopId: "",
      ngaySinh: "",
      queQuan: "",
      gioiTinh: "",
    },
    defaultItem: {
      id: "",
      hoTen: "",
      lopId: "",
      ngaySinh: "",
      queQuan: "",
      gioiTinh: "",
    },
  }),

  created() {
    this.getStudentList();
    eventBus.$on("reloadStudentList", this.reloadStudentList);
  },

  methods: {
    //axios
    getStudentList() {
      axios.get("https://localhost:44389/api/hocsinh").then((res) => {
        res.data.forEach((val) => {
          val.ngaySinh = this.getShortDate(val.ngaySinh);
        });
        this.studentList = res.data;
      });
    },

    deleteStudent(studentId) {
      axios.delete(`https://localhost:44389/api/hocsinh/${studentId}`).then(() => {
        this.getStudentList();
      });
    },

    openDialog() {
      this.dialog = true;
      this.editedIndex = -1;
      eventBus.$emit("openDialog", this.dialog);
      eventBus.$emit("checkIndex", this.editedIndex);
    },

    // getShortDate(val) {
    //   let temp = new Date(val);
    //   let month = temp.getMonth() + 1;
    //   let date = temp.getDate();
    //   let year = temp.getFullYear();
    //   // let shortStartDate = date + "/" + month + "/" + year;
    //   let shortStartDate = year + "-" + month + "-" + date;
    //   // shortStartDate = new Date(val).toISOString().substr(0,10);
    //   return shortStartDate;
    // },

    getShortDate(date) {
      return moment(date).format("YYYY-MM-DD");
    },

    initialize() {
      this.studentList = [
        {
          id: "",
          hoTen: "",
          lopId: "",
          ngaySinh: "",
          queQuan: "",
          gioiTinh: "",
        },
      ];
    },

    editStudent(item) {
      this.editedIndex = this.studentList.indexOf(item);
      this.editedStudent = Object.assign({}, item);
      this.dialog = true;
      eventBus.$emit("checkIndex", this.editedIndex);
      eventBus.$emit("openDialog", this.dialog);
      eventBus.$emit("currentStudent", this.editedStudent);
    },

    deleteBtn(item) {
      confirm("Bạn có chắc chắn muốn xóa học sinh này không?") && this.deleteStudent(item.id);
      this.getStudentList();
    },

    reloadStudentList(val) {
      this.studentList = val;
    },

    resetLst() {
      return this.studentList;
    },
  },
};
</script>
