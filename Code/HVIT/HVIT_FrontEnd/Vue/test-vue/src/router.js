import Router from 'vue-router';
import Vue from 'vue'
Vue.use(Router)
import HelloWorld from './components/HelloWorld.vue'

export default new Router({
  routes: [
    {
      path: '/',
      component: HelloWorld,
    },
  ]
})
