<template>
    <el-card>{{ params }}</el-card>
</template>

<script>
export default {
    name: "WeightDetail",
    data() {
        return {
            params: JSON.stringify(this.$route.params),
        };
    },
};
</script>