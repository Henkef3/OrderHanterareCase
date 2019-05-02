using OrderHandler.Contexts;
using OrderHandler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OrderHandlerContext _orderHandlerContext;
        private IKundRepositry _kundRadRepositry;
        private IOrderRepositry _orderRepositry;
        private IOrderRadRepositry _orderRadRepositry;

        public IKundRepositry Kunder
        {
            get
            {
                if (_kundRadRepositry == null)
                {
                    _kundRadRepositry = new KundRepository(_orderHandlerContext);
                }

                return _kundRadRepositry;
            }
        }

        public IOrderRepositry Ordrar
        {
            get
            {
                if (_orderRepositry == null)
                {
                    _orderRepositry = new OrderRepository(_orderHandlerContext);
                }

                return _orderRepositry;
            }
        }

        public IOrderRadRepositry OrderRader
        {
            get
            {
                if (_orderRadRepositry == null)
                {
                    _orderRadRepositry = new OrderRadRepository(_orderHandlerContext);
                }

                return _orderRadRepositry;
            }
        }

        public RepositoryWrapper(OrderHandlerContext orderHandlerContext)
        {
            _orderHandlerContext = orderHandlerContext;
        }

        public void Save()
        {
            _orderHandlerContext.SaveChanges();
        }
    }
}