using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GGbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionCardsController : ControllerBase
    {
        private readonly AppContext _context;

        public ActionCardsController(AppContext context)
        {
            _context = context;
        }

        // GET: api/ActionCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionCard>>> GetActionCard()
        {
            return await _context.ActionCard.ToListAsync();
        }

        // GET: api/ActionCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActionCard>> GetActionCard(int id)
        {
            var actionCard = await _context.ActionCard.FindAsync(id);

            if (actionCard == null)
            {
                return NotFound();
            }

            return actionCard;
        }

        // PUT: api/ActionCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActionCard(int id, ActionCard actionCard)
        {
            if (id != actionCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(actionCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionCardExists(id))
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

        // POST: api/ActionCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActionCard>> PostActionCard(ActionCard actionCard)
        {
            _context.ActionCard.Add(actionCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActionCard", new { id = actionCard.Id }, actionCard);
        }

        // DELETE: api/ActionCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActionCard(int id)
        {
            var actionCard = await _context.ActionCard.FindAsync(id);
            if (actionCard == null)
            {
                return NotFound();
            }

            _context.ActionCard.Remove(actionCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActionCardExists(int id)
        {
            return _context.ActionCard.Any(e => e.Id == id);
        }
    }
}
