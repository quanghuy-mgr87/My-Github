<template>
  <v-app>
    <v-app-bar app dense color="indigo lighten-1" dark v-if="this.$router.currentRoute.path !== '/' && this.$router.currentRoute.path !== '/signUp'">
      <!-- ẩn thuộc tính khi vào link này (ở đây là ẩn thanh bar đi)-->
      <v-app-bar-nav-icon @click.stop="openNavBar"></v-app-bar-nav-icon>
      <v-spacer></v-spacer>
      <v-menu bottom origin="center center" transition="scale-transition" offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn icon v-bind="attrs" v-on="on">
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item v-for="(item, i) in menu" :key="i" link :to="item.link">
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>

    <v-btn v-scroll="onScroll" v-show="fab" fab dark fixed bottom right color="primary" @click="toTop">
      <v-icon>keyboard_arrow_up</v-icon>
    </v-btn>

    <NavBar />

    <v-main>
      <router-view></router-view>
    </v-main>

    <v-footer color="indigo lighten-1" dense dark v-if="this.$router.currentRoute.path !== '/' && this.$router.currentRoute.path !== '/signUp'">
      <v-row justify="center">
        <v-icon v-for="(val, index) in footerIcons" :key="index" class="px-10 py-5">{{ val.icon }}</v-icon>
        <div style="text-align:center;">
          <span>
            When the days are cold and the cards all fold And the saints we see are all made of gold When your dreams all fail and the ones we hail Are the worst of all and the blood's run stale I
            want to hide the truth, I want to shelter you But with the beast inside, there's nowhere we can hide No matter what we breed, we still are made of greed This is my kingdom come, this is my
            kingdom come When you feel my heat, look into my eyes It's where my demons hide, it's where my demons hide Don't get too close, it's dark inside It's where my demons hide, it's where my
            demons hide
          </span>
          <br />
          <br />
          <span> &copy;2018 - <b>Vuetify</b> </span>
        </div>
      </v-row>
    </v-footer>
  </v-app>
</template>

<script>
import { eventBus } from "./main";
import NavBar from "./components/NavBar/NavBar";
export default {
  components: {
    NavBar,
  },
  created() {},
  data() {
    return {
      drawer: false,
      fab: false,
      footerIcons: [
        {
          icon: "fab fa-facebook-square",
        },
        {
          icon: "fab fa-twitter",
        },
        {
          icon: "fab fa-google-plus",
        },
        {
          icon: "fab fa-linkedin",
        },
        {
          icon: "fab fa-instagram",
        },
      ],
      menu: [{ title: "Tài khoản của tôi" }, { title: "Đăng xuất", link: "/" }],
    };
  },
  methods: {
    openNavBar() {
      this.drawer = !this.drawer;
      eventBus.$emit("openNavBar", this.drawer);
      this.drawer = !this.drawer;
    },

    onScroll(e) {
      if (typeof window === "undefined") return;
      const top = window.pageYOffset || e.target.scrollTop || 0;
      this.fab = top > 20;
    },
    toTop() {
      this.$vuetify.goTo(0);
    },
  },
};
</script>
