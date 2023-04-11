using Entity.API.Dto.Movie;
using Entity.API.Entity.MovieEntity;
using Services.API.ResponseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Abstract
{
    public interface IMovieService
    {
        Task<Response<List<MovieIndex>>> GetAll();
        Task<Response<MovieListDto>> GetIdMovieList(int id);
        Task<Response<MovieListDto>> CreateMovie(MovieCreateDto movieCreateDto,string fileDir);
        Task<Response<NoContent>> DeleteMovie(int id);
    }
}
