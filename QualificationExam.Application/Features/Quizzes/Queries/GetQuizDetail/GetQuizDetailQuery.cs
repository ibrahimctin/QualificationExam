namespace QualificationExam.Application.Features.Quizzes.Queries.GetQuizDetail
{
    public class GetQuizDetailQuery:IRequest<ServiceResponse>
    {
       public string QuizId { get; set; }
    }
}
