<template>
  <div class="home row">
    <div class="card">
      <img :src=activeKeep.img alt="KeepImg" style="width:100%; height: 35%">
      <div class="container">
        <h4><b>{{activeKeep.name}}</b></h4>
        <p>{{activeKeep.description}}</p>
      </div>
    </div>
    <div class="card-2">
      <select v-model="selectedVault">
        <option v-for="vault in vaults" :value=vault.id>{{vault.name}}</option>
      </select>
      <button @click="addToVault(activeKeep.id)">Add to vault</button>
      <div class="container">
        <form @submit.prevent="editKeep(activeKeep)">
          <input type="text" v-model="activeKeep.name">
          <input type="text" v-model="activeKeep.description">
          <input type="text" v-model="activeKeep.img">
          <button type="submit">Edit Keep</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "Keep",
    data() {
      return {
        selectedVault: "",
        keep: {
          name: "",
          description: "",
          img: ""
        }
      }
    },
    mounted() {
      this.$store.dispatch('getMyVaults')
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      vaults() {
        return this.$store.state.myVaults
      }
    },
    methods: {
      editKeep(keep) {
        console.log("This button works")
        this.$store.dispatch('editKeep', keep)
      },
      addToVault(keepId) {
        let vaultkeep = {
          keepId: keepId,
          vaultId: this.selectedVault
        }
        this.$store.dispatch('addToVault', vaultkeep)
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
    width: 15vw;
    margin: 1%;
    max-height: 50%;
  }

  .card-2 {
    /* Add shadows to create the "card" effect */
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
    transition: 0.3s;
    width: 45vw;
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