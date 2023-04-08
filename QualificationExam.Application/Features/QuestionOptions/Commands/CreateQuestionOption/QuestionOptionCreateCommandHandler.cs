namespace QualificationExam.Application.Features.QuestionOptions.Commands.CreateQuestionOption
{
    public class QuestionOptionCreateCommandHandler : IRequestHandler<QuestionOptionCreateCommand, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IQuestionOptionWriteRepository _questionOptionWriteRepository;

        public QuestionOptionCreateCommandHandler(
            IMapper mapper,
            IQuestionReadRepository questionReadRepository, 
            IQuestionOptionWriteRepository questionOptionWriteRepository)
        {
            _mapper = mapper;
            _questionReadRepository = questionReadRepository;
            _questionOptionWriteRepository = questionOptionWriteRepository;
        }

        public async Task<ServiceResponse> Handle(QuestionOptionCreateCommand request, CancellationToken cancellationToken)
        {
            var questionOptionResult = _mapper.Map<QuestionOption>(request.CreateQuestionOptionRequest);
            var questionResult = await GetQuestionAsync(questionOptionResult.questionId);
            if (questionResult is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuestionNotFound);
            }
            var createdQuestinOption = await _questionOptionWriteRepository.AddAsync(questionOptionResult);
           

            await _questionOptionWriteRepository.SaveAsync();
            return createdQuestinOption! ?
                ServiceResponse.CreateSuccess(ResponseMessage.AddedSuccessfully) :
                ServiceResponse.CreateError(ResponseMessage.AddedFailed);
        }
        #region  Private Methods

        private async Task<Question> GetQuestionAsync(string questionId) =>
             await _questionReadRepository
            .GetAsync(x => x.Id == questionId,includes:x=>x.QuestionOptions);
        #endregion
    }
}
