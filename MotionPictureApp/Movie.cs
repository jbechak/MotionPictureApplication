using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionPictureApp
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }

        public Movie() { }

        public Movie(String id, String name, String description, String releaseYear)
        {
            Id = id;
            Name = name;
            Description = description;
            ReleaseYear = releaseYear;
        }

        public Movie(String name, String description, String releaseYear)
        {
            Name = name;
            Description = description;
            ReleaseYear = releaseYear;
        }

    }
}
