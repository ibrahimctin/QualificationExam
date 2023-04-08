namespace QualificationExam.Application.Features.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQueryHandler : IRequestHandler<GetQuestionDetailQuery, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionReadRepository _questionReadRepository;

        public GetQuestionDetailQueryHandler(
            IMapper mapper,
            IQuestionReadRepository questionReadRepository)
        {
            _mapper = mapper;
            _questionReadRepository = questionReadRepository;
        }

        public async Task<ServiceResponse> Handle(GetQuestionDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _questionReadRepository.GetAsync(
                x => x.Id == request.QuestionId
               );
            if (result is not null)
            {
                var resultPayload = _mapper.Map<QuestionDetailResponse>(result);
                return ServiceResponse.CreateSuccess(nameof(GetQuestionDetailQueryHandler), resultPayload);
            }
            return ServiceResponse.CreateError(ResponseMessage.AddedFailed);
        }
    }
}
