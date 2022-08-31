export default {
    state: {
        menuList: [{
            title: "导航1",
            icon: "el-icon-location",
            path: "link",
            menuList: [{
                title: "weight管理",
                icon: "",
                path: "/weight",
                menuList: []
            }, {
                title: "Tick管理",
                icon: "",
                path: "/tick",
                menuList: []
            }, {
                title: "数据库字符串",
                icon: "",
                path: "/conn",
                menuList: []
            }]
        },{
            title: "数据库",
            icon: "el-icon-location",
            path: "db",
            menuList: [{
                title: "DatabaseView",
                icon: "",
                path: "/database",
                menuList: []
            }]
        }],
    }
}

