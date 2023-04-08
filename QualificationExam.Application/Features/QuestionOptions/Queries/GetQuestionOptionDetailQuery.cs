namespace QualificationExam.Application.Features.QuestionOptions.Queries
{
    public class GetQuestionOptionDetailQuery:IRequest<ServiceResponse>
    {
        public string QuestionOptionId { get; set; }
    }
}
