<template>
  <div id="confirm-delete" class="bottom-border">
    <div id="question">
      Delete {{ movie.name }} from the database?  
    </div>
    
    <div id="btns">
      <div class="button" @click="deleteMovie">Delete</div>
      <div class="button" @click="cancel">Cancel</div>
    </div>
  </div>
</template>

<script>
import MovieService from '@/services/MovieService';
export default {
  props: ["movie"],
  methods: {
    deleteMovie() {
        MovieService.deleteMovie(this.movie.id);
        if (this.$store.state.isEditingMovie) {
        this.$store.commit("TOGGLE_EDITING_MOVIE");
        }
        this.$store.commit("DELETE_MOVIE", this.movie.id);
        // this.$emit("deleted");
    },
    cancel() {
      console.log("blah");
      this.$emit("cancelled");
      // this.$store.commit("TOGGLE_ADDING_MOVIE");
      
    },
  }
};
</script>

<style>
#confirm-delete {
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    margin-right: 20px;
    margin-left: 20px;
    padding-bottom: 20px;
    background-color: rgba(95, 95, 95, 0.408);

}

#btns {
  display: flex;
}

#question {
    margin-top: 10px;
    margin-bottom: 10px;
    margin-right: 10px;
    
}
</style>