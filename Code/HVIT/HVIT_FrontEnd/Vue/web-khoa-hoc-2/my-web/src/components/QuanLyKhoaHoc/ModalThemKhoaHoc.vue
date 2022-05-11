<template>
  <v-dialog v-model="dialog" max-width="600px">
    <v-card>
      <v-card-title>
        <span class="headline"
          ><b>{{ title }}</b></span
        >
      </v-card-title>

      <v-card-text>
        <v-container>
          <ValidationObserver>
            <v-row>
              <v-col cols="12" lg="12">
                <ValidationProvider v-slot="{ errors }" name="Tên khoá học" rules="required">
                  <v-text-field prepend-icon="create" label="Tên khoá học" :error-messages="errors" required v-model="thongTinLop.TenLop"></v-text-field>
                </ValidationProvider>
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field prepend-icon="http" label="Hình ảnh (URL)" v-model="thongTinLop.LinkAnh"></v-text-field>
              </v-col>
              <v-col cols="12" lg="6">
                <v-text-field prepend-icon="attach_money" type="number" label="Học phí" v-model="thongTinLop.Gia"></v-text-field>
              </v-col>
              <v-col cols="12" lg="6">
                <v-text-field prepend-icon="redeem" type="number" label="Khuyến mãi (%)" v-model="thongTinLop.KhuyenMai"></v-text-field>
              </v-col>
              <v-col cols="12" lg="6">
                <ValidationProvider v-slot="{ errors }" name="Hình thức học" rules="required">
                  <v-select prepend-icon="school" :items="lstHinhThuc" label="Hình thức" :error-messages="errors" required v-model="thongTinLop.HinhThuc"></v-select>
                </ValidationProvider>
              </v-col>
              <v-col cols="12" lg="6">
                <ValidationProvider v-slot="{ errors }" name="Chủ để" rules="required">
                  <v-select
                    prepend-icon="color_lens"
                    :items="lstChuDe"
                    item-text="chuDe"
                    item-value="id"
                    label="Chủ đề"
                    :error-messages="errors"
                    required
                    v-model="thongTinLop.LoaiKhoaHocId"
                  ></v-select>
                </ValidationProvider>
              </v-col>
            </v-row>
            <p style="color:#FF5252;">{{ error }}</p>
          </ValidationObserver>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn text color="green darken-4" @click="save" dark rounded large> <h3>Save</h3> </v-btn>
        <v-btn text color="indigo lighten-1" @click="clear" dark rounded large> <h3>Clear</h3> </v-btn>
        <v-btn text color="red darken-1" @click="cancel" dark rounded large> <h3>Cancel</h3> </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
import { ValidationProvider, ValidationObserver, extend } from "vee-validate";
import { required } from "vee-validate/dist/rules";
import { eventBus } from "../../main";
import axios from "axios";
extend("required", {
  ...required,
  messages: "{_field_} không được để trống",
});
export default {
  components: {
    ValidationProvider,
    ValidationObserver,
  },
  data() {
    return {
      dialog: false,
      error: "",
      index: -1,
      lstHinhThuc: ["Trực tuyến", "Phòng Lab"],
      lstChuDe: [],
      thongTinLop: {
        Id: "",
        TenLop: "",
        LinkAnh: "",
        Gia: "",
        HinhThuc: "",
        KhuyenMai: "",
        LoaiKhoaHocId: "",
      },
    };
  },
  computed: {
    title() {
      return this.index == -1 ? "Thêm khoá học" : "Sửa khoá học";
    },
  },
  created() {
    eventBus.$on("openDialog", this.openDialog);
    eventBus.$on("checkIndex", this.checkIndex);
    eventBus.$on("currentStudent", this.currentStudent);
    eventBus.$on("reloadChuDe", this.reloadChuDe);
    this.getTypeOfCourseList();
  },
  methods: {
    getClassList() {
      axios.get("https://localhost:44389/api/lop").then((response) => {
        eventBus.$emit("reloadClassList", response.data);
      });
    },
    getTypeOfCourseList() {
      axios.get("https://localhost:44389/api/loaiKhoaHoc").then((response) => {
        this.lstChuDe = response.data;
      });
    },
    createNewClass(newClass) {
      axios.post("https://localhost:44389/api/lop", newClass).then(() => {
        alert("Cập nhật thành công");
        this.getClassList();
        this.clear();
      });
    },
    updateClass(currentClass) {
      axios.put("https://localhost:44389/api/lop", currentClass).then(() => {
        alert("Cập nhật thành công");
        this.getClassList();
        this.dialog = false;
      });
    },
    reloadChuDe(val) {
      this.lstChuDe = val;
    },
    openDialog(val) {
      this.clear();
      this.dialog = val;
    },
    checkIndex(val) {
      this.index = val;
    },
    currentStudent(val) {
      this.thongTinLop.Id = val.id;
      this.thongTinLop.TenLop = val.tenLop;
      this.thongTinLop.LinkAnh = val.linkAnh;
      this.thongTinLop.Gia = val.gia;
      this.thongTinLop.HinhThuc = val.hinhThuc;
      this.thongTinLop.KhuyenMai = val.khuyenMai;
      this.thongTinLop.LoaiKhoaHocId = val.loaiKhoaHocId;
    },
    cancel() {
      this.clear();
      this.dialog = false;
    },
    save() {
      if (this.thongTinLop.TenLop != "" && this.thongTinLop.HinhThuc != "" && this.thongTinLop.LoaiKhoaHocId != "") {
        if (this.index == -1) {
          this.thongTinLop.Id = 0;
          this.createNewClass(this.thongTinLop);
        } else {
          this.updateClass(this.thongTinLop);
        }
      } else {
        this.error = "Bạn chưa nhập đủ thông tin!";
      }
    },
    clear() {
      this.thongTinLop.TenLop = "";
      this.thongTinLop.LinkAnh = "";
      this.thongTinLop.Gia = "";
      this.thongTinLop.HinhThuc = "";
      this.thongTinLop.KhuyenMai = "";
      this.thongTinLop.LoaiKhoaHocId = "";
      this.error = "";
    },
  },
};
</script>
