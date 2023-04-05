namespace QualificationExam.Application.Features.Quizzes.Commands.UpdateQuiz
{
    public class QuizUpdateCommand:IRequest<ServiceResponse>
    {
        public UpdateQuizRequest UpdateQuizRequest { get; set; }
    }
}
