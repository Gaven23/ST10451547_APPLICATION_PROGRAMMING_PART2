using System.ComponentModel.DataAnnotations;

namespace ST10451547_APPLICATION_PROGRAMMING_PART2
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
