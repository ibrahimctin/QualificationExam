namespace QualificationExam.Application.Features.Quizzes.Commands.UpdateQuiz
{
    public class QuizUpdateCommandValidator:AbstractValidator<QuizUpdateCommand>
    {
        public QuizUpdateCommandValidator()
        {
             RuleFor(q => q.UpdateQuizRequest.Title)
                .NotEmpty()
                .Length(10, 250);
            RuleFor(q => q.UpdateQuizRequest.QuestionCount)
                .NotEmpty()
                .LessThanOrEqualTo(100);
            RuleFor(q => q.UpdateQuizRequest.Description)
                .NotEmpty()
                .Length(10, 250);
        }
    }
}
