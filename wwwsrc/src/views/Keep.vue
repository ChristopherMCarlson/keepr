<template>
  <div class="home center-content">
    <div>
      <div v-if="showEdit == false">
        <h1>{{activeKeep.name}}</h1>
        <h5>{{activeKeep.description}}</h5>
        <img :src=activeKeep.img alt="" class="img-fit-screen">
        <div class="row space-between">
          <div>
            <h2>Keeps</h2>
            <h5>{{activeKeep.keeps}}</h5>
          </div>
          <div>
            <h2>Views</h2>
            <h5>{{activeKeep.views}}</h5>
          </div>
          <div>
            <h2>Shares</h2>
            <h5>{{activeKeep.shares}}</h5>
          </div>
        </div>
      </div>
      <div v-else>
        <form @submit.prevent="editKeep(activeKeep)" class="edit-form">
          <h2>Edit Keep</h2>
          <h5>Title</h5>
          <input class="my-1" type="text" v-model="activeKeep.name" value=activeKeep.name>
          <p>{{remainingChar}}/20 Characters remaining</p>
          <h5>Description</h5>
          <textarea class="my-1" type="text" v-model="activeKeep.description" value=activeKeep.description></textarea>
          <h5>Image Url</h5>
          <input class="my-1" type="text" v-model="activeKeep.img" value=activeKeep.img>
          <button class="my-1 show-edit" type="submit">Edit Keep</button>
        </form>
      </div>
      <div v-if="showEdit == false">
        <select v-model="selectedVault">
          <option value="" disabled selected>Add to vault...</option>
          <option v-for="vault in vaults" :value=vault.id>{{vault.name}}</option>
        </select>
        <button class="add-button" @click="addToVault(activeKeep)">+</button>
      </div>
      <div v-if="activeKeep.isPrivate == true && showEdit == false">
        <button class="show-edit" @click="showEdit = true">Edit Keep</button>
        <button class="show-public" @click="publicKeep(activeKeep)">Make Public</button>
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
        showEdit: false
      }
    },
    mounted() {
      this.$store.dispatch('getMyVaults')
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      remainingChar() {
        return (20 - this.activeKeep.name.length)
      },
      vaults() {
        return this.$store.state.myVaults
      }
    },
    methods: {
      editKeep(keep) {
        this.$store.dispatch('editKeep', keep)
        this.showEdit = false
      },
      publicKeep(keep) {
        keep.isPrivate = false
        this.$store.dispatch('publicKeep', keep)
      },
      addToVault(keep) {
        let vaultkeep = {
          keepId: keep.id,
          vaultId: this.selectedVault
        }
        this.$store.dispatch('addToVault', vaultkeep)
        keep.keeps++
        this.$store.dispatch('editKeep', keep)
      }
    }
  };
</script>

<style>
  .img-fit-screen {
    width: auto;
    height: 45vh;
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

  .center-content {
    justify-content: center;
    margin-top: -4%;
  }

  .show-edit {
    background-color: grey;
    border: none;
    color: white;
    padding: 15px;
    margin: 1% 1% 1% 1%;
    border-radius: 12px;
    transition: .5s ease;
    cursor: pointer;
  }

  .show-edit:hover {
    background-color: black
  }

  .edit-form {
    display: flex;
    flex-direction: column;
    width: 50vw;
  }

  .show-public {
    background-color: rgb(122, 0, 0);
    border: none;
    color: white;
    padding: 15px;
    margin: 1% 1% 1% 1%;
    border-radius: 12px;
    transition: .5s ease;
    cursor: pointer;
  }

  .show-public:hover {
    background-color: red;
  }

  .add-button {
    background-color: grey;
    border: none;
    color: white;
    font-size: 0.8rem;
    transition: .5s ease;
    cursor: pointer;
  }

  .add-button:hover {
    background-color: black
  }
</style>