<template>
  <div class="home">
    <div class="outer" v-for="keep in MyVaultKeeps">
      <img :src=keep.img alt="Avatar" class="image">
      <div class="overlay">
        <div class="text">
          <h3>{{keep.name}}</h3>
          <p>{{keep.description}}</p>
        </div>
        <div>
          <button class="remove-button" @click="removeKeep(keep)">Remove from Vault</button>
        </div>
        <div class="bottom-text">
          <div class="block-row clickable-block">
            <i class="fas fa-save block-row mr-1"></i>
            <p class="block-row">{{keep.keeps}}</p>
          </div>
          <div class="block-row clickable-block" @click="viewKeep(keep)">
            <i class="fas fa-eye block-row mr-1"></i>
            <p class="block-row">{{keep.views}}</p>
          </div>
          <div class="block-row clickable-block">
            <i class="fas fa-share block-row mr-1"></i>
            <p class="block-row">{{keep.shares}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "VaultKeeps",
    data() {
      return {

      }
    },
    computed: {
      MyVaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    methods: {
      removeKeep(keep) {
        let vaultKeep = {
          KeepId: keep.id,
          VaultId: this.$store.state.activeVault,
          userId: this.$store.state.user.id
        }
        this.$store.dispatch('removeKeep', vaultKeep)
        keep.keeps--
        this.$store.dispatch('editKeep', keep)
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
  }

  .outer {
    position: relative;
    width: 23%;
    margin: 1% 1% 1% 1%;
  }

  .image {
    display: block;
    width: 100%;
    height: 100%;
    object-fit: cover;
  }

  .overlay {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.383);
    overflow: hidden;
    width: 100%;
    height: 0;
    transition: .5s ease;
  }

  .outer:hover .overlay {
    height: 100%;
  }

  .text {
    white-space: nowrap;
    color: white;
    font-size: 1rem;
  }

  .bottom-text {
    white-space: nowrap;
    color: white;
    font-size: 1rem;
    position: relative;
    width: 100%;
    top: 20%;
    justify-content: space-around;
    display: flex;
    align-items: center;
  }

  .block-row {
    display: inline-block;
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

  .clickable-block {
    color: grey;
    transition: .3s ease;
    cursor: pointer;
  }

  .clickable-block:hover {
    color: white;
  }

  .remove-button {
    background-color: rgb(122, 0, 0);
    border: none;
    color: white;
    padding: 5px 10px 5px 10px;
    margin-top: 5%;
    border-radius: 12px;
    transition: .5s ease;
    cursor: pointer;
  }

  .remove-button:hover {
    background-color: red;
  }
</style>