using Data.API.Repositories.Abstract;
using Entity.API.Dto.Movie;
using Entity.API.Entity.MovieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Dal.MovieDal.Abstract
{
    public interface IMovieDal:IGenericRepository<Movie>
    {
        Task<Movie> CreateMovie(MovieCreateDto createDto,string dirpath);
    }
}
