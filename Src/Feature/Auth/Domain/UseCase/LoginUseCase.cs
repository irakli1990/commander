
using System.Threading.Tasks;
using Commander.Src.Core.AuthCore.JWTModels;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Generic.UseCase;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Auth.Domain.Entity;
using Commander.Src.Feature.Auth.Domain.Repository;
using Commander.Src.Feature.Cmd.Domain.Repository;

namespace Commander.Src.Feature.Cmd.Domain.UseCase
{
    public class LoginUseCase : UseCase<JsonWebToken, Credentials>
    {

        private readonly IAuthRepository _authRepository;

        public LoginUseCase(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public Task<Either<Failure, JsonWebToken>> execute(Credentials credentials)
        {
            return _authRepository.Login(credentials);
        }
    }
}