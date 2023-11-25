using Microsoft.AspNetCore.Identity;
using TestMVC.Models.ERole;

namespace TestMVC.Models.ERole
{
    public class User:IdentityUser
    {
        public List<Task> Tasks { get; set; }
    }
}
