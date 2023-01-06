import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isAddingMovie: false,
    isEditingMovie: false,
    savingACopy: false,
    movies: [],
    currentMovie: {
      id: "",
      name: "",
      description: "",
      releaseYear: ""
    },
    movieToAdd: {
      id: "",
      name: "",
      description: "",
      releaseYear: ""
    }
  },
  getters: {
  },
  mutations: {
    TOGGLE_ADDING_MOVIE() {
      this.state.isAddingMovie = !this.state.isAddingMovie;
    },
    TOGGLE_EDITING_MOVIE() {
      this.state.isEditingMovie = !this.state.isEditingMovie;
    },
    SET_MOVIES(state, movies) {
      this.state.movies = movies;
    },
    ADD_MOVIE(state, movie) {
      console.log(this.state.movies);
      this.state.movies.push({ id: movie.id, name: movie.name, description: movie.description, releaseYear: movie.releaseYear });
    },
    UPDATE_MOVIE(state, movie) {
      this.state.movies.splice(this.state.movies.findIndex(mov => mov.id == movie.id), 1,
      { id: movie.id, name: movie.name, description: movie.description, releaseYear: movie.releaseYear });
    },
    DELETE_MOVIE(state, id) {
      this.state.movies.splice(this.state.movies.findIndex(movie => movie.id == id), 1);
    },

    SET_CURRENT_MOVIE(state, movie) {
      this.state.currentMovie.id = movie.id;
      this.state.currentMovie.name = movie.name;
      this.state.currentMovie.description = movie.description;
      this.state.currentMovie.releaseYear = movie.releaseYear;
    },
    SET_SAVING_A_COPY(state, status) {
      this.state.savingACopy = status;
    }
  },
  actions: {
  },
  modules: {
  }
})
