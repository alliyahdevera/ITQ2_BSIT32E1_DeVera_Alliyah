namespace ITQ2_BSIT32E1_DeVera_Alliyah.Models.UserGroups
{
    public class EditUserGroupRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> UserIDs { get; set; } = new();
    }
}
