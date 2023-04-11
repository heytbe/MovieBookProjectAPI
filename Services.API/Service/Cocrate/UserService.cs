using AutoMapper;
using Entity.API.Dto.User;
using Entity.API.Entity;
using Microsoft.AspNetCore.Identity;
using Services.API.ResponseService;
using Services.API.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Cocrate
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _manager;
        private readonly IMapper _mapper;
        public UserService(UserManager<UserApp> manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Response<UserAppDto>> CreateUser(CreateUserDto createUserDto)
        {
            var user = new UserApp
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email
            };

            var response = await _manager.CreateAsync(user, createUserDto.Password);
            if(response.Succeeded)
            {
                var automapper = _mapper.Map<UserAppDto>(user);
                return Response<UserAppDto>.Success(automapper,200);
            }
            else
            {
                var error = response.Errors.Select(x => x.Description).ToList();
                return Response<UserAppDto>.Fail(new Error(error, true), 400);
            }
        }
    }
}
