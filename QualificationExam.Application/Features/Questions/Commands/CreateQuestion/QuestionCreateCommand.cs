namespace QualificationExam.Application.Features.Questions.Commands.CreateQuestion
{
    public class QuestionCreateCommand:IRequest<ServiceResponse>
    {
        public CreateQuestionRequest CreateQuestionRequest { get; set; }
    }
}
