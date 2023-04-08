namespace QualificationExam.Application.Features.QuestionOptions.Commands.UpdateQuestionOption
{
    public class QuestionOptionUpdateValidator:AbstractValidator<QuestionOptionUpdateCommand>
    {
        public QuestionOptionUpdateValidator()
        {
            RuleFor(q => q.UpdateQuestionOptionRequest.Content)
               .NotNull()
               .NotEmpty()
               .Length(10, 500);
            RuleFor(q => q.UpdateQuestionOptionRequest.questionId)
                .NotNull();
            RuleFor(q => q.UpdateQuestionOptionRequest.IsCorrect)
                .NotEmpty();
        }
    }
}
