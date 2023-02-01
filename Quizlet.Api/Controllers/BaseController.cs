using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Quizlet.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
