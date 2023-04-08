namespace QualificationExam.Application.Features.QuestionOptions.Queries
{
    public class GetQuestionOptionDetailQueryHandler : IRequestHandler<GetQuestionOptionDetailQuery, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionOptionReadRepository _questionOptionReadRepository;

        public GetQuestionOptionDetailQueryHandler(
            IMapper mapper,
            IQuestionOptionReadRepository questionOptionReadRepository)
        {
            _mapper = mapper;
            _questionOptionReadRepository = questionOptionReadRepository;
        }

        public async Task<ServiceResponse> Handle(GetQuestionOptionDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _questionOptionReadRepository.GetAsync(
                x => x.Id == request.QuestionOptionId
               );
            if (result is not null)
            {
                var resultPayload = _mapper.Map<QuestionOptionDetailResponse>(result);
                return ServiceResponse.CreateSuccess(nameof(GetQuestionOptionDetailQueryHandler), resultPayload);
            }
            return ServiceResponse.CreateError(ResponseMessage.ServerError);
        }
    }
}
