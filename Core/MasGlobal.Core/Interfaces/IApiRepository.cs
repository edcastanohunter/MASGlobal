using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Core.Interfaces
{
    public interface IApiRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> List();
    }
}
