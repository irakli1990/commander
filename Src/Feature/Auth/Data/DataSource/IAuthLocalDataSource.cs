using System.Threading.Tasks;
using Commander.Src.Feature.Auth.Domain.Entity;

namespace Commander.Src.Feature.Auth.Data.DataSource
{
    public interface IAuthLocalDataSource
    {
         Task<User> GetUser(string username);
         Task SaveUser(User user);
    }
}