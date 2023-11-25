using System.ComponentModel.DataAnnotations;

namespace TestMVC.Dto_s
{
    public class AdminDto
    {
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
