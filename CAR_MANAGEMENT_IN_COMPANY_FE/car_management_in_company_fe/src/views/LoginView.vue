<template>
  <div id="loginContainer">
    <Login :title="title" />
    <!-- <img alt="Vue logo" src="../assets/logo.png" /> -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Login from "@/components/Login/LoginForm.vue"; // @ is an alias to /src

console.log(Login);

export default Vue.extend({
  name: "LoginView",
  components: {
    Login,
  },
  data() {
    return {
      title: "Login Form",
    };
  },
});
</script>

<style lang="scss" scoped>
#loginContainer {
  height: 100vh;
  background-image: linear-gradient(315deg, #a1c4fdc2 0%, #c2e9fb4f 70%),
    linear-gradient(45deg, #a18cd1b4 50%, #fbc2eba6 70%);
  box-shadow: 1;
  padding: 30px 0;
}
</style>
