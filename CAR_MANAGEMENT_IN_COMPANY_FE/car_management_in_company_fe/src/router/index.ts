import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import LoginView from "../views/LoginView.vue";
import AboutView from "@/views/AboutView.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "homeBforeLogin",
    component: LoginView,
  },
  {
    path: "/Home",
    redirect: "/",
  },
  {
    path: "/about",
    name: "about",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    // component: () => import(/* webpackChunkName: "about" */ "../views/AboutView.vue"),
    component: () => import("@/views/AboutView.vue"),
    // component: AboutView,
  },
];

const router = new VueRouter({
  routes,
});

export default router;
