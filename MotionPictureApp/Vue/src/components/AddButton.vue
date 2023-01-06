<template>
  <div id="add-button" class="button" @click="toggleAddingMovie">
    <font-awesome-icon class="add-icon" icon="circle-plus" />
    Add
  </div>
</template>

<script>
export default {

  methods: {
    toggleAddingMovie() {
      this.$store.commit("SET_SAVING_A_COPY", false);
      this.$store.commit("TOGGLE_ADDING_MOVIE");
    }
  }
}
</script>

<style>
#add-button {
    
    display: flex;
    
    justify-content: center;
    width: 60px;
    
    margin-left: auto;
    margin-right: 20px;
    

}

#add-button:hover {
    cursor: pointer;
}

.add-icon {
    width: 20px;
    margin-right: 5px;
}
</style>