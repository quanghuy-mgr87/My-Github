import Vue from "vue";
import VueRouter from "vue-router";
import BaiTap2Student from "../components/BaiTap2Student";

Vue.use(VueRouter);

const routes = [
  {
    path: "/studentList",
    component: BaiTap2Student,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
