<template>
  <nav id="topMenuContainer">
    <section class="hamburgerSection">
      <div id="toggle" ref="toggle" @click="toggleHamburger"></div>
      <ul v-if="isToggle">
        <li v-for="(item, idx) in toggleList" :key="idx">
          <span>{{ item }}</span>
        </li>
      </ul>
    </section>
    <section class="menuSection">
      <li>
        <ul v-for="item in menuList" :key="item">
          <strong>{{ item }}</strong>
        </ul>
      </li>
    </section>
    <section class="accountSection">
      <button>account Info</button>
    </section>
  </nav>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      tempTitle: "TopMenuContainer",
      isToggle: false,
      toggleList: [] as string[],
      menuList: [] as any[],
    };
  },
  methods: {
    toggleHamburger() {
      this.$nextTick(() => {
        const toggle = this.$refs.toggle as HTMLElement;
        toggle?.classList.toggle("active");
        this.isToggle = !this.isToggle;
      });
    },
    getToggleList(): string[] {
      let list = ["Home", "About", "FAQ"];
      return list;
    },
    getMenuList(): string[] {
      let list = ["Introduce", "History", "Map"];
      return list;
    },
  },
  created() {
    this.toggleList = this.getToggleList();
    this.menuList = this.getMenuList();
  },
  mounted() {
    // const toggle = document.getElementById("toggle") as HTMLElement;
    // toggle.onclick = function () {
    //   toggle?.classList.toggle("active");
    // };
  },
});
</script>

<style lang="scss" scoped>
// #region variable
$li-gap: 10vw;
$menu-ul-sizes: 30%, 20%, 25%;

$toggleColor: #fff;
$toggleOnMenu: #37a6ff;
$toggleOffMenu: #f7226a;
// #endregion variable

// #region css
.f-center-center {
  display: flex;
  justify-content: center;
  align-items: center;
}

#topMenuContainer {
  display: flex;
  justify-content: space-between;
  background-image: linear-gradient(to left bottom, #d0ecff 0%, #b0c8d8 100%);
  position: fixed;
  width: 100%;
  height: 7.5vh;
  top: 0;
  left: 0;

  section:where(:nth-child(1), :nth-child(3)) {
    @extend .f-center-center;
    width: 100%;
    flex: 0 0 10%;
  }
  section:nth-child(2) {
    @extend .f-center-center;
    width: 100%;
    flex: 0 0 80%;
    background-image: linear-gradient(to left bottom, #e8f2e2 0%, #b9d9a3 100%);

    li {
      width: 100%;
      display: flex;
      justify-content: start;
      gap: $li-gap;
      padding: 0 $li-gap;

      @each $size in $menu-ul-sizes {
        ul {
          width: $size;
        }
      }
    }
  }
  // #endregion css

  // #region hamburger toggle
  #toggle {
    position: relative;
    width: 50px;
    height: 50px;
    background-color: $toggleOnMenu;
    cursor: pointer;
    @extend .f-center-center;
    transition: 0.2s;

    &::before {
      content: "";
      position: absolute;
      width: 28px;
      height: 2px;
      background: $toggleColor;
      transition: 0.5s;
      transform: translateY(-10px);
      box-shadow: 0 10px 0 $toggleColor;
    }
    &::after {
      content: "";
      position: absolute;
      width: 28px;
      height: 2px;
      background: $toggleColor;
      transition: 0.5s;
      transform: translateY(10px);
    }

    &.active {
      background: $toggleOffMenu;
    }
    &.active::before {
      transform: translateY(0) rotate(45deg);
      box-shadow: 0 0 0;
    }
    &.active::after {
      transform: translateY(0) rotate(-45deg);
    }
  }
  // #endregion hamburger toggle
}
</style>
