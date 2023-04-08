namespace QualificationExam.Persistence.Repositories.QuestionOptions
{
    public class QuestionOptionWriteRepository : WriteRepository<QuestionOption>, IQuestionOptionWriteRepository
    {
        public QuestionOptionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
