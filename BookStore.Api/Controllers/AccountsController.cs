using BookStore.Api.Models;
using BookStore.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync([FromBody]SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return BadRequest();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync([FromBody]SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            
            return Ok(result);
        }
    }
}
