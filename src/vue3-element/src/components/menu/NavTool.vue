<template>
    <el-header style="height: 50px">
        <el-row :gutter="10">
            <el-col :span="18">
                <el-breadcrumb
                    separator-class="el-icon-arrow-right"
                    style="line-height: 50px; font-size: 16px"
                >
                    <el-breadcrumb-item
                        v-for="item in breadcrumbItemList"
                        :key="item.pathName"
                        :to="item.path"
                    >{{ item.pathName }}</el-breadcrumb-item>
                </el-breadcrumb>
            </el-col>
            <el-col :span="6">
                <el-dropdown>
                    <i class="el-icon-setting" style="margin-right: 15px"></i>
                    <template #dropdown>
                        <el-dropdown-menu>
                            <el-dropdown-item
                                v-for="(item, index) in dropDownMenuList"
                                :key="index"
                            >{{ item }}</el-dropdown-item>
                        </el-dropdown-menu>
                    </template>
                </el-dropdown>
                <span>{{ userName }}</span>
            </el-col>
        </el-row>
    </el-header>
</template>

<script>
export default {
    name: "NavTool",
    data() {
        return {
            userName: "admin",
            dropDownMenuList: ["查看", "新增", "删除"],
            breadcrumbItemList: [
                {
                    path: "/welcome",
                    pathName: "首页",
                },
                {
                    pathName: "活动管理",
                },
                {
                    pathName: "活动列表",
                },
            ],
        };
    },
};
</script>


<style scoped>
.el-header {
    background-color: #d2e6e5d2;
    color: #333;
    line-height: 50px;
    text-align: right;
    font-size: 16px;
}
</style>