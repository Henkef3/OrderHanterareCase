using Microsoft.EntityFrameworkCore;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Contexts
{
    public class OrderHandlerContext : DbContext
    {
        public OrderHandlerContext(DbContextOptions<OrderHandlerContext> options)
            : base(options)
        {

        }

        public DbSet<Kund> Kunder { get; set; }

        public DbSet<Order> Ordrar { get; set; }

        public DbSet<OrderRad> OrderRader { get; set; }

    }
}
