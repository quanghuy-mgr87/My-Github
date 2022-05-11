import Vue from 'vue'
import App from './App.vue'
import { createApp } from 'vue';
import Antd from 'ant-design-vue';

Vue.config.productionTip = false
const app = createApp();
app.config.productionTip = false;

app.use(Antd);

new Vue({
  render: h => h(App),
}).$mount('#app')
