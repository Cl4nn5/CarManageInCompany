<template>
  <div id="app">
    <!-- <nav>
      <router-link to="/">Login</router-link> |
      <router-link to="/about">About</router-link>
    </nav> -->
    <TopMenu />
    <section class="whiteSpace"></section>
    <router-view />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import TopMenu from "@/components/TopMenu/TopMenu.vue";

export default Vue.extend({
  components: {
    TopMenu,
  },
});
</script>

<style lang="scss">
@import "reset-css";

// #region Css Variable
:root {
  --top-height: 7.5vh;
}
$topMenuHeight: var(--top-height);
// #endregion

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

  display: block;
  // height: 200vh;
}

.whiteSpace {
  height: $topMenuHeight;
}
</style>
