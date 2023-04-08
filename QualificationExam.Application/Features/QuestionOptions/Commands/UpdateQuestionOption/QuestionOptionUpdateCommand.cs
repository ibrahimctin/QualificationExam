namespace QualificationExam.Application.Features.QuestionOptions.Commands.UpdateQuestionOption
{
    public class QuestionOptionUpdateCommand:IRequest<ServiceResponse>
    {
        public UpdateQuestionOptionRequest UpdateQuestionOptionRequest { get; set; }
    }
}
