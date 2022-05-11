<template>
  <v-container fluid id="screen">
    <v-container class="home">
      <v-row>
        <v-col cols="12" lg="2" style="border-right: solid 1px #CFD8DC;">
          <h1 class="my-5">Lọc khoá học</h1>
          <div>
            <h3>Hình thức học</h3>
            <v-radio-group v-model="learningFormFilter">
              <v-radio v-for="(item, index) in lstHinhThuc" :key="index" :value="item.label">
                <template v-slot:label>
                  <div class="my-1">
                    <strong>{{ item.label }}</strong>
                  </div>
                </template>
              </v-radio>
            </v-radio-group>
            <hr width="80%" />
            <br />
            <h3>Chủ đề</h3>
            <v-radio-group v-model="typeOfClassFilfer">
              <v-radio v-for="item in lstChuDe" :key="item.id" :value="item.id">
                <template v-slot:label>
                  <div class="my-1">
                    <strong>{{ item.chuDe }}</strong>
                  </div>
                </template>
              </v-radio>
            </v-radio-group>
            <v-toolbar flat>
              <v-btn v-if="radioChecked == true" width="100%" dark color="red lighten-2" @click="clearFilter">Xoá lọc</v-btn>
            </v-toolbar>
          </div>
        </v-col>
        <v-col class="pl-6" cols="12" lg="10">
          <v-row style="border-bottom: solid 1px #CFD8DC;">
            <v-col class="pb-0" cols="12" lg="6">
              <v-text-field prepend-inner-icon="search" color="indigo lighten-2" rounded solo label="Tìm kiếm khoá học" v-model="keyword"></v-text-field>
            </v-col>
            <v-col class="pb-0" cols="12" lg="6"> </v-col>
          </v-row>
          <v-row>
            <v-col v-for="val in lstLop" :key="val.id" cols="12" lg="3">
              <v-card class="mx-auto" max-width="400" height="450px">
                <v-img class="white--text align-end" height="200px" :src="val.linkAnh"> </v-img>
                <v-card-title class="className"
                  ><p>{{ val.tenLop }}</p></v-card-title
                >
                <v-card-subtitle class="pb-0">
                  <div>{{ val.hinhThuc }}</div>
                </v-card-subtitle>

                <v-card-text class="text--primary">
                  <h3>
                    Học phí: <span style="color:#FF5252">{{ fee(val.gia) }}đ</span>
                  </h3>
                </v-card-text>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue lighten-1" text>
                    Chi tiết
                  </v-btn>

                  <v-btn color="red lighten-1" text>
                    Đăng ký
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-container>
</template>
<script>
import axios from "axios";
import { eventBus } from "../../main";
export default {
  data() {
    return {
      lstLop: [],
      lstTemp: [],
      dialog: false,
      dialogTitle: "",
      keyword: "",
      lstHinhThuc: [{ label: "Phòng Lab" }, { label: "Trực tuyến" }],
      lstChuDe: [],
      radioChecked: false,
      learningFormFilter: "",
      typeOfClassFilfer: "",
    };
  },
  created() {
    this.getClassList();
    this.getTypeOfCourseList();
    eventBus.$on("reloadClassList", this.reloadClassList);
  },
  watch: {
    keyword() {
      if (this.keyword != "") {
        this.searchClass(this.keyword);
      } else {
        this.getClassList();
      }
    },
    learningFormFilter() {
      this.radioChecked = true;
      this.getClassList();
    },
    typeOfClassFilfer() {
      this.radioChecked = true;
      this.getClassList();
    },
  },
  methods: {
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((response) => {
        this.lstLop = response.data;
        if (this.learningFormFilter != "") {
          let lstTemp = [];
          this.lstLop.forEach((val) => {
            if (val.hinhThuc == this.learningFormFilter) {
              lstTemp.push(val);
            }
          });
          this.lstLop = lstTemp;
        }
        if (this.typeOfClassFilfer != "") {
          let lstTemp = [];
          this.lstLop.forEach((val) => {
            if (this.typeOfClassFilfer == val.loaiKhoaHocId) {
              lstTemp.push(val);
            }
          });
          this.lstLop = lstTemp;
        }
        if (this.learningFormFilter == "" && this.typeOfClassFilfer == "") {
          this.radioChecked = false;
        }
      });
    },
    getTypeOfCourseList() {
      axios.get("https://localhost:44389/api/loaiKhoaHoc").then((response) => {
        this.lstChuDe = response.data;
      });
    },
    searchClass(keyword) {
      axios.get(`https://localhost:44389/api/lop/searchClass/${keyword}`).then((response) => {
        this.lstLop = response.data;
      });
    },
    clearFilter() {
      this.learningFormFilter = "";
      this.typeOfClassFilfer = "";
    },
    reloadClassList(val) {
      this.lstLop = val;
    },
    reverseString(str) {
      var newStr = "";
      for (let index = str.length - 1; index >= 0; index--) {
        newStr += str[index];
      }
      for (let index = 0; index < newStr.length; index++) {
        if (newStr[0] == ",") {
          newStr = newStr.substring(1);
        }
      }
      return newStr;
    },
    fee(val) {
      let hocPhi = val + "";
      let newHocPhi = "";
      let count = 0;
      for (let index = hocPhi.length - 1; index >= 0; index--) {
        count++;
        if (count == 3) {
          newHocPhi = newHocPhi + hocPhi[index] + ",";
          count = 0;
        } else {
          newHocPhi += hocPhi[index];
        }
      }
      return this.reverseString(newHocPhi);
    },
  },
};
</script>
<style scoped>
.className {
  height: 150px;
  padding: 0 auto;
}
.home {
  padding: 0 2%;
}
</style>
