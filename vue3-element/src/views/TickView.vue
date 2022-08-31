<template>
  <div>
    <el-table :data="tableData" border stripe>
      <el-table-column prop="id" label="ID" fit></el-table-column>
      <el-table-column prop="tick" label="时间戳" fit></el-table-column>
      <el-table-column fixed="right">
        <template #default="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">Edit</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">Delete</el-button>
        </template>
      </el-table-column>
    </el-table>
    <WeightManager :visible="visible" :data="data" v-if="data" :callback="callback" />
  </div>
</template>

<script>
import axios from "axios";
import WeightManager from "@/components/tick/TickManager.vue";
import urlconfig from "../utils/url_config";

export default {
    name: "TickTable",
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

    methods: {
        handleEdit(index, row) {
            this.visible = true;
            this.data = { id: row.id, tick: row.tick };
            this.callback = (result) => {
                if (result) {
                    this.getTickDataList();
                }
                this.visible = false;
            };
            console.log(index, row);
        },
        handleDelete(index, row) {
            axios
                .post(urlconfig.url("/api/tick/delete"), row)
                .then((res) => {
                    if (res.status == 200 && res.data == true) {
                        alert("删除成功!!!!!!");
                        this.getTickDataList();
                    }
                })
                .catch((e) => {
                    alert(JSON.stringifye);
                    console.log(JSON.stringify(e));
                });
        },
        async getTickDataList() {
            await axios
                .get(urlconfig.url("/api/tick/list"))
                // .get("http://localhost:8080/api/tick/list")
                .then((res) => {
                    this.tableData = res.data;
                })
                .catch((e) => {
                    console.log(JSON.stringify(e));
                });
        },
    },

    created() {
        this.getTickDataList();
    },
};
</script>
