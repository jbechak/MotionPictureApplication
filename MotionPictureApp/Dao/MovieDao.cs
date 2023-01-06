using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureApp.Dao
{
    interface MovieDao
    {
        List<Movie> GetMovies();

        Movie GetMovie(int id);

        int CreateMovie(Movie newMovie);

        void UpdateMovie(int id, Movie movie);

        void DeleteMovie(int id);
    }
}
