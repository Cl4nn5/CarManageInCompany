<template>
  <nav id="topMenuContainer">
    <section class="hamburgerSection">
      <div id="toggle" ref="toggle" @click="toggleHamburger"></div>
      <ul v-if="isToggle" ref="toggleSlideList" id="toggleSlideList">
        <li v-once v-for="(item, idx) in toggleList" :key="idx">
          <span>{{ item }}</span>
        </li>
      </ul>
    </section>
    <section class="menuSection">
      <li class="menu_li" ref="menuLi">
        <ul
          v-once
          v-for="(item, idx) in menuList"
          :key="item"
          ref="menuUlList"
          @click="clickMenu(idx)"
        >
          <strong>{{ item }}</strong>
        </ul>
      </li>
    </section>
    <section class="accountSection">
      <button>account Info</button>
    </section>
    <!-- 2nd line -->
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
    //#region css Methods
    toggleHamburger() {
      const toggle = this.$refs.toggle as HTMLElement;
      toggle?.classList.toggle("active");
      this.isToggle = !this.isToggle;
    },
    getToggleList(): string[] {
      let list = ["Home", "About", "FAQ"];
      return list;
    },
    getMenuList(): string[] {
      let list = ["Introduce", "History", "Map", "Non-Menu"];
      return list;
    },
    clickMenu(idx = 0): void {
      console.log(idx);
    },
    divisionMenuList(): void {
      const menuUlList = this.$refs.menuUlList as HTMLElement[];
      menuUlList.forEach((e: HTMLElement) => {
        e.style.width = `${100 / menuUlList.length}%`;
      });
    },
    //#endregion css Methods
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

    //#region css
    this.$nextTick(() => {
      this.divisionMenuList();
    });
    //#endregion
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

$topMenuHeight: 7.5vh;

$hamUlHeight: 50px;

.f-center-center {
  display: flex;
  justify-content: center;
  align-items: center;
}

// #endregion variable

// #region topMenu css
#topMenuContainer {
  display: flex;
  justify-content: space-between;
  background-image: linear-gradient(to left bottom, #d0ecff 0%, #b0c8d8 100%);
  position: fixed;
  width: 100%;
  height: $topMenuHeight;
  top: 0;
  left: 0;

  section {
    position: relative;
    @extend .f-center-center;
    width: 100%;
  }

  section:where(:nth-child(1), :nth-child(3)) {
    flex: 0 0 10%;
  }

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

  // #region toggleSlideList
  #toggleSlideList {
    background-image: linear-gradient(150deg, #b7d0e1 20%, #bec0e7 80%);
    position: absolute;
    display: flex;
    flex-direction: column;
    justify-content: space-evenly;
    width: 100%;
    height: calc($hamUlHeight * 4);
    top: $topMenuHeight;
    padding: 10px 0;
    gap: 10px;

    & > li {
      height: $hamUlHeight;
      @extend .f-center-center;
      cursor: pointer;
      border: 1px solid slateblue;
      border-image: linear-gradient(
          to right bottom,
          slateblue 30%,
          gray 70%,
          #902d99 100%
        )
        0.5;
      border-radius: 15px;
    }
  }
  // #endregion

  // #region menuList
  .menuSection {
    @extend .f-center-center;
    width: 100%;
    flex: 0 0 80%;
    background-image: linear-gradient(to left bottom, #e8f2e2 0%, #b9d9a3 100%);

    & > li {
      width: 100%;
      height: 100%;
      display: flex;
      justify-content: space-between;
      align-items: center;
      gap: $li-gap;

      // ul {
      //   width: calc(100% / length($list: $menu-ul-sizes));
      // }
    }
  }
  // #endregion
}
// #endregion css
</style>
