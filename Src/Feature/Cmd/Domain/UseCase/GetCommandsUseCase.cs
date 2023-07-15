
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Generic.UseCase;
using Commander.Src.Core.NoParams;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Cmd.Domain.Entity;
using Commander.Src.Feature.Cmd.Domain.Repository;

namespace Commander.Src.Feature.Cmd.Domain.UseCase
{
    public class GetCommandsUseCase : UseCase<List<Command>, NoParams>
    {

        private readonly ICommandRepository _commandRepository;

        public GetCommandsUseCase(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public Task<Either<Failure, List<Command>>> execute(NoParams @params)
        {
            return _commandRepository.GetAllCommands();
        }
    }
}