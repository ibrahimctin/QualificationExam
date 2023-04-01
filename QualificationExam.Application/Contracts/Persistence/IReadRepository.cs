namespace QualificationExam.Application.Contracts.Persistence
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
