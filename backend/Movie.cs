﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ Name } { Description } ({ ReleaseYear })";
            }
        }

    }
}
