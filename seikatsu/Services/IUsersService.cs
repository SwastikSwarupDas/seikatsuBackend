using seikatsu.Models;

namespace seikatsu.Services
{
    public interface IUsersService
    {
        List<Users> Get();
        Users Get(string id);

        Users Create(Users user);

        void Update(string id, Users user);

        void Remove(string id);      

    }
}
