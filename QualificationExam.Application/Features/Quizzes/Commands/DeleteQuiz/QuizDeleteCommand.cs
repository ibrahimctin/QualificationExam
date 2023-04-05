namespace QualificationExam.Application.Features.Quizzes.Commands.DeleteQuiz
{
    public class QuizDeleteCommand:IRequest<ServiceResponse>
    {
        public string QuizId { get; set; }
    }
}
