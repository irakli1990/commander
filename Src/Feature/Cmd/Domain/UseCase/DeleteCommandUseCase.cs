
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Generic.UseCase;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Cmd.Domain.Repository;

namespace Commander.Src.Feature.Cmd.Domain.UseCase
{
    public class DeleteCommandUseCase : UseCase<int, int>
    {

        private readonly ICommandRepository _commandRepository;

        public DeleteCommandUseCase(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public Task<Either<Failure, int>> execute(int id)
        {
            return _commandRepository.DeleteCommand(id);
        }
    }
}