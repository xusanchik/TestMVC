using System.ComponentModel.DataAnnotations;

namespace TestMVC.Dto_s
{
    public class EmailSenderDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Email { get; set; }
        public string Massage { get; set; }
    }
}
