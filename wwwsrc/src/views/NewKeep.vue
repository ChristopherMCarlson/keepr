<template>
  <div class="center">
    <form @submit.prevent="newKeep(keep)" class="edit-form">
      <h2>New Keep</h2>
      <h5>Title</h5>
      <input class="my-1" type="text" v-model="keep.name">
      <p>{{remainingChar}}/20 Characters remaining</p>
      <h5>Description</h5>
      <textarea class="my-1" type="text" v-model="keep.description"></textarea>
      <h5>Image Url</h5>
      <input class="my-1" type="text" v-model="keep.img">
      <button class="my-1 show-edit" type="submit">Submit New Keep</button>
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
    computed: {
      remainingChar() {
        return (20 - this.keep.name.length)
      }
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