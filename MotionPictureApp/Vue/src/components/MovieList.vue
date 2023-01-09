<template>
  <div>
    <div id="header-row">
      <div id="header-title" @click="nameSort">Name</div>
      <div id="header-description" @click="descriptionSort">Description</div>
      <div id="header-year" @click="releaseYearSort">Release Year</div>
      <div id="header-actions">Actions</div>
    </div>

    <div v-for="movie in movies" v-bind:key="movie.id">
      <movie-list-item v-bind:movie="movie" @movie-copied="copyMovie($event)" />
    </div>
  </div>
</template>

<script>
import MovieListItem from "../components/MovieListItem.vue";

export default {
  components: { MovieListItem },
  data() {
    return {
      movies: [],
      sortedByName: false,
      sortedByDescription: false,
      sortedByReleaseYear: false,
      ascending: false,
      isLoading: true,
    };
  },

  created() {
    this.movies = this.$store.state.movies;
  },

  methods: {
    copyMovie(movie) {
      this.movies.push(movie);
    },
    nameSort() {
      if (this.sortedByName && this.ascending) {
        this.movies.sort(function (a, b) {
          return a.name < b.name ? 1 : b.name < a.name ? -1 : 0;
        });
        this.ascending = false;
      } else {
        this.movies.sort(function (a, b) {
          return a.name > b.name ? 1 : b.name > a.name ? -1 : 0;
        });
        this.sortedByName = true;
        this.sortedByDescription = false;
        this.sortedByReleaseYear = false;
        this.ascending = true;
      }
    },
    descriptionSort() {
      if (this.sortedByDescription && this.ascending) {
        this.movies.sort(function (a, b) {
          return a.description < b.description
            ? 1
            : b.description < a.description
            ? -1
            : 0;
        });
        this.ascending = false;
      } else {
        this.movies.sort(function (a, b) {
          return a.description > b.description
            ? 1
            : b.description > a.description
            ? -1
            : 0;
        });
        this.sortedByName = false;
        this.sortedByDescription = true;
        this.sortedByReleaseYear = false;
        this.ascending = true;
      }
    },
    releaseYearSort() {
      if (this.sortedByReleaseYear && this.ascending) {
        this.movies.sort(function (a, b) {
          return a.releaseYear < b.releaseYear
            ? 1
            : b.releaseYear < a.releaseYear
            ? -1
            : 0;
        });
        this.ascending = false;
      } else {
        this.movies.sort(function (a, b) {
          return a.releaseYear > b.releaseYear
            ? 1
            : b.releaseYear > a.releaseYear
            ? -1
            : 0;
        });
        this.sortedByName = false;
        this.sortedByDescription = false;
        this.sortedByReleaseYear = true;
        this.ascending = true;
      }
    },
  },
};
</script>

<style>
#header-row {
  margin-top: 10px;
  margin-left: 20px;
  margin-right: 20px;
  display: flex;
  justify-content: stretch;
  color: rgb(230, 230, 230);
  font-weight: 600;
  border-top: 1px solid;
  border-bottom: 2px solid;
  border-color: rgb(85, 85, 85);
}

#header-title {
  flex: 1 1 0;
  padding-left: 10px;
  padding-right: 7px;
  padding-top: 20px;
  padding-bottom: 20px;
}

#header-title:hover,
#header-description:hover,
#header-year:hover {
  cursor: pointer;
  opacity: 70%;
  
  background-color: rgb(77, 76, 76);
  border-radius: 5px;
}

#header-description {
  flex: 2 1 0;
  padding-left: 10px;
  padding-right: 10px;
  padding-top: 20px;
  padding-bottom: 20px;
}

#header-year {
  padding-left: 10px;
  flex: .8 1 0;
  padding-top: 20px;
  padding-bottom: 20px;
}

#header-actions {
  padding-left: 10px;
  flex: .5 1 0;
  padding-top: 20px;
  padding-bottom: 20px;
}
</style>