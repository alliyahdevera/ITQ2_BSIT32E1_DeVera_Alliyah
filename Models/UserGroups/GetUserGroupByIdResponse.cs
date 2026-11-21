using ITQ2_BSIT32E1_DeVera_Alliyah.Data;
namespace ITQ2_BSIT32E1_DeVera_Alliyah.Models.UserGroups
{
    public class GetUserGroupByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserGroupMemberDTO> Users { get; set; } = new();
    }
}