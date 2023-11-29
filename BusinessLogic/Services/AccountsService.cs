using BusinessLogic.ApiModels.Accounts;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BusinessLogic.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtService jwtService;
        private readonly SignInManager<User> signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> userManager;

        public AccountsService(IJwtService jwtService ,SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.jwtService = jwtService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null|| !await userManager.CheckPasswordAsync(user,model.Password)) { throw new HttpException("Invalid login or password!", HttpStatusCode.BadRequest); }
          await signInManager.SignInAsync(user,true);
            return new LoginResponse
                {
                Token =jwtService.CreateToken(jwtService.GetClaims(user))};
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterRequest model)
        {
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                Birthdate = model.Birthdate
            };
          var result= await userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded) 
            { 
                var errorMessages = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new HttpException(errorMessages,HttpStatusCode.BadRequest);
            }
        }
    }
}
