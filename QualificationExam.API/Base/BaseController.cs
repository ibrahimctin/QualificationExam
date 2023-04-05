using Microsoft.AspNetCore.Mvc;
using QualificationExam.Application.Shared.Responses;
using System.Net;

namespace QualificationExam.API.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {

        protected IActionResult Error(ServiceResponse response)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

    }
}
