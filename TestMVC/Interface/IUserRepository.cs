using Microsoft.AspNetCore.Identity;
using TestMVC.Dto_s;

namespace TestMVC.Interface;
public interface IUserRepository
{
    Task<SignInResult> Login(LoginDto model);
    Task<RegisterDto> Register(RegisterDto model);

}
