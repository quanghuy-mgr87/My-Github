<template>
  <v-app>
    <v-app-bar app color="primary" dense dark>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    </v-app-bar>

    <v-main>
      <router-view></router-view>
    </v-main>

    <v-navigation-drawer v-model="drawer" absolute temporary>
      <v-list-item>
        <v-list-item-avatar>
          <v-icon>fas fa-school</v-icon>
        </v-list-item-avatar>

        <v-list-item-content>
          <v-list-item-title><h1 style="color: grey;">Menu</h1></v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense>
        <v-list-item v-for="item in items" :key="item.title" link :to="item.link">
          <v-list-item-icon>
            <v-icon size="30">{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-app>
</template>
<script>
export default {
  data() {
    return {
      drawer: null,
      items: [
        { title: "Class list", icon: "list_alt", link: "/classList" },
        { title: "Student list", icon: "list_alt", link: "/studentList" },
      ],
    };
  },
};
</script>
