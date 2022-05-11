<template>
  <div>
    <h4><i>Nhập thông tin:</i></h4>
    <hr />
    <div class="form-group">
      <label>Họ tên: </label>
      <input type="text" class="form-control" v-model="hoTen" placeholder="Nhập họ tên..." />
      <label>Giới tính:</label> <input type="radio" value="Nam" v-model="gioiTinh" /> Nam <input type="radio" value="Nữ" v-model="gioiTinh" /> Nữ <br />
      <label>Giới thiệu bản thân: </label><textarea cols="30" rows="5" class="form-control" v-model="gioiThieu"></textarea>
      <label>Email: </label>
      <input type="text" class="form-control" v-model="email" placeholder="Nhập email..." />
      <hr />
      <button class="btn btn-primary" @click="submit">Submit</button>
    </div>
  </div>
</template>
<script>
import { eventBus } from "../main.js";
export default {
  name: "mainComponent",
  data: function() {
    return {
      hoTen: "",
      gioiTinh: "",
      gioiThieu: "",
      email: "",
    };
  },
  methods: {
    submit() {
      this.clicked = true;
      eventBus.$emit("onClick", this.hoTen, this.gioiTinh, this.gioiThieu, this.email);
    },
  },
};
</script>
