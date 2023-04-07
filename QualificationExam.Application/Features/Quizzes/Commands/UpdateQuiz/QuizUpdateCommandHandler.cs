namespace QualificationExam.Application.Features.Quizzes.Commands.UpdateQuiz
{
    public class QuizUpdateCommandHandler : IRequestHandler<QuizUpdateCommand, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuizWriteRepository _quizWriteRepository;
        private readonly IQuizReadRepository _quizReadRepository;

        public QuizUpdateCommandHandler(
            IMapper mapper, 
            IQuizWriteRepository quizWriteRepository, 
            IQuizReadRepository quizReadRepository)
        {
            _mapper = mapper;
            _quizWriteRepository = quizWriteRepository;
            _quizReadRepository = quizReadRepository;
        }

        public async Task<ServiceResponse> Handle(QuizUpdateCommand request, CancellationToken cancellationToken)
        {
            var quizResult = await _quizReadRepository.GetByIdAsync(request.UpdateQuizRequest.Id);
            if (quizResult is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuizNotFound);
            }
            var quizPayload = _mapper.Map(request.UpdateQuizRequest,quizResult);
            var updatedQuiz = _quizWriteRepository.Update(quizPayload);
            await _quizWriteRepository.SaveAsync();
            return updatedQuiz!
                ? ServiceResponse.CreateSuccess(ResponseMessage.UpdatedSuccessfully)
                : ServiceResponse.CreateError(ResponseMessage.InvalidRequest);
        }
    }
}
