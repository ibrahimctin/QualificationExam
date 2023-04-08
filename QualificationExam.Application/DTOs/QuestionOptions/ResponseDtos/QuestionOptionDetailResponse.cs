namespace QualificationExam.Application.DTOs.QuestşonOptions.ResponseDtos
{
    public class QuestionOptionDetailResponse
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public string questionId { get; set; }
        public QuestionDetailResponse QuestionDetailResponse { get; set; }
    }
}
