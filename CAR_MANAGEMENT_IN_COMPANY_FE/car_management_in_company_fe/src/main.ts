import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import EventBus from "vue-bus-ts";

Vue.config.productionTip = false;

Vue.use(EventBus);
const bus = new EventBus.Bus();

new Vue({
  data: {
    backendServer: {
      // host: "127.0.0.1",
      host: "localhost",
      port: "44345",
    },
    isTestMode: false,
  },
  created() {
    if (location.port === "8080") this.isTestMode = true;
  },
  bus,
  router,
  render: (h) => h(App),
}).$mount("#app");
