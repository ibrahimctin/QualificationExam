namespace QualificationExam.Application.Features.Questions.Commands.CreateQuestion
{
    public class QuestionCreateCommandHandler : IRequestHandler<QuestionCreateCommand, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuizReadRepository _quizReadRepository;

        public QuestionCreateCommandHandler(
            IMapper mapper,
            IQuestionWriteRepository questionWriteRepository,
            IQuizReadRepository quizReadRepository)
        {
            _mapper = mapper;
            _questionWriteRepository = questionWriteRepository;
            _quizReadRepository = quizReadRepository;
        }

        public async Task<ServiceResponse> Handle(QuestionCreateCommand request, CancellationToken cancellationToken)
        {
            var questionResult = _mapper.Map<Question>(request.CreateQuestionRequest);
            var quizResult = await GetQuizAsync(questionResult.quizId);
            if (quizResult is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuizNotFound);
            }
            var createdQuestin = await _questionWriteRepository.AddAsync(questionResult);
            if (quizResult.Questions.Count >= quizResult.QuestionCount)
            {
                throw new ApplicationLayerException(ResponseMessage.InvalidRequest);
            };  

          
            await _questionWriteRepository.SaveAsync();
            return createdQuestin! ?
                ServiceResponse.CreateSuccess(ResponseMessage.AddedSuccessfully):
                ServiceResponse.CreateError(ResponseMessage.AddedFailed);
        }


        #region  Private Methods

        private async Task<Quiz> GetQuizAsync(string quizId) =>
             await _quizReadRepository
            .GetAsync(x=>x.Id==quizId,includes:x=>x.Questions);
        #endregion
    }
}
