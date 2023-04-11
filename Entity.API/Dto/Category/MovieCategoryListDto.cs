using Entity.API.Dto.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Category
{
    public class MovieCategoryListDto
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        public MovieListDto Movie { get; set; }
    }
}
