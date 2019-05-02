using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Extensions
{
    public static class UserExtension
    {
        public static void Map(this Kund dbKund, Kund kund)
        {

            dbKund.Namn = kund.Namn;
            dbKund.Typ = kund.Typ;
        }
    }
}
