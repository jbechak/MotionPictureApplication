<template>
  <div class="home">
    <add-button/>
    <modal-form v-if="$store.state.isEditingMovie == true || $store.state.isAddingMovie == true"/>
    <movie-list v-if="isLoading == false" />

  </div>
</template>

<script>
import MovieList from "../components/MovieList.vue";
import AddButton from "../components/AddButton.vue";
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
