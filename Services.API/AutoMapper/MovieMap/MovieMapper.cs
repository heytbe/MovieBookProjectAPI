using AutoMapper;
using Entity.API.Dto.Movie;
using Entity.API.Entity;
using Entity.API.Entity.MovieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.AutoMapper.MovieMap
{
    public class MovieMapper:Profile
    {
        public MovieMapper() 
        {
            CreateMap<MovieListDto, Movie>().ReverseMap();
            CreateMap<MovieCategoryList, MovieCategory>().ReverseMap();
            CreateMap<MovieImagesList,MovieImages>().ReverseMap();
            CreateMap<MovieIndex, Movie>().ReverseMap();
        }
    }
}
