import axios from 'axios';

export default {

    getAll() {
        return axios.get('/movie');
    },

    getMovie(id) {
        return axios.get(`movie/${id}`);
    },

    createMovie(newMovie) {
        return axios.post('/movie', newMovie);
    },

    updateMovie(movie, id) {
        return axios.put(`/movie/${id}`, movie);
    },

    deleteMovie(id) {
        axios.delete(`/movie/${id}`);
    }


}