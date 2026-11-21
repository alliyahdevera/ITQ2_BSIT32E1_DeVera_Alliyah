namespace ITQ2_BSIT32E1_DeVera_Alliyah.Data
{
    public class UserRepository : IUserRepository
    {

        public List<User> GetAllUsers()
        {
            return DataStore.Users;
        }

        // READ (one) - returns null if not found
        public User? GetUserById(int id)
        {
            return DataStore.Users.FirstOrDefault(u => u.Id == id);
        }

        // CREATE - generates the id and returns the new user
        public User CreateUser(string name, string email)
        {
            var user = new User
            {
                Id = DataStore.NextUserId++,
                Name = name,
                Email = email
            };

            DataStore.Users.Add(user);
            return user;
        }

        // UPDATE - returns false if the user does not exist
        public bool UpdateUser(int id, string name, string email)
        {
            var user = GetUserById(id);
            if (user == null)
                return false;

            user.Name = name;
            user.Email = email;
            return true;
        }

        // DELETE - returns false if the user does not exist
        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return false;

            DataStore.Users.Remove(user);

            // also take the user out of any group they belong to
            foreach (var group in DataStore.Groups)
                group.Users.RemoveAll(u => u.Id == id);

            return true;
        }

        public List<UserGroups> GetAllGroups()
        {
            return DataStore.Groups;
        }

        // READ (one) - returns null if not found
        public UserGroups? GetGroupById(int id)
        {
            return DataStore.Groups.FirstOrDefault(g => g.Id == id);
        }

        // Returns the ids that do not belong to any existing user
        public List<int> FindMissingUserIds(List<int> userIds)
        {
            return userIds
                .Distinct()
                .Where(id => !DataStore.Users.Any(u => u.Id == id))
                .ToList();
        }

        // CREATE - generates the id and returns the new group
        public UserGroups CreateGroup(string name, List<int> userIds)
        {
            var group = new UserGroups
            {
                Id = DataStore.NextGroupId++,
                Name = name,
                Users = DataStore.Users.Where(u => userIds.Contains(u.Id)).ToList()
            };

            DataStore.Groups.Add(group);
            return group;
        }

        // UPDATE - returns false if the group does not exist
        public bool UpdateGroup(int id, string name, List<int> userIds)
        {
            var group = GetGroupById(id);
            if (group == null)
                return false;

            group.Name = name;
            group.Users = DataStore.Users.Where(u => userIds.Contains(u.Id)).ToList();
            return true;
        }

        // DELETE - returns false if the group does not exist
        public bool DeleteGroup(int id)
        {
            var group = GetGroupById(id);
            if (group == null)
                return false;

            DataStore.Groups.Remove(group);
            return true;
        }
    }
}