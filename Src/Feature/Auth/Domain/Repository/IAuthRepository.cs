using System.Threading.Tasks;
using Commander.Src.Core.AuthCore.JWTModels;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Auth.Domain.Entity;


namespace Commander.Src.Feature.Auth.Domain.Repository
{
    public interface IAuthRepository
    {
        Task<Either<Failure, JsonWebToken>> Login(Credentials credentials);
        Task<Either<Failure, Task>> Register(User user);

        Task<Either<Failure, JsonWebToken>> RefreshAccessToken(string token);


        Task<Either<Failure, Task>> RevokeRefreshToken(string token);

    }
}