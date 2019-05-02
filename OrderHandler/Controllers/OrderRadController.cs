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
    public class OrderRadController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderRadController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/OrderRad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderRad>>> GetOrderRader()
        {
            return _repositoryWrapper.OrderRader.FindAll().ToList();
        }

        // GET: api/OrderRad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderRad>> GetOrderRad(long id)
        {
            var orderRad = _repositoryWrapper.OrderRader.GetOrderRadById(id);

            if (orderRad == null)
            {
                return NotFound();
            }

            return orderRad;
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<OrderRad>> GetOrderRadWithDetails(long id)
        {
            var orderRad = _repositoryWrapper.OrderRader.GetOrderRadWithDetails(id);

            if (orderRad == null)
            {
                return NotFound();
            }

            return Ok(orderRad);
        }

        // PUT: api/OrderRad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderRad(long id, OrderRad orderRad)
        {
            if (id != orderRad.OrderRadId)
            {
                return BadRequest();
            }

            _repositoryWrapper.OrderRader.Update(orderRad);

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

        // POST: api/OrderRad
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrderRad(OrderRad orderRad)
        {
            _repositoryWrapper.OrderRader.Create(orderRad);
            _repositoryWrapper.Save();

            return CreatedAtAction("GetOrderRad", new { id = orderRad.OrderRadId }, orderRad);
        }

        // DELETE: api/OrderRad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderRad>> DeleteOrderRad(long id)
        {
            var orderRad = _repositoryWrapper.OrderRader.FindByCondition(x => x.OrderId.Equals(id)).FirstOrDefault();
            if (orderRad == null)
            {
                return NotFound();
            }

            _repositoryWrapper.OrderRader.Delete(orderRad);
            _repositoryWrapper.Save();

            return orderRad;
        }

        private bool OrderExists(long id)
        {
            return _repositoryWrapper.OrderRader.FindByCondition(x => x.OrderId.Equals(id)).Count() != 0;
        }
    }
}
