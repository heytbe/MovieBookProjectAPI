using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.UnitOfWorkRepo
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        Task<int> CommitAsync();
        void Commit();
    }
}
