<template>
  <v-dialog v-model="dialog" max-width="500px">
    <v-card>
      <v-card-title>
        <span class="headline">{{ formTitle }}</span>
      </v-card-title>

      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12">
              <v-text-field v-model="editedStudent.hoTen" color="info" :rules="[]" label="Họ tên"></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-radio-group row v-model="editedStudent.gioiTinh">
                <span style="color: grey; margin-right: 15px;">Giới tính:</span>
                <v-radio color="info" v-for="val in gentle" :key="val.value" :value="val.value" :label="val.text"></v-radio>
              </v-radio-group>
            </v-col>
            <v-col cols="4">
              <v-select v-model="editedStudent.lopId" :items="classList" item-value="id" item-text="tenLop" color="info" label="Lớp"></v-select>
            </v-col>
            <v-col cols="8">
              <v-menu v-model="menu2" :close-on-content-click="false" transition="scale-transition" offset-y max-width="290px" min-width="290px">
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field color="info" v-model="computedDateFormatted" label="Ngày sinh" persistent-hint prepend-icon="mdi-calendar" readonly v-bind="attrs" v-on="on"></v-text-field>
                </template>
                <template v-slot:[`item.ngaySinh`]="{ item }">{{ formatDate(item.ngaySinh) }}</template>
                <v-date-picker v-model="date" no-title @input="menu2 = false"></v-date-picker>
              </v-menu>
            </v-col>
            <v-col cols="12">
              <v-text-field v-model="editedStudent.queQuan" color="info" label="Địa chỉ"></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" @click="cancel" text>Đóng</v-btn>
        <v-btn color="blue darken-1" @click="save" text>Lưu</v-btn>
        <!-- <v-btn color="blue darken-1" @click="test" text>Test</v-btn> -->
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
import { eventBus } from "../../main";
import axios from "axios";
import moment from "moment";
export default {
  data: (vm) => {
    return {
      date: new Date().toISOString().substr(0, 10),
      dateFormatted: vm.formatDate(new Date().toISOString().substr(0, 10)),
      menu2: false,

      dialog: false,
      editedIndex: -1,
      gentle: [
        { text: "Nam", value: 'Nam' },
        { text: "Nữ", value: 'Nữ' },
        { text: "Khác", value: 'Khác' },
      ],

      editedStudent: {
        id: "",
        hoTen: "",
        lopId: "",
        ngaySinh: "",
        queQuan: "",
        gioiTinh: "",
      },

      classList: [],
      studentList: [],
    };
  },

  created() {
    eventBus.$on("openDialog", this.openDialog);
    eventBus.$on("checkIndex", this.checkIndex);
    eventBus.$on("currentStudent", this.currentStudent);
    this.getClassList();
  },

  computed: {
    //date
    computedDateFormatted() {
      return this.formatDate(this.date);
    },

    formTitle() {
      return this.editedIndex == -1 ? "Thêm học sinh" : "Sửa thông tin";
    },
  },

  watch: {
    date() {
      this.dateFormatted = this.formatDate(this.date);
    },
  },

  methods: {
    getStudentList() {
      axios.get("https://localhost:44389/api/hocsinh").then((res) => {
        res.data.forEach((val) => {
          val.ngaySinh = this.getShortDate(val.ngaySinh);
        });
        this.studentList = res.data;
        eventBus.$emit("reloadStudentList", this.studentList);
      });
    },
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((res) => {
        this.classList = res.data;
      });
    },
    createStudent(val) {
      axios.post("https://localhost:44389/api/hocsinh", val).then((res) => {
        this.getStudentList();
        alert(`Thêm ${res.data.hoTen} thành công!`);
      });
    },
    updateStudent(student) {
      axios.put("https://localhost:44389/api/hocsinh", student).then(() => {
        this.getStudentList();
        alert(`Câp nhật thành công!`);
      });
    },
    openDialog(val) {
      this.date = new Date().toISOString().substr(0, 10);
      this.editedStudent = {};
      this.dialog = val;
    },

    checkIndex(val) {
      this.editedIndex = val;
    },

    currentStudent(val) {
      this.editedStudent.id = val.id;
      this.editedStudent.hoTen = val.hoTen;
      this.editedStudent.lopId = val.lopId;
      this.date = val.ngaySinh;
      this.editedStudent.queQuan = val.queQuan;
      this.editedStudent.gioiTinh = val.gioiTinh;
    },

    cancel() {
      this.dialog = false;
    },

    save() {
      if (this.editedIndex > -1) {
        this.editedStudent.ngaySinh = this.date;
        this.updateStudent(this.editedStudent);
      } else {
        this.editedStudent.ngaySinh = this.date;
        this.createStudent(this.editedStudent);
      }
      this.dialog = false;
    },

    // test() {
    //   console.log(this.editedStudent.gioiTinh);
    // },

    formatDate(date) {
      return moment(date).format("DD/MM/YYYY");
    },
    getShortDate(date) {
      return moment(date).format("YYYY-MM-DD");
    },
  },
};
</script>
