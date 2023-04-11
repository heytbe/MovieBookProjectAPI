using Entity.API.Dto.Token;
using Microsoft.Extensions.DependencyInjection;
using Services.API.Service.Abstract;
using Services.API.Service.Cocrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Extensions
{
    public static class ServiceLayer
    {
        public static IServiceCollection ServiceLayerLoadExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieService, MovieService>();
            return services;
        }
    }
}
