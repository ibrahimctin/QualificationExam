namespace QualificationExam.Application.Features.Questions.Commands.UpdateQuestion
{
    public class QuestionUpdateValidator:AbstractValidator<QuestionUpdateCommand>
    {
        public QuestionUpdateValidator()
        {
            RuleFor(q => q.UpdateQuestionRequest.Title)
              .Length(10, 250)
              .NotEmpty();
            RuleFor(q => q.UpdateQuestionRequest.Content)
                .Length(10, 250)
                .NotEmpty();
            RuleFor(q=>q.UpdateQuestionRequest.Id)
                .NotNull();
               
        }
    }
}
