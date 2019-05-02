using OrderHandler.Contracts;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Contracts
{
    public interface IOrderRepositry : IRepositoryBase<Order>
    {
        Order GetOrderById(long id);
        OrderExtended GetOrderWithDetails(long id);
    }
}
