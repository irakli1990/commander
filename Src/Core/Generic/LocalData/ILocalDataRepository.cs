using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Src.Core.Generic.LocalData
{

    public interface ILocalDataRepository<TEntity>
    where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}