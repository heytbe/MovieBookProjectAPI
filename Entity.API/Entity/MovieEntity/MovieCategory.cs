using Core.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entity.MovieEntity
{
    public class MovieCategory:EntityBase
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public Movie Movie{ get; set; }
        public Category Category { get; set; }
    }
}
