namespace QualificationExam.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public ReadRepository(AppDbContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return filter == null ? query : query.Where(filter);
        }

     

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
