using Data.API.Repositories.Abstract;
using Data.API.UnitOfWorkRepo;
using Entity.API.Dto.Token;
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
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _manager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _repository;
        public AuthenticationService(ITokenService tokenService,UserManager<UserApp> userManager,IUnitOfWork unitOfWork,IGenericRepository<UserRefreshToken> repository)
        {
            _manager = userManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Response<TokenDto>> CreateToken(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _manager.FindByEmailAsync(loginDto.Email);
            if(user == null)
            {
                return Response<TokenDto>.Fail("Email or Password is wrong", 400);
            }

            if((await _manager.CheckPasswordAsync(user,loginDto.Password)) == false)
            {
                return Response<TokenDto>.Fail("Email or Password is wrong", 400);
            }

            var userToken = _tokenService.CreateToken(user);
            var refreshToken = await _repository.GetIdListAsync(x => x.UserId == user.Id);
            if(refreshToken == null)
            {
                await _repository.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    RefreshToken = userToken.RefreshToken,
                    RefreshTokenExpiration = userToken.RefreshTokenExpiration
                });
            }
            else
            {
                refreshToken.RefreshToken = userToken.RefreshToken;
                refreshToken.RefreshTokenExpiration = userToken.RefreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();

            return Response<TokenDto>.Success(userToken, 200);

        }
    }
}
