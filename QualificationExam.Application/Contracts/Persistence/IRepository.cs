namespace QualificationExam.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
