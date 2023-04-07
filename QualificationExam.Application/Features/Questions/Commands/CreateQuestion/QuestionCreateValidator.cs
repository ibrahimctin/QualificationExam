namespace QualificationExam.Application.Features.Questions.Commands.CreateQuestion
{
    public class QuestionCreateValidator:AbstractValidator<QuestionCreateCommand>
    {
        public QuestionCreateValidator()
        {
            RuleFor(q => q.CreateQuestionRequest.Title)
                .Length(10, 250)
                .NotEmpty();
            RuleFor(q=>q.CreateQuestionRequest.Content)
                .Length(10,250)
                .NotEmpty();
            RuleFor(q => q.CreateQuestionRequest.QuizId)
                .NotNull();
        }
    }
}
