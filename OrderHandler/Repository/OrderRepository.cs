using OrderHandler.Contexts;
using OrderHandler.Contracts;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepositry
    {
        public OrderRepository(OrderHandlerContext orderHandlerContext)
            : base(orderHandlerContext)
        {
        }

        public Order GetOrderById(long id)
        {
            return FindByCondition(x => x.OrderId.Equals(id)).FirstOrDefault();
        }

        public OrderExtended GetOrderWithDetails(long id)
        {
            var orderRader = OrderHandlerContext.OrderRader.Where(a => a.OrderId == id);
            var rabatt = GetOrderById(id).TotalRabatt;
            return new OrderExtended(GetOrderById(id))
            {
                OrderRader = orderRader,
                TotalSumma = CalculateTotalSumma(orderRader) - rabatt
            };


        }

        public int CalculateTotalSumma(IQueryable<OrderRad> orderRader)
        {
            int summa = 0;
            foreach (var orderRad in orderRader)
            {
                summa += (orderRad.Pris * orderRad.Antal) - orderRad.TotalRabatt;
            }
            return summa;
        }
    }
}