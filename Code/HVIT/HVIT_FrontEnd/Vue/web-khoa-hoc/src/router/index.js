import Vue from "vue";
import VueRouter from "vue-router";
import LoginForm from "../views/LoginForm";
import Home from "../views/TrangChu/Home";
import SignUpForm from "../components/SignUp/SignUpForm.vue";
import QuanLyKhoaHoc from "../components/QuanLyKhoaHoc/QuanLyKhoaHoc";
import QuanTriNguoiDung from "../components/QuanTriNguoiDung/QuanTriNguoiDung.vue";
import KhoaHoc from "../views/TrangChu/KhoaHoc";
import { store } from "../store/index";

Vue.use(VueRouter);

const routes = [{
        path: "/",
        component: LoginForm,
    },
    {
        path: "/signUp",
        component: SignUpForm,
    },
    {
        path: "/home",
        component: Home,
        beforeEnter: (to, from, next) => {
            if (store.state.check) {
                next();
            } else {
                next("/");
            }
        },
    },
    {
        path: "/dsKhoaHoc",
        component: KhoaHoc,
        beforeEnter: (to, from, next) => {
            if (store.state.check) {
                next();
            } else {
                next("/");
            }
        },
    },
    {
        path: "/qlKhoaHoc",
        component: QuanLyKhoaHoc,
        beforeEnter: (to, from, next) => {
            if (store.state.check && store.state.admin == 1) {
                next();
            } else {
                next("/");
            }
        },
    },
    {
        path: "/qlNguoiDung",
        component: QuanTriNguoiDung,
        beforeEnter: (to, from, next) => {
            if (store.state.check && store.state.admin == 1) {
                next();
            } else {
                next("/");
            }
        },
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;