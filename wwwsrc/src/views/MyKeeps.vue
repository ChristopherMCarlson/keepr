<template>
  <div class="home row">
    <div class="card" v-for="keep in MyKeeps">
      <img :src=keep.img alt="KeepImg" style="width:100%; height: 35%">
      <div class="container">
        <h4><b>{{keep.name}}</b></h4>
        <p>{{keep.description}}</p>
        <div class="row space-between">
          <div class="col">
            Keeps: {{keep.keeps}}
          </div>
          <div class="col">
            Views: {{keep.views}}
          </div>
          <div class="col">
            Shares: {{keep.shares}}
          </div>
        </div>
      </div>
      <div v-if=keep.isPrivate>
        <button @click="publicKeep(keep)">Make Public</button>
        <br>
        <button @click="deleteKeep(keep)">Delete</button>
        <br>
        <button @click="viewKeep(keep)">View</button>
      </div>
      <div v-else>
        <button @click="viewKeep(keep)">View</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "home",
    data() {
      return {

      }
    },
    computed: {
      MyKeeps() {
        return this.$store.state.myKeeps
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getMyKeeps')
    },
    methods: {
      deleteKeep(keep) {
        this.$store.dispatch('deleteKeep', keep)
      },
      publicKeep(keep) {
        keep.isPrivate = false
        this.$store.dispatch('publicKeep', keep)
      },
      viewKeep(keep) {
        keep.views++
        this.$store.dispatch('viewKeep', keep)
      }
    }
  };
</script>

<style>
  .home {
    padding-top: 5%;
    align-content: space-between;
    padding-left: 2%;
    padding-right: 2%;
    display: flex;
    flex-wrap: wrap;
  }

  .card {
    /* Add shadows to create the "card" effect */
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    transition: 0.3s;
    width: 20vw;
    margin: 1%;
    max-height: 50%;
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