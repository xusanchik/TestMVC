using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using TestMVC.Models.ERole;

namespace TestMVC.Models;

public class Task
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    public string Description { get; set; }
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    public  EStatus EStatus{ get; set; }

}
