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
    [Produces("application/json")]
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
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.id == id);
            if (ticket != null) return Ok(ticket);
            return BadRequest();
        }

        [HttpGet("{slot:int}")]
        public async Task<IActionResult> GetBySlot(int slot) {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Slot == slot);
            if (ticket != null) return Ok(ticket);
            return BadRequest();
        }

        [HttpGet("{gameId:int}")]
        public async Task<IActionResult> GetByGameID(int gameId) {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.GameID == gameId);
            if (ticket != null) return Ok(ticket);
            return BadRequest();
        }
    }
}