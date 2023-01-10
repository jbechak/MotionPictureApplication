<template>
  <div id="app">
      <router-view/> 
      <notifications group="messages" position="top center" /> 
  </div>
</template>

<script>
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #afafaf;

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
