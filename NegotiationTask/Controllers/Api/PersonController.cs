using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegotiationTask.Data;
using NegotiationTask.Models;
using System.Text;

namespace NegotiationTask.Controllers.Api
{
    [Route("api/[controller]")]
    //[ApiController]
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PersonController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetPersons()
        {

            var persons = await _db.Persons.ToListAsync();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Handle Ajax request
                return Ok(persons);
            }
            else
            {
                // Handle non-Ajax request
                return View("FullView", persons);
            }

        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            return Ok(person);
        }
    }
}
