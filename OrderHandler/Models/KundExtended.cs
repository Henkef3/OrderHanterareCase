using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Models
{
    public class KundExtended
    {
        public long Id { get; set; }
        public string Namn { get; set; }
        public string Typ { get; set; }
        public IEnumerable<Order> Ordrar { get; set; }

        public KundExtended()
        {

        }

        public KundExtended(Kund kund)
        {
            Id = kund.Id;
            Namn = kund.Namn;
            Typ = kund.Typ;
        }
    }
}
