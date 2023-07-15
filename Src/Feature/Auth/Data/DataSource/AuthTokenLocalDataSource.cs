using System.Linq;
using System.Threading.Tasks;
using Commander.Src.Core.AuthCore.JWTModels;
using Commander.Src.Core.Database;
using Commander.Src.Core.Generic.LocalData;
using Microsoft.EntityFrameworkCore;

namespace Commander.Src.Feature.Auth.Data.DataSource
{
    public class AuthTokenLocalDataSource : LocalDataRepository<RefreshToken>, IAuthTokenLocalDataSource
    {
        public AuthTokenLocalDataSource(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<RefreshToken> GetRefreshToken(string token)
        {
             return await GetAll()
                .Where(c => c.Token == token)
                .FirstOrDefaultAsync();
        }

        public Task SaveRefreshToken(RefreshToken refreshToken)
        {
            return Create(refreshToken);
        }
    }
}