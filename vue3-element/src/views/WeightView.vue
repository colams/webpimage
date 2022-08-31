<template>
    <div>
        <el-table
            :data="tableData"
            border
            stripe
            style="box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04)"
        >
            <el-table-column prop="id" label="ID" fit></el-table-column>
            <el-table-column prop="weight" label="weight" fit></el-table-column>
            <el-table-column prop="createDate" label="createDate" fit></el-table-column>
            <el-table-column label="操作">
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
        <WeightManager :visible="visible" :data="data" v-if="data" :callback="callback" />
    </div>
</template>

<script>
import axios from "axios";
import WeightManager from "@/components/weight/WeightManager.vue";
import urlconfig from "../utils/url_config";

export default {
    name: "WeightTable",
    components: {
        WeightManager,
    },
    data() {
        return {
            tableData: [],
            visible: false,
            data: null,
            callback: null,
        };
    },
    created() {
        this.getWeightDataList();
    },
    methods: {
        handleEdit(index, row) {
            this.visible = true;
            this.data = {
                id: row.id,
                weight: row.weight,
                createDate: row.createDate,
            };
            this.callback = (result) => {
                if (result) {
                    this.getWeightDataList();
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
            axios
                .post(urlconfig.url("/api/weight/delete"), row)
                .then((res) => {
                    if (res.status == 200 && res.data == true) {
                        alert("删除成功!!!!!!");
                        this.getWeightDataList();
                    }
                })
                .catch((e) => {
                    alert(JSON.stringifye);
                    console.log(JSON.stringify(e));
                });
        },

        async getWeightDataList() {
            await axios
                .get(urlconfig.url("/api/weight/list"))
                // .get("http://localhost:8080/api/weight/list")
                .then((res) => {
                    console.log(JSON.stringify(res));
                    this.tableData = res.data;
                })
                .catch((e) => {
                    console.log(JSON.stringify(e));
                });
        },
    },
};
</script>

<style scoped>
.box-card {
    padding: 0;
}
</style>