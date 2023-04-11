using AutoMapper;
using Data.API.Context;
using Data.API.Dal.CategoryDal.Abstract;
using Data.API.Dal.MovieDal.Abstract;
using Data.API.UnitOfWorkRepo;
using Entity.API.Dto.Category;
using Entity.API.Dto.Movie;
using Entity.API.Entity;
using Entity.API.Entity.MovieEntity;
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
    public class MovieService : IMovieService
    {
        private readonly IMovieDal _movieDal;
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public MovieService(IMovieDal movieDal,IMapper mapper,IUnitOfWork unitOfWork,ICategoryDal categoryDal,AppDbContext context)
        {
            _movieDal = movieDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryDal = categoryDal;
            _context = context;
        }

        public async Task<Response<MovieListDto>> CreateMovie(MovieCreateDto movieCreateDto, string fileDir)
        {
            var response = await _movieDal.CreateMovie(movieCreateDto, fileDir);
            await _movieDal.AddAsync(response);
            await _unitOfWork.CommitAsync();
            var automapper = _mapper.Map<MovieListDto>(response);
            return Response<MovieListDto>.Success(automapper, 200);
        }

        public async Task<Response<NoContent>> DeleteMovie(int id)
        {
            var moviedelete = await _movieDal.GetIdListAsync(x => x.Id.Equals(id),x => x.MovieImages,x => x.Categories);
            if(moviedelete == null)
            {
                return Response<NoContent>.Fail("Filim Bulunamadı",404);
            }
            _movieDal.Delete(moviedelete);
            await _unitOfWork.CommitAsync();
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<MovieIndex>>> GetAll()
        {
            var reponse = await _movieDal.GetAllAync(x => x.IsDeleted.Equals(false),x => x.Categories);
            var automapper = _mapper.Map<List<MovieIndex>>(reponse);
            return Response<List<MovieIndex>>.Success(automapper, 200);
        }

        public async Task<Response<MovieListDto>> GetIdMovieList(int id)
        {
            //var reponse = await _movieDal.GetIdListAsync(x => x.Id.Equals(id), x => x.MovieImages, x => x.Categories);
            var response = _context.Movies.Include(x => x.MovieImages).Include(x => x.Categories).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id.Equals(id));
            var automapper = _mapper.Map<MovieListDto>(response);
            return Response<MovieListDto>.Success(automapper,200);
        }
    }
}
