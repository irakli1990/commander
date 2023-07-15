using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Utils;

namespace Commander.Src.Core.Generic.UseCase
{
    public interface UseCase<Type, Params>
    {
        Task<Either<Failure, Type>> execute(Params @params);
    }
}