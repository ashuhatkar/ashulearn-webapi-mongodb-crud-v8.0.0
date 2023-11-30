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