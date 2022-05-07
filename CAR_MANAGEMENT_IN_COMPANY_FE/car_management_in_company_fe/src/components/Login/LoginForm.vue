<template>
  <article class="loginContainer" v-if="isShow">
    <!-- <section class="loginWrap">
      <h3 class="loginForm header">
        <label for="inputId">{{ title }}</label>
      </h3>
      <div class="loginForm inputForm">
        <div class="input line">
          <label for="inputId" class="input label">ID</label>
          <input
            id="inputId"
            class="input inputLogin"
            type="text"
            v-model="user.id"
            placeholder="아이디를 입력하세요"
          />
        </div>
        <div class="input line">
          <label for="inputPwd" class="input label">PassWord</label>
          <input
            id="inputPwd"
            class="input inputLogin"
            type="password"
            v-model="user.pwd"
            placeholder="비밀번호를 입력하세요"
          />
        </div>
      </div>
    </section> -->
    <section class="blueBg">
      <div class="box signin">
        <h2>로그인 영역</h2>
        <button @click="sign(true)" ref="signinBtn" class="signinBtn">
          Sign in
        </button>
      </div>
      <div class="box signup">
        <h2>회원가입 영역</h2>
        <button @click="sign(false)" ref="signupBtn" class="signupBtn">
          Sign up
        </button>
      </div>
    </section>
    <section class="formBox" ref="formBox"></section>
  </article>
</template>

<script lang="ts">
class Sign {
  type: string;

  protected types = ["in", "up"];

  constructor(isHaveAccount: boolean) {
    this.type = `sign${this.types[+isHaveAccount]}`;
  }
}

import Vue from "vue";
//import axios from "axios";

export default Vue.extend({
  name: "LoginForm",
  props: {
    title: {
      type: String,
      default: "로그인 영역",
    },
  },
  data() {
    return {
      temp: "로그인 공간",
      isShow: false,
      user: {
        id: "",
        pwd: "",
      },
    };
  },
  computed: {
    backendUrl(): string {
      const url: string = this.$root.$data.backendServer.host;
      const port: string = this.$root.$data.backendServer.port;
      return `${url}:${port}`;
    },
  },
  methods: {
    //#region Css
    //#endregion
    //#region Logic
    async login() {
      // axios.post(`https://${this.backendUrl}/Common/DbLogin`, {
      //   id: this.user.id ?? null,
      //   pwd: this.user.pwd ?? null,
      // });

      let res = false;

      await fetch(`https://${this.backendUrl}/Common/DbLogin`, {
        method: "POST",
      })
        .then((res) => (res.status === 200 ? res.json() : null))
        .then((json) => {
          if (json === null) {
            return false;
          } else {
            this.user.id = json.data.id;
            console.log(json);
            return true;
          }
        })
        .catch((e) => {
          console.log(e);
          return false;
        });

      return res;
    },
    sign(isHaveAccount: boolean) {
      const signinBtn = this.$refs.signinBtn as Element;
      const signupBtn = this.$refs.signupBtn as Element;
      const formBox = this.$refs.formBox as Element;

      let signCondition = new Sign(isHaveAccount);

      console.log(signCondition);
      if (isHaveAccount) {
        formBox.classList.remove("active");
      } else {
        formBox.classList.add("active");
      }
    },
    //#endregion
  },
  created() {
    console.log("LoginComponent");
    this.login();

    this.$bus.$on("show:loginForm", (isShowLoginForm: boolean) => {
      this.isShow = isShowLoginForm;
    });

    // Test Mode
    if (this.$root.$data.isTestMode === true) {
      this.isShow = true;
    }
  },
  // mounted() {

  // },
});
</script>

<style lang="scss" scoped>
// #region Variable
$container-width: 800px;
$container-height: 500px;
$color-signup: rgb(135, 206, 235);
$color-signin: salmon;

$formBoxBorderRadiusList-default: 15% 5% 5% 15%;
$formBoxBorderRadiusList-active: 5% 15% 15% 5%;

.f-center-center {
  display: flex;
  justify-content: center;
  align-items: center;
}

// #endregion

// #region Common
.loginContainer {
  position: relative;
  width: $container-width;
  height: $container-height;
  margin: 30px;

  h2 {
    font-weight: 900;
  }

  // #region signUp
  & > .blueBg {
    position: absolute;
    top: 40px;
    width: 100%;
    height: calc($container-height * 0.8);
    // background-color: $color-signup;
    background-color: rgba(135, 206, 235, 0.75);
    box-shadow: 0 5px 45px rgba(0, 0, 0, 0.15);

    @extend .f-center-center;

    & .box {
      position: relative;
      width: 50%;
      height: 100%;
      @extend .f-center-center;
      flex-direction: column;

      & > h2 {
        color: #fff;
        font-size: 1.2em;
        font-weight: 500;
        margin-bottom: 10px;
      }

      & > button {
        cursor: pointer;
        padding: 10px 20px;
        background-color: #fff;
        color: #333;
        font-size: 16px;
        font-weight: 500;
        border: none;
        border-radius: 10px;
      }
    }
  }

  & > .formBox {
    position: absolute;
    top: 0;
    left: 0;
    width: 50%;
    height: 100%;
    background: #fff;
    z-index: 1000;
    @extend .f-center-center;
    box-shadow: 0.5px 45px rgba(0, 0, 0, 0.05);
    border-radius: $formBoxBorderRadiusList-default;
    // border-radius: 15% 0 0 15%;
    transition: 0.5s ease-in-out;

    &.active {
      left: 50%;
      border-radius: $formBoxBorderRadiusList-active;
    }
  }
  // #endregion

  // #region signIn

  // #endregion
}
// #endregion
</style>
