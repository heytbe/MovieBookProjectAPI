using Data.API.Context;
using Data.API.Dal.CategoryDal.Abstract;
using Data.API.Dal.CategoryDal.Cocrate;
using Data.API.Dal.MovieDal.Abstract;
using Data.API.Dal.MovieDal.Cocrate;
using Data.API.Repositories.Abstract;
using Data.API.Repositories.Cocrate;
using Data.API.UnitOfWorkRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Extensions
{
    public static class DataLayer
    {
        public static IServiceCollection DataLayerLoadExtensions(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Mssql"]);
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IMovieDal, MovieDal>();
            return services;
        }
    }
}
