import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

// export default new Vuex.Store({
//   state: {},
//   mutations: {},
//   actions: {},
//   modules: {}
// });

export const store = new Vuex.Store({
    state: {
        // check: false,
        // admin: 0,
        check: true,
        admin: 1,
    },
    mutations: {
        checkLog(state, status) {
            state.check = status;
        },
        checkAdmin(state, status) {
            state.admin = status;
        },
    },
});