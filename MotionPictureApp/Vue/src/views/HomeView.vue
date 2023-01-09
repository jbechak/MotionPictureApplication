<template>
  <div class="home">
    <add-button/>
    <modal-form v-if="$store.state.isEditingMovie == true || $store.state.isAddingMovie == true"
    @saved="notifySaved"
    @deleted="notifyDeleted"
    />
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

  methods: {
    notifySaved(name) {
      this.$notify({
        group: 'messages',
        title: name + ' saved'
      });
    },
    notifyDeleted(name) {
      this.$notify({
        group: 'messages',
        title: name + ' deleted'
      });
    }
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
  min-height: 98vh;
  padding-top: 2vh;
  /* overflow-y: auto; */
}
</style>
