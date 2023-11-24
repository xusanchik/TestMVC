using System.ComponentModel.DataAnnotations;
using TestMVC.Models.ERole;

namespace TestMVC.Dto_s;
public class RegisterDto
{
    public string Name { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword {  get; set; }
    public ERole Role { get; set; }   
}
