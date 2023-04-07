namespace QualificationExam.Application.Features.Questions.Commands.UpdateQuestion
{
    public class QuestionUpdateCommand:IRequest<ServiceResponse>
    {
        public UpdateQuestionRequest UpdateQuestionRequest { get; set; }
    }
}
