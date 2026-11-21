namespace ITQ2_BSIT32E1_DeVera_Alliyah.Data
{
    public class UserGroups
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new();
    }

    public class UserGroupMemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}