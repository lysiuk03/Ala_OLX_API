﻿using BusinessLogic.ApiModels.Accounts;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ala_OLX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
           var response=await accountsService.LoginAsync(model);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
           await accountsService.RegisterAsync(model);
            return Ok();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
           await accountsService.LogoutAsync();
            return Ok();
        }

    }
}
