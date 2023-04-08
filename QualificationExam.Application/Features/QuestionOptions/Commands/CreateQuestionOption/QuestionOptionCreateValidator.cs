namespace QualificationExam.Application.Features.QuestionOptions.Commands.CreateQuestionOption
{
    public class QuestionOptionCreateValidator : AbstractValidator<QuestionOptionCreateCommand>
    {
        public QuestionOptionCreateValidator()
        {
            RuleFor(q => q.CreateQuestionOptionRequest.Content)
                .NotNull()
                .NotEmpty()
                .Length(10, 500);
            RuleFor(q => q.CreateQuestionOptionRequest.questionId)
                .NotNull();
            RuleFor(q => q.CreateQuestionOptionRequest.IsCorrect)
                .NotEmpty();
        }
    }
}
