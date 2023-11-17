using MongoDB.Driver;
using seikatsu.Models;

namespace seikatsu.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly IMongoCollection<Properties> _properties;

        public PropertiesService(IPropertiesSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _properties = database.GetCollection<Properties>(settings.SeikatsuCollectionName);
        }

        public Properties Create(Properties property)
        {
            _properties.InsertOne(property);
            return property;
        }

        public List<Properties> Get()
        {
            return _properties.Find(property => true).ToList();
        }

        public Properties Get(string id)
        {
            return _properties.Find(property => property.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _properties.DeleteOne(property => property.Id == id);
        }

        public void Update(string id, Properties property)
        {
            _properties.ReplaceOne(property => property.Id == id, property);
        }

        public bool CheckPropertyAlreadyPresent(string SKU)
        {
            var PropertyExists = _properties.Find(property=>property.SKU == SKU).FirstOrDefault();

            if (PropertyExists != null)
            {
                return true;
            }

            return false;
        }
    }
}
