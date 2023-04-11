using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Movie
{
    public class MovieIndex
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Poster_Path { get; set; }
        public bool Adult { get; set; }
        public string? Imdb { get; set; }
        public string? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public List<MovieCategoryList> Categories { get; set; }
    }
}
