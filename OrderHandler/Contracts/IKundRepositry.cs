using OrderHandler.Contracts;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Contracts
{
    public interface IKundRepositry : IRepositoryBase<Kund>
    {
        Kund GetKundById(long id);
        KundExtended GetKundWithDetails(long id);
        void CreateKund(Kund kund);
        void UpdateKund(Kund dbKund, Kund kund);
    }
}
