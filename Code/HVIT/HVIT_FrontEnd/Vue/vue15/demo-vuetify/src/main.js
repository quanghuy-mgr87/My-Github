import Vue from "vue";
import App from "./App.vue";
import vuetify from "./plugins/vuetify";
import "roboto-fontface/css/roboto/roboto-fontface.css";
import "@fortawesome/fontawesome-free/css/all.css";
import VueRouter from "vue-router";
import { routes } from "./routes.js";

Vue.use(VueRouter);
const router = new VueRouter({
  mode: "history",
  routes,
});

Vue.config.productionTip = false;
export const eventBus = new Vue();

new Vue({
  router,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
