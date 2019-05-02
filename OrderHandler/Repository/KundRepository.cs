using OrderHandler.Contexts;
using OrderHandler.Contracts;
using OrderHandler.Extensions;
using OrderHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Repository
{
    public class KundRepository : RepositoryBase<Kund>, IKundRepositry
    {
        public KundRepository(OrderHandlerContext orderHandlerContext)
            : base(orderHandlerContext)
        {
        }

        public void CreateKund(Kund kund)
        {
            Create(kund);
        }

        public Kund GetKundById(long id)
        {
            return FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public KundExtended GetKundWithDetails(long id)
        {

            return new KundExtended(GetKundById(id))
            {
                Ordrar = OrderHandlerContext.Ordrar.Where(a => a.Id == id),
            };
        }

        public void UpdateKund(Kund dbKund, Kund kund)
        {
            dbKund.Map(kund);
            Update(dbKund);
        }
    }
}
