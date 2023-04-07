namespace QualificationExam.Application.Features.Quizzes.Commands.CreateQuiz
{
    public class QuizCreateCommandHandler : IRequestHandler<QuizCreateCommand, ServiceResponse>
    {
        private readonly IQuizWriteRepository _quizWriteRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public QuizCreateCommandHandler(
            IQuizWriteRepository quizWriteRepository,
            IMapper mapper, 
            ICurrentUserService currentUserService)
        {
            _quizWriteRepository = quizWriteRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResponse> Handle(QuizCreateCommand request, CancellationToken cancellationToken)
        {
            var quizResult = _mapper.Map<Quiz>(request.CreateQuizRequest);
            quizResult.UserId = await _currentUserService.GetCurrentUserIdAsync();
            request.CreateQuizRequest.UserId = quizResult.UserId; 
            var createdQuiz = await _quizWriteRepository.AddAsync(quizResult);
            await _quizWriteRepository.SaveAsync();
            return createdQuiz!?
                ServiceResponse.CreateSuccess(ResponseMessage.AddedSuccessfully):
                ServiceResponse.CreateError(ResponseMessage.AddedFailed);
        }
    }
}