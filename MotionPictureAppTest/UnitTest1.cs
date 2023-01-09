using MotionPictureApp;
using MotionPictureApp.Controllers;
using NUnit.Framework;
using System.Collections.Generic;

namespace MotionPictureAppTest
{
    public class Tests
    {
        Movie starWars = new Movie("1", "Star Wars", "Sci-Fi Classic", "1977");
        Movie titanic = new Movie("Titanic", "Big ship sinks", "1997");
        Movie pulpFiction = new Movie("Pulp Fiction", "A Tarantino gem of the 90's. Now that's a tasty burger!", "1994");
        
        Movie badYearStarWars = new Movie("1", "Star Wars", "Sci-Fi Classic, the original", "NOT A YEAR");
        Movie badYearTitanic = new Movie("Titanic", "Big ship sinks", "NOT A YEAR");
        
        MovieController sut = new MovieController();


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GET_MOVIES_RETURNS_NOT_EMPTY_LIST()
        {
            List<Movie> result = sut.GetMovies();
                        
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void GET_MOVIE_RETURNS_CORRECT_MOVIE()
        {
            Movie result = sut.GetMovie(1);
            Movie Expected = starWars;

            Assert.AreEqual(Expected.Id, result.Id);
            Assert.AreEqual(Expected.Name, result.Name);
            Assert.AreEqual(Expected.Description, result.Description);
            Assert.AreEqual(Expected.ReleaseYear, result.ReleaseYear);
        }

        [Test]
        public void GET_MOVIE_RETURNS_EMPTY_MOVIE_WHEN_ID_IS_NONEXISTENT()
        {
            Movie result = sut.GetMovie(100);

            Assert.Null(result.Id);
            Assert.Null(result.Name);
            Assert.Null(result.Description);
            Assert.Null(result.ReleaseYear);
        }



        [Test]
        public void CREATE_MOVIE_CREATES_NEW_MOVIE()
        {
            Movie result = sut.GetMovie(sut.CreateMovie(titanic));
            Movie Expected = titanic;

            Assert.AreEqual(Expected.Name, result.Name);
            Assert.AreEqual(Expected.Description, result.Description);
            Assert.AreEqual(Expected.ReleaseYear, result.ReleaseYear);
        }

        [Test]
        public void CREATE_MOVIE_RETURNS_ZERO_WHEN_YEAR_IS_NOT_A_NUMBER()
        {
            var result = sut.CreateMovie(badYearTitanic);

            Assert.Zero(result);
        }

        [Test]
        public void UPDATE_MOVIE_PROPERLY_UPDATES_MOVIE()
        {
            /* For this test to remain useful after it successfully passes, 
             * either reset the database using the MotionPicturesDB.sql file 
             * or change the 'Expected' variable. */
            
            sut.UpdateMovie(3, pulpFiction);

            Movie result = sut.GetMovie(3);
            Movie Expected = pulpFiction;

            Assert.AreEqual(Expected.Name, result.Name);
            Assert.AreEqual(Expected.Description, result.Description);
            Assert.AreEqual(Expected.ReleaseYear, result.ReleaseYear);
        }

        [Test]
        public void UPDATE_MOVIE_DOESNT_UPDATE_WHEN_YEAR_IS_NOT_A_NUMBER()
        {
            sut.UpdateMovie(1, badYearStarWars);
            Movie result = sut.GetMovie(1);
            Movie Expected = starWars;

            Assert.AreEqual(Expected.Name, result.Name);
            Assert.AreEqual(Expected.Description, result.Description);
            Assert.AreEqual(Expected.ReleaseYear, result.ReleaseYear);
        }

        [Test]
        public void UPDATE_MOVIE_DOESNT_UPDATE_WHEN_ID_DOESNT_EXIST()
        {
            sut.UpdateMovie(100, pulpFiction);
            Movie result = sut.GetMovie(100);
            
            Assert.Null(result.Id);
            Assert.Null(result.Name);
            Assert.Null(result.Description);
            Assert.Null(result.ReleaseYear);
        }

        [Test]
        public void DELETE_MOVIE_DELETES_MOVIE()
        {
            /* For this test to remain useful after it successfully passes, 
             * reset the database using the MotionPicturesDB.sql file */

            sut.DeleteMovie(5);
            Movie result = sut.GetMovie(5);
            
            Assert.Null(result.Id);
            Assert.Null(result.Name);
            Assert.Null(result.Description);
            Assert.Null(result.ReleaseYear);
        }



    }
}