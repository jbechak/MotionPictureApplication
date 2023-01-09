<template>
  <div class="modal-backdrop">
    <div class="modal" id="edit-page">
      
        <div id="page-title">
          <h2 v-if="$store.state.isAddingMovie == true">New Movie</h2>
          <h2 v-else-if="$store.state.savingACopy == true">Copy Movie</h2>
          <h2 v-else>Edit Movie</h2>
        </div>
        <form v-on:submit.prevent="submitForm">
          <div id="top-fields" class="top-border bottom-border">
            <div class="field" :class="{ bad: validName == false }">
              <label for="">Name: </label>
              <input
                type="text"
                maxlength="50"
                v-model="currentMovie.name"
                oninvalid="this.setCustomValidity('Enter a movie title (50 characters max)')"
                oninput="this.setCustomValidity('')"
                @invalid="validName = false"
                @keyup="validName = true"
                required
                placeholder="enter movie title"
              />
            </div>
            <div class="field" :class="{ bad: validYear == false }">
              <label for="">Release Year: </label>
              <input
                type="text"
                pattern="[0-9]{4}"
                v-model="currentMovie.releaseYear"
                oninvalid="this.setCustomValidity('Enter a 4-digit year (numbers only)')"
                oninput="this.setCustomValidity('')"
                @invalid="validYear = false"
                @keyup="validYear = true"
                required
                placeholder="enter 4-digit year"
              />
            </div>
          </div>

          <div class="field description-field">
            <div id="description-label">
              <label for="">Description: </label>
            </div>
            <div id="description-box">
              <textarea
                cols="68"
                rows="10"
                maxlength="500"
                v-model="currentMovie.description"
                placeholder="enter description (500 character max)"
              ></textarea>
            </div>
          </div>

          <div id="buttons">
            <input
              v-if="$store.state.savingACopy == true"
              type="submit"
              class="button"
              value="Save a Copy"
            />

            <input v-else type="submit" class="button" value="Save" />

            <div
              v-if="!$store.state.isAddingMovie"
              class="button"
              @click="deletingMovie = !deletingMovie"
            >
              Delete
            </div>
            <div class="button" @click="cancel">Cancel</div>
          </div>
        </form>

        <modal-delete 
        v-show="deletingMovie == true"
          :movie="currentMovie"
          @deleted="deleteMovie"
          @cancelled="deletingMovie = false"
          />
        
      </div>

    
  </div>
</template>

<script>
import ModalDelete from "./ModalDelete.vue";
import MovieService from "@/services/MovieService";
export default {
  components: { ModalDelete },
  props: ["movie"],
  name: "ModalForm",
  data() {
    return {
      savingACopy: false,
      currentMovie: {
        id: "",
        name: "",
        description: "",
        releaseYear: "",
      },
      validYear: true,
      validName: true,
      deletingMovie: false,
    };
  },
  methods: {
    submitForm() {
      if (this.$store.state.savingACopy || this.$store.state.isAddingMovie) {
        this.currentMovie.id = "";
        MovieService.createMovie(this.currentMovie).then((response) => {
          this.currentMovie.id = response.data;
          this.$store.commit("ADD_MOVIE", this.currentMovie);
          this.toggleStatus();
        });
      } else {
        MovieService.updateMovie(this.currentMovie, this.currentMovie.id).then(
          (response) => {
            response.data;
            this.$store.commit("UPDATE_MOVIE", this.currentMovie);
            this.toggleStatus();
          }
        );
      }
    },
    resetMovie() {
      this.currentMovie.id = "";
      this.currentMovie.name = "";
      this.currentMovie.description = "";
      this.currentMovie.releaseYear = "";
    },

    cancel() {
      this.toggleStatus();
    },

    deleteMovie() {
      this.$emit("deleted");
    },

    toggleStatus() {
      if (this.$store.state.isAddingMovie) {
        this.$store.commit("TOGGLE_ADDING_MOVIE");
      } else {
        this.$store.commit("TOGGLE_EDITING_MOVIE");
      }
    },
  
    close() {
      this.$emit("close");
    },
  },
  created() {
    if (!this.$store.state.isAddingMovie) {
      this.currentMovie = this.$store.state.currentMovie;
    }
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
  background-color: rgba(0, 0, 0, 0.689);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  
  box-shadow: 2px 2px 20px 1px rgb(51, 51, 51);
  /* overflow-x: auto; */
  display: flex;
  flex-direction: column;
  border-radius: 5px;
}

#edit-page {
  display: flex;
  flex-direction: column;
  align-items: center;
}

h2 {
  padding-bottom: 0px;
}

.field {
  margin-top: 1px;
  margin-bottom: 10px;
  margin-left: 10px;
  margin-right: 20px;
  padding: 5px;
}

#top-fields {
  display: flex;
  justify-content: center;
  margin-top: 10px;
  padding-top: 20px;
  padding-bottom: 10px;
}

#description-label {
  margin-bottom: 5px;
}

.description-field {
  display: flex;
  flex-direction: column;
  padding-top: 20px;
}

#buttons {
  display: flex;
  margin-left: auto;
  justify-content: center;
  margin-bottom: 20px;
}

.button {
  padding: 10px;
  padding-left: 6px;
}

.button:hover {
  cursor: pointer;
}

.bad {
  border: 1px solid red;
  margin-top: 0px;
  margin-bottom: 9px;
  padding-left: 4px;
  padding-right: 4px;
}
</style>