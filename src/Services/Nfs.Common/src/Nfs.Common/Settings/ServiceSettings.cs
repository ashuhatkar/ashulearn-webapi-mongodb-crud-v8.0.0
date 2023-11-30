using Nfs.Common.Configuration;

namespace Nfs.Common.Settings
{
    public partial class ServiceSettings : ISettings
    {
        public string ServiceName { get; init; }
    }
}