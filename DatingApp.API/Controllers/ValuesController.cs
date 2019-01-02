using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // http://localhost://5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _context { get; }

        // injecting the database class, so that we can retreive data
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get() //! default
        public async Task<IActionResult> GetValues() // returning http requests to the client
        {
            // going to the database and getting the values in async way
            var values =  await _context.Values.ToListAsync();
            return Ok(values);
            //return new string[] { "value1", "value8" }; //! default
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public ActionResult<string> Get(int id) //! default
        public async Task<IActionResult> GetValue(int id){
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
