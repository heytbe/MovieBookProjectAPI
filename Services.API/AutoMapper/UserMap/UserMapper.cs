using AutoMapper;
using Entity.API.Dto.User;
using Entity.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API.AutoMapper.UserMap
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<UserAppDto,UserApp>().ReverseMap();
        }
    }
}
