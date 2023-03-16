using Microsoft.AspNetCore.Mvc;
using PTP.Gateway.Business.Models;
using PTP.Gateway.Common.Extensions;
using PTP.Gateway.Services.Interfaces;

namespace PTP.Gateway.API.Controllers
{
    [ApiController]
    [Route("v1/account")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;   

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Login and receive JWT token
        /// </summary>
        /// <returns><see cref="LoginResponse"/></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Ok(await _accountService.LoginAsync(request));
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register()
        {
            return this.Created();
        }
    }
}
