import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import ThongTinHocSinh from "./components/ThongTinHocSinh.vue";
//import ThongTinTroGiang from "./components/ThongTinTroGiang.vue";

Vue.component('thong-tin-hoc-sinh', ThongTinHocSinh)
    //Vue.component('thong-tin-tro-giang', ThongTinTroGiang)
Vue.config.productionTip = false;

new Vue({
    router,
    render: h => h(App)
}).$mount("#app");