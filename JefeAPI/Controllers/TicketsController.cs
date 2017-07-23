using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JefeAPI.Models;
namespace JefeAPI.Controllers
{
    [Produces("application/json", Type = typeof(Ticket))]
    [Route("api/Tickets")]
    public class TicketsController : Controller {
        private readonly ApiContext _context;

        public TicketsController(ApiContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var tickets = await _context.Tickets.ToArrayAsync();
            return Ok(tickets);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) {
            var ticket = await _context.Tickets
                .Where(t => t.id == id).SingleOrDefaultAsync();
            if (ticket != null) return Ok(ticket);
            return NotFound();
        }

        [HttpGet("{slot:int}")]
        public async Task<IActionResult> GetBySlot(int slot) {
            var ticket = await _context.Tickets
                .Where(t => t.Slot == slot).SingleOrDefaultAsync();
            if (ticket != null) return Ok(ticket);
            return NotFound();
        }

        [HttpGet("{gameId:int}")]
        public async Task<IActionResult> GetByGameID(int gameId) {
            var ticket = await _context.Tickets
                .Where(t => t.GameID == gameId).FirstOrDefaultAsync();
            if (ticket != null) return Ok(ticket);
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody]Ticket newTicket) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Tickets.Add(new Entities.TicketEntity {
                id = 0,
                GameID = newTicket.GameID,
                Slot = newTicket.Slot,
                Value = newTicket.Value
            });
            _context.SaveChanges();
            return Created("some URI here", newTicket);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Ticket item) {
            if (item == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ticket = _context.Tickets.Where(t => t.id == id).SingleOrDefault();
            ticket.GameID = item.GameID;
            ticket.Slot = item.Slot;
            ticket.Value = item.Value;
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}