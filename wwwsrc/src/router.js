import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import MyKeeps from './views/MyKeeps.vue'
// @ts-ignore
import NewKeep from './views/NewKeep.vue'
// @ts-ignore
import NewVault from './views/NewVault.vue'
// @ts-ignore
import MyVaults from './views/MyVaults.vue'
// @ts-ignore
import Keep from './views/Keep.vue'
// @ts-ignore
import VaultKeeps from './views/VaultKeeps.vue'
// @ts-ignore
import EditVault from './views/EditVault.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/myKeeps',
      name: 'myKeeps',
      component: MyKeeps
    },
    {
      path: '/newKeep',
      name: 'newKeep',
      component: NewKeep
    },
    {
      path: '/newVault',
      name: 'newVault',
      component: NewVault
    },
    {
      path: '/myVaults',
      name: 'myVaults',
      component: MyVaults
    },
    {
      path: '/keep',
      name: 'keep',
      component: Keep
    },
    {
      path: '/vaultkeeps',
      name: 'vaultkeeps',
      component: VaultKeeps
    },
    {
      path: '/editVault',
      name: 'editVault',
      component: EditVault
    }
  ]
})
