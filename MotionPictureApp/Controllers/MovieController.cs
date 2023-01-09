using MotionPictureApp;
using MotionPictureApp.Dao;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        IMovieDao dao = new DBMovieDao();

        [EnableCors]
        [HttpGet]
        public List<Movie> GetMovies()
        {
            return dao.GetMovies();
            
        }

        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return dao.GetMovie(id);
        }

        //[EnableCors]
        [HttpPost]
        public int CreateMovie(Movie newMovie)
        {
            return dao.CreateMovie(newMovie);
        }

        [HttpPut("{id}")]
        public void UpdateMovie(int id, [FromBody] Movie movie)
        {
            dao.UpdateMovie(id, movie);
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            dao.DeleteMovie(id);
        }


    }
}
