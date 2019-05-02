using Microsoft.EntityFrameworkCore;
using OrderHandler.Contexts;
using OrderHandler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderHandler.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected OrderHandlerContext OrderHandlerContext { get; set; }

        public RepositoryBase(OrderHandlerContext orderHandlerContext)
        {
            this.OrderHandlerContext = orderHandlerContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.OrderHandlerContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.OrderHandlerContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.OrderHandlerContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.OrderHandlerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.OrderHandlerContext.Set<T>().Remove(entity);
        }
    }
}
