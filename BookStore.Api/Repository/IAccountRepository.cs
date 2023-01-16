using BookStore.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Api.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        public Task<string> LoginAsync(SignInModel signInModel);
    }
}
