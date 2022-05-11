<template>
  <v-app>
    <v-navigation-drawer dark color="indigo lighten-1" app permanent expand-on-hover>
      <Navigation />
    </v-navigation-drawer>

    <v-app-bar color="indigo lighten-1" app dense>
      <!-- -->  
    </v-app-bar>

    <!-- Sizes your content based upon application components -->
    <v-main>
      <!-- Provides the application the proper gutter -->
      <v-container fluid>
        <!-- If using vue-router -->
        <router-view></router-view>
      </v-container>
    </v-main>

    <v-footer app>
      <!-- -->
    </v-footer>
  </v-app>
</template>

<script>
import Navigation from "@/views/Navigation.vue";
export default {
  components: {
    Navigation,
  },
  data: () => ({
    //
  }),
};
</script>
