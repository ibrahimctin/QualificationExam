namespace QualificationExam.Application.Features.Quizzes.Queries.GetQuizDetail
{
    public class GetQuizDetailQueryHandler : IRequestHandler<GetQuizDetailQuery, ServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuizReadRepository _quizReadRepository;

        public GetQuizDetailQueryHandler(IMapper mapper, IQuizReadRepository quizReadRepository)
        {
            _mapper = mapper;
            _quizReadRepository = quizReadRepository;
        }

        public async Task<ServiceResponse> Handle(GetQuizDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _quizReadRepository. GetAsync(
                x=>x.Id==request.QuizId 
               ,includes:c=>c.Questions);
            if (result is not null)
            {
                var resultPayload = _mapper.Map<QuizDetailResponse>(result);
                return ServiceResponse.CreateSuccess(ResponseMessage.AddedSuccessfully,resultPayload);
            }
            return ServiceResponse.CreateError(ResponseMessage.AddedFailed);
        }
    }
}
