using Hydra.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.WebApi.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BasicApiController : ControllerBase
    {

    }
}