using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
