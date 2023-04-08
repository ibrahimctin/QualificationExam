namespace QualificationExam.Application.DTOs.QuestionOptions.RequestDtos
{
    public class CreateQuestionOptionRequest
    {
       
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public string questionId { get; set; }
    }
}
