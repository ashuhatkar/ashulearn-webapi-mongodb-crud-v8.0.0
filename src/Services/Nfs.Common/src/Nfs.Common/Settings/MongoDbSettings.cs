using Nfs.Common.Configuration;

namespace Nfs.Common.Settings
{
    /// <summary>
    /// MongoDB settings
    /// </summary>
    public partial class MongoDbSettings : ISettings
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}