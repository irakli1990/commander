
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Generic.UseCase;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Auth.Domain.Entity;
using Commander.Src.Feature.Auth.Domain.Repository;

namespace Commander.Src.Feature.Cmd.Domain.UseCase
{
    public class RegisterUseCase : UseCase<Task, User>
    {

        private readonly IAuthRepository _authRepository;

        public RegisterUseCase(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public Task<Either<Failure, Task>> execute(User user)
        {
            return _authRepository.Register(user);
        }
    }
}