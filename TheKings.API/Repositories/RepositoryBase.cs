using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheKings.API.Data;

namespace TheKings.API.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly MonarchContext _dbContext;

        public RepositoryBase(MonarchContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

       
     
    }
}
