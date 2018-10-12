<template>
  <div class="home">
    <div class="card" v-for="keep in keeps">
      <img :src=keep.img alt="KeepImg" style="width:100%; height: auto">
      <div class="container">
        <h4><b>{{keep.name}}</b></h4>
        <p>{{keep.description}}</p>
        <div class="row space-between">
          <div class="col">
            Keeps
          </div>
          <div class="col">
            Views
          </div>
          <div class="col">
            Shares
          </div>
        </div>
        <div class="row space-between">
          <div class="col">
            {{keep.keeps}}
          </div>
          <div class="col">
            {{keep.views}}
          </div>
          <div class="col">
            {{keep.shares}}
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
  import { mapState } from "vuex"
  export default {
    name: "home",
    data() {
      return {

      }
    },
    computed: {
      ...mapState(["keeps"])
    },
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch("authenticate");
      this.$store.dispatch('getPublicKeeps')
    }
  };
</script>

<style>
  .home {
    padding-top: 5%;
    align-content: space-between;
    padding-left: 2%;
    padding-right: 2%;
  }

  .card {
    /* Add shadows to create the "card" effect */
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    transition: 0.3s;
    width: 15vw;
  }

  /* On mouse-over, add a deeper shadow */
  .card:hover {
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
  }

  /* Add some padding inside the card container */
  .container {
    padding: 2px 16px;
  }

  .row {
    display: flex;
    flex-direction: row;
  }

  .col {
    display: flex;
    flex-direction: column;
  }

  .space-between {
    justify-content: space-between;
  }
</style>