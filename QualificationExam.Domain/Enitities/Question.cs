namespace QualificationExam.Domain.Enitities
{
    public class Question:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Quiz Quiz { get; set; }
        public string quizId { get; set; }

        public ICollection<QuestionOption> QuestionOptions { get; set; }

    }
}