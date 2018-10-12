<template>
  <div class="center">
    <form @submit.prevent="newVault" class="row-form">
      <input type="text" v-model="vault.name" placeholder="Name">
      <input type="text" v-model="vault.description" placeholder="Description">
      <button type="submit">Create Vault</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: "NewVault",
    mounted() {
      //checks for valid session
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    data() {
      return {
        vault: {
          name: "",
          description: ""
        }
      };
    },
    methods: {
      newVault() {
        this.$store.dispatch("newVault", this.vault);
      }
    }
  };
</script>

<style>
  .center {
    height: 95vh;
    width: 95vw;
    justify-content: center;
    align-content: center;
    display: flex;
    flex-direction: row;
  }

  .row-form {
    display: flex;
    flex-direction: row;
    height: 1.5rem;
  }

  .col {
    display: flex;
    flex-direction: column;
  }
</style>