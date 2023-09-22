using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IValidators
    {
        Task<Tuple<bool, Result>> ValidationByID(int data);
        Task<Tuple<bool, Result>> ValidationInsert(InsertMovie data);

    }
}
