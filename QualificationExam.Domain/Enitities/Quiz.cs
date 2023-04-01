
namespace QualificationExam.Domain.Enitities
{
    public class Quiz:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionCount { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
