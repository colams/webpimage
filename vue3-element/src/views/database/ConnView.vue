<template>
    <el-main>
        <span>{{ conn }}</span>
    </el-main>
</template>

<script>
import axios from "axios";

export default {
    name: "Conn",

    data() {
        return {
            conn: "",
        };
    },

    created() {
        this.getConnString();
    },

    methods: {
        async getConnString() {
            await axios
                .post("https://colams.herokuapp.com/api/database/conn")
                .then((res) => {
                    this.conn = res.data;
                })
                .catch((e) => {
                    console.log(JSON.stringify(e));
                });
        },
    },
};
</script>

<style scoped>
.el-main {
    display: block;
}
</style>