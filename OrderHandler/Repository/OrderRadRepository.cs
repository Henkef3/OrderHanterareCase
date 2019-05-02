using OrderHandler.Contexts;
using OrderHandler.Contracts;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Repository
{

    public class OrderRadRepository : RepositoryBase<OrderRad>, IOrderRadRepositry
    {
        public OrderRadRepository(OrderHandlerContext orderHandlerContext)
            : base(orderHandlerContext)
        {
        }

        public OrderRad GetOrderRadById(long id)
        {
            return FindByCondition(x => x.OrderRadId.Equals(id)).FirstOrDefault();
        }

        public OrderRadExtended GetOrderRadWithDetails(long id)
        {
            var orderRad = GetOrderRadById(id);
            var antal = orderRad.Antal;
            var pris = orderRad.Pris;
            var summa = antal * pris;
            var rabatt = orderRad.TotalRabatt;
            return new OrderRadExtended(GetOrderRadById(id))
            {
                TotalSumma = summa - (summa * rabatt)
            };
        }
    }
}
