using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Src.Core.Generic.LocalData;
using Commander.Src.Feature.Cmd.Domain.Entity;

namespace Commander.Src.Feature.Cmd.Data.DataSource
{

    public interface ICommandLocalDataSource
    {
        Task<List<Command>> GetAllCommand();
        Task<Command> GetCommandById(int id);
    }

}