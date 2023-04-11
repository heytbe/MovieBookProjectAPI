using Data.API.Context;
using Data.API.Dal.MovieDal.Abstract;
using Data.API.Extensions;
using Data.API.Repositories.Cocrate;
using Entity.API.Dto.Movie;
using Entity.API.Entity.MovieEntity;

namespace Data.API.Dal.MovieDal.Cocrate
{
    public class MovieDal : GenericRepository<Movie>, IMovieDal
    {
        public MovieDal(AppDbContext context) : base(context)
        {
        }

        public async Task<Movie> CreateMovie(MovieCreateDto createDto,string dirpath)
        {
            Movie movie = new Movie();
            movie.MovieName = createDto.MovieName;
            movie.Adult = createDto.Adult;
            movie.MovieFragman = createDto.MovieFragman;
            movie.Imdb = createDto.Imdb;
            movie.OrjinalName = createDto.OrjinalName;
            movie.Overview = createDto.Overview;
            movie.ReleaseDate = createDto.ReleaseDate;
            movie.RunTime = createDto.RunTime;
            movie.TagLine = createDto.TagLine;
            if (createDto.Poster_Path != null) {
                var image = await Upload.ImageUpload(createDto.Poster_Path, dirpath, createDto.MovieName);
                movie.Poster_Path = image[0];
            }

            if(createDto.BackdropPath != null)
            {
                var image = await Upload.ImageUpload(createDto.BackdropPath, dirpath, createDto.MovieName);
                movie.BackdropPath = image[0];
            }

            foreach(var item in createDto.MovieImages)
            {
                var image = await Upload.ImageUpload(item, dirpath, createDto.MovieName);

                movie.MovieImages.Add(new MovieImages()
                {
                    ImageName = image[0],
                    ImageSize = image[1]
                });
            }

            if (createDto.Categories != null) {

                foreach (var item in createDto.Categories)
                {
                    movie.Categories.Add(new MovieCategory()
                    {
                        CategoryId = item
                    });
                }
            }

            return movie;
        }
    }
}
