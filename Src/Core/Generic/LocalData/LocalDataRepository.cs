using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Src.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Commander.Src.Core.Generic.LocalData
{
    public class LocalDataRepository<TEntity> : ILocalDataRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DataBaseContext _dbContext;

        public LocalDataRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}