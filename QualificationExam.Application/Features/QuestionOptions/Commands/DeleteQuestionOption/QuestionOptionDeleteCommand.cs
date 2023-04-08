namespace QualificationExam.Application.Features.QuestionOptions.Commands.DeleteQuestionOption
{
    public class QuestionOptionDeleteCommand:IRequest<ServiceResponse>
    {
        public string QuestionOptionId { get; set; }
    }
}
