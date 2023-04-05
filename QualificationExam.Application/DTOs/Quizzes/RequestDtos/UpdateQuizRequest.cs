namespace QualificationExam.Application.DTOs.Quizzes.RequestDtos
{
    public class UpdateQuizRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionCount { get; set; }
    }
}
