namespace ITQ2_BSIT32E1_DeVera_Alliyah.Models.Users
{
    public class GetUsersResponse
    {
        public List<GetUserDTO> Users { get; set; } = new List<GetUserDTO>();
    }   
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
