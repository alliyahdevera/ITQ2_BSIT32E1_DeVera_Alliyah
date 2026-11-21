using System.ComponentModel.DataAnnotations;

namespace ITQ2_BSIT32E1_DeVera_Alliyah.Models.UserGroups
{
    public class CreateUserGroupRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<int> UserIDs { get; set; } = new();
    }
}
