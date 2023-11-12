namespace seikatsu.Models
{
    public class UsersSettings : IUsersSettings
    {
        public string SeikatsuCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;

    }
}
