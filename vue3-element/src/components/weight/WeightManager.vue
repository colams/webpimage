<template>
    <el-dialog title="weight 管理" :before-close="closeDialog" lock-scroll v-model="visible">
        <el-card>
            <el-form :model="data">
                <el-form-item label="ID">
                    <el-input v-model="data.id" disabled></el-input>
                </el-form-item>
                <el-form-item label="createDate">
                    <el-input v-model="data.createDate" disabled></el-input>
                </el-form-item>
                <el-form-item label="weight">
                    <el-input v-model="data.weight"></el-input>
                </el-form-item>
            </el-form>
        </el-card>
        <template #footer>
            <el-button @click="closeDialog">取 消</el-button>
            <el-button type="primary" @click="submit">确 定</el-button>
        </template>
    </el-dialog>
</template>

<script>
import axios from "axios";
import urlconfig from "@/utils/url_config";

export default {
    name: "WeightManager",
    props: {
        visible: {
            type: Boolean,
            default: false,
        },
        data: {
            type: Object,
            default: {
                id: 0,
                tick: 0,
                weight: 0,
            },
        },
        callback: {
            default: null,
        },
    },
    methods: {
        closeDialog() {
            if (this.callback) {
                this.callback();
            }
        },
        submit() {
            console.log(this.data);
            axios
                .post(
                    urlconfig.url("/api/weight/addOrUpdate"),
                    // "http://localhost:8080/api/weight/addOrUpdate",
                    // JSON.stringify(this.data)
                    this.data
                )
                .then((res) => {
                    if (res.status == 200 && res.data == true) {
                        alert("修改成功!!!!!!");
                        this.callback(true);
                    }
                })
                .catch((e) => {
                    alert(JSON.stringify(e));
                    console.log("e=>", e);
                });
        },
    },
};
</script>