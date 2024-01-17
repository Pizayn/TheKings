using System.Linq.Expressions;
using TheKings.API.Data;

namespace TheKings.API.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
    }

}
