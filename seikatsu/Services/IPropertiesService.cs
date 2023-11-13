using seikatsu.Models;

namespace seikatsu.Services
{
    public interface IPropertiesService
    {
        List<Properties> Get();
        Properties Get(string id);

        Properties Create(Properties property);

        void Update(string id, Properties property);

        void Remove(string id);

    }
}
