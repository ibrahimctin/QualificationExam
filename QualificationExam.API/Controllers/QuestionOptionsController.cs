namespace QualificationExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionOptionsController : BaseController
    {
        private readonly IMediator _mediator;

        public QuestionOptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetQuestionOptionDetailQuery { QuestionOptionId = id };
            var result = await _mediator.Send(query);

            if (result is ValidationErrorResponse)
            {
                return BadRequest(result);
            }

            if (result.Payload == null)
            {
                return NotFound();
            }

            return !result.Success
                ? Error(result)
                : Ok(result);
        }



        [HttpPost("CreateQuestionOption")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateQuestionOption([FromBody] CreateQuestionOptionRequest request)
        {
            var command = new QuestionOptionCreateCommand { CreateQuestionOptionRequest = request };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }


        [HttpPost("UpdateQuestionOption")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionOptionRequest request)
        {
            var command = new QuestionOptionUpdateCommand { UpdateQuestionOptionRequest = request };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }

        [HttpDelete("DeleteQuestionOption")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteQuestionOption(string Id)
        {
            var command = new QuestionOptionDeleteCommand { QuestionOptionId = Id };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }
    }
}
