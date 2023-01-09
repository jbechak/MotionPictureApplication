<template>
  <div class="modal-backdrop">
    
      <div id="confirm-delete" class="modal bottom-border">
        <div id="question">Delete {{ movie.name }} from the database?</div>

        <div id="btns">
          <div class="button" @click="deleteMovie">Delete</div>
          <div class="button" @click="cancel">Cancel</div>
        </div>
      </div>
    
  </div>
</template>
  
  <script>
import MovieService from "@/services/MovieService";
export default {
  props: ["movie"],
  methods: {
    deleteMovie() {
      MovieService.deleteMovie(this.movie.id);
      if (this.$store.state.isEditingMovie) {
        this.$store.commit("TOGGLE_EDITING_MOVIE");
      }
      this.$store.commit("DELETE_MOVIE", this.movie.id);
    },
    cancel() {
      this.$emit("cancelled");
    },
  },
};
</script>
  
  <style>
  .modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.693);
}

.modal {
  background: #ffffff;
  background-color: rgb(58, 58, 58);
  
  box-shadow: 2px 2px 20px 1px rgb(51, 51, 51);
  overflow-x: auto;
  display: flex;
  flex-direction: column;
  border-radius: 5px;
}
#confirm-delete {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
}

#btns {
  display: flex;
}

#question {
  margin-bottom: 15px;
}
</style>