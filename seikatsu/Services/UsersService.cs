using MongoDB.Driver;

using seikatsu.Models;

namespace seikatsu.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<Users> _users;

        public UsersService(IUsersSettings settings,IMongoClient mongoClient ) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<Users>(settings.SeikatsuCollectionName);
        }

        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<Users> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public Users Get(string username)
        {
            return _users.Find(user => user.Username == username).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void Update(string username, Users user)
        {
            _users.ReplaceOne(user => user.Username == username, user);
        }

        public bool CheckUserAlreadyPresent(string userName, string email)
        {
            var UserExists = _users.Find(user=>user.Username==userName).FirstOrDefault();
            var EmailExists = _users.Find(user=>user.Email==email).FirstOrDefault();
            if (UserExists!=null && EmailExists!=null)
                return true;
            return false;
        }
    }
}
