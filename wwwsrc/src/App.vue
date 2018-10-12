<template>
  <div id="app" class="page-margin">
    <ul>
      <router-link tag="li" to="/">
        <a>Home</a>
      </router-link>
      <router-link tag="li" to="/myKeeps">
        <a>My Keeps</a>
      </router-link>
      <router-link tag="li" to="/myVaults">
        <a>My Vaults</a>
      </router-link>
      <router-link tag="li" to="/newKeep">
        <a>New Keep</a>
      </router-link>
      <router-link tag="li" to="/newVault">
        <a>New Vault</a>
      </router-link>
      <li v-if="loggedIn" class="top-bar-right">
        <button @click="logout()">Logout</button>
      </li>
      <router-link v-else class="top-bar-right" tag="li" to="/login">
        <a>Login/Register</a>
      </router-link>
    </ul>
    <router-view />
  </div>
</template>

<script>
  import LoginModal from "@/components/LoginModal"
  export default {
    name: "app",
    data() {
      return {

      }
    },
    computed: {
      //blocks users not logged in
      loggedIn() {
        return this.$store.state.user.id
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    }
  }

</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  ul {
    position: fixed;
    top: 0;
    width: 100vw;
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
  }

  li {
    float: left;
  }

  li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
  }

  /* Change the link color to #111 (black) on hover */
  li a:hover {
    background-color: #111;
  }

  li p {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
  }

  /* Change the link color to #111 (black) on hover */
  li p:hover {
    background-color: #111;
  }

  .top-bar-right {
    float: right;
    padding-right: 1%;
  }

  .page-margin {
    padding: 3rem 0 0 0;
  }
</style>