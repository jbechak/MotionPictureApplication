using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureApp.Dao
{
    public class DBMovieDao
    {
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new();
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MotionPictures;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select * from MotionPictures";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = "" + reader.GetInt32(0);
                                movie.Name = reader.GetString(1);
                                movie.Description = reader.GetString(2);
                                movie.ReleaseYear = "" + reader.GetInt32(3);

                                movies.Add(movie);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return movies;

        }

        public Movie GetMovie(int id)
        {
            Movie movie = new Movie();
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MotionPictures;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select * from MotionPictures where ID = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                movie.Id = "" + reader.GetInt32(0);
                                movie.Name = reader.GetString(1);
                                movie.Description = reader.GetString(2);
                                movie.ReleaseYear = "" + reader.GetInt32(3);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return movie;
        }

        public int CreateMovie(Movie newMovie)
        {
            int newId = 0;
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MotionPictures;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "insert into MotionPictures " +
                                "(Name, Description, [Release Year]) " +
                                "VALUES (@name, @description, @releaseYear);" +
                                "SELECT CAST(scope_identity() AS int);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", newMovie.Name);
                        command.Parameters.AddWithValue("@description", newMovie.Description);
                        command.Parameters.AddWithValue("@releaseYear", newMovie.ReleaseYear);
                        //command.ExecuteNonQuery();
                        newId = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());

            }
            return newId;
        }

        public void UpdateMovie(int id, Movie movie)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MotionPictures;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE MotionPictures " +
                                "SET Name = @name, Description = @description, [Release Year] = @releaseYear " +
                                "WHERE id = @id;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", movie.Name);
                        command.Parameters.AddWithValue("@description", movie.Description);
                        command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());

            }
        }

        public void DeleteMovie(int id)
        {
            try
            {
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MotionPictures;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "delete from MotionPictures where ID = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }


    
    }
}
