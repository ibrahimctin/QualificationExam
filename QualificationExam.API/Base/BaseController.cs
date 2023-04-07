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
