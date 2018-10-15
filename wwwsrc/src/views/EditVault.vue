<template>
  <div class="center">
    <form @submit.prevent="editVault(vaultToEdit)" class="row-form">
      <input type="text" v-model="vaultToEdit.name" value="vaultToEdit.name">
      <input type="text" v-model="vaultToEdit.description" value="vaultToEdit.description">
      <button type="submit">Edit Vault</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: "EditVault",
    mounted() {
      //checks for valid session
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    data() {
      return {
        vaultToEdit: this.$store.state.activeEdit
      };
    },
    methods: {
      editVault(vault) {
        this.$store.dispatch("editVault", vault);
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