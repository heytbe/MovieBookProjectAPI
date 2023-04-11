using Entity.API.Dto.Token;
using Entity.API.Dto.User;
using Services.API.ResponseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Abstract
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateToken(LoginDto loginDto);
    }
}
