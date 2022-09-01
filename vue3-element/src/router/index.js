import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Tick from '../views/TickView.vue'
import Weight from '../views/WeightView.vue'
import Conn from '../views/database/ConnView.vue'
import Haipi from '../views/Haipi.vue'
import Welcome from '../views/WelcomeView.vue'
import WeightDetail from '@/components/weight/WeightDetail.vue'
import DatabaseView from '../views/database/DatabaseView.vue'

// [
//     {
//       path: '/',
//       name: 'Home',
//       component: Home
//     },
//     {
//       path: '/about',
//       name: 'About',
//       // route level code-splitting
//       // this generates a separate chunk (about.[hash].js) for this route
//       // which is lazy-loaded when the route is visited.
//       component: function () {
//         return import(/* webpackChunkName: "about" */ '../views/About.vue')
//       }
//     }
//   ]

const routes = [


    {
        path: "/",
        name: "Home",
        component: Home,
        redirect: "/welcome",
        children: [
            {
                path: '/welcome',
                name: 'Welcome',
                component: Welcome
            },
            {
                path: "/weight",
                name: "Weight",
                component: Weight,
            },
            {
                path: "/weightDetail",
                name: "WeightDetail",
                component: WeightDetail,
            },
            {
                path: "/tick",
                name: "Tick",
                component: Tick,
            },
            {
                path: "/conn",
                name: "Conn",
                component: Conn,
            },
            {
                path: "/haipi",
                name: "Haipi",
                component: Haipi,
            },
            {
                path: "/database",
                name: "DatabaseView",
                component: DatabaseView,
            },
        ]
    }
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

export default router
