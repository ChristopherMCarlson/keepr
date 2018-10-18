<template>
  <div class="center">
    <form @submit.prevent="newVault()" class="edit-form">
      <h2>New Vault</h2>
      <h5>Title</h5>
      <input class="my-1" type="text" v-model="vault.name">
      <p>{{remainingChar}}/20 Characters remaining</p>
      <h5>Description</h5>
      <textarea class="my-1" type="text" v-model="vault.description"></textarea>
      <button class="my-1 show-edit" type="submit">Submit New Vault</button>
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
    computed: {
      remainingChar() {
        return (20 - this.vault.name.length)
      }
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