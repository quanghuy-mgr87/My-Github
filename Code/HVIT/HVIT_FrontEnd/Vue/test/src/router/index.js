import Vue from "vue";
import VueRouter from "vue-router";
import SecondComponent from "../components/SecondComponent";
import FirstComponent from "../components/FirstComponent";
import HelloWorld from "../components/HelloWorld";
// import Home from "../views/Home.vue";

Vue.use(VueRouter);

const routes = [{
        path: "/",
        name: "Home",
        component: FirstComponent,
    },
    {
        path: "/second",
        component: SecondComponent,
    },
    {
        path: "/test",
        component: HelloWorld,
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;