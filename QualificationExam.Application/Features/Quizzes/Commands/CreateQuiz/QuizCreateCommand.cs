namespace QualificationExam.Application.Features.Quizzes.Commands.CreateQuiz
{
    public class QuizCreateCommand: IRequest<ServiceResponse>
    {
        
        public CreateQuizRequest CreateQuizRequest { get; set; }
    }
}
