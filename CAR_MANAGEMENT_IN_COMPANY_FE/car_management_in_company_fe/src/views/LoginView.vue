<template>
  <div class="home">
    <Login :title="title" />
    <img alt="Vue logo" src="../assets/logo.png" />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Login from "@/components/LoginForm.vue"; // @ is an alias to /src

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
