using Entity.API.Dto.Category;
using Entity.API.Dto.Movie;
using Services.API.ResponseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryListDto>>> CategoryList();
        Task<Response<CategoryListDto>> CreateCategory(CategoryDto categoryDto,string fileDir);
        Task<Response<List<MovieCategoryListDto>>> FindMovie(int id);
    }
}
