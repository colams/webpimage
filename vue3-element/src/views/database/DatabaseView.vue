<template>
    <el-card>
        <el-row style="margin-top: 10px;">
            <el-col :span="24">
                <Catalogs />
            </el-col>
        </el-row>
        <el-row style="margin-top: 10px;">
            <el-col :span="24">
                <Tables />
            </el-col>
        </el-row>
        <el-row style="margin-top: 10px;">
            <el-col :span="24">
                <TableTypes />
            </el-col>
        </el-row>
        <el-row style="margin-top: 10px;">
            <el-col :span="24">
                <Columns />
            </el-col>
        </el-row>
    </el-card>
</template>

<script>
import axios from "axios";

import Catalogs from "@/components/database/Catalogs.vue"
import Columns from "@/components/database/Columns.vue"
import Tables from "@/components/database/Tables.vue"
import TableTypes from "@/components/database/TableTypes.vue"

export default {
    name: "DatabaseView",
    components: {
        Catalogs,
        Columns,
        Tables,
        TableTypes,
    },
    data() {
        return {
            columnsName: [],
            dataList: [],
            visible: false,
            data: null,
            callback: null,
        };
    }
};
</script>

<style scoped>
.box-card {
    padding: 0;
}
</style>