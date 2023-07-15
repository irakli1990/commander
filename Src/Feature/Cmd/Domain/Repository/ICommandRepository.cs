using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Cmd.Domain.Entity;

namespace Commander.Src.Feature.Cmd.Domain.Repository
{
    public interface ICommandRepository
    {
        Task<Either<Failure, List<Command>>> GetAllCommands();
        Task<Either<Failure, Command>> GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        Task<Either<Failure, int>> DeleteCommand(int id);
    }
}