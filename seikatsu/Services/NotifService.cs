using MongoDB.Driver;
using seikatsu.Models;

namespace seikatsu.Services
{
    public class NotifService : INotifService
    {
        private readonly IMongoCollection<Notif> _notif;

        public NotifService(INotifSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _notif = database.GetCollection<Notif>(settings.SeikatsuCollectionName);
        }

        public Notif Create(Notif notif)
        {
            _notif.InsertOne(notif);
            return notif;
        }

        public List<Notif> Get()
        {
            return _notif.Find(property => true).ToList();
        }

        public Notif Get(string receiver)
        {
            return _notif.Find(notif => notif.ReceiverName == receiver).FirstOrDefault();
        }


        public void Remove(string id)
        {
            _notif.DeleteOne(notif => notif.Id == id);
        }

        public void Update(string id, Notif notif)
        {
            _notif.ReplaceOne(notif => notif.Id == id, notif);
        }
    }
}
