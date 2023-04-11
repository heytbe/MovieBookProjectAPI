using Core.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entity.MovieEntity
{
    public class MovieImages:EntityBase
    {
        public string? ImageName { get; set; }
        public string? ImageDir { get; set; }
        public string? ImageSize { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
