using Core.API.Entity;
using Entity.API.Entity.MovieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entity
{
    public class Category:EntityBase
    {
        public Category()
        {
            Movies = new HashSet<MovieCategory>();
        }
        public string CategoryName { get; set; }
        public string? Categoryimage { get; set; }
        public virtual ICollection<MovieCategory>  Movies { get; set; }
    }
}
