namespace QualificationExam.Application.Features.Questions.Commands.DeleteQuestion
{
    public class QuestionDeleteCommandHandler : IRequestHandler<QuestionDeleteCommand, ServiceResponse>
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;

        public QuestionDeleteCommandHandler(IQuestionWriteRepository questionWriteRepository)
        {
            _questionWriteRepository = questionWriteRepository;
        }

        public async Task<ServiceResponse> Handle(QuestionDeleteCommand request, CancellationToken cancellationToken)
        {
            if (request.QuestionId is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuestionNotFound);
            }
            var deletedQuestion = await _questionWriteRepository.RemoveAsync(request.QuestionId);
            await _questionWriteRepository.SaveAsync();
            return deletedQuestion!?
            ServiceResponse.CreateSuccess(ResponseMessage.DeletedSuccessfully) :
            ServiceResponse.CreateSuccess(ResponseMessage.InvalidRequest);
        }
    }
}
