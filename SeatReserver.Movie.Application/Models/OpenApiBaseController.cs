using Microsoft.AspNetCore.Components;
using SeatReserver.Movie.Application.Models;

namespace ProjectManager.WebFramework.Api
{

    public class InternalApiController : BaseController
    {
    }


    [Route("api/v{version:apiVersion}/[controller]")]
    public class OpenApiController : BaseController
    {
    }   
}
