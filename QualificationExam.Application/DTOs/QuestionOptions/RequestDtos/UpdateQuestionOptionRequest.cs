namespace QualificationExam.Application.DTOs.QuestionOptions.RequestDtos
{
    public class UpdateQuestionOptionRequest
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public string questionId { get; set; }
    }
}
