using AutoMapper;
using Entity.API.Dto.Category;
using Entity.API.Entity;
using Entity.API.Entity.MovieEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.AutoMapper.CategoryMap
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper() 
        {
            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap<MovieCategoryListDto, MovieCategory>().ReverseMap();
        }
    }
}
