namespace QualificationExam.Application.DTOs.Quizzes.ResponseDtos
{
    public class QuizDetailResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionCount { get; set; }
        public string UserId { get; set; }

        public ICollection<QuestionDetailResponse> questionDetails { get; set; }

    }
}
