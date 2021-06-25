using RecipeExpress.Data.Interfaces;

namespace RecipeExpress.Data.Config
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
