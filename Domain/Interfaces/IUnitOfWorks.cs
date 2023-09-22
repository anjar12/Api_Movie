using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWorks
    {
        IAuthRepository auth { get; }
        IMovieReposiory movie { get; }
        IValidators validators { get; }
    }
}
