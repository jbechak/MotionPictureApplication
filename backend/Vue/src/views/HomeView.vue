<template>
  <div class="home">
    <!-- <add-button
      v-show="
        $store.state.isAddingMovie == false &&
        $store.state.isEditingMovie == false
      "
    /> -->
    <add-button/>
    <modal-form v-if="$store.state.isEditingMovie == true || $store.state.isAddingMovie == true"/>
    <!-- <movie-form v-if="$store.state.isEditingMovie == true || $store.state.isAddingMovie == true"/> -->
    <!-- <movie-list v-if="isLoading == false && $store.state.isAddingMovie == false && $store.state.isEditingMovie == false" /> -->
    <movie-list v-if="isLoading == false" />

  </div>
</template>

<script>
import MovieList from "../components/MovieList.vue";
import AddButton from "../components/AddButton.vue";
// import MovieForm from "@/components/MovieForm.vue";
import MovieService from "@/services/MovieService";
import ModalForm from "@/components/ModalForm.vue";

export default {
  name: "HomeView",
  components: {
    MovieList,
    AddButton,
    
    ModalForm
  },
  data() {
    return {
      isLoading: true
    };
  },
  created() {
    MovieService.getAll().then((response) => {
      this.$store.commit("SET_MOVIES", response.data);
      this.isLoading = false;
    });
  },

};
</script>

<style>
.home {
  background-color: rgba(0, 0, 0, 0.9);
  min-height: 100vh;
  padding-top: 20px;
}
</style>
