using Project.Models;
using Project.Data.Interfaces;

namespace Project.Data.Services
{
    public class InMemoryAuthenticationService : IAuthenticationService
    {
        private readonly List<Users> _users;

        public InMemoryAuthenticationService()
        {
            _users = new List<Users>
            {
                new Users { UserID = 1, UserName = "admin", PasswordHash = "admin", RoleName = RoleName.Admin },
                new Users { UserID = 2, UserName = "moderator", PasswordHash = "moderator", RoleName = RoleName.Moderator },
                new Users { UserID = 3, UserName = "user", PasswordHash = "user", RoleName = RoleName.User }
            };
        }

        public Users Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(u => u.UserName == username && u.PasswordHash == password);
        }
    }
}
