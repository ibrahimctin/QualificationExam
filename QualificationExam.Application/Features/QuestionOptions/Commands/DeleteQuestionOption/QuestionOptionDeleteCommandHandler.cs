namespace QualificationExam.Application.Features.QuestionOptions.Commands.DeleteQuestionOption
{
    public class QuestionOptionDeleteCommandHandler : IRequestHandler<QuestionOptionDeleteCommand, ServiceResponse>
    {
        private readonly IQuestionOptionWriteRepository _questionOptionWriteRepository;

        public QuestionOptionDeleteCommandHandler(

            IQuestionOptionWriteRepository questionOptionWriteRepository)
        {
        
            _questionOptionWriteRepository = questionOptionWriteRepository;
        }

        public async Task<ServiceResponse> Handle(QuestionOptionDeleteCommand request, CancellationToken cancellationToken)
        {
            if (request.QuestionOptionId is null)
            {
                throw new ApplicationLayerException(ResponseMessage.QuestionOptionNotFount);
            }
            var deletedQuestionOption = await _questionOptionWriteRepository.RemoveAsync(request.QuestionOptionId);
            await _questionOptionWriteRepository.SaveAsync();
            return deletedQuestionOption! ?
            ServiceResponse.CreateSuccess(ResponseMessage.DeletedSuccessfully) :
            ServiceResponse.CreateSuccess(ResponseMessage.InvalidRequest);
        }
    }
}
