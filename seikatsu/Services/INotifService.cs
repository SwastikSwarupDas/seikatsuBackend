using seikatsu.Models;

namespace seikatsu.Services
{
    public interface INotifService
    {
        List<Notif> Get();
        Notif Get(string receiver);

        Notif Create(Notif notif);

        void Update(string id, Notif notif);

        void Remove(string id);

    }
}
