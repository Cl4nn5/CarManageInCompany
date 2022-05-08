<template>
  <div id="loginContainer" v-if="isShow">
    <LoginForm :title="title" />
    <!-- <img alt="Vue logo" src="../assets/logo.png" /> -->
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import LoginForm from "@/components/Login/LoginForm.vue"; // @ is an alias to /src

export default Vue.extend({
  name: "LoginView",
  components: {
    LoginForm,
  },
  props: {
    isLogin: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      isShow: true,
      title: "Login Form",
    };
  },
  created() {
    this.$bus.$on("show:loginForm", (isShowLoginForm: boolean) => {
      this.isShow = !this.isShow;
      console.log(isShowLoginForm);
      // this.isShow = isShowLoginForm;
    });
  },
  destroyed() {
    console.log(this.$bus);
    this.$bus.$off("show:loginForm", 0);
    console.log(this.$bus);
  },
});
</script>

<style lang="scss" scoped>
#loginContainer {
  display: flex;
  justify-content: center;
  align-items: center;
  height: calc(100vh - 7.5vh);
  background-image: linear-gradient(315deg, #a1c4fdc2 0%, #c2e9fb4f 70%),
    linear-gradient(45deg, #a18cd1b4 50%, #fbc2eba6 70%);
  box-shadow: 1;
  padding: 30px 0;
}
</style>
