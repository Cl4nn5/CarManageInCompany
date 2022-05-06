<template>
  <div id="app">
    <!-- <nav>
      <router-link to="/">Login</router-link> |
      <router-link to="/about">About</router-link>
    </nav> -->
    <TopMenu />
    <router-view />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import TopMenu from "@/components/Login/TopMenu.vue";

export default Vue.extend({
  components: {
    TopMenu,
  },
});
</script>

<style lang="scss">
@import "reset-css";

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

  display: block;
  height: 200vh;
}

// nav {
//   padding: 30px;

//   a {
//     font-weight: bold;
//     color: #2c3e50;

//     &.router-link-exact-active {
//       color: #42b983;
//     }
//   }

//   .align-flex-center-center {
//     display: flex;
//     align-items: center;
//     justify-content: center;
//   }
// }
</style>
