using System.ComponentModel.DataAnnotations;

namespace MVC_Project_13_April.Models
{
    public class ForgetPassword
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
