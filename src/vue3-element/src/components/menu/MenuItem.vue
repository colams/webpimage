<template>
    <el-sub-menu
        :index="item.path"
        :key="item.title"
        :disabled="item.disable"
        v-if="item.menuList.length > 0"
    >
        <template #title>
            <i :class="item.icon" v-if="item.icon.length > 0"></i>
            <span v-if="isFolder">{{ item.title }}</span>
            <span v-else-if="item.menuList.length > 0">{{ item.title }}</span>
            <template v-else>{{ item.title }}</template>
        </template>

        <template v-for="subItem in item.menuList" :key="subItem.title">
            <MenuItem :item="subItem" />
        </template>
    </el-sub-menu>

    <el-menu-item :index="item.path" :key="item.path" :disabled="item.disable" v-else>
        <i :class="item.icon" v-if="item.icon.length > 0"></i>
        <span v-if="isFolder">{{ item.title }}</span>
        <template v-else>{{ item.title }}</template>
    </el-menu-item>
</template>


<script>
export default {
    name: "MenuItem",
    props: {
        item: Object,
    },
    computed: {
        isFolder() {
            return this.item.menuList && this.item.menuList.length;
        },
    },
};
</script>

<style scoped>
.el-submenu .el-menu-item {
    padding-left: 45px !important;
    text-align: left;
}
</style>