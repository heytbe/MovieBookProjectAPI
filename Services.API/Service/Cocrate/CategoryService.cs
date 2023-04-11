using AutoMapper;
using Data.API.Context;
using Data.API.Dal.CategoryDal.Abstract;
using Data.API.Dal.MovieDal.Abstract;
using Data.API.Extensions;
using Data.API.UnitOfWorkRepo;
using Entity.API.Dto.Category;
using Entity.API.Dto.Movie;
using Entity.API.Entity;
using Microsoft.EntityFrameworkCore;
using Services.API.ResponseService;
using Services.API.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Cocrate
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public CategoryService(ICategoryDal categoryDal,IUnitOfWork unitOfWork,IMapper mapper,AppDbContext context)
        {
            _categoryDal = categoryDal;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Response<List<CategoryListDto>>> CategoryList()
        {
            var category = await  _categoryDal.GetAllAync(x => x.IsDeleted.Equals(false));
            var automapper = _mapper.Map<List<CategoryListDto>>(category);
            return Response<List<CategoryListDto>>.Success(automapper, 200);
        }

        public async Task<Response<CategoryListDto>> CreateCategory(CategoryDto categoryDto,string fileDir)
        {
            Category category = new Category();
            category.CategoryName = categoryDto.CategoryName;
            var categoryimage = await Upload.ImageUpload(categoryDto.Categoryimage, fileDir, categoryDto.CategoryName);
            if(categoryDto.Categoryimage != null)
            {
                category.Categoryimage = categoryimage[0];
            }
            await _categoryDal.AddAsync(category);
            await _unitOfWork.CommitAsync();
            var automapper = _mapper.Map<CategoryListDto>(category);
            return Response<CategoryListDto>.Success(automapper,200);
        }

        public async Task<Response<List<MovieCategoryListDto>>> FindMovie(int id)
        {
            var movie = await _context.MovieCategories.Include(x => x.Movie).Include(x => x.Category).Where(x => x.CategoryId.Equals(id)).ToListAsync();
            
            var automapper = _mapper.Map<List<MovieCategoryListDto>>(movie);

            return Response<List<MovieCategoryListDto>>.Success(automapper,200);
        }
    }
}
