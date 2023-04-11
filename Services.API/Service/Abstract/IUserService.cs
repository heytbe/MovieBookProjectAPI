using Entity.API.Dto.User;
using Services.API.ResponseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Abstract
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUser(CreateUserDto createUserDto);
    }
}
