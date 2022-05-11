import Vue from "vue";
import Vuex from "vuex";
import App from "./App.vue";
import router from "./router";
import vuetify from "./plugins/vuetify";
import "roboto-fontface/css/roboto/roboto-fontface.css";
import "@fortawesome/fontawesome-free/css/all.css";

Vue.config.productionTip = false;
Vue.use(Vuex);

export const eventBus = new Vue();
export const store = new Vuex.Store({
  state: {
    check: false,
  },
  mutations: {
    checkLogin(state, status) {
      state.check = status;
      localStorage.setItem("state", status);
    },
  },
});

new Vue({
  router,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
