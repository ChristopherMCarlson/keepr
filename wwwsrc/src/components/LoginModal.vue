<template>
  <div class="login-modal">
    <!-- Button trigger modal -->
    <button class="top-bar-right" data-toggle="modal" data-target="#exampleModalCenter">
      Create New
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">Create New</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <slot></slot>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "LoginModal",
    data() {
      return {
        modalId: 'm' + Math.floor(Math.random() * (1000) + 1)
      }
    },
    mounted() {
      this.$emit('modalOpen', this.modalId)
    }
  }
</script>

<style>
  .openForm-btn {
    background: none;
    color: #ccc;
    width: 10rem;
    height: 3rem;
    border: 1px solid #338033;
    background-color: #40514e;
    font-size: 1rem;
    border-radius: .25rem;
    transition: .6s;
    overflow: hidden;
  }

  .openForm-btn:hover {
    background-color: #30e3ca;
    cursor: pointer;
    color: #40514e;
  }
</style>