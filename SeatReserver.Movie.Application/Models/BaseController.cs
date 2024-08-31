using Microsoft.AspNetCore.Mvc;
using SeatReserver.Movie.Application.Filters;

namespace SeatReserver.Movie.Application.Models
{
    [ApiController]
    [ApiResultFilter]
    [Route("/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }

    [ApiController]
    [ApiResultFilter]
    [Route("/v{version:apiVersion}/[controller]")]
    public class BaseMvcController : Controller
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}
