namespace QualificationExam.Application.Features.Questions.Commands.DeleteQuestion
{
    public class QuestionDeleteCommand:IRequest<ServiceResponse>
    {
        public string QuestionId { get; set; }
    }
}
