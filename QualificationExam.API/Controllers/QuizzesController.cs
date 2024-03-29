﻿namespace QualificationExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : BaseController
    {
        private readonly IMediator _mediator;

        public QuizzesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateQuiz")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizRequest request)
        {
            var command = new QuizCreateCommand { CreateQuizRequest = request };
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
            var query = new GetQuizDetailQuery { QuizId = id};
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

        [HttpPost("UpdateQuiz")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateQuiz([FromBody] UpdateQuizRequest request)
        {
            var command = new QuizUpdateCommand { UpdateQuizRequest = request };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }

        [HttpDelete("DeleteQuiz")]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteQuiz(string Id)
        {
            var command = new QuizDeleteCommand { QuizId = Id };
            var result = await _mediator.Send(command);
            return !result.Success
                ? Error(result)
                : Ok(result);
        }
    }
}
