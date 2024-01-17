using TheKings.API.Data;
using TheKings.API.Entities;

namespace TheKings.API.Repositories
{
    public class MonarchRepository : RepositoryBase<Monarch>, IMonarchRepository
    {
        public MonarchRepository(MonarchContext dbContext) : base(dbContext)
        {
        }
    }
}
