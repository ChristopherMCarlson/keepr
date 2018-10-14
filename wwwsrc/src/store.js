import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "//localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "//localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    myKeeps: [],
    myVaults: [],
    activeKeep: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, keeps) {
      state.keeps = keeps
    },
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps
    },
    setMyVaults(state, vaults) {
      state.myVaults = vaults
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit }) {
      auth.delete('Logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'home' })
        })
    },
    getPublicKeeps({ commit }) {
      api.get('keep/getKeeps')
        .then(res => {
          commit('setPublicKeeps', res.data)
        })
    },
    getMyKeeps({ commit }) {
      api.get('keep/getMyKeeps')
        .then(res => {
          commit('setMyKeeps', res.data)
        })
    },
    deleteKeep({ dispatch }, keep) {
      api.post('keep/DeleteKeep', keep)
        .then(() => {
          dispatch('getMyKeeps')
        })
    },
    publicKeep({ dispatch }, keep) {
      api.put('keep/EditKeep', keep)
        .then(() => {
          dispatch('getMyKeeps')
        })
    },
    newKeep({ dispatch }, keep) {
      api.post('keep/CreateKeep', keep)
        .then(res => {
          console.log(res.data)
        })
    },
    newVault({ dispatch }, vault) {
      api.post('vault/CreateVault', vault)
        .then(res => {
          console.log(res.data)
        })
    },
    getMyVaults({ commit }) {
      api.get('vault/getMyVaults')
        .then(res => {
          commit('setMyVaults', res.data)
        })
    },
    deleteVault({ dispatch }, vault) {
      api.post('vault/DeleteVault', vault)
        .then(() => {
          dispatch('getMyVaults')
        })
    },
    viewKeep({ dispatch, commit }, keep) {
      commit('setActiveKeep', keep)
      api.put('keep/ViewKeep', keep)
        .then(() => {
          router.push({ name: "keep" })
        })
    },
    addToVault({ commit }, addToVault) {
      api.post('vaultKeep/CreateVaultKeep', addToVault)
        .then(res => {
          console.log(res.data)
        })
    },
    editKeep({ dispatch, commit }, keep) {
      api.put('keep/EditKeep', keep)
        .then(() => {
          router.push({ name: "keep" })
        })
    },
    viewVaultKeeps({ commit }, vaultId) {
      api.get('vaultkeep/' + vaultId)
        .then(res => {
          commit('setVaultKeeps', res.data)
          router.push({ name: "vaultkeeps" })
        })
    }
  }
})