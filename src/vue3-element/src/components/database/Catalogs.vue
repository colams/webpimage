<template>
    <span style="color:gray;font-size:10px">catalogs 总条目：{{ dataList.length }}</span>
    <el-table
        :data="dataList"
        border
        stripe
        style="box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04)"
        v-if="dataList.length > 0"
    >
        <el-table-column type="index" :index="indexMethod" />

        <el-table-column
            v-for="(name,index) in columnsName"
            :label="name.toLowerCase()"
            :key="name"
            fit
            #default="scope"
        >{{ scope.row[index] }}</el-table-column>
        <el-table-column align="left" label="操作">
            <template #default="scope">
                <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">Edit</el-button>
                <el-button size="mini" @click="handleDetail(scope.$index, scope.row)">Detail</el-button>
                <el-button
                    size="mini"
                    type="danger"
                    @click="handleDelete(scope.$index, scope.row)"
                >Delete</el-button>
            </template>
        </el-table-column>
    </el-table>
</template>

<script>
import axios from "axios";

export default {
    name: "Catalogs",
    data() {
        return {
            columnsName: [],
            dataList: [],
        };
    },
    created() {
        this.getCatalogs();
    },
    methods: {
        indexMethod(index) {
            return index + 1
        },
        handleEdit(index, row) {
            this.visible = true;
            this.data = {
                id: row.id,
                weight: row.weight,
                createDate: row.createDate,
            };
            this.callback = (result) => {
                if (result) {
                    this.getCatalogs();
                }
                this.visible = false;
            };
            console.log(index, row);
        },
        handleDetail(index, row) {
            this.data = {
                id: row.id,
                weight: row.weight,
                createDate: row.createDate,
            };
            this.$router.push({ name: "WeightDetail", params: this.data });
        },
        handleDelete(index, row) {
            console.log(index, row);
        },
        async getCatalogs() {
            let res = await axios.post("http://localhost:8090/api/database/catalogs");
            this.columnsName = res.data.columnsNames;
            this.dataList = res.data.dataList;
        },
    },
};
</script>

<style scoped>
.box-card {
    padding: 0;
}
</style>