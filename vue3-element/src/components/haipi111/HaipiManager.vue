<template>
    <el-dialog title="Haipi111" v-model="visible" :before-close="closeDialog" lock-scroll>
        <el-form :model="data">
            <el-form-item label="ID">
                <el-input v-model="data.id" disabled></el-input>
            </el-form-item>
            <el-form-item label="responseData">
                <el-input v-model="data.responseData"></el-input>
            </el-form-item>
        </el-form>

        <template #footer>
            <el-button @click="closeDialog">取 消</el-button>
            <el-button type="primary" @click="submit">确 定</el-button>
        </template>
    </el-dialog>
</template>

<script>
import axios from "axios";

export default {
    name: "HaipiManager",
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
                    urlconfig.url("/api/tick/addOrUpdate"),
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