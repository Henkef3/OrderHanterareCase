using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Models
{
    public class OrderRadExtended
    {
        public long OrderRadId { get; set; }
        public string Artikel { get; set; }
        public int Antal { get; set; } = 0;
        public int Pris { get; set; } = 0;
        public int TotalRabatt { get; set; } = 0;
        public int TotalSumma { get; set; }

        public OrderRadExtended()
        {

        }

        public OrderRadExtended(OrderRad orderRad)
        {
            OrderRadId = orderRad.OrderRadId;
            Artikel = orderRad.Artikel;
            Antal = orderRad.Antal;
            Pris = orderRad.Pris;
            TotalRabatt = orderRad.TotalRabatt;
        }
    }
}
