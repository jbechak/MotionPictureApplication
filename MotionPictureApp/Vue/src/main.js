import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'
import Notifications from 'vue-notification'



/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { faUserSecret } from '@fortawesome/free-solid-svg-icons'
import { faHatWizard } from '@fortawesome/free-solid-svg-icons'
import { faPenToSquare } from '@fortawesome/free-solid-svg-icons'
import { faCopy } from '@fortawesome/free-solid-svg-icons'
import { faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { faCirclePlus } from '@fortawesome/free-solid-svg-icons'
// import { apply } from 'core-js/fn/reflect'

/* add icons to the library */
library.add(faUserSecret);
library.add(faHatWizard);
library.add(faPenToSquare);
library.add(faCopy);
library.add(faTrashCan);
library.add(faCirclePlus);

/* add font awesome icon component */
Vue.component('font-awesome-icon', FontAwesomeIcon);

import MovieListItem from '@/components/MovieListItem.vue';

Vue.config.productionTip = false

Vue.use(Notifications)


axios.defaults.baseURL = 'https://localhost:5001';

new Vue({
  el: '#app',
  components: { App, MovieListItem },
  template: '<App/>',
  router,
  store,
  render: h => h(App)
}).$mount('#app')
