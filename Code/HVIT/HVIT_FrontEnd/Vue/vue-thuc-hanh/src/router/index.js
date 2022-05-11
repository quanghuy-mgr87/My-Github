import Vue from "vue";
import VueRouter from "vue-router";
import BaiViet from "../components/BaiViet.vue";
import ChiTietBaiViet from "../components/ChiTietBaiViet.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/home",
    component: BaiViet,
  },
  {
    path: "/home/:id",
    component: ChiTietBaiViet,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
