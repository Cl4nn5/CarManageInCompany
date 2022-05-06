<template>
  <article class="loginContainer">
    <section class="loginWrap">
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
    </section>
  </article>
</template>

<script lang="ts">
import Vue from "vue";
//import axios from "axios";

export default Vue.extend({
  name: "Login",
  props: {
    title: {
      type: String,
      default: "로그인 영역",
    },
  },
  data() {
    return {
      temp: "로그인 공간",
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
  },
  created() {
    console.log("LoginComponent");
    this.login();
  },
});
</script>

<style lang="scss" scoped>
input {
  border: 1px solid black;
  border-radius: 0 5px 5px 0;
  box-sizing: border-box;
}
label {
  box-sizing: border-box;
}

.loginContainer {
  display: flex;
  width: 100%;
  justify-content: center;

  .loginWrap {
    display: flex;
    height: 100%;
    justify-content: center;
    width: 40%;
  }

  .loginForm {
    &.header {
      color: red;
      flex: 1 1 30%;
    }

    &.inputForm {
      display: flex;
      flex: 1 1 70%;
      justify-content: center;
      flex-direction: column;

      .input.line {
        display: flex;
        width: 100%;
        height: 100%;
      }
      .input.line > label {
        flex: 1 1 34%;
        height: 100%;
      }
      .input.line > input {
        flex: 1 1 66%;
        height: 100%;
      }
      .input.label {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100%;
        border: 1px solid black;
        border-right: none;
        border-bottom: none;
      }
      .input.inputLogin {
        border-bottom: none;
      }
      .input.line:last-of-type .input.label {
        border-bottom: 1px solid black;
      }
      .input.line:last-of-type .input.inputLogin {
        border-bottom: 1px solid black;
      }
    }
  }

  .input {
    height: 100%;
  }
}
</style>
