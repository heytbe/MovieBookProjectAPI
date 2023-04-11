using Core.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entity.MovieEntity
{
    public class Movie : EntityBase
    {
        public Movie()
        {
            MovieImages = new HashSet<MovieImages>();
            Categories = new HashSet<MovieCategory>();
        }

        public string MovieName { get; set; }
        public string Poster_Path { get; set; }
        public bool Adult { get; set; }
        public string? MovieFragman { get; set; }
        public string? Imdb { get; set; }
        public string? OrjinalName { get; set; }
        public string? Overview { get; set; }
        public string? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public string? TagLine { get; set; }
        public string? BackdropPath { get; set; }

        public virtual ICollection<MovieImages> MovieImages { get; set; }
        public virtual ICollection<MovieCategory> Categories { get; set; }

    }
}
