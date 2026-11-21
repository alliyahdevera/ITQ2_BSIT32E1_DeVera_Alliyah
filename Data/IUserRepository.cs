namespace ITQ2_BSIT32E1_DeVera_Alliyah.Data
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User CreateUser(string name, string email);
        bool UpdateUser(int id, string name, string email);
        bool DeleteUser(int id);

        List<UserGroups> GetAllGroups();
        UserGroups? GetGroupById(int id);
        List<int> FindMissingUserIds(List<int> userIds);
        UserGroups CreateGroup(string name, List<int> userIds);
        bool UpdateGroup(int id, string name, List<int> userIds);
        bool DeleteGroup(int id);
    }
}