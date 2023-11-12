namespace seikatsu.Models
{
    public interface IUsersSettings
    {
        string SeikatsuCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }   

    }
}
