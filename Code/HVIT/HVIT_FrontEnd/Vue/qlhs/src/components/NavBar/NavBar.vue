<template>
  <v-navigation-drawer v-model="drawer" app fixed temporary>
    <v-list-item to="/home" color="indigo darken-1">
      <v-list-item-avatar>
        <v-icon size="50" color="indigo darken-1">fab fa-bitcoin</v-icon>
      </v-list-item-avatar>

      <v-list-item-content>
        <v-list-item-title
          ><b>B <u style="color:red;">í</u> t c o i</b></v-list-item-title
        >
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>

    <v-list dense>
      <v-list-item to="/home">
        <v-list-item-icon>
          <v-icon>home</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title><h3>Trang chủ</h3></v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-list-group color="indigo lighten-1" no-action>
        <template v-slot:activator>
          <v-list-item-icon>
            <v-icon>list</v-icon>
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
      items: [
        { title: "Danh sách lớp", icon: "list", link: "/dsLop" },
        { title: "Danh sách học sinh", icon: "list", link: "/dsHocSinh" },
        // { title: "test", icon: "list", link: "/test" },
      ],
    };
  },
  created() {
    eventBus.$on("openNavBar", this.openNavBar);
  },
  methods: {
    openNavBar(val) {
      this.drawer = val;
    },
  },
};
</script>
<style scoped></style>
