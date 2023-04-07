namespace QualificationExam.Application.Features.Quizzes.Commands.DeleteQuiz
{
    public class QuizDeleteCommandHandler : IRequestHandler<QuizDeleteCommand, ServiceResponse>
    {
        private readonly IQuizWriteRepository _quizWriteRepository;
        public QuizDeleteCommandHandler(IQuizWriteRepository quizWriteRepository)
        {
            _quizWriteRepository = quizWriteRepository;
        }
        public async Task<ServiceResponse> Handle(QuizDeleteCommand request, CancellationToken cancellationToken)
        {
  
                if (request.QuizId is null)
                {
                    throw  new ApplicationLayerException(ResponseMessage.QuizNotFound);
                } 
                var deletedQuiz =  await _quizWriteRepository.RemoveAsync(request.QuizId);
                await _quizWriteRepository.SaveAsync();
                return deletedQuiz!?
                ServiceResponse.CreateSuccess(ResponseMessage.DeletedSuccessfully) :
                ServiceResponse.CreateSuccess(ResponseMessage.InvalidRequest);
        }
    }
}