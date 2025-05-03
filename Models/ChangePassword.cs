using System.ComponentModel.DataAnnotations;

namespace MVC_Project_13_April.Models
{
    public class ChangePassword
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string CurrentPassword { get; set; }


        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
