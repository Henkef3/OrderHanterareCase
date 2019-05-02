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
    public class KundController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public KundController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/Kund
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kund>>> GetKunder()
        {
            return _repositoryWrapper.Kunder.FindAll().ToList();
        }

        // GET: api/Kund/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kund>> GetKund(long id)
        {
            var kund = _repositoryWrapper.Kunder.GetKundById(id);

            if (kund == null)
            {
                return NotFound();
            }

            return kund;
        }
        // GET: api/Kund/5/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<Kund>> GetKundWithDetails(long id)
        {
            var kund = _repositoryWrapper.Kunder.GetKundWithDetails(id);

            if (kund == null)
            {
                return NotFound();
            }

            return Ok(kund);
        }

        // PUT: api/Kund/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKund(long id, Kund kund)
        {
            if (id != kund.Id)
            {
                return BadRequest();
            }

            var dbKund = _repositoryWrapper.Kunder.GetKundById(id);

            _repositoryWrapper.Kunder.UpdateKund(dbKund,kund);

            try
            {
                _repositoryWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundExists(id))
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

        // POST: api/Kund
        [HttpPost]
        public async Task<ActionResult<Kund>> PostKund([FromBody] Kund kund)
        {
            _repositoryWrapper.Kunder.CreateKund(kund);
             _repositoryWrapper.Save();

            return CreatedAtAction("GetKund", new { id = kund.Id }, kund);
        }

        // DELETE: api/Kunds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kund>> DeleteKund(long id)
        {
            var kund = _repositoryWrapper.Kunder.GetKundById(id);
            if (kund == null)
            {
                return NotFound();
            }

            _repositoryWrapper.Kunder.Delete(kund);
            _repositoryWrapper.Save();

            return kund;
        }

        private bool KundExists(long id)
        {
            return _repositoryWrapper.Kunder.FindByCondition(x => x.Id.Equals(id)).Count() != 0;
        }
    }
}
