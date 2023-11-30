/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : Microsoft.AspNetCore.Mvc
  --* Description     : Base api controller
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using Microsoft.AspNetCore.Mvc;

namespace Nfs.Common
{
    /// <summary>
    /// Base api controller
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public abstract partial class BaseApiController : ControllerBase
    {
    }
}