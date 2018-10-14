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
          <input type="text" v-model="activeKeep.name" value=activeKeep.name>
          <textarea type="text" v-model="activeKeep.description" value=activeKeep.description></textarea>
          <input type="text" v-model="activeKeep.img" value=activeKeep.img>
          <button type="submit">Edit Keep</button>
        </form>
      </div>
      <div v-if="activeKeep.isPrivate == true && showEdit == false">
        <button class="show-edit" @click="showEdit = true">Edit Keep</button>
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
      vaults() {
        return this.$store.state.myVaults
      }
    },
    methods: {
      editKeep(keep) {
        this.$store.dispatch('editKeep', keep)
        this.showEdit = false
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
  .home {
    padding-top: 5%;
    align-content: space-between;
    padding-left: 2%;
    padding-right: 2%;
    display: flex;
    flex-wrap: wrap;
  }

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
  }

  .show-edit {
    background-color: grey;
    border: none;
    color: white;
    padding: 15px;
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
</style>