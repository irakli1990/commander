using System.Threading.Tasks;
using Commander.Src.Core.AuthCore.JWTModels;

namespace Commander.Src.Feature.Auth.Data.DataSource
{
    public interface IAuthTokenLocalDataSource
    {
        Task<RefreshToken> GetRefreshToken(string token);
        Task SaveRefreshToken(RefreshToken refreshToken);
    }
}