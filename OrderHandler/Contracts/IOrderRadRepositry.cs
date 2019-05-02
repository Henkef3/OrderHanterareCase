using OrderHandler.Contracts;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Contracts
{
    public interface IOrderRadRepositry : IRepositoryBase<OrderRad>
    {
        OrderRad GetOrderRadById(long id);
        OrderRadExtended GetOrderRadWithDetails(long id);
    }
}
