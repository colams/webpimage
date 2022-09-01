<template>
  <div>
    <el-table :data="tableData" border stripe>
      <el-table-column prop="id" label="ID" fit></el-table-column>
      <el-table-column prop="uid" label="UID" fit></el-table-column>
      <el-table-column prop="infoid" label="InfoId" fit></el-table-column>
      <el-table-column prop="action" label="Action" fit></el-table-column>
      <el-table-column
        prop="requestdata"
        label="responsedata"
        fit
      ></el-table-column>
      <el-table-column
        prop="responsedata"
        label="responsedata"
        fit
      ></el-table-column>
      <el-table-column label="createDate" fit>
        <template #default="scope">
          {{ formatDate(scope.row.createDate) }}
        </template>
      </el-table-column>
      <el-table-column fixed="right">
        <template #header>
          <el-input
            v-model="search"
            size="small"
            placeholder="Type to search"
            @change="handleChange"
          />
        </template>
        <template #default="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)"
            >Edit</el-button
          >
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.$index, scope.row)"
            >Delete</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <HaipiManager
      :visible="visible"
      :data="data"
      v-if="data"
      :callback="callback"
    />
  </div>
</template>

<script>
import axios from "axios";
import HaipiManager from "@/components/haipi111/HaipiManager.vue";
import urlconfig from "../utils/url_config";

export default {
  name: "Haipi",
  components: {
    HaipiManager,
  },
  data() {
    return {
      search: "",
      tableData: [],
      tableDatabak: [],
      visible: false,
      data: null,
      callback: null,
    };
  },

  methods: {
    handleChange() {
      this.tableData = this.tableDatabak.filter(
        (e) => e.id == this.search || this.search.trim() == ""
      );
    },

    handleEdit(index, row) {
      this.visible = true;
      this.data = { id: row.id, uid: row.uid, infoid: row.infoid };
      this.callback = (result) => {
        if (result) {
          this.getDataList();
        }
        this.visible = false;
      };
      console.log(index, row);
    },
    handleDelete(index, row) {
      axios
        .post(urlconfig.url(urlconfig.haipi.delete), row)
        .then((res) => {
          if (res.status == 200 && res.data == true) {
            alert("删除成功!!!!!!");
            this.getDataList();
          }
        })
        .catch((e) => {
          alert(JSON.stringifye);
          console.log(JSON.stringify(e));
        });
    },
    async getDataList() {
      await axios
        .get(urlconfig.url(urlconfig.haipi.list))
        .then((res) => {
          this.tableData = res.data;
          this.tableDatabak = this.tableData;
        })
        .catch((e) => {
          console.log(JSON.stringify(e));
        });
    },

    formatDate(timestamp) {
      var date = new Date(timestamp); 
      var Y = date.getUTCFullYear() + "-";
      var M =
        (date.getUTCMonth() + 1 < 10
          ? "0" + (date.getMonth() + 1)
          : date.getMonth() + 1) + "-";
      var D = date.getUTCDate() + " ";
      var h = date.getUTCHours() + ":";
      var m = date.getUTCMinutes() + ":";
      var s = date.getUTCSeconds();
      return Y + M + D + h + m + s;
    },
  },

  created() {
    this.getDataList();
  },
};
</script>
