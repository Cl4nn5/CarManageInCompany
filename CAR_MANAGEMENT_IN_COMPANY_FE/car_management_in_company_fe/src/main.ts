import Vue from "vue";
import App from "./App.vue";
import router from "./router";

Vue.config.productionTip = false;

new Vue({
  data: {
    backendServer: {
      // host: "127.0.0.1",
      host: "localhost",
      port: "44345",
    },
  },
  router,
  render: (h) => h(App),
}).$mount("#app");
