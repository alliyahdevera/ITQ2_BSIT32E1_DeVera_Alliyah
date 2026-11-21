namespace ITQ2_BSIT32E1_DeVera_Alliyah.Data
{
    public class DataStore
    {
        public static readonly List<User> Users = new()
        {
            new User { Id = 1,  Name = "Alliyah De Vera",   Email = "alliyahdevera@gmail.com" },
            new User { Id = 2,  Name = "Juan Dela Cruz",    Email = "juan.delacruz@example.com" },
            new User { Id = 3,  Name = "Maria Santos",      Email = "maria.santos@example.com" },
            new User { Id = 4,  Name = "Jose Reyes",        Email = "jose.reyes@example.com" },
            new User { Id = 5,  Name = "Ana Garcia",        Email = "ana.garcia@example.com" },
            new User { Id = 6,  Name = "Miguel Ramos",      Email = "miguel.ramos@example.com" },
            new User { Id = 7,  Name = "Sofia Mendoza",     Email = "sofia.mendoza@example.com" },
            new User { Id = 8,  Name = "Carlo Bautista",    Email = "carlo.bautista@example.com" },
            new User { Id = 9,  Name = "Isabel Torres",     Email = "isabel.torres@example.com" },
            new User { Id = 10, Name = "Paolo Villanueva",  Email = "paolo.villanueva@example.com" }
        };
        public static readonly List<UserGroups> Groups = new()
        {
            new UserGroups { Id = 1, Name = "Admins",   Users = new List<User> { Users[0] } },
            new UserGroups { Id = 2, Name = "Students", Users = new List<User> { Users[1], Users[2], Users[3], Users[4], Users[5] } },
            new UserGroups { Id = 3, Name = "Staff",    Users = new List<User> { Users[6], Users[7], Users[8], Users[9] } }
        };

        public static int NextUserId = 11;
        public static int NextGroupId = 4;
    }
}