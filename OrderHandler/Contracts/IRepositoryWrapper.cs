using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Contracts
{
    public interface IRepositoryWrapper
    {
        IKundRepositry Kunder { get; }
        IOrderRepositry Ordrar { get; }
        IOrderRadRepositry OrderRader { get; }
        void Save();
    }
}