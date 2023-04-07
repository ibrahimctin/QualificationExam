namespace QualificationExam.Application.Features.Questions.Commands.UpdateQuestion
{
    public class QuestionUpdateCommandHandler : IRequestHandler<QuestionUpdateCommand, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;

        public QuestionUpdateCommandHandler(
            IMapper mapper,
            IQuestionWriteRepository questionWriteRepository,
            IQuestionReadRepository questionReadRepository)
        {
            _mapper = mapper;
            _questionWriteRepository = questionWriteRepository;
            _questionReadRepository = questionReadRepository;
        }

        public async Task<ServiceResponse> Handle(QuestionUpdateCommand request, CancellationToken cancellationToken)
        {
            var questionResult = await _questionReadRepository.GetByIdAsync(request.UpdateQuestionRequest.Id);
            if (questionResult is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuizNotFound);
            }
            var questionPayload = _mapper.Map(request.UpdateQuestionRequest, questionResult);
            var updatedQuestion = _questionWriteRepository.Update(questionPayload);
            await _questionWriteRepository.SaveAsync();
            return updatedQuestion!
                ? ServiceResponse.CreateSuccess(ResponseMessage.UpdatedSuccessfully)
                : ServiceResponse.CreateError(ResponseMessage.InvalidRequest);
        }
    }
}
