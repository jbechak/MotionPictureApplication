<template>
  <div>

    <div id="movie-row" class="bottom-border" v-show="isDeleted == false">
      <div id="title">
        {{ movie.name }}
      </div>
      <div id="description">
        {{ movie.description }}
      </div>
      <div id="year">
        {{ movie.releaseYear }}
      </div>

      <div id="actions">
        <font-awesome-icon class="icon" icon="pen-to-square" @click="editMovie" />
        <font-awesome-icon class="icon" icon="copy" @click="copyMovie" />
        <font-awesome-icon
          class="icon"
          id="trash"
          icon="trash-can"
          @click="deletingMovie = true"
        />
      </div>
    </div>
    
    <modal-delete 
    v-show="deletingMovie == true"
      :movie="movie"
      @cancelled="deletingMovie = false"
    />

    <!-- <delete-movie
      v-show="deletingMovie == true"
      :movie="movie"
      @cancelled="deletingMovie = false"
      
    /> -->


    
  </div>
</template>

<script>
// import DeleteMovie from "../components/DeleteMovie.vue";
import ModalDelete from "./ModalDelete.vue";

export default {
  name: "MovieListItem",
  components: { ModalDelete },
  props: ["movie"],
  data() {
    return {
      deletingMovie: false,
      isDeleted: false,
      editingMovie: false,
      currentMovie: {},
      savingACopy: false
    };
  },
  methods: {
    deleteMovie() {
        console.log("deleted");
      this.deletingMovie = false;
      this.isDeleted = true;
    },

    editMovie() {
        this.currentMovie = this.movie;
        this.$store.commit("SET_SAVING_A_COPY", false);
        this.$store.commit("SET_CURRENT_MOVIE", this.currentMovie);
        this.$store.commit("TOGGLE_EDITING_MOVIE");
    },

    copyMovie() {
      console.log("copying movie");
        this.currentMovie = this.movie;
        this.$store.commit("SET_SAVING_A_COPY", true);
        console.log(this.$store.state.savingACopy);
        this.$store.commit("SET_CURRENT_MOVIE", this.currentMovie);
        this.$store.commit("TOGGLE_EDITING_MOVIE");
    },
  },
};
</script>

<style>
#movie-row {
  color: #afafaf;
  display: flex;
  justify-content: stretch;
  margin-left: 20px;
  margin-right: 20px;
  padding-top: 20px;
  padding-bottom: 20px;

}

#title {
  flex: 1 1 0;
  padding-left: 10px;
  padding-right: 10px;
}

#description {
  flex: 2 1 0;
  padding-right: 10px;
}

#year {
  flex: 1 1 0;
}

#actions {
  flex: 1 1 0;
  display: flex;
}

.icon {
  margin-left: 10px;
  color: rgb(230, 230, 230);
  height: 18px;
}

.icon:hover {
  cursor: pointer;
  height: 16px;
  margin-right: 2px;
  opacity: 70%;
}

#trash {
  color: rgba(255, 0, 0, 0.829);
}
</style>