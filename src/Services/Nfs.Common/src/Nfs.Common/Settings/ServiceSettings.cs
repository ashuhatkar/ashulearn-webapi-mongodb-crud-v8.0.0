/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : Nfs.Common.Configuration
  --* Description     : Service settings
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using Nfs.Common.Configuration;

namespace Nfs.Common.Settings
{
    /// <summary>
    /// Represents a service settings
    /// </summary>
    public partial class ServiceSettings : ISettings
    {
        /// <summary>
        /// Gets or sets the service name
        /// </summary>
        public string ServiceName { get; init; }
    }
}