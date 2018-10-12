<template>
  <div class="center">
    <form @submit.prevent="newKeep" class="row-form">
      <input type="text" v-model="keep.name" placeholder="Name">
      <input type="text" v-model="keep.description" placeholder="Description">
      <input type="text" v-model="keep.img" placeholder="Img URL">
      <button type="submit">Create Keep</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: "NewKeep",
    mounted() {
      //checks for valid session
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    data() {
      return {
        keep: {
          name: "",
          description: "",
          img: ""
        }
      };
    },
    methods: {
      newKeep() {
        this.$store.dispatch("newKeep", this.keep);
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