<template>
  <div class="home row">
    <div class="card" v-for="vault in myVaults">
      <div class="container">
        <h4><b>{{vault.name}}</b></h4>
        <p>{{vault.description}}</p>
      </div>
      <div>
        <button @click="viewVaultKeeps(vault.id)">View</button>
        <button @click="deleteVault(vault)">Delete</button>
        <button @click="editVault(vault)">Edit</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "MyVaults",
    data() {
      return {

      }
    },
    computed: {
      myVaults() {
        return this.$store.state.myVaults
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getMyVaults')
    },
    methods: {
      deleteVault(vault) {
        this.$store.dispatch('deleteVault', vault)
      },
      viewVaultKeeps(vaultId) {
        this.$store.dispatch('viewVaultKeeps', vaultId)
      },
      editVault(vault) {
        this.$store.dispatch('viewEditVault', vault)
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
    width: 25vw;
    margin: 1%;
    min-height: 20vh;
    max-height: 50vh;
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