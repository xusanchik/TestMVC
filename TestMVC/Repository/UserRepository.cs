using Microsoft.AspNetCore.Identity;
using TestMVC.Data;
using TestMVC.Dto_s;
using TestMVC.ExtensionFunctions;
using TestMVC.Interface;
using TestMVC.Models;
using TestMVC.Models.ERole;

namespace TestMVC.Repository;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserRepository(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<SignInResult> Login(LoginDto model)
    {
        if (!CheckEmail.IsValidEmail(model.Email))
            throw new Exception("Invalid email address format");
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) throw new Exception("Invalid email or password");
        var passResult = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!passResult)
            throw new Exception("Invalid email or password");

        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if (!result.Succeeded)
            throw new Exception("Invalid email or password");
        return result;
    }

    public async Task<RegisterDto> Register(RegisterDto model)
    {
        if (!CheckEmail.IsValidEmail(model.Email))
            throw new Exception("Invalid email address format");
        var existUser = await _userManager.FindByEmailAsync(model.Email);
        if (existUser != null)
            throw new Exception("Email already taken ");
        var user = new User { UserName = model.Name, Email = model.Email };
        user.Password = model.Password;
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
                if(model.Role == ERole.Admin)
                {
                    await _userManager.AddToRoleAsync(user, "ADMIN");
                    await _context.SaveChangesAsync();
                }
                else if (model.Role == ERole.User)
                {
                    await _userManager.AddToRoleAsync(user, "USER");
                    await _context.SaveChangesAsync();
                }
                else
                {
                await _userManager.AddToRoleAsync(user, "MANAGER");
                await _context.SaveChangesAsync();
            }


        }

        foreach (var error in result.Errors)
            throw new Exception($"{error.Description}");

        return model ?? new RegisterDto();
    }
}
