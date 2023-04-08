namespace QualificationExam.Application.Features.QuestionOptions.Commands.CreateQuestionOption
{
    public class QuestionOptionCreateCommand:IRequest<ServiceResponse>
    {
        public CreateQuestionOptionRequest CreateQuestionOptionRequest { get; set; }
    }
}
