<template>
  <div>
    <h4><i>Thông tin cá nhân:</i></h4>
    <hr>
    <div>
      <p><b>Họ tên:</b> {{ hoTen }}</p>
      <p><b>Giới tính:</b> {{ gioiTinh }}</p>
      <p><b>Giới thiệu bản thân:</b> {{ gioiThieu }}</p>
      <p><b>Email:</b> {{ email }}</p>
    </div>
  </div>
</template>
<script>
import { eventBus } from "../main.js";
export default {
  name: "secondComponent",
  data: function() {
    return {
      hoTen: "",
      gioiTinh: "",
      gioiThieu: "",
      email: "",
    };
  },
  created() {
    eventBus.$on("onClick", this.onClick);
  },
  methods: {
    onClick(hoTen, gioiTinh, gioiThieu, email) {
      this.hoTen = hoTen;
      this.gioiTinh = gioiTinh;
      this.gioiThieu = gioiThieu;
      this.email = email;
    },
  },
};
</script>
