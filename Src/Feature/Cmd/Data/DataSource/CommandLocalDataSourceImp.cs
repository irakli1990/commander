using System.Collections.Generic;
using Commander.Src.Feature.Cmd.Domain.Entity;
using Commander.Src.Core.Generic.LocalData;
using Commander.Src.Core.Errors;
using System.Threading.Tasks;
using Commander.Src.Core.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Commander.Src.Feature.Cmd.Data.DataSource
{
    public class CommandLocalDataSourceImp : LocalDataRepository<Command>, ICommandLocalDataSource
    {

        public CommandLocalDataSourceImp(DataBaseContext dbContext)
      : base(dbContext)
        {

        }



        public async Task<List<Command>> GetAllCommand()
        {
            var result = await Task.FromResult(GetAll().ToList());
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new DataBaseException();
            }
        }

        public async Task<Command> GetCommandById(int id)
        {
            var result = await GetById(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new DataBaseException();
            }
        }
    }
}