using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderHandler.Contexts;
using OrderHandler.Contracts;
using OrderHandler.Models;

namespace OrderHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdrar()
        {
            return _repositoryWrapper.Ordrar.FindAll().ToList();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var order = _repositoryWrapper.Ordrar.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<Order>> GetOrderWithDetails(long id)
        {
            var order = _repositoryWrapper.Ordrar.GetOrderWithDetails(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _repositoryWrapper.Ordrar.Update(order);

            try
            {
                _repositoryWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _repositoryWrapper.Ordrar.Create(order);
            _repositoryWrapper.Save();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(long id)
        {
            var order = _repositoryWrapper.Ordrar.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            _repositoryWrapper.Ordrar.Delete(order);
            _repositoryWrapper.Save();

            return order;
        }

        private bool OrderExists(long id)
        {
            return _repositoryWrapper.Ordrar.FindByCondition(x => x.OrderId.Equals(id)).Count() != 0;
        }
    }
}
