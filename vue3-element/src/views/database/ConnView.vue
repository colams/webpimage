<template>
    <el-main>
        <span>{{ conn }}</span>
    </el-main>
</template>

<script>
import axios from "axios";
import urlconfig from "../../utils/url_config";

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
                .post(urlconfig.url("/api/database/conn"))
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