
using System.Threading.Tasks;
using Commander.Src.Core.AuthCore.JWTModels;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Generic.UseCase;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Auth.Domain.Entity;
using Commander.Src.Feature.Auth.Domain.Repository;

namespace Commander.Src.Feature.Cmd.Domain.UseCase
{
    public class RefreshTokenUseCase : UseCase<JsonWebToken, string>
    {

        private readonly IAuthRepository _authRepository;

        public RefreshTokenUseCase(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public Task<Either<Failure, JsonWebToken>> execute(string token)
        {
            return _authRepository.RefreshAccessToken(token);
        }
    }
}