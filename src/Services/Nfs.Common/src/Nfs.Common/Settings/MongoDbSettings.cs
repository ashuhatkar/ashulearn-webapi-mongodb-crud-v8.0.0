/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : Nfs.Common.Configuration
  --* Description     : Settings
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
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