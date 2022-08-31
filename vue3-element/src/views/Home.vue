<template>
    <el-container class="home">
        <NavSide />
        <el-container class="is-vertical">
            <NavTool />
            <el-main>
                <router-view></router-view>
            </el-main>
        </el-container>
    </el-container>
</template>

<script>
// @ is an alias to /src
import NavSide from '@/components/menu/NavSide.vue'
import NavTool from '@/components/menu/NavTool.vue'

export default {
    name: 'Home',
    components: {
        NavTool,
        NavSide
    }
}
</script>
<style scoped>
.home {
    height: 100%;
    background-color: rgba(211, 214, 185, 0.144);
}
</style>
