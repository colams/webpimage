<template>
    <el-aside
        :width="isCollapse ? '65px' : '200px'"
        style="background-color: rgba(211, 214, 100, 0.144)"
    >
        <div
            v-on:click="toggleCollapse"
            style="
        height: 50px;
        line-height: 50px;
        text-align: center;
        font-size: 20px;
      "
        >
            <i :class="collapseIcon"></i>
        </div>
        <el-menu
            :default-active="activePath"
            :default-openeds="subMenuArray"
            @open="handleOpen"
            :collapse-transition="false"
            :collapse="isCollapse"
            router
        >
            <template v-for="item in menuList" :key="item.title">
                <MenuItem :item="item" />
            </template>
        </el-menu>
    </el-aside>
</template>

<script>
import MenuItem from "./MenuItem";

export default {
    name: "NavSide",
    data() {
        return {
            isCollapse: false,
            menuList: this.$store.state.menu.menuList,
            activePath: this.$route.path, // todo
            subMenuArray: ["导航1"], // todo
            collapseIcon: "el-icon-d-arrow-left",
        };
    },
    created() { },
    components: {
        MenuItem,
    },
    methods: {
        toggleCollapse() {
            this.collapseIcon = !this.isCollapse
                ? "el-icon-d-arrow-right"
                : "el-icon-d-arrow-left";
            this.isCollapse = !this.isCollapse;
        },

        handleOpen(key, keyPath) {
            console.log(key);
            console.log(keyPath);
        },
    },
    computed: {
        getActivePath: function () {
            return this.$route.path;
        },
    },
};
</script>

<style scoped>
</style>
