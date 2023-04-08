namespace QualificationExam.Application.Features.QuestionOptions.Commands.UpdateQuestionOption
{
    public class QuestionOptionUpdateCommandHandler : IRequestHandler<QuestionOptionUpdateCommand, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionOptionReadRepository _questionOptionReadRepository;
        private readonly IQuestionOptionWriteRepository _questionOptionWriteRepository;

        public QuestionOptionUpdateCommandHandler(
            IMapper mapper, 
            IQuestionOptionReadRepository questionOptionReadRepository,
            IQuestionOptionWriteRepository questionOptionWriteRepository)
        {
            _mapper = mapper;
            _questionOptionReadRepository = questionOptionReadRepository;
            _questionOptionWriteRepository = questionOptionWriteRepository;
        }

        public async Task<ServiceResponse> Handle(QuestionOptionUpdateCommand request, CancellationToken cancellationToken)
        {

            var questionOptionResult = await _questionOptionReadRepository.GetByIdAsync(request.UpdateQuestionOptionRequest.questionId);
            if (questionOptionResult is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuestionOptionNotFount);
            }
            var questionOptionPayload = _mapper.Map(request.UpdateQuestionOptionRequest, questionOptionResult);
            var updatedQuestionOption = _questionOptionWriteRepository.Update(questionOptionPayload);
            await _questionOptionWriteRepository.SaveAsync();
            return updatedQuestionOption!
                ? ServiceResponse.CreateSuccess(ResponseMessage.UpdatedSuccessfully)
                : ServiceResponse.CreateError(ResponseMessage.InvalidRequest);
        }
    }
}
