namespace seikatsu.Models
{
    public interface IPropertiesSettings
    {   
        string SeikatsuCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
