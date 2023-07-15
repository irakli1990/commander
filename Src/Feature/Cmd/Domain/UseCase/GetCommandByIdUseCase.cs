
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Generic.UseCase;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Cmd.Domain.Entity;
using Commander.Src.Feature.Cmd.Domain.Repository;

namespace Commander.Src.Feature.Cmd.Domain.UseCase
{
    public class GetCommandByIdUseCase : UseCase<Command, int>
    {

        private readonly ICommandRepository _commandRepository;

        public GetCommandByIdUseCase(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public Task<Either<Failure, Command>> execute(int id)
        {
            return _commandRepository.GetCommandById(id);
        }
    }
}