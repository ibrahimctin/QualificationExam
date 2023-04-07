namespace QualificationExam.Application.Features.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQuery:IRequest<ServiceResponse>
    {
        public string QuestionId { get; set; }
    }
}
