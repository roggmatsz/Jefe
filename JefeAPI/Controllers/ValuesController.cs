using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JefeAPI.Models;

namespace JefeAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ApiContext _context;

        public ValuesController(ApiContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var tickets = await _context.Tickets.ToArrayAsync();
            return Ok(tickets);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Produces(typeof(Ticket))]
        public IActionResult Post([FromBody]Ticket value)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _context.Tickets.Add(value);
            _context.SaveChanges();
            return CreatedAtAction("GET", new { id = value.id }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
