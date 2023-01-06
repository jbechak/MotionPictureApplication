<template>
  <div id="app">
    
      <router-view/>
    
    <!-- <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </nav> -->
    
  </div>
</template>

<script>
// import MovieListItem from '@/components/MovieListItem.vue'

// export default {
//   components: {
//     MovieListItem
//   }
// }

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  /* text-align: center; */
  color: #afafaf;
  /* background-color: rgba(0, 0, 0, 0.9); */
  /* padding-top: 15px; */
  /* padding-left: 0px;
  margin-left: 0px; */
  /* width: 100%;
  height: 100%; */
}

body, html {
 margin: 0px; 
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}

.button {
  background-color: rgb(105, 105, 255);
  color: rgb(230, 230, 230);
  /* display: flex; */

  /* justify-content: center; */
  padding: 10px;
  padding-left: 6px;
  border-radius: 4px;
  border-top: 2px solid;
  border-left: 2px solid;
  border-color: rgb(122, 122, 255);
  margin-left: 10px;
  margin-right: 10px;
  font-size: 20px;
}

.button:hover {
  cursor: pointer;
  background-color: rgb(130, 130, 250);
}

.top-border {
  border-top: solid;
  border-width: 1px;
  border-color: rgb(85, 85, 85);
}

.bottom-border {
  border-bottom: solid;
  border-width: 1px;
  border-color: rgb(85, 85, 85);
}

</style>
