using System.ComponentModel.DataAnnotations;

namespace ITQ2_BSIT32E1_DeVera_Alliyah.Models.Users
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
