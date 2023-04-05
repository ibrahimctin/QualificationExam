namespace QualificationExam.Application.Features.Quizzes.Commands.CreateQuiz
{
    public class QuizCreateCommandValidator:AbstractValidator<QuizCreateCommand>
    {
        public QuizCreateCommandValidator()
        {
            RuleFor(q => q.CreateQuizRequest.Title)
                .NotEmpty()
                .Length(10, 250);
            RuleFor(q => q.CreateQuizRequest.QuestionCount)
                .NotEmpty()
                .LessThanOrEqualTo(100);
            RuleFor(q => q.CreateQuizRequest.Description)
                .NotEmpty()
                .Length(10, 250);
           
        }
    }
}