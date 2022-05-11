<template>
  <div>
    <v-list>
      <v-list-item class="px-2 d-flex justify-center">
        <v-list-item-avatar>
          <v-img src="https://randomuser.me/api/portraits/women/85.jpg"></v-img>
        </v-list-item-avatar>
      </v-list-item>

      <v-list-item link>
        <v-list-item-content>
          <v-list-item-title class="title">
            Sandra Adams
          </v-list-item-title>
          <v-list-item-subtitle>sandra_a88@gmail.com</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list nav dense>
      <v-list-item link v-for="(item, index) in listContent" :key="index">
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>
        <v-list-item-title>{{ item.name }}</v-list-item-title>
      </v-list-item>
    </v-list>
  </div>
</template>
<script>
export default {
  data() {
    return {
      listContent: [
        { icon: "mdi-folder", name: "My Files" },
        { icon: "mdi-account-multiple", name: "Shared with me" },
        { icon: "mdi-star", name: "Starred" },
      ],
    };
  },
};
</script>
