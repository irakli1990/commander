using System.Linq;
using System.Threading.Tasks;
using Commander.Src.Core.Database;
using Commander.Src.Core.Generic.LocalData;
using Commander.Src.Feature.Auth.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Commander.Src.Feature.Auth.Data.DataSource
{
    public class AuthLocalDataSource : LocalDataRepository<User>, IAuthLocalDataSource
    {
        public AuthLocalDataSource(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUser(string username)
        {
            return await GetAll()
                .Where(c => c.UserName == username)
                .FirstOrDefaultAsync();
        }

        public Task SaveUser(User user)
        {
            return Create(user);
        }
    }
}