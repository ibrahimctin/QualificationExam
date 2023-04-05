namespace QualificationExam.Application.DTOs.Quizzes.RequestDtos
{
    public class CreateQuizRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionCount { get; set; }
        [JsonIgnore]
        public string? UserId { get; set; }
    }
}
