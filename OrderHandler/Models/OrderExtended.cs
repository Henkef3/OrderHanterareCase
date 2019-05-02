using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Models
{
    public class OrderExtended
    {
        public long OrderId { get; set; }
        public int TotalSumma { get; set; }
        public int TotalRabatt { get; set; }
        public IEnumerable<OrderRad> OrderRader { get; set; }

        public OrderExtended()
        {

        }

        public OrderExtended(Order order)
        {
            OrderId = order.OrderId;
            TotalRabatt = order.TotalRabatt;
        }
    }
}
