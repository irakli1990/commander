using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Cmd.Domain.Entity;
using Commander.Src.Feature.Cmd.Domain.Repository;
using Commander.Src.Feature.Cmd.Data.DataSource;

namespace Commander.Src.Feature.Cmd.Data.Repository
{
    public class CommandRepositoryImpl : ICommandRepository
    {

        private readonly ICommandLocalDataSource _localDataSource;

        public CommandRepositoryImpl(ICommandLocalDataSource localDataSource)
        {
            _localDataSource = localDataSource;
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public Task<Either<Failure, int>> DeleteCommand(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Either<Failure, List<Command>>> GetAllCommands()
        {
            try
            {
                var result = await _localDataSource.GetAllCommand();
                return (Either<Failure, List<Command>>)result;
            }
            catch (DataBaseException)
            {
                return (Either<Failure, List<Command>>)new DataBaseFailure();
            }
        }

        public async Task<Either<Failure, Command>> GetCommandById(int id)
        {
            try
            {
                var result = await _localDataSource.GetCommandById(id);
                return (Either<Failure, Command>)result;
            }
            catch (DataBaseException)
            {
                return (Either<Failure, Command>)new DataBaseFailure();
            }
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}