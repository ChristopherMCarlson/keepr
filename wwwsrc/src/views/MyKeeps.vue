<template>
  <div class="home">
    <div class="outer" v-for="keep in MyKeeps">
      <img :src=keep.img alt="Avatar" class="image">
      <div class="overlay">
        <div class="text">
          <h4>{{keep.name}}</h4>
          <p>{{keep.description}}</p>
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
    name: "home",
    data() {
      return {

      }
    },
    computed: {
      MyKeeps() {
        return this.$store.state.myKeeps
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getMyKeeps')
    },
    methods: {
      deleteKeep(keep) {
        this.$store.dispatch('deleteKeep', keep)
      },
      viewKeep(keep) {
        this.$store.dispatch('viewKeep', keep)
      }
    }
  };
</script>

<style>
  .outer {
    position: relative;
    width: 20vw;
    height: 30vh;
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
    overflow: hidden;
    text-overflow: ellipsis;
    color: white;
    font-size: 1vw;
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

  .home {
    justify-content: space-around;
  }
</style>