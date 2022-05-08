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
    <transition name="change-bg-color">
      <section
        :class="isLoginAction ? 'blueBg' : 'redBg'"
        :key="isLoginAction"
        ref="blueBg"
      >
        <div class="box signin">
          <h2>회원가입 하세요</h2>
          <button @click="changeSignUI(true)" ref="signinBtn" class="signinBtn">
            Sign in
          </button>
        </div>
        <div class="box signup">
          <h2>로그인 하세요</h2>
          <button
            @click="changeSignUI(false)"
            ref="signupBtn"
            class="signupBtn"
          >
            Sign up
          </button>
        </div>
      </section>
    </transition>
    <section class="formBox" ref="formBox">
      <div class="form" :class="isLoginAction ? 'signinForm' : 'signupForm'">
        <form action="POST">
          <h3>Sign In</h3>
          <input type="text" placeholder="ID" v-model="user.id" />
          <input
            v-if="!isLoginAction"
            type="email"
            placeholder="Email Address"
          />
          <input type="password" placeholder="Password" v-model="user.pwd" />
          <input
            v-if="!isLoginAction"
            type="password"
            placeholder="Confirm Password"
          />
          <input
            type="submit"
            value="Login"
            @click.prevent="submitLogin($event)"
          />
          <a href="#" class="forgot">Forgot Password</a>
        </form>
      </div>
    </section>
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
import axios from "axios";

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
      isLoginAction: true,
      user: {
        id: "",
        pwd: "",
        email: "",
        confirmPwd: "",
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
    async submitLogin() {
      // axios.post(`https://${this.backendUrl}/Common/DbLogin`, {
      //   id: this.user.id ?? null,
      //   pwd: this.user.pwd ?? null,
      // });

      let res = false;

      await fetch(`https://${this.backendUrl}/Common/DbLogin`, {
        method: "POST",
        body: JSON.stringify({
          loginId: this.user.id,
          loginPwd: this.user.pwd,
        }),
        mode: "cors",
        headers: {
          // "Content-Type": "application/x-www-form-urlencoded",
          "Content-Type": "application/json",
          // "Access-Control-Request-Headers": "Content-Type",
          "Access-Control-Allow-Origin": "*",
        },
      })
        .then((res) => {
          console.log(res);
          return res.status === 200 ? res.json() : null;
        })
        .then((json) => {
          console.log(json);
          if (json === null) {
            return false;
          } else {
            this.user.id = json.data.id;
            return true;
          }
        })
        .catch((e) => {
          console.log(e);
          return false;
        });

      return res;
    },
    changeSignUI(isHaveAccount: boolean) {
      const signinBtn = this.$refs.signinBtn as Element;
      const signupBtn = this.$refs.signupBtn as Element;
      const formBox = this.$refs.formBox as Element;

      let signCondition = new Sign(isHaveAccount);
      // console.log(signCondition.type);

      setTimeout(() => {
        this.isLoginAction = isHaveAccount;
      }, 300);
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
    // this.login();

    // this.$bus.$on("show:loginForm", (isShowLoginForm: boolean) => {
    //   this.isShow = isShowLoginForm;
    // });

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
$color-signin: rgb(135, 206, 235);
$color-signup: salmon;

$formBoxBorderRadiusList-default: 10% 5% 5% 15%;
$formBoxBorderRadiusList-active: 5% 10% 15% 5%;

$btnColor: #333;

.f-center-center {
  display: flex;
  justify-content: center;
  align-items: center;
}
// #endregion

//#region vue Transition
// .fade-enter /* .fade-leave-active below version 2.1.8 */ {
//   left: -150%;
// }
// .fade-leave-to {
//   left: 150%;
//   background-color: blue;
// }
// .fade-enter-active {
//   transition: opacity 0.5s ease-in-out;
// }
// .fade-leave-active {
//   transition: opacity 0.5s ease-in-out;
// }

// .change-bg-color-enter {
//   display: none;
// }
// .change-bg-color-enter-to {
//   display: none;
// }
// .change-bg-color-enter-active {
//   transition: 0.5s ease-in-out;
// }

//#endregion

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
  & > section {
    position: absolute;
    top: 40px;
    width: 100%;
    height: calc($container-height * 0.8);
    // background-color: $color-signup;
    box-shadow: 0 5px 45px rgba(0, 0, 0, 0.15);

    @extend .f-center-center;

    @keyframes changeColor-blueToRed {
      0% {
        background-color: $color-signin;
      }
      100% {
        background-color: $color-signup;
      }
    }
    @keyframes changeColor-redToBlue {
      0% {
        background-color: $color-signup;
      }
      100% {
        background-color: $color-signin;
      }
    }

    &.blueBg {
      background-color: $color-signin;
      animation: 0.5s changeColor-redToBlue;
    }
    &.redBg {
      animation: 0.5s changeColor-blueToRed;
      background-color: $color-signup;
      // transition: 0.5s ease-in-out;
    }

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
        color: $btnColor;
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
    overflow: hidden;

    &.active {
      left: 50%;
      border-radius: $formBoxBorderRadiusList-active;
    }

    & .form {
      position: absolute;
      left: 0;
      width: 100%;
      padding: 50px;
      transition: 0.5s;

      & form {
        width: 100%;
        display: flex;
        flex-direction: column;
        gap: 1.25rem;

        & h3 {
          font-size: 1.5em;
          color: $btnColor;
          font-weight: 700;
        }
        & input {
          box-sizing: content-box;
          width: 100%;
          padding: 10px;
          outline: none;
          font-size: 1rem;
          border: 1px solid $btnColor;
        }
        & input[type="submit"] {
          background-color: $color-signin;
          border: none;
          max-width: 100px;
          cursor: pointer;
        }
        & .forgot {
          color: $btnColor;
          text-decoration: none;
        }
      }
    }

    // 로그인/회원가입 페이지 변환 애니메이션
    & .signinForm {
      left: 0;
      transition-delay: 0.25s;
    }
    &.active .signinForm {
      left: -200%;
      transition-delay: 0s;
    }
    & .signupForm {
      left: 200%;
      transition-delay: 0s;
    }
    &.active .signupForm {
      left: 0;
      transition-delay: 0.25s;
    }
  }
  // #endregion

  // #region signIn

  // #endregion
}
// #endregion
</style>
