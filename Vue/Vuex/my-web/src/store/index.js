import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    todos: [
      { id: 1, title: "Viec 1", completed: true },
      { id: 2, title: "Viec 2", completed: false },
      { id: 3, title: "Viec 3", completed: true },
      { id: 4, title: "Viec 4", completed: false },
    ],
    auth: {
      isAuthenticated: true,
    },
  },
  getters: {},
  mutations: {},
  actions: {},
  modules: {},
});
