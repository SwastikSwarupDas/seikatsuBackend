using seikatsu.Models;

namespace seikatsu.Services
{
    public interface IUsersService
    {
        List<Users> Get();
        Users Get(string username);

        Users Create(Users user);

        void Update(string username, Users user);

        void Remove(string id);

        bool CheckUserAlreadyPresent(string userName, string email);

    }
}
