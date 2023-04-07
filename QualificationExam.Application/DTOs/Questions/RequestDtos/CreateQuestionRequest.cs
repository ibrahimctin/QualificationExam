namespace QualificationExam.Application.DTOs.Questions.RequestDtos
{
    public class CreateQuestionRequest
    {
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
