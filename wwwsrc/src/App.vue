<template>
  <div id="app">
    <ul class="page-margin">
      <router-link tag="li" to="/">
        <a>Home</a>
      </router-link>
      <router-link tag="li" to="/myKeeps">
        <a>My Keeps</a>
      </router-link>
      <router-link tag="li" to="/myVaults">
        <a>My Vaults</a>
      </router-link>
      <li v-if="loggedIn" class="top-bar-right"><a href="">Logout</a></li>
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
        loggedIn: true
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.loggedIn = false;
      }
    }
  };
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

  .top-bar-right {
    float: right;
    padding-right: 1%;
  }

  .page-margin {
    margin-bottom: 64px;
  }
</style>