
using Commander.Src.Core.AuthCore.JWTModels;

namespace Commander.Src.Core.AuthCore
{
  public interface IJwtHandler
    {
        JsonWebToken Create(string username);
    }
}