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
        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
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
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault( x => x.id == id);
            if(ticket != null) return Ok(ticket);
            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
