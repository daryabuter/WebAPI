using Project.Models;

namespace Project.Data.Interfaces
{
    public interface IAuthenticationService
    {
        Users Authenticate(string username, string password);
    }
}

