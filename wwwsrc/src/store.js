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
    myKeeps: []
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
    deleteKeep({ dispatch }) {
      api.delete('keep/DeleteKeep')
        .then(() => {
          dispatch('getMyKeeps')
        })
    }
  }
})