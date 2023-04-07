namespace QualificationExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("CreateQuestion")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionRequest request)
        {
            var command = new QuestionCreateCommand { CreateQuestionRequest = request };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var query = new GetQuestionDetailQuery { QuestionId = id };
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

        [HttpPost("UpdateQuestion")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionRequest request)
        {
            var command = new QuestionUpdateCommand { UpdateQuestionRequest = request };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }

        [HttpDelete("DeleteQuestion")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteQuestion(string Id)
        {
            var command = new QuestionDeleteCommand { QuestionId = Id };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }

    }
}
