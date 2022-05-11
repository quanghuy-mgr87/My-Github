<template>
  <div>
    <v-dialog v-model="dialog" max-width="500px">
      <v-card>
        <v-card-text class="pt-3">
          <v-data-table :headers="headers" :items="lstChuDe" :search="search" :items-per-page="6">
            <template v-slot:top>
              <v-toolbar flat>
                <v-text-field color="indigo lighten-1" class="mr-10 mt-5" placeholder="Tìm kiếm" v-model="search"></v-text-field>
                <v-spacer></v-spacer>
                <v-btn color="brown darken-1" small dark class="mb-2" @click="addItem">Thêm chủ đề</v-btn>
              </v-toolbar>
            </template>
            <template v-slot:[`item.actions`]="{ item }">
              <v-icon color="green" class="mr-2" @click="editItem(item)">
                mdi-pencil
              </v-icon>
              <v-icon color="red" @click="deleteItem(item)">
                mdi-delete
              </v-icon>
            </template>
          </v-data-table>
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-dialog v-model="dialog2" max-width="300px">
      <v-card>
        <v-card-title
          ><span>{{ title }}</span></v-card-title
        >
        <v-card-text>
          <v-text-field prepend-icon="school" placeholder="Chủ đề" v-model="loaiKhoaHoc.ChuDe"></v-text-field>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn text color="green" @click="save"><b>Lưu</b></v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import { eventBus } from "../../main";
import axios from "axios";
export default {
  data() {
    return {
      search: "",
      dialog: true,
      dialog2: false,
      checkUpdate: false,
      loaiKhoaHoc: {
        Id: "",
        ChuDe: "",
      },
      lstKhoaHoc: [],
      headers: [
        {
          text: "ID",
          align: "start",
          value: "id",
          width: 70,
        },
        { text: "Chủ đề", value: "chuDe" },
        { text: "Actions", width: 100, value: "actions", sortable: false },
      ],
      lstChuDe: [],
    };
  },
  created() {
    eventBus.$on("typeOfCourse", this.typeOfCourse);
    this.getTypeOfCourseList();
    this.getClassList();
  },
  computed: {
    title() {
      return this.checkUpdate ? "Sửa chủ đề" : "Thêm chủ đề";
    },
  },
  methods: {
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((response) => {
        this.lstKhoaHoc = response.data;
        eventBus.$emit("reloadClassList", response.data);
      });
    },
    getTypeOfCourseList() {
      axios.get("https://localhost:44389/api/loaiKhoaHoc").then((response) => {
        this.lstChuDe = response.data;
        eventBus.$emit("reloadChuDe", response.data);
      });
    },
    createTypeOfCourse(chuDe) {
      axios.post("https://localhost:44389/api/loaiKhoaHoc", chuDe).then(() => {
        alert("Cập nhật thành công!");
        this.getClassList();
        this.getTypeOfCourseList();
      });
    },
    updateTypeOfCourse(chuDe) {
      axios.put("https://localhost:44389/api/loaiKhoaHoc", chuDe).then(() => {
        alert("Cập nhật thành công!");
        this.getClassList();
        this.getTypeOfCourseList();
      });
    },
    deleteTypeOfCourse(id) {
      axios.delete(`https://localhost:44389/api/loaiKhoaHoc/${id}`).then(() => {
        this.getClassList();
        this.getTypeOfCourseList();
      });
    },
    save() {
      if (!this.checkUpdate) {
        this.loaiKhoaHoc.Id = 0;
        this.createTypeOfCourse(this.loaiKhoaHoc);
      } else {
        this.updateTypeOfCourse(this.loaiKhoaHoc);
      }
      this.dialog2 = false;
    },
    editItem(item) {
      this.loaiKhoaHoc.ChuDe = "";
      this.checkUpdate = true;
      this.dialog2 = true;
      this.loaiKhoaHoc.Id = item.id;
      this.loaiKhoaHoc.ChuDe = item.chuDe;
    },
    addItem() {
      this.loaiKhoaHoc.ChuDe = "";
      this.checkUpdate = false;
      this.dialog2 = true;
    },
    deleteItem(item) {
      let check = true;
      this.lstKhoaHoc.forEach((val) => {
        if (item.id == val.loaiKhoaHocId) {
          check = false;
        }
      });
      if (!check) {
        let r = confirm("Đang có khoá học thuộc chủ đề này, bạn có chắc chắn muốn xoá không?");
        if (r) {
          this.deleteTypeOfCourse(item.id);
        }
      } else {
        let r = confirm("Bạn có chắc chắn muốn xoá chủ đề này không?");
        if (r) {
          this.deleteTypeOfCourse(item.id);
        }
      }
    },
    typeOfCourse(val) {
      this.dialog = val;
    },
  },
};
</script>
