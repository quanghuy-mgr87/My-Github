import Vue from "vue";
// import { store } from "../main";
import VueRouter from "vue-router";
import TrangChu from "../components/TrangChu/TrangChu";
import DanhSachLop from "../components/QuanLyLop/DanhSachLop";
import DanhSachHocSinh from "../components/QuanLyHocSinh/DanhSachHocSinh";
import LoginScreen from "../views/LoginScreen";
import SignUp from "../views/SignUp";
import { store } from "../main";
// import test from "../components/test";

Vue.use(VueRouter);

const routes = [{
        path: "/",
        component: LoginScreen,
    },
    {
        path: "/signUp",
        component: SignUp,
    },
    {
        path: "/home",
        component: TrangChu,
        name: "home",
        beforeEnter: (to, from, next) => {
            if (store.state.check) {
                next();
            } else {
                next("/");
            }
        },
    },
    {
        path: "/dsLop",
        component: DanhSachLop,
        beforeEnter: (to, from, next) => {
            if (store.state.check) {
                next();
            } else {
                next("/");
            }
        },
    },
    {
        path: "/dsHocSinh",
        component: DanhSachHocSinh,
        beforeEnter: (to, from, next) => {
            if (store.state.check) {
                next();
            } else {
                next("/");
            }
        },
    },
    // {
    //   path: "/test",
    //   component: LoginScreen,
    // },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;