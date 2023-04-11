using Entity.API.Dto.Token;
using Entity.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.Service.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
    }
}
