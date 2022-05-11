<template>
  <v-container fluid id="screen">
    <v-container class="home">
      <v-data-table :headers="headers" :items="lstUser" :search="search" class="elevation-1">
        <template v-slot:top>
          <v-toolbar flat>
            <v-toolbar-title>Danh sách người dùng</v-toolbar-title>
            <v-divider class="mx-4" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-text-field color="indigo lighten-1" class="mr-10 mt-5" placeholder="Tìm kiếm" prepend-inner-icon="fas fa-search" v-model="search"></v-text-field>
          </v-toolbar>
        </template>
        <template v-slot:[`item.actions`]="{ item }">
          <v-tooltip bottom>
            <template v-slot:activator="{ on, attrs }">
              <v-icon :color="item.quyenAdmin == 1 ? 'red' : 'green'" class="mr-5" v-bind="attrs" v-on="on" @click="updateAdmin(item)">
                {{ item.quyenAdmin == 1 ? "fas fa-trash-alt" : "fas fa-user" }}
              </v-icon>
            </template>
            <span>{{ item.quyenAdmin == 1 ? "Gỡ admin" : "Đặt làm admin" }}</span>
          </v-tooltip>
          <v-tooltip bottom>
            <template v-slot:activator="{ on, attrs }">
              <v-icon color="blue" v-bind="attrs" v-on="on" @click="refreshPassword(item)">
                fas fa-sync-alt
              </v-icon>
            </template>
            <span>Đặt lại mật khẩu</span>
          </v-tooltip>
        </template>
      </v-data-table>
    </v-container>
  </v-container>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      search: "",
      lstUser: [],
      headers: [
        { text: "ID", value: "id" },
        { text: "Username", value: "taiKhoan" },
        { text: "Email", value: "email" },
        { text: "Số điện thoại", value: "soDienThoai" },
        { text: "Quyền quản trị", value: "quyenAdmin" },
        { text: "Thiết lập tài khoản", value: "actions" },
      ],
    };
  },
  created() {
    this.getUserList();
  },
  methods: {
    getUserList() {
      axios.get("https://localhost:44389/api/user").then((response) => {
        this.lstUser = response.data;
      });
    },
    updateUser(user) {
      axios.put("https://localhost:44389/api/user", user).then(() => {
        this.getUserList();
      });
    },

    // addAdmin(item) {
    //   item.quyenAdmin = 1;
    //   this.updateUser(item);
    // },

    updateAdmin(item) {
      if (item.quyenAdmin == 1) {
        item.quyenAdmin = null;
      } else {
        item.quyenAdmin = 1;
      }
      this.updateUser(item);
    },

    refreshPassword(item) {
      item.matKhau = "123456";
      this.updateUser(item);
      alert("Thao tác thành công!");
    },
  },
};
</script>
<style scoped></style>
