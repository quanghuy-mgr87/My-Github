<template>
  <v-navigation-drawer dark v-model="drawer" app fixed temporary>
    <v-list-item color="white">
      <v-list-item-avatar tile>
        <v-img src="../../logo/myLogo.png"></v-img>
      </v-list-item-avatar>

      <v-list-item-content>
        <v-list-item-title
          ><h2>
            <u><span style="color: #00B0FF">G</span> <span style="color:red">I</span> <span style="color:violet">R</span> <span style="color:yellow">L</span> <span style="color:#76FF03">S</span></u>
          </h2></v-list-item-title
        >
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>

    <v-list dense>
      <v-list-item v-for="val in mainItems" :key="val.title" :to="val.link">
        <v-list-item-icon>
          <v-icon>{{ val.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title
            ><h3>{{ val.title }}</h3></v-list-item-title
          >
        </v-list-item-content>
      </v-list-item>
      <v-list-group v-if="admin == 1" color="white" no-action>
        <template v-slot:activator>
          <v-list-item-icon>
            <v-icon>work</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title><h3>Quản lý</h3></v-list-item-title>
          </v-list-item-content>
        </template>

        <v-list-item v-for="item in items" :key="item.title" :to="item.link">
          <v-list-item-content>
            <v-list-item-title v-text="item.title"></v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-group>
    </v-list>
  </v-navigation-drawer>
</template>
<script>
import { eventBus } from "../../main";
export default {
  data() {
    return {
      drawer: false,
      admin: 0,
      mainItems: [
        { title: "Trang chủ", icon: "home", link: "/home" },
        { title: "Khoá học", icon: "school", link: "/dsKhoaHoc" },
      ],
      items: [
        { title: "Quản lý khoá học", icon: "list", link: "/qlKhoaHoc" },
        { title: "Danh sách học sinh", icon: "list", link: "/qlHocSinh" },
        { title: "Quản trị người dùng", icon: "list", link: "/qlNguoiDung" },
      ],
    };
  },
  created() {
    eventBus.$on("openNavBar", this.openNavBar);
    eventBus.$on("checkAdmin", this.checkAdmin);
  },
  methods: {
    openNavBar(val) {
      this.drawer = val;
    },
    checkAdmin(val) {
      this.admin = val;
    },
  },
};
</script>
<style scoped></style>
